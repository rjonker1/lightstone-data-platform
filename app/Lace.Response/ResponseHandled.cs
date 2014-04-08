namespace Lace.Response
{
    public class ResponseHandled
    {
        public bool Handled
        {
            get;
            private set;
        }

        public void NotHandled()
        {
            Handled = false;
        }

        public void IsHandled()
        {
            Handled = true;
        }
    }
}
