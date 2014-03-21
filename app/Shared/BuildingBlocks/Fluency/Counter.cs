namespace BuildingBlocks.Fluency
{
    public class Counter
    {
        private int counter;
        private readonly int upperRange = int.MaxValue;

        public Counter()
        {
        }

        public Counter(int upperRange)
        {
            this.upperRange = upperRange;
        }

        public Counter Increment()
        {
            counter++;
            return this;
        }

        public bool Exceeded()
        {
            return counter >= upperRange;
        }
    }
}