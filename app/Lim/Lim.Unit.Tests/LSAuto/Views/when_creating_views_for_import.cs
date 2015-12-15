using System.Collections.Generic;
using System.Linq;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Factories;
using Toolbox.LightstoneAuto.Import.Views.AutoCarStats;
using Xunit.Extensions;

namespace Lim.Unit.Tests.LSAuto.Views
{
    public class when_creating_views_for_import : Specification
    {
        private readonly BuildViewDtoFactory _buildFactory;
        private List<DatabaseViewDto> _views;

        public when_creating_views_for_import()
        {
            _buildFactory = new BuildViewDtoFactory();
        }

        public override void Observe()
        {
            _views = (List<DatabaseViewDto>)_buildFactory.Build(true);
        }

        [Observation]
        public void then_views_dtos_should_be_created()
        {
            _views.Count.ShouldEqual(1);

            var specView = _views.FirstOrDefault(w => w.Name == (typeof (VehicleSpecifcationView)).Name);
            specView.ShouldNotBeNull();
            specView.ViewColumns.Count.ShouldEqual(22);
        }
    }
}
