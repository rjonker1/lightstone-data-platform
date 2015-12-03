namespace Lim.Domain.Extensions
{
    public static class ReflectionExtensions
    {
        public static dynamic AsDynamic(this object @object)
        {
            return ReflectionHelper.WrapObjectIfNeeded(@object);
        }
    }
}
