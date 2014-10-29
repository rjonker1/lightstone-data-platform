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
                return new StateBuilder().With("Draft").Build();
            }
        }

        public static State Published
        {
            get
            {
                return new StateBuilder().With("Published").Build();
            }
        }

        public static State Expired
        {
            get
            {
                return new StateBuilder().With("Expired").Build();
            }
        }
    }
}