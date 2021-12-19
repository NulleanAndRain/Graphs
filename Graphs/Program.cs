using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Program
    {
        static Graph graph = new Graph();
        
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                var aboba = GetMenu();
                switch (aboba)
                {
                    case "1":
                        {
                            string text;
                            bool loop = true;
                            do
                            {
                                Console.WriteLine("В каком формате записан граф?");
                                Console.WriteLine(" 1 - матрица");
                                Console.WriteLine(" 2 - число вершин и список рёбер");
                                Console.WriteLine(" 3 - назад");
                                text = Console.ReadLine();
                                switch (text)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Введите путь до файла");
                                            graph = GraphFileReader.ReadFromMatrix(Console.ReadLine());
                                            loop = false;
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Введите путь до файла");
                                            graph = GraphFileReader.ReadFromEdgeList(Console.ReadLine());
                                            loop = false;
                                            break;
                                        }
                                    case "3":
                                        {
                                            loop = false;
                                            break;
                                        }
                                    default: break;
                                }
                                Console.WriteLine("Граф загружен");
                                PauseConsole();
                            }
                            while (loop);
                            break;
                        }
                    case "2":
                        {
                            graph.AddVertex();
                            break;
                        }
                    case "3":
                        {
                            string vertex;
                            int v1, v2;
                            double weight;
                            do
                            {
                                Console.WriteLine("Введите номер первой вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v1));
                            do
                            {
                                Console.WriteLine("Введите номер второй вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v2));
                            do
                            {
                                Console.WriteLine("Введите вес ребра");
                                vertex = Console.ReadLine();
                            }
                            while (!double.TryParse(vertex, out weight));
                            graph.AddEdge(v1, v2, weight);
                            break;
                        }
                    case "4":
                        {
                            string vertex;
                            int v1, v2;
                            do
                            {
                                Console.WriteLine("Введите номер первой вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v1));
                            do
                            {
                                Console.WriteLine("Введите номер второй вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v2));
                            graph.RemoveEdge(v1, v2);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine(graph.GetEdgesCount());
                            PauseConsole();
                            break;
                        }
                    case "6":
                        {
                            string vertex;
                            int v1, v2;
                            do
                            {
                                Console.WriteLine("Введите номер первой вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v1));
                            do
                            {
                                Console.WriteLine("Введите номер второй вершины");
                                vertex = Console.ReadLine();
                            }
                            while (!int.TryParse(vertex, out v2));
                            Console.WriteLine(graph.GetEgdeWeight(v1, v2));
                            PauseConsole();
                            break;
                        }
                    case "7":
                        {
                            string text;
                            bool loop = true;
                            do
                            {
                                Console.WriteLine("В каком формате сохранить граф?");
                                Console.WriteLine(" 1 - матрица");
                                Console.WriteLine(" 2 - число вершин и список рёбер");
                                Console.WriteLine(" 3 - назад");
                                text = Console.ReadLine();
                                switch (text)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Введите путь до файла");
                                            GraphFileSaver.SaveAsMatrix(Console.ReadLine(), graph);
                                            loop = false;
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Введите путь до файла");
                                            GraphFileSaver.SaveAsEdgeList(Console.ReadLine(), graph);
                                            loop = false;
                                            break;
                                        }
                                    case "3":
                                        {
                                            loop = false;
                                            break;
                                        }
                                    default: break;
                                }
                                Console.WriteLine("Сохранено");
                                PauseConsole();
                            }
                            while (loop);
                            break;
                        }
                    case "8":
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
                            Console.WriteLine(builder.ToString());
                            PauseConsole();
                            break;
                        }
                    case "9": 
                        Environment.Exit(0); 
                        break;
                    default: break;
                }
            }
        }

        static void PauseConsole()
        {
            Console.WriteLine("Введите что-нибудь чтобы продолжить");
            Console.ReadKey();
        }

        static string GetMenu()
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine(" 1 - Загрузить граф");
            Console.WriteLine(" 2 - Добавить вершину");
            Console.WriteLine(" 3 - Добавить ребро между вершинами");
            Console.WriteLine(" 4 - Удалить ребро");
            Console.WriteLine(" 5 - Получить количество рёбер");
            Console.WriteLine(" 6 - Получить вес ребра");
            Console.WriteLine(" 7 - Сохранить граф");
            Console.WriteLine(" 8 - Вывести матрицу смежности");
            Console.WriteLine(" 9 - Выход");

            return Console.ReadLine(); 
        }
    }
}
