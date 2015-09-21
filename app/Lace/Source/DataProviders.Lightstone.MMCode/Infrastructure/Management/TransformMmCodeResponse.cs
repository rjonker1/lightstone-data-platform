using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace DataProviders.Lightstone.MMCode.Infrastructure.Management
{
    public class TransformMmCodeResponse : ITransformResponseFromDataProvider
    {
        public bool Continue { get; private set; }
        public IProvideDataFromMmCode Result { get; private set; }

        private readonly MmCode _mmCode;

        public TransformMmCodeResponse(MmCode mmCode)
        {
            Continue = mmCode != null;
            _mmCode = mmCode;
            Result = Continue ? null : new MMCodeResponse();
        }

        public void Transform()
        {
            Result = new MMCodeResponse(_mmCode.MML_ID, _mmCode.Car_ID, _mmCode.MM_Code);
        }
    }
}