using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging
{
    public interface ICommand
    {
		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		Guid Id { get; }
    }
}
