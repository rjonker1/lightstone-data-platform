using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Caching;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class DataFieldCrudViewModel
    {
        #region Private Methods

        private void BuildVm()
        {
            try
            {
                if (CacheProvider.Exist("DataProviders"))
                    DataProviders = (List<SelectListItem>) CacheProvider.Get("DataProviders");
                else
                {
                    // TODO: Modify TEXT (SelectList)
                    DataProviders =
                        _serviceDataProvider.GetAll(null, null)
                            .Select(
                                x => new SelectListItem {Text = Convert.ToString(x.Id), Value = Convert.ToString(x.Id)})
                            .ToList();
                    CacheProvider.Set("DataProviders", DataProviders);
                }
                if (CacheProvider.Exist("Industrys"))
                    Industrys = (List<SelectListItem>) CacheProvider.Get("Industrys");
                else
                {
                    // TODO: Modify TEXT (SelectList)
                    Industrys =
                        _serviceIndustry.GetAll(null, null)
                            .Select(
                                x => new SelectListItem {Text = Convert.ToString(x.Id), Value = Convert.ToString(x.Id)})
                            .ToList();
                    CacheProvider.Set("Industrys", Industrys);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMDataField ERROR"),
                        ex);
            }
        }

        #endregion
    }
}