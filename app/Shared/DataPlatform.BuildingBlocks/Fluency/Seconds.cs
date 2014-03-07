namespace DataPlatform.BuildingBlocks.Fluency
{
    public class Seconds
    {
        public Seconds(int seconds)
        {
            Count = seconds;
        }

        public int Count { get; private set; }

        public int AsMilliSeconds
        {
            get { return Count*1000; }
        }
    }
}