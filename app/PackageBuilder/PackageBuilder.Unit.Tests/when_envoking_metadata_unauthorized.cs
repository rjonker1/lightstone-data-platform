﻿using DataPlatform.Shared.Dtos;
using Nancy;
using Nancy.Testing;
using PackageBuilder.Unit.Tests.Fakes;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests
{
    public class when_envoking_metadata_unauthorized : Specification
    {
        private readonly Browser _browser = new Browser(new TestBootstrapper("admin"));
        private BrowserResponse _response;
        private ApiMetaData _apiMetaData;

        public override void Observe()
        {
            _response = _browser.Get("/getUserMetaData", with =>
            {
                with.HttpRequest();
            });
        }

        [Observation]
        public void should_return_unauthorized()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.Unauthorized);
        }
    }
}