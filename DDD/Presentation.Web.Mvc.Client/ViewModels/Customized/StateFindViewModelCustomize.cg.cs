using System;
using System.Globalization;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class StateFindViewModel
    {
        #region Private Methods

        private void BuildVm()
        {
            try
            {
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMState ERROR"),
                        ex);
            }
        }

        #endregion
    }
}