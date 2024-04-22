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

        public List<int[]> Dijkstra(int startVertex, int endVertex)//обход всех вершин от начальной до конечной
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();//длины путей
            Dictionary<int, int> preVertices = new Dictionary<int, int>();//предыдущие вершины
            List<int> visited = new List<int>();//посещенные вершины
            List<int[]> res = new List<int[]>();//маршрут

            PriorityQueue<(int, int)> priorityQueue = new PriorityQueue<(int, int)>();
            priorityQueue.Enqueue((0, startVertex));
            distances[startVertex] = 0;

            while (priorityQueue.Count > 0)//пока очередь не пуста
            {
                (int dist, int currentVertex) = priorityQueue.Dequeue();//извлечь вершину с наименьшем расстоянием

                if (visited.Contains(currentVertex))//если вершина посещена идем к следующей
                {
                    continue;
                }

                visited.Add(currentVertex);//добавить текущую вершину как посещенную

                if (currentVertex == endVertex)// при достижении конечной точки пути
                {
                    List<int> way = GetShortestWay(preVertices, startVertex, endVertex);//формируем путь
                    int previous = -1;//предыдущая станция
                    int fullweight = 0;//полная стоимость маршрута
                    foreach (int vertex in way)
                    {
                        if (previous != -1)
                        {
                            int weight = adjacencyList[previous].Find(x => x.Item1 == vertex).Item2;//находим вес между двумя станциями
                            res.Add([ previous, vertex, weight]);//добавляем две станции и стоимость между ними
                            fullweight += weight;//прибавить путь между станциями к полному пути
                        }
                        previous = vertex;//изменить предыдущую станцию
                    }
                    
                    
                    res.Add([fullweight]);//добавить к маршруту информацию о стоимости полного пути
                    return res;
                }

                if (adjacencyList.ContainsKey(currentVertex))//обновление расстояний между вершинами
                {
                    foreach ((int neighbor, int weight) in adjacencyList[currentVertex])
                    {
                        int newDistance = dist + weight;//новая дистанция с учетом добавленной станции
                        if (!distances.ContainsKey(neighbor) || newDistance < distances[neighbor])//если новая дистанция короче или такого пути не было
                        {
                            distances[neighbor] = newDistance;//записать дистанцию
                            preVertices[neighbor] = currentVertex;//записывается пройденная вершина
                            priorityQueue.Enqueue((newDistance, neighbor));//вершина добавляется в очередь
                        }
                    }
                }
            }

            return res;
        }
       
        private List<int> GetShortestWay(Dictionary<int, int> preVertices, int startVertex, int endVertex)//формируем путь между станциями
        {
            List<int> way = new List<int>();
            int currentVertex = endVertex;
            while (currentVertex != startVertex)//пока не дойдем до начала маршрута
            {
                way.Add(currentVertex);//добавить вершину в список
                currentVertex = preVertices[currentVertex];//получить следущую вершину
            }
            way.Add(startVertex);//добавить начальную вершину
            way.Reverse();//развернуть список
            return way;
        }
        
    }

    class PriorityQueue<T>//приоритетная очередь
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