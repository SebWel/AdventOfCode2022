namespace Riddle05
{
    using Common.Interfaces;

    public class Riddle05b : ISolvable
    {
        public string Result { get; private set; }

        private FileStream File { get; set; }

        private List<Stack<char>> Stacks { get; set; }

        private List<(int move, int from, int to)> Instructions { get; set;}

        public ISolvable Solve()
        {
            Load();
            Parse();
            PerformInstructions();
            Calculate();

            return this;
        }

        private void Load()
        {
            string pathSource = Directory.GetCurrentDirectory() + "\\Input05.txt";
            File = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
        }

        private void Parse()
        {
            var stackLines = new List<string>();
            var instructionLines = new List<string>();

            bool firstPart = true;

            using (var stream = new StreamReader(File))
            {
                while (stream.Peek() >= 0)
                {
                    var line = stream.ReadLine();

                    if (line == string.Empty)
                    {
                        firstPart = false;
                        continue;
                    }

                    if (firstPart)
                        stackLines.Add(line + ' ');
                    else
                        instructionLines.Add(line);
                }
            }

            ParseStacks(stackLines);
            ParseInstructions(instructionLines);
        }

        private void ParseStacks(List<string> lines)
        {
            Stacks = new List<Stack<char>>();
            for (int pointer = 0; pointer < lines.First().Length; pointer += 4)
            {
                Stacks.Add(new Stack<char>());
            }

            lines.Reverse();
            lines.RemoveAt(0);
            lines.ForEach(line => ParseStack(line));
        }

        private void ParseStack(string line)
        {
            for (int pointer = 0; pointer < line.Length; pointer += 4)
            {
                int groupNr = pointer / 4;
                var group = line.Substring(pointer, 4);
                char secondChar = group[1];

                if (secondChar == ' ')
                    continue;

                Stacks[groupNr].Push(secondChar);
            }
        }

        private void ParseInstructions(List<string> lines)
        {
            Instructions = new List<(int, int, int)>();
            lines.ForEach(line => ParseInstruction(line));
        }

        private void ParseInstruction(string line)
        {
            var x = line.Split(' ');

            int move = int.Parse(x[1]);
            int from = int.Parse(x[3])-1;
            int to = int.Parse(x[5])-1;

            (int move, int from, int to) tuple = (move, from, to);

            Instructions.Add(tuple);
        }

        private void PerformInstructions()
        {
            Instructions.ForEach(instruction => PerformInstruction(instruction));
        }

        private void PerformInstruction((int move, int from, int to) instruction)
        {
            var reverseFrom = new Stack<char>();
            for (int i = 0; i < instruction.move; i++)
                reverseFrom.Push(Stacks[instruction.from].Pop());

            for (int i = 0; i < instruction.move; i++)
                PerformInstruction(reverseFrom, Stacks[instruction.to]);
        }

        private void PerformInstruction(Stack<char> from, Stack<char> to)
        {
            to.Push(from.Pop());
        }

        private void Calculate()
        {
            Result = new string(Stacks.Select(s => s.Peek()).ToArray());
        }
    }
}
