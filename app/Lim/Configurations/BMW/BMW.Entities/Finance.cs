﻿namespace Toolbox.Bmw.Entities
{
    public class Finance
    {
        public virtual long Id { get; set; }
        public virtual string Chassis { get; set; }
        public virtual string Engine { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string Description { get; set; }
        public virtual int RegistrationYear { get; set; }
        public virtual string DealType { get; set; }
        public virtual string DealStatus { get; set; }

        public virtual string VinEngineId
        {
            get
            {
                if (string.IsNullOrEmpty(Chassis))
                    return Engine ?? string.Empty;

                return (7 >= Chassis.Length)
                    ? string.Format("{0}{1}", Chassis, Engine ?? "")
                    : string.Format("{0}{1}", Chassis.Substring(Chassis.Length - 7), Engine ?? "");
            }
        }
    }
}