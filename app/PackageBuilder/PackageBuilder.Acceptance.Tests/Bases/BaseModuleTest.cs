﻿using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.TestHelper.BaseTests;

namespace PackageBuilder.Acceptance.Tests.Bases
{
    public abstract class BaseModuleTest : MemoryTestDataBaseHelper
    {
        protected readonly Browser Browser = new Browser(new TestBootstrapper());
    }
}