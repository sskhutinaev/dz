using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 1 },
            { 0, 1, 1, 0, 1 },
            { 0, 0, 1, 1, 0 }
        };

            bool[] visited = new bool[5]; // Массив для отслеживания посещенных вершин

            Console.WriteLine("Обход графа в глубину начиная с вершины 0:");
            DFS(graph, 0, visited);
        }

        static void DFS(int[,] graph, int vertex, bool[] visit)
        {
            // Отметить вершину как посещенную
            visit[vertex] = true;
            Console.WriteLine(vertex);

            // Рекурсивно обойти все смежные вершины
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[vertex, i] == 1 && !visit[i])
                {
                    DFS(graph, i, visit);
                }
            }
        }
    }
}
