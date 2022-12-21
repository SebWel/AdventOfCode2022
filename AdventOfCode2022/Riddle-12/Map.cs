namespace AdventOfCode2022
{
    public class Map
    {
        public Knot[,] Graph { get; set; }

        public Queue<Knot> Todo { get; set; }

        public Knot Start { get; set; }

        public Knot End { get; set; }

        public Map()
        {
            Graph = new Knot[144, 41];
            Todo = new Queue<Knot>();
        }

        public void Init()
        {
            Todo.Clear();

            foreach(var knot in Graph)
            {
                knot.Distance = 10_000;
                knot.Predecessor = null;
                Todo.Enqueue(knot);
            }

            Start.Distance = 0;
        }

        public void Dijkstra()
        {
            Init();

            while (Todo.Count != 0)
            {
                Todo = new Queue<Knot>(Todo.OrderBy(x => x.Distance));
                var current = Todo.Dequeue();

                if (End == current)
                    return;

                foreach (var neighbor in Neighbors(current))
                {
                    if (Todo.Contains(neighbor))
                    {
                        var alternativWay = current.Distance + 1;

                        if (alternativWay < neighbor.Distance)
                        {
                            neighbor.Distance = alternativWay;
                            neighbor.Predecessor = current;
                        }
                    }
                }
            }
        }

        public IEnumerable<Knot> Neighbors(Knot knot)
        {
            var east = knot.X != Graph.GetLength(0) - 1 ? Graph[knot.X + 1, knot.Y] : null;
            var south = knot.Y != Graph.GetLength(1) - 1 ? Graph[knot.X, knot.Y + 1] : null;
            var north = knot.Y != 0 ? Graph[knot.X, knot.Y - 1] : null;
            var west = knot.X != 0 ? Graph[knot.X - 1, knot.Y] : null;

            if (east is not null && east.Heigh - knot.Heigh <= 1)
                yield return east;

            if (south is not null && south.Heigh - knot.Heigh <= 1)
                yield return south;

            if (north is not null && north.Heigh - knot.Heigh <= 1)
                yield return north;

            if (west is not null && west.Heigh - knot.Heigh <= 1)
                yield return west;
        }

        public Queue<Knot> ShortestDistance()
        {
            Queue<Knot> shotestDistance = new();

            var knot = End;
            while (knot is not null)
            {
                shotestDistance.Enqueue(knot);
                knot = knot.Predecessor;
            }

            return shotestDistance;
        }

        public void Write()
        {
            var shortestDistance = ShortestDistance();

            Console.WriteLine();

            for (int y = 0; y < 41; y++)
            {
                for (int x = 0; x < 144; x++)
                {
                    var element = Graph[x,y];

                    Console.ForegroundColor = shortestDistance.Contains(element) ? ConsoleColor.Red : ConsoleColor.White;

                    Console.Write((char)(element.Heigh + 'a'));
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
