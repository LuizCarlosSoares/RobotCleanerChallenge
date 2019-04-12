using System;
using System.Collections.Generic;
using Office;

namespace RobotCleaner
{
    public class Robot
    {

        private const char V = ' ';
        private Dictionary<string, int> Directions { get; set; } = new Dictionary<string, int>();

        private Graph<OfficeTile> room;
        private List<int> currenActions;
        private int total_actions = 0;
        public List<Coordinate> cleanedPlaces = new List<Coordinate>();
        public Nullable<Coordinate> currentPlace;

        public List<Coordinate?> Route = new List<Coordinate?>();


        public Robot()
        {

        }


        public Robot(int actions)
        {
            this.total_actions = actions;
        }

        public void AddCleaningDirections(string direction)
        {
            var value = direction.Split(V);
            Directions.Add(value[0], int.Parse(value[1]));
        }

        public void Move(Coordinate NextCoordinate)
        {

            this.currentPlace = IsOutofBounds(NextCoordinate) ? new Nullable<Coordinate>() : NextCoordinate;
        }

        public void StartClean(Graph<OfficeTile> office)
        {
            this.room = office;
            GetRoute();
            this.Clean();
        }

        private void GetRoute()
        {
            this.Route.Add(currentPlace);
        }

        public bool IsOutofBounds(Coordinate? coordinate)
        {
            return !(coordinate.Value.X >= 0 && coordinate.Value.X < this.room.Width && coordinate.Value.Y >= 0 && coordinate.Value.Y < this.room.Height);
        }
        public void Clean()
        {

            reset();

            foreach (var coordinate in Route)
            {

                if (!IsOutofBounds(coordinate))
                {
                    for (int i = 0; i < total_actions; i++)
                    {
                        this.currenActions.Add(i);
                    }

                    if (currenActions.Count.Equals(total_actions))
                    {
                        this.IsPlaceCleaned = true;
                    }
                }
                reset();
            }


        }



        public void TurnOn(Graph<OfficeTile> room)
        {
            this.room = room;
            CalculateRoute();
        }

        private void CalculateRoute()
        {
            this.Route.Add(currentPlace);
            foreach (var direction in Directions)
            {
                var coordinate = new Coordinate(currentPlace.Value.X, currentPlace.Value.Y);
                var nextplace = GetNextPlace(coordinate, direction);
            }
        }

        private Coordinate? GetNextPlace(Coordinate coordinate, KeyValuePair<string, int> direction)
        {
            var newCoordinate = new Coordinate(0, 0);
            return coordinate;
        }

        private void reset()
        {
            this.currenActions = new List<int>();
        }

        public bool IsPlaceCleaned { get; set; }
    }
}
