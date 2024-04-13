using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_t_p
{


    class SearchGraph
    {
        private int verticesCount;
        private List<List<(int, int)>> adjacencyList;

        public SearchGraph(int vertices)
        {
            verticesCount = vertices*2;
            adjacencyList = new List<List<(int, int)>>(vertices*2);
            for (int i = 0; i < vertices*2; i++)
            {
                adjacencyList.Add(new List<(int, int)>());
            }
        }

        public void AddEdge(int source, int destination, int weight)
        {
            adjacencyList[source].Add((destination, weight));
            adjacencyList[destination].Add((source, weight));
        }

        public List<int> Dijkstra(int source, int destination)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
            int[] parent = new int[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;
            parent[source] = -1;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                foreach (var vertex in adjacencyList[u])
                {
                    int v = vertex.Item1;
                    int weight = vertex.Item2;

                    if (!shortestPathTreeSet[v] && distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    {
                        parent[v] = u;
                        distance[v] = distance[u] + weight;
                    }
                }
            }

           return PrintShortestPath(source, destination, distance, parent);
        }

        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private List<int> PrintShortestPath(int source, int destination, int[] distance, int[] parent)
        {
            var list = new List<int>
            {
                distance[destination]
            };

            //Console.Write($"Shortest Path from {source} to {destination}: ");
            list.AddRange(PrintPath(destination, parent));
            return list;
            //Console.WriteLine($" (Distance: {distance[destination]})");
        }

        private List<int> PrintPath(int currentVertex, int[] parent)
        {
            if (currentVertex == -1)
                return new List<int>();
            var list = new List<int>();
            list.AddRange(PrintPath(parent[currentVertex], parent));
            list.Add(currentVertex);
            return list;
            //Console.Write(currentVertex + " ");
        }
    }

    
}