﻿using Lace.Domain.Core.Contracts;

namespace Lace.Domain.Core.Dto
{
    public class AudatexResponseHandled : IResponseProviderHandled
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
