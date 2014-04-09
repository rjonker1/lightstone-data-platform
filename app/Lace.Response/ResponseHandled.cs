namespace Lace.Response
{
    public class ResponseHandled
    {
        public bool Handled
        {
            get;
            private set;
        }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}
