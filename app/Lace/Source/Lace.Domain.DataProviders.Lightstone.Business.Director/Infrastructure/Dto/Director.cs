using System.Data;
using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Extensions;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto
{
    public class Director
    {
        private Director(long directorId, string firstname, string surname, long idnumber)
        {
            DirectorId = directorId;
            Firstname = firstname;
            Surname = surname;
            IdNumber = idnumber;
        }

        private Director()
        {
            
        }

        public static Director GetFromDataset(DataSet dataSet)
        {
            return dataSet.Tables["directors"]
               .AsEnumerable()
               .Select(
                   s =>
                       new Director(s.GetLongRowValue("directorid"), s.GetStringValue("firstname"), s.GetStringValue("surname"),
                           s.GetLongRowValue("idnumber"))).FirstOrDefault();
        }

        public bool Valid()
        {
            return DirectorId > 0 && IdNumber > 0;
        }

        public long DirectorId { get; private set; }
        public string Firstname { get; private set; }
        public string Surname { get; private set; }
        public long IdNumber { get; private set; }
    }
}
