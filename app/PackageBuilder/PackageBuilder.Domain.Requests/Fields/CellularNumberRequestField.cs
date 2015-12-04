using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class CellularNumberRequestField : IAmCellularNumberRequestField
    {
       public string Field { get; private set; }

       public CellularNumberRequestField(string field)
        {
            Field = field;
        }
    }
}
