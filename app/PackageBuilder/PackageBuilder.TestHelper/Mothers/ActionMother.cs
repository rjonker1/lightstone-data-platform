using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ActionMother
    {
        public static IAction EzScoreAction
        {
            get
            {
                return new ActionBuilder()
                            .With("Get EzScore")
                            .With(DataFieldMother.ColourField)
                            .Build();
            }
        }

        public static IAction VerifyAction
        {
            get
            {
                return new ActionBuilder()
                            .With("Partial")
                            .With(DataFieldMother.ColourField)
                            .Build();
            }
        }

        public static IAction LicenseScanAction
        {
            get
            {
                return new ActionBuilder()
                            .With("License Scan")
                            .With(DataFieldMother.ColourField)
                            .Build();
            }
        }

        public static IAction AllAction
        {
            get
            {
                return new ActionBuilder()
                            .With("Full")
                            .With(DataFieldMother.ColourField)
                            .Build();
            }
        }

        public static IAction LicensePlateSearchAction
        {
            get
            {
                return new ActionBuilder()
                            .With("License plate search")
                            .With(DataFieldMother.LicenseField)
                            .Build();
            }
        }
    }
}