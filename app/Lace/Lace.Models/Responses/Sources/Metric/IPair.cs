namespace Lace.Models.Responses.Sources.Metric
{
    public interface IPair<T1, T2>
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
    }
}