namespace Lim.Domain.Extensions
{
    public class RepeatValue
    {
        public RepeatValue(int times)
        {
            Times = times;
        }

        public int Times { get; private set; }
    }
}
