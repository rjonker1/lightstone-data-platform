namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{
    public class PackageClonedEvent : PackageCreatedEvent
    {

        public PackageClonedEvent(Package package)
            : base(package)
        {
            
            
        }

    }
}