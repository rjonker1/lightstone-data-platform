using Lace.Toolbox.PCubed.Extensions;

namespace Lace.Toolbox.PCubed.Domain
{
    public class Header
    {
        private string _phone1;
        private string _phone2;
        private string _phone3;
        private string _emailAddress1;
        private string _emailAddress2;
        private string _emailAddress3;
        private string _surname;
        private string _firstName;
        private string _idNumber;

        public string IDNumber
        {
            get { return _idNumber.Fix(); }
            set { _idNumber = value; }
        }

        public string FirstName
        {
            get { return _firstName.Fix(); }
            set { _firstName = value; }
        }

        public string Surname
        {
            get { return _surname.Fix(); }
            set { _surname = value; }
        }

        public string Phone1
        {
            get { return _phone1.Fix(); }
            set { _phone1 = value; }
        }

        public string Phone2
        {
            get { return _phone2.Fix(); }
            set { _phone2 = value; }
        }

        public string Phone3
        {
            get { return _phone3.Fix(); }
            set { _phone3 = value; }
        }

        public string EmailAddress1
        {
            get { return _emailAddress1.Fix(); }
            set { _emailAddress1 = value; }
        }

        public string EmailAddress2
        {
            get { return _emailAddress2.Fix(); }
            set { _emailAddress2 = value; }
        }

        public string EmailAddress3
        {
            get { return _emailAddress3.Fix(); }
            set { _emailAddress3 = value; }
        }
    }
}
