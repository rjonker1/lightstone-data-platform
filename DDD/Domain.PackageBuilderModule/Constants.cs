using System;

namespace LightstoneApp.Domain.PackageBuilderModule
{
    public static class Constants
    {
        public static class IndustryKeys
        {
            public static readonly Guid Consumer = new Guid("b60a95b0-c5cc-4950-9f2c-3230aa470625");
            public static readonly Guid Government = new Guid("06bcb7fd-fef5-4bea-878d-3fbc421ec9dd");
            public static readonly Guid Insurance = new Guid("ea0c14c6-108c-446c-90fc-ad9fa6fcdde0");
            public static readonly Guid Dealer = new Guid("3f71f8cb-fcfd-4efb-b68d-e29ed794e1fe");
            public static readonly Guid Banking = new Guid("74d29c6b-8a1a-4b34-9ce7-fd5b850e66c6");
            public static readonly Guid Other = new Guid("a5f908f8-f645-4c94-93f5-fedbc9781f8c");
        }

        public static class StateKeys
        {
            public static readonly Guid Expired = new Guid("5DBBF4E7-7E5C-49C7-B8CE-219AA637076B");
            public static readonly Guid UnderConstruction = new Guid("80ADC8FE-A229-4B00-A491-818DD0273B16");
            public static readonly Guid Published = new Guid("72E27DAA-B3B3-4919-9568-E4843683165B");
        }
    }
}
