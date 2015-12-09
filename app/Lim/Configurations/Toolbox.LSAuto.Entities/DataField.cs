using System;
namespace Toolbox.LSAuto.Entities
{
    public class DataField
    {
        public virtual long Id { get; set; }
        public virtual DataSet DataSet { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool Selected { get; set; }
        public virtual bool Activated { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
    }
}