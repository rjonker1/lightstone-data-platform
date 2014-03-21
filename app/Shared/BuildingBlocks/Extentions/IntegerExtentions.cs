using BuildingBlocks.Fluency;

namespace BuildingBlocks.Extentions
{
    public static class IntegerExtentions
    {
        public static Times Times(this int value)
        {
            return new Times(value);
        }

        public static Seconds Seconds(this int value)
        {
            return new Seconds(value);
        }

        public static Seconds Second(this int value)
        {
            return new Seconds(1);
        }
    }
}