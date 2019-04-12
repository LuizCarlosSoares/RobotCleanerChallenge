using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Office
{

    public sealed class Graph<T>
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public IEnumerable<T> AllNodes { get; }

        private IDictionary<T, IEnumerable<T>> Edges;

        public Graph(IDictionary<T, IEnumerable<T>> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException(nameof(edges));
            }
            Edges = new ReadOnlyDictionary<T, IEnumerable<T>>(edges);
            AllNodes = Edges.Keys;
        }

        public IEnumerable<T> Neighbours(T node)
        {
            return Edges[node];
        }
    }
}