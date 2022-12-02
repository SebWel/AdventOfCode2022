namespace Common.Interfaces
{
    public interface ISolvable
    {
        string Result { get; }

        ISolvable Solve();
    }
}
