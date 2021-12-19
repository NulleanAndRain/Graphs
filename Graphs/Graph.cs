using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph
    {
        public List<List<double>> Matrix { get; private set; }

        public Graph(int vertisesCout = 0)
        {
            Matrix = new List<List<double>>(vertisesCout);
            for (int i = 0; i < vertisesCout; i++)
            {
                Matrix[i] = new List<double>(vertisesCout);
            }
        }

        public void AddVertex()
        {
            var n = Matrix.Count;
            foreach (var l in Matrix)
            {
                l.Add(0);
            }
            Matrix.Add(new List<double>(n + 1));
        }

        public int VerticesCout => Matrix.Count;

        public bool AreVerticesConnected(int vertex1, int vertex2) => 
            Matrix[vertex1][vertex2] != 0 || Matrix[vertex2][vertex1] != 0;
        
    }
}
