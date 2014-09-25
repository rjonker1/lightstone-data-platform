using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Entities;
using Nancy;
using Shared.BuildingBlocks.Api;
using Lace.Models.Ivid.Dto;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.Api.Modules
{
    public class IndexModule : NancyModule//SecureModule
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        //public IndexModule(IPackageLookupRepository packageLookupRepository)
        //{
        //    Get["/package/{action}"] = parameters =>
        //    {
        //        var package = packageLookupRepository.Get(Context.CurrentUser.UserName, parameters.action);

        //        return Response.AsJson((IPackage) package);
        //    };

        //    Get["/getUserMetaData"] = parameters =>
        //    {
        //        _log.InfoFormat("getUserMetaData");

        //        var actions = packageLookupRepository.GetActions(Context.CurrentUser.UserName);

        //        return Response.AsJson(new {path = "/action/{action}", actions});
        //    };

        //    Get["/getDataProviders"] = parameters =>
        //    {

        //        var props = new DataProviderDto("Ivid");
        //        //typeof(IvidResponse).GetProperties()
        //        //        .Select(x => new DataProviderFieldItemDto(x.Name, x.PropertyType.Name));
        //        //.GetPublicProperties().Select(x => new DataProviderFieldItemDto(x.Name, x.PropertyType.Name));

        //        return Response.AsJson(props);

        //    };
        //}
    }

    //public class DataProviderDto
    //{
    //    public DataProviderDto(string name)
    //    {

    //        Name = name;
    //        Fields = typeof(IvidResponse).GetProperties()
    //                    .Select(x => new DataProviderFieldItemDto(x.Name, x.PropertyType.Name));       
    //    }

    //    public string Name { get; set; }
    //    public IEnumerable<DataProviderFieldItemDto> Fields { get; set; }

    //}

    //public class DataProviderFieldItemDto
    //{
    //    public DataProviderFieldItemDto(string name, string type)
    //    {
    //        Name = name;
    //        Type = type;
    //        Price = 100;
    //    }

    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public string Label { get; set; }
    //    public string Definition { get; set; }
    //    public string Industries { get; set; }
    //    public double Price { get; set; }
    //    public bool IsSelected { get; set; }

    //}
}