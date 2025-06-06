using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //1. Разработать функцию, которая генерирует граф (неориентированный)
            //одним из способов представления графов:
            //•	матрица смежности;	
            //• матрица инцидентности;
            //• список смежности;
            //• список рёбер. 
            //Вершины графа обозначать целыми числами(уникальными).


            Console.WriteLine("Введите число вершин:");
            int ver = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число рёбер:");
            int ed = int.Parse(Console.ReadLine());

            Console.WriteLine("Выберите способ представления (1 - матрица, 2 - матрица инцидентности, 3 - список смежности, 4 - список рёбер):");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string text = GenerateAdjacencyMatrix(ver, ed);
                SaveToFile("graph.txt", text);
            }
            else if (choice == "2")
            {
                string text = GenerateIncidenceMatrix(ver, ed);
                SaveToFile("graph.txt", text);
            }
            else if (choice == "3")
            {
                string text = GenerateAdjacencyList(ver, ed);
                SaveToFile("graph.txt", text);
            }
            else if (choice == "4")
            {
                string text = GenerateEdgeList(ver, ed);
                SaveToFile("graph.txt", text);
            }
            else
            {
                Console.WriteLine("Такого способа нет");
            }
        }

        static string GenerateAdjacencyMatrix(int vk, int ek)
        {
            int[,] matrix = new int[vk, vk];
            for (int i = 0; i < ek; i++)
            {
                int a;
                int b;
                do
                {
                    a = rnd.Next(vk);
                    b = rnd.Next(vk);
                } while (a == b || matrix[a, b] == 1);

                matrix[a, b] = 1;
                matrix[b, a] = 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vk; i++)
            {
                for (int j = 0; j < vk; j++)
                {
                    sb.Append(matrix[i, j] + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        static string GenerateIncidenceMatrix(int vk, int ek)
        {
            int[,] matrix = new int[vk, ek];
            for (int i = 0; i < ek; i++)
            {
                int a;
                int b;
                do
                {
                    a = rnd.Next(vk);
                    b = rnd.Next(vk);
                } while (a == b || matrix[a, i] == 1 || matrix[b, i] == 1);

                matrix[a, i] = 1;
                matrix[b, i] = 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vk; i++)
            {
                for (int j = 0; j < ek; j++)
                    sb.Append(matrix[i, j] + " ");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        static string GenerateAdjacencyList(int vk, int ek)
        {
            List<int>[] adj = new List<int>[vk];
            for (int i = 0; i < vk; i++) adj[i] = new List<int>();

            for (int i = 0; i < ek; i++)
            {
                int a;
                int b;
                do
                {
                    a = rnd.Next(vk);
                    b = rnd.Next(vk);
                } while (a == b || adj[a].Contains(b));

                adj[a].Add(b);
                adj[b].Add(a);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vk; i++)
            {
                sb.Append(i + ": " + string.Join(", ", adj[i]));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        static string GenerateEdgeList(int vk, int ek)
        {
            HashSet<(int, int)> edges = new HashSet<(int, int)>();

            while (edges.Count < ek)
            {
                int a = rnd.Next(vk);
                int b;
                do
                {
                    b = rnd.Next(vk);
                } while (a == b || edges.Contains((a, b)) || edges.Contains((b, a)));

                edges.Add((a, b));
            }

            StringBuilder sb = new StringBuilder();
            foreach (var e in edges)
            {
                sb.AppendLine($"{e.Item1} - {e.Item2}");
            }
            return sb.ToString();
        }

        static void SaveToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
            Console.WriteLine("Граф сохранён в файл " + filename);
        }
    }
}
