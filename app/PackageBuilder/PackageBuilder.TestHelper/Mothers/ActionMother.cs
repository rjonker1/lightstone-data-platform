using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ActionMother
    {
        public static IAction EzScoreAction
        {
            get
            {
                return ActionBuilder.Get("Get EzScore", DataFieldMother.ColourField);
            }
        }

        public static IAction VerifyAction
        {
            get
            {
                return ActionBuilder.Get("Partial", DataFieldMother.ColourField);
            }
        }

        public static IAction LicenseScanAction
        {
            get
            {
                return ActionBuilder.Get("License Scan", DataFieldMother.ColourField);
            }
        }

        public static IAction AllAction
        {
            get
            {
                return ActionBuilder.Get("Full", DataFieldMother.ColourField);
            }
        }

        public static IAction LicensePlateSearchAction
        {
            get
            {
                return ActionBuilder.Get("License plate search", DataFieldMother.LicenseField);
            }
        }
    }
}