namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{
    public class PackageClonedEvent : PackageCreatedEvent
    {

        public PackageClonedEvent(Model.Package package)
            : base(package)
        {
            
            
        }

    }
}