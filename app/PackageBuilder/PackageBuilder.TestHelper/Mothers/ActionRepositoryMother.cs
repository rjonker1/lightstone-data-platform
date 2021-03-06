﻿using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Builders.Repositories;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ActionRepositoryMother
    {
        public static IActionRepository AllActionsRepository
        {
            get
            {
                return new TestRepositoryBuilder<TestActionRepository, IAction>()
                    .With(ActionMother.LicensePlateSearchAction,
                                  ActionMother.EzScoreAction,
                                  ActionMother.VerifyAction,
                                  ActionMother.LicenseScanAction,
                                  ActionMother.AllAction)
                    .Build();
            }
        }
    }
}