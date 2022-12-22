namespace AdventOfCode2022
{
    public class DistressPair
    {
        public int Index { get; set; }

        public bool? Valid { get; set; }

        public Packet Left { get; set; }

        public Packet Right { get; set; }

        public void Validate()
        {
            Valid = Validate(Left, Right);
        }

        public static bool? Validate(Packet left, Packet right)
        {
            if (left.Value is null && left.Childs is null && right.Value is null && right.Childs is null)
                return null;
            if (left.Value is null && left.Childs is null) 
                return true;
            if (right.Value is null && right.Childs is null) 
                return false;

            if (left.Value.HasValue && right.Value.HasValue)
            {
                if (left.Value.Value < right.Value.Value)
                    return true;

                if (left.Value.Value > right.Value.Value)
                    return false;

                return null;
            }

            if (left.Value.HasValue)
            {
                Convert(left);
            }

            if (right.Value.HasValue)
            {
                Convert(right);
            }

            if (left.Childs is not null && right.Childs is not null)
            {
                while(true)
                {
                    var leftHasNext = left.Childs.TryDequeue(out Packet l);
                    var rightHasNext = right.Childs.TryDequeue(out Packet r);

                    if (!leftHasNext && !rightHasNext)
                        return null;

                    if (!leftHasNext)
                        return true;
                    
                    if (!rightHasNext)
                        return false;

                    var valid = Validate(l, r);

                    if (valid is not null)
                        return valid;
                }
            }

            return true;
        }

        public static void Convert(Packet packet)
        {
            int temp = packet.Value.Value;
            packet.Value = null;

            packet.Childs = new();
            packet.Childs.Enqueue(new Packet($"{temp}"));
        }

        public string ToString()
        {
            return $"{Index}: {Valid}";
        }
    }
}
