namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Handling
{
    /// <summary>
	/// Marker interface that makes it easier to discover handlers via reflection.
	/// </summary>
	public interface ICommandHandler { }

	public interface ICommandHandler<T> : ICommandHandler
		where T : ICommand
	{
		void Handle(T command);
	}
}
