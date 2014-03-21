namespace DataPlatform.BuildingBlocks.Fluency
{
    public class Times
    {
        public Times(int times)
        {
            Count = times;
        }

        public int Count { get; private set; }

    }
}