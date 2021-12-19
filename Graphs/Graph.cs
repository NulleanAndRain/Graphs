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

        public Graph(int vertisesCout = 1)
        {
            Matrix = new List<List<double>>();
            for (int i = 0; i < vertisesCout; i++)
            {
                Matrix.Add(new List<double>(vertisesCout));
                for (int j = 0; j < vertisesCout; j++)
                {
                    Matrix[i].Add(0);
                }
            }
        }

        public void AddVertex()
        {
            var n = Matrix.Count;
            for (int i = 0; i < n; i++)
            {
                Matrix[i].Add(0);
            }
            Matrix.Add(new List<double>(n + 1));
            for (int j = 0; j <= n; j++) {
                Matrix[n].Add(0);
            }
        }

        public void AddEdge(int vert1, int vert2, double weight)
        {
            vert1--;
            vert2--;
            while (vert1 >= VerticesCout || vert2 >= VerticesCout)
                AddVertex();
            Matrix[vert1][vert2] = weight;
        }

        public void RemoveEdge(int vert1, int vert2)
        {
            vert1--;
            vert2--;
            if (vert1 >= VerticesCout || vert2 >= VerticesCout) return;
            Matrix[vert1][vert2] = 0;
        }

        public int VerticesCout => Matrix.Count;

        public bool AreVerticesConnected(int vertex1, int vertex2) =>
            Matrix[vertex1][vertex2] != 0 || Matrix[vertex2][vertex1] != 0;

        public bool isOriented
        {
            get
            {
                int count = Matrix.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (i == j) break;
                        if (Matrix[i][j] != Matrix[j][i]) return true;
                    }
                }
                return false;
            }
        }

        public int GetEdgesCount()
        {
            int count = Matrix.Count;
            int edges = 0;
            if (isOriented)
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; i++)
                    {
                        if (i == j) continue;
                        if (Matrix[i][j] != 0) edges++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (i == j) break;
                        if (Matrix[i][j] != 0) edges++;
                    }
                }

            }
            return edges;
        }

        public double GetEgdeWeight(int vert1, int vert2)
        {
            vert1--;
            vert2--;
            if (vert1 >= VerticesCout || vert2 >= VerticesCout) return 0;
            return Matrix[vert1][vert2];
        }
        public List<(int, int, double)> GetAllEdges()
        {
            var edges = new List<(int, int, double)>();
            int count = Matrix.Count;

            if (isOriented)
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; i++)
                    {
                        if (i == j) continue;
                        if (Matrix[i][j] != 0) edges.Add((i, j, Matrix[i][j]));
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (i == j) break;
                        if (Matrix[i][j] != 0) edges.Add((i, j, Matrix[i][j]));
                    }
                }
            }
            return edges;
        }
    }
}
