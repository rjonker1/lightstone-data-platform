using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace DataProviders.Lightstone.MMCode.Core.Contracts
{
    public interface IGetMmCode
    {
        MmCode MmCode { get; }
        void GetCarMmCode(int request);
    }
}