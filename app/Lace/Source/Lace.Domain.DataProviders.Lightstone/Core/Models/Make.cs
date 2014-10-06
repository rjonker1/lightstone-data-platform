namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Make
    {
        public Make()
        {
             
        }

        public Make(int makeId, string makeName)
        {
            Make_ID = makeId;
            MakeName = makeName;
        }

        public int Make_ID { get; set; }
        public string MakeName { get; set; }
    }
}
