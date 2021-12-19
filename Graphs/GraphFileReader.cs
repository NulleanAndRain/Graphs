using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphFileReader
    {
        static readonly char[] _separators = new char[] { ' ', '\t' };

        public static Graph ReadFromMatrix(string path)
        {
            if (!File.Exists(path)) return new Graph();
            var lines = File.ReadAllLines(path);
            var graph = new Graph(lines.Length);
            int i = 0;
            foreach (var line in lines)
            {
                int j = 0;
                foreach (var weightStr in line.Split(_separators, StringSplitOptions.None)) {
                    if (double.TryParse(weightStr, out var w))
                    {
                        graph.Matrix[i][j] = w;
                    }
                    else
                    {
                        graph.Matrix[i][j] = 0;
                    }
                    j++;
                }
                i++;
            }
            return graph;
        }

        public static Graph ReadFromEdgeList(string path)
        {
            if (!File.Exists(path)) return new Graph();
            var lines = File.ReadAllLines(path);
            int vertices = 0;
            if (int.TryParse(lines[0], out var v)) vertices = v;
            var graph = new Graph(vertices);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(_separators, StringSplitOptions.None);
                if (int.TryParse(parts[0], out int i) && int.TryParse(parts[1], out int j))
                {
                    double weight = 0;
                    if (double.TryParse(parts[2], out var w)) weight = w;
                    graph.Matrix[i][j] = weight;
                }
            }

            return graph;
        }
    }
}
