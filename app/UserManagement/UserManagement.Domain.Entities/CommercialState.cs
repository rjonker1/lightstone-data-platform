namespace UserManagement.Domain.Entities
{
    public class CommercialState : ValueEntity
    {
        protected CommercialState() { }

        public CommercialState(string val) : base(val)
        {
            Value = val;
        }
    }
}
