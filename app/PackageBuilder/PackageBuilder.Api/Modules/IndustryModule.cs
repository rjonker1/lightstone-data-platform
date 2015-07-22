using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using Nancy.Extensions;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.Read;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class IndustryModule : SecureModule
    {
        public IndustryModule(IPublishStorableCommands publisher, IRepository<Industry> repository)
        {
            const string industriesRoute = "/Industries";

            Get[industriesRoute + "/{industryIds?}"] = parameters =>
            {
                var allIndustryDtos = Mapper.Map<IEnumerable<IIndustry>, IEnumerable<IndustryDto>>(repository);
                if (!parameters.industryIds.HasValue)
                    return Response.AsJson(allIndustryDtos);

                var filteredIndustries = Enumerable.Empty<Industry>();
                if (parameters.industryIds.HasValue)
                {
                    var industryString = (string)parameters.industryIds.Value;
                    var industryIds = industryString.Split(',').Select(x => new Guid(x));
                    filteredIndustries = repository.Where(x => industryIds.Contains(x.Id));
                }

                var industries = filteredIndustries as IList<Industry> ?? filteredIndustries.ToList();
                var filteredIndustryDtos = Mapper.Map<IEnumerable<IIndustry>, IEnumerable<IndustryDto>>(industries).ToList();
                foreach (var industry in filteredIndustryDtos)
                    industry.IsSelected = true;

                var industryDtos = allIndustryDtos as IList<IndustryDto> ?? allIndustryDtos.ToList();
                var response = industries.Any()
                ? filteredIndustryDtos.Concat(industryDtos).DistinctBy(c => c.Id)
                : industryDtos;

                return Response.AsJson(response);
            };

            Post[industriesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.name.Value == null)
                    throw new LightstoneAutoException("Could not bind 'Name' value");

                publisher.Publish(new CreateIndustry(Guid.NewGuid(), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };

            Put[industriesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    throw new LightstoneAutoException("Could not bind 'id' or 'Name' value");
                    
                publisher.Publish(new RenameIndustry(new Guid(model.id.Value), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}