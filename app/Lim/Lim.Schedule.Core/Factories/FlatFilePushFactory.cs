using System;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Factories
{
    public class FlatFilePushFactory : AbstractPushFactory<FlatFilePushInitializeCommand>
    {
        public FlatFilePushFactory()
        {
            
        }

        public override void Push(FlatFilePushInitializeCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
