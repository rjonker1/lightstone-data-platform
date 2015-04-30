namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Make
    {
        private const string SelectAll = @"SELECT * FROM Make";

        public Make()
        {
             
        }

        public Make(int makeId, string makeName)
        {
            Make_ID = makeId;
            MakeName = makeName;
        }

        public static string GetAll()
        {
            return SelectAll;
        }

        public int Make_ID { get; set; }
        public string MakeName { get; set; }
    }
}
