using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphFileSaver
    {
        public static void SaveAsMatrix(string path, Graph graph)
        {
            try
            {
                var builder = new StringBuilder();
                foreach (var line in graph.Matrix)
                {
                    foreach (var w in line)
                    {
                        builder.Append(w.ToString("F4")).Append(' ');
                    }
                    builder.Append(Environment.NewLine);
                }
                File.WriteAllText(path, builder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption occured: " + e.ToString());
            }
        }

        public static void SaveAsEdgeList(string path, Graph graph)
        {
            try
            {
                var builder = new StringBuilder(graph.VerticesCout);
                builder.Append(Environment.NewLine);
                foreach (var edge in graph.GetAllEdges())
                {
                    builder.Append(edge.Item1)
                        .Append('\t')
                        .Append(edge.Item2)
                        .Append('\t')
                        .Append(edge.Item3.ToString("F4"))
                        .Append(Environment.NewLine);
                }
                File.WriteAllText(path, builder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption occured: " + e.ToString());
            }
        }
    }
}
