namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    public class MonitoringWithArgumentDto
    {
        public MonitoringWithArgumentDto()
        {
            
        }

        public MonitoringWithArgumentDto(string argument, short pageOffset, short pageNext)
        {
            Argument = argument;
            Offset = pageOffset;
            Next = pageNext;
        }

        public readonly string Argument;
        public readonly short Offset;
        public readonly short Next;
    }
}