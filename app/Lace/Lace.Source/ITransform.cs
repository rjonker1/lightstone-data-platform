using System.Runtime.InteropServices.ComTypes;

namespace Lace.Source
{
    public interface ITransform
    {
        bool Continue { get; }
        void Transform();
    }
}
