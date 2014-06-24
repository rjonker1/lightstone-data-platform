using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Builders.Repositories;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ActionRepositoryMother
    {
        public static IActionRepository Get()
        {
            return ActionRepositoryBuilder.Get(ActionMother.LicensePlateSeacrhAction, ActionMother.EzScoreAction, ActionMother.VerifyAction, ActionMother.LicenseScanAction, ActionMother.AllAction);
        }
    }
}