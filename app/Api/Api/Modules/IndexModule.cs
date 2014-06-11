using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using DataPlatform.Shared.Public.Entities;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Workflow.BuildingBlocks;

namespace Api.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/license"] = parameters =>
            {
                this.RequiresAuthentication();

                var licRequest = this.Bind<Request>();
                var request = new LicensePlateNumberRequest(licRequest.LicenseNo);
                var entryPoint = new EntryPoint(new Workflow.RabbitMQ.Publisher(new BusFactory().CreateBus("", new WindsorContainer()))); //TODO: Need to build functionality to create a bus and pass in IPublishMessages
                var responses = entryPoint.GetResponsesFromLace(request);

                return Response.AsJson(responses.First().Response);
            };
        }
    }

    public class Request
    {
        public string LicenseNo { get; set; }
        public IPackage Package
        {
            get
            {
                return new Package
                {
                    Name = "License plate lookup package",
                    DataSets =
                        new[]
                        {
                            new DataSet
                            {
                                Name = "License plate lookup DataSet",
                                DataFields = new[]
                                {
                                    new DataField{Name = "License plate number"},
                                }
                            }
                        }
                };
            }
        }
    }

    public class Package : IPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataSet> DataSets { get; set; }
        public IEnumerable<IWorkflow> Workflows { get; set; }
    }

    public class DataSet : IDataSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataField> DataFields { get; set; }
    }

    public class DataField : IDataField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDataSource DataSource { get; set; }
    }
}