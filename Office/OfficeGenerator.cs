using System;
using System.Collections.Generic;
using System.Linq;

namespace Office
{
    public class OfficeMapGenerator
    {
        private int height;
        private int width;

        private HashSet<Coordinate> walls = new HashSet<Coordinate>();
        private HashSet<Coordinate> water = new HashSet<Coordinate>();

        private static readonly Coordinate[] CardinalDirections = new[]
        {
        new Coordinate(0, 1),
        new Coordinate(1, 0),
        new Coordinate(0, -1),
        new Coordinate(-1, 0)
    };

        public OfficeMapGenerator(int width, int height)
        {
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            this.height = height;
            this.width = width;
        }

        internal OfficeMapGenerator AddWall(Coordinate location)
        {
            if (!IsWithinGrid(location))
            {
                throw new ArgumentException("Wall location must be within the grid", nameof(location));
            }
            walls.Add(location);
            return this;
        }

        internal OfficeMapGenerator AddWater(Coordinate location)
        {
            if (!IsWithinGrid(location))
            {
                throw new ArgumentException("Water location must be within the grid", nameof(location));
            }
            water.Add(location);
            return this;
        }

        private bool IsWithinGrid(Coordinate c)
        {
            return c.X >= 0 && c.X < width && c.Y >= 0 && c.Y < height;
        }

        private IEnumerable<OfficeTile> CreateEdges(OfficeTile tile)
        {
            if (walls.Contains(tile.Location))
            {
                return Enumerable.Empty<OfficeTile>();
            }

            return (from d in CardinalDirections
                    let newLocation = tile.Location + d
                    where IsWithinGrid(newLocation) && !walls.Contains(newLocation)
                    select CreateOfficeTile(newLocation))
                   .ToArray();
        }

        private OfficeTile CreateOfficeTile(Coordinate location)
        {
            int? cost = null;
            if (!walls.Contains(location))
            {
                cost = water.Contains(location) ? 5 : 1;
            }
            return new OfficeTile(location, cost);
        }

        public Graph<OfficeTile> Build()
        {
            var edges = new Dictionary<OfficeTile, IEnumerable<OfficeTile>>();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var location = new Coordinate(x, y);
                    var tile = CreateOfficeTile(location);
                    edges[tile] = CreateEdges(tile);
                }
            }
            return new Graph<OfficeTile>(edges);
        }
    }
}