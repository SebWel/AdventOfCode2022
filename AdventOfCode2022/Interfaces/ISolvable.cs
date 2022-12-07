namespace AdventOfCode2022.Interfaces
{
    public interface ISolvable
    {
        string ResultA { get; }

        string ResultB { get; }

        //TODO: Writing Integration Tests
        string SolutionA { get; }

        //TODO: Writing Integration Tests
        string SolutionB { get; }

        ISolvable Solve();
    }
}
