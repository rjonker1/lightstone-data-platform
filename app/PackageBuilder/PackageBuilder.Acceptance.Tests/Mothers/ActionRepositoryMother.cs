using PackageBuilder.Acceptance.Tests.Builders.Repositories;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Mothers
{
    public class ActionRepositoryMother
    {
        public static IActionRepository Get()
        {
            return ActionRepositoryBuilder.Get(ActionMother.EzScoreAction, ActionMother.VerifyAction, ActionMother.LicenseScanAction, ActionMother.AllAction);
        }
    }
}