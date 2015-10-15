using Lace.Toolbox.Database.Models;

namespace DataProviders.MMCode.Core.Contracts
{
    public interface IGetMmCode
    {
        MmCode MmCode { get; }
        void GetCarMmCode(int request);
    }
}