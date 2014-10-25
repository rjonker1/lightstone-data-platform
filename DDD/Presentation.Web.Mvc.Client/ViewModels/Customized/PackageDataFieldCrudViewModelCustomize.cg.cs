using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Caching;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class PackageDataFieldCrudViewModel
    {
        #region Private Methods

        private void BuildVm()
        {
            try
            {
                if (CacheProvider.Exist("DataFields"))
                    DataFields = (List<SelectListItem>) CacheProvider.Get("DataFields");
                else
                {
                    // TODO: Modify TEXT (SelectList)
                    DataFields =
                        _serviceDataField.GetAll(null, null)
                            .Select(
                                x => new SelectListItem {Text = Convert.ToString(x.Id), Value = Convert.ToString(x.Id)})
                            .ToList();
                    CacheProvider.Set("DataFields", DataFields);
                }
                if (CacheProvider.Exist("Packages"))
                    Packages = (List<SelectListItem>) CacheProvider.Get("Packages");
                else
                {
                    // TODO: Modify TEXT (SelectList)
                    Packages =
                        _servicePackage.GetAll(null, null)
                            .Select(
                                x => new SelectListItem {Text = Convert.ToString(x.Id), Value = Convert.ToString(x.Id)})
                            .ToList();
                    CacheProvider.Set("Packages", Packages);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - InitializeVMPackageDataField ERROR"), ex);
            }
        }

        #endregion
    }
}