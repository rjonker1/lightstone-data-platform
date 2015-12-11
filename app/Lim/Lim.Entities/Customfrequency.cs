namespace Lim.Entities
{
    
    public class CustomFrequency {
        public virtual long Id { get; protected set; }
        public virtual long ConfigurationId { get; set; }
        public virtual int Seconds { get; set; }
        public virtual int Minutes { get; set; }
        public virtual int Hours { get; set; }
        public virtual string Month { get; set; }
        public virtual string Weekday { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
