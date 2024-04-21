using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_t_p
{


    class SearchGraph
    {
        public Dictionary<int, List<(int, int)>> adjacencyList;//словарь графа

        public SearchGraph()
        {
            adjacencyList = new Dictionary<int, List<(int, int)>>();
        }

        public void AddEdge(int source, int destination, int weight)//добавить ребро
        {
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new List<(int, int)>();
            }
            adjacencyList[source].Add((destination, weight));


            if (!adjacencyList.ContainsKey(destination))
            {
                adjacencyList[destination] = new List<(int, int)>();
            }
            adjacencyList[destination].Add((source, weight));


        }

        public List<int[]> Dijkstra(int startVertex, int endVertex)
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();
            Dictionary<int, int> preVertices = new Dictionary<int, int>();
            HashSet<int> visited = new HashSet<int>();

            PriorityQueue<(int, int)> priorityQueue = new PriorityQueue<(int, int)>();
            priorityQueue.Enqueue((0, startVertex));
            distances[startVertex] = 0;
            List<int[]> res = new List<int[]>();

            while (priorityQueue.Count > 0)
            {
                (int dist, int currentVertex) = priorityQueue.Dequeue();

                if (visited.Contains(currentVertex))
                {
                    continue;
                }

                visited.Add(currentVertex);

                if (currentVertex == endVertex)
                {
                    List<int> path = GetShortestPath(preVertices, startVertex, endVertex);
                    int previous = -1;
                    int fullweight = 0;
                    foreach (int vertex in path)
                    {
                        if (previous != -1)
                        {
                            int weight = adjacencyList[previous].Find(x => x.Item1 == vertex).Item2;
                            res.Add([ previous, vertex, weight]);
                            fullweight += weight;
                        }
                        previous = vertex;
                    }
                    res.Add([fullweight]);
                    return res;
                }

                if (adjacencyList.ContainsKey(currentVertex))
                {
                    foreach ((int neighbor, int weight) in adjacencyList[currentVertex])
                    {
                        int newDistance = dist + weight;
                        if (!distances.ContainsKey(neighbor) || newDistance < distances[neighbor])
                        {
                            distances[neighbor] = newDistance;
                            preVertices[neighbor] = currentVertex;
                            priorityQueue.Enqueue((newDistance, neighbor));
                        }
                    }
                }
            }

            return res;
        }

        private List<int> GetShortestPath(Dictionary<int, int> preVertices, int startVertex, int endVertex)
        {
            List<int> path = new List<int>();
            int currentVertex = endVertex;
            while (currentVertex != startVertex)
            {
                path.Add(currentVertex);
                currentVertex = preVertices[currentVertex];
            }
            path.Add(startVertex);
            path.Reverse();
            return path;
        }
    }

    class PriorityQueue<T>
    {
        private SortedDictionary<T, int> elements = new SortedDictionary<T, int>();

        public int Count => elements.Count;

        public void Enqueue(T element)
        {
            if (!elements.ContainsKey(element))
            {
                elements[element] = 0;
            }
            elements[element]++;
        }

        public T Dequeue()
        {
            var first = elements.First();
            var element = first.Key;
            if (first.Value > 1)
            {
                elements[first.Key]--;
            }
            else
            {
                elements.Remove(first.Key);
            }
            return element;
        }

    }
}