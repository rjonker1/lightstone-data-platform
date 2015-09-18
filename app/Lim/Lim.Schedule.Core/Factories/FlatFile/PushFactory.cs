using System;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Factories.FlatFile
{
    public class PushFactory : AbstractPushFactory<FlatFilePushInitializeCommand>
    {
        public PushFactory()
        {
            
        }

        public override void Push(FlatFilePushInitializeCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
