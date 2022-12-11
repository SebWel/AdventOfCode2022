namespace AdventOfCode2022
{
    public class Tail : Knot
    {
        public List<Coordinate> VisitedCoordinates { get; set; }

        public void Follow()
        {
            if (this == Parent)
            {
            } 
            else if (IsTouching(Parent))
            {
            } 
            else if (X == Parent.X)
            {
                Y = Y < Parent.Y ? Y + 1 : Y - 1;
            }
            else if (Y == Parent.Y)
            {
                X = X < Parent.X ? X + 1 : X - 1;
            }
            else
            {
                X = X < Parent.X ? X + 1 : X - 1;
                Y = Y < Parent.Y ? Y + 1 : Y - 1;
            }
            
            UpdateVisitedCoordinates();
        }

        private void UpdateVisitedCoordinates()
        {
            if (VisitedCoordinates is null)
                return;

            if (!VisitedCoordinates.Contains(this))
                VisitedCoordinates.Add(new Coordinate(X, Y));
        }
    }
}
