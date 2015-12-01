using Toolbox.LightstoneAuto.Database.Domain.Helpers;

namespace Toolbox.LightstoneAuto.Database.Domain.Extensions
{
    public static class ReflectionExtensions
    {
        public static dynamic AsDynamic(this object @object)
        {
            return ReflectionHelper.WrapObjectIfNeeded(@object);
        }
    }
}
