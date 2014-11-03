using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class StateMother
    {
        public static State Draft
        {
            get
            {
                return new StateBuilder().With(StateName.Draft).With(StateName.Draft.ToString()).Build();
            }
        }

        public static State Published
        {
            get
            {
                return new StateBuilder().With(StateName.Published).With(StateName.Published.ToString()).Build();
            }
        }

        public static State Expired
        {
            get
            {
                return new StateBuilder().With(StateName.Expired).With(StateName.Expired.ToString()).Build();
            }
        }
    }
}