﻿namespace Lace.Models.Lightstone
{
    public class LightstoneResponseHandled : IResponseHandled
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