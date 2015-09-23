using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;

namespace DataProviders.MMCode.Infrastructure.Management
{
    public class TransformMmCodeResponse : ITransform
    {
        public bool Continue { get; private set; }
        public IProvideDataFromMmCode Result { get; private set; }

        private readonly MmCode _mmCode;

        public TransformMmCodeResponse(MmCode mmCode, ICauseCriticalFailure critical)
        {
            Continue = mmCode != null;
            _mmCode = mmCode;
            Result = Continue ? null : critical.IsCritical() ? MMCodeResponse.Failure(critical.Message) : MMCodeResponse.Empty();
        }

        public void Transform()
        {
            Result = new MMCodeResponse(_mmCode.MML_ID, _mmCode.Car_ID, _mmCode.MM_Code);
        }
    }
}