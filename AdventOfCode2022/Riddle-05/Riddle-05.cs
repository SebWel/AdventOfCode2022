namespace AdventOfCode2022
{
    using Interfaces;

    public class Riddle05 : ISolvable
    {
        public string ResultA { get; private set; }

        public string ResultB { get; private set; }

        public string SolutionA => "TLNGFGMFN";

        public string SolutionB => "FGLQJCMBD";

        private List<Stack<char>> StacksA { get; set; }
        
        private List<Stack<char>> StacksB { get; set; }

        private List<(int move, int from, int to)> Instructions { get; set;}

        public ISolvable Solve()
        {
            Parse();
            PerformInstructions();
            Calculate();

            return this;
        }

        private void Parse()
        {
            var stackLines = new List<string>();
            var instructionLines = new List<string>();

            bool firstPart = true;

            foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\Riddle-05\\Input05.txt"))
            {
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

            ParseStacks(stackLines);
            ParseInstructions(instructionLines);
        }

        private void ParseStacks(List<string> lines)
        {
            StacksA = new List<Stack<char>>();
            StacksB = new List<Stack<char>>();

            for (int pointer = 0; pointer < lines.First().Length; pointer += 4)
            {
                StacksA.Add(new Stack<char>());
                StacksB.Add(new Stack<char>());
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

                StacksA[groupNr].Push(secondChar);
                StacksB[groupNr].Push(secondChar);
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
            for (int i = 0; i < instruction.move; i++)
                PerformInstruction(StacksA[instruction.from], StacksA[instruction.to]);

            //---

            var reverseFrom = new Stack<char>();
            for (int i = 0; i < instruction.move; i++)
                reverseFrom.Push(StacksB[instruction.from].Pop());

            for (int i = 0; i < instruction.move; i++)
                PerformInstruction(reverseFrom, StacksB[instruction.to]);
        }

        private void PerformInstruction(Stack<char> from, Stack<char> to)
        {
            to.Push(from.Pop());
        }

        private void Calculate()
        {
            ResultA = new string(StacksA.Select(s => s.Peek()).ToArray());
            ResultB = new string(StacksB.Select(s => s.Peek()).ToArray()); ;
        }
    }
}
