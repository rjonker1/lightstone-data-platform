namespace Lace.Models.Audatex
{
    public class AudatexResponseHandled : IResponseHandled
    {
        public bool Handled { get; private set; }

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
