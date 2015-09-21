using System;

namespace Toolbox.Bmw.Entities
{
    public class Finance
    {
        public virtual Guid Id { get; set; }
        public virtual string Chassis { get; set; }
        public virtual string Engine { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string Description { get; set; }
        public virtual int RegistrationYear { get; set; }
        public virtual string DealType { get; set; }
        public virtual string DealStatus { get; set; }
        public virtual string VinEngineId { get; set; }
        public virtual DateTime DateAdded { get; set; }

        public Finance SetVinEngineId()
        {
            if (string.IsNullOrEmpty(Chassis))
            {
                VinEngineId = (Engine ?? string.Empty).TrimStart('0');
                return this;
            }

            VinEngineId = (7 >= Chassis.Length)
                ? string.Format("{0}{1}", Chassis, (Engine ?? "").TrimStart('0'))
                : string.Format("{0}{1}", Chassis.Substring(Chassis.Length - 7), (Engine ?? "").TrimStart('0'));
            return this;
        }
    }
}