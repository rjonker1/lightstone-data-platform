namespace DataPlatform.Shared.Public
{
    public abstract class CannedDatabase<T>
    {
        public static T[] Entities;

        protected void Add(params T[] entities)
        {
            Entities = entities;
        }
    }
}