using System;

namespace Lim.Entities
{
    public class ConfigurationFtp
    {
        public virtual long Id { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual string Host { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string CreatedBy { get; set; }

    }
}
