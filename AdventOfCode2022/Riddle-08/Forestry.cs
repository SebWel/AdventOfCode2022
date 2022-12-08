using System.Text;

namespace AdventOfCode2022
{
    internal class Forestry
    {
        private Tree[,] Trees { get; set; }

        public int Length => (int)Math.Sqrt(Trees.Length);

        public Forestry(int length)
        {
            Trees = new Tree[length, length];
        }

        public IEnumerable<Tree> AllTrees()
        {
            for (int y = 0; y < Length; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    yield return Trees[x, y];
                }
            }
        }

        public void Add(int x, int y, byte heigh)
        {
            Trees[x, y] = new Tree { Heigh = heigh, Visible = true };
        }

        public void CalculateVisibility()
        {
            // TODO: Derive the visibility from the ViewDistance
            for (int y = 0; y < Length; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    Trees[x, y].Visible = VisibleN(x, y) || VisibleE(x, y) || VisibleS(x, y) || VisibleW(x, y);
                }
            }
        }

        public void CalculateScenicScore()
        {
            for (int y = 0; y < Length; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    var n = ViewDistanceN(x, y);
                    var e = ViewDistanceE(x, y);
                    var s = ViewDistanceS(x, y);
                    var w = ViewDistanceW(x, y);

                    int scenicScore = n * e * s * w;

                    Trees[x, y].ScenicScore = ViewDistanceN(x, y) * ViewDistanceE(x, y) * ViewDistanceS(x, y) * ViewDistanceW(x, y);
                }
            }
        }

        public int ViewDistanceN(int x, int y)
        {
            var heigh = Trees[x, y].Heigh;
            int viewDistance = 0;

            for (var n = y - 1; n >= 0; n--)
            {
                viewDistance++;

                if (Trees[x, n].Heigh >= heigh)
                    return viewDistance;
            }

            return viewDistance;
        }

        public int ViewDistanceE(int x, int y)
        {
            var heigh = Trees[x, y].Heigh;
            int viewDistance = 0;

            for (var e = x + 1; e < Length; e++)
            {
                viewDistance++;

                if (Trees[e, y].Heigh >= heigh)
                    return viewDistance;
            }

            return viewDistance;
        }

        public int ViewDistanceS(int x, int y)
        {
            var heigh = Trees[x, y].Heigh;
            int viewDistance = 0;

            for (var s = y + 1; s < Length; s++)
            {
                viewDistance++;

                if (Trees[x, s].Heigh >= heigh)
                    return viewDistance;
            }

            return viewDistance;
        }

        public int ViewDistanceW(int x, int y)
        {
            var heigh = Trees[x, y].Heigh;
            int viewDistance = 0;

            for (var w = x - 1; w >= 0; w--)
            {
                viewDistance++;

                if (Trees[w, y].Heigh >= heigh)
                    return viewDistance;
            }

            return viewDistance;
        }

        public bool VisibleN(int x, int y)
        {
            if (y == 0)
                return true;

            var heigh = Trees[x, y].Heigh;

            for(var n = y-1; n >= 0; n--)
            {
                if (Trees[x, n].Heigh >= heigh)
                    return false;
            }

            return true;
        }

        public bool VisibleE(int x, int y)
        {
            if (x == Length-1)
                return true;

            var heigh = Trees[x, y].Heigh;

            for (var e = x + 1; e <= Length - 1; e++)
            {
                if (Trees[e, y].Heigh >= heigh)
                    return false;
            }

            return true;
        }

        public bool VisibleS(int x, int y)
        {
            if (y == Length - 1)
                return true;

            var heigh = Trees[x, y].Heigh;

            for (var s = y + 1; s <= Length - 1; s++)
            {
                if (Trees[x, s].Heigh >= heigh)
                    return false;
            }

            return true;
        }

        public bool VisibleW(int x, int y)
        {
            if (x == 0)
                return true;

            var heigh = Trees[x, y].Heigh;

            for (var w = x - 1; w >= 0; w--)
            {
                if (Trees[w, y].Heigh >= heigh)
                    return false;
            }

            return true;
        }
    }

    public class Tree
    {
        public byte Heigh { get; set; }

        public bool Visible { get; set; }

        public int ScenicScore { get; set; }
    }
}
