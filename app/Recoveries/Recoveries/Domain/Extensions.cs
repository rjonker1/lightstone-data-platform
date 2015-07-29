namespace Recoveries.Domain
{
    public static class Extensions
    {
        public static T Get<T>(this IQueueOptions options, string property)
        {
            var obj = options.GetType().GetProperty(property).GetValue(options, null);
            return (T)obj;
        }
    }
}
