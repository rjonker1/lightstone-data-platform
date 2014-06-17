using System.Web.Mvc;

namespace LiveAutoWeb.ViewModels
{
    public class DynamicPageViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Url { get; set; }
    }
}