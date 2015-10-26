using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Api.Domain.Core.Meta;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;
using UserManagement.Api.Routes;

namespace Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUserManagementApiClient userManagementApi, IPackageBuilderApiClient packageBuilderApi)
        {
            Post["/login"] = parameters =>
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"]))
                    return Response.AsJson(new { data = "Service unavailable - Maintenance in progress" }, HttpStatusCode.ServiceUnavailable);

                var username = Context.Request.Headers["Username"].FirstOrDefault();
                var password = Context.Request.Headers["Password"].FirstOrDefault();

                var response = userManagementApi.Post("", "/login/api", null, null, new[]
                {
                    new KeyValuePair<string, string>("Username", username), 
                    new KeyValuePair<string, string>("Password", password)
                });

                return response;
            };

            // Note: Beta functionality - to be finalized
            Post["/login/mobi"] = parameters =>
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"]))
                    return Response.AsJson(new { data = "Service unavailable - Maintenance in progress" }, HttpStatusCode.ServiceUnavailable);

                var username = Context.Request.Headers["Username"].FirstOrDefault();
                var password = Context.Request.Headers["Password"].FirstOrDefault();

                var token = userManagementApi.Post("", "/login/api", null, null, new[]
                {
                    new KeyValuePair<string, string>("Username", username), 
                    new KeyValuePair<string, string>("Password", password)
                });

                var consumerMeta = JsonConvert.DeserializeObject<MetaConsumer>(userManagementApi.Get(token, "/Meta/User/" + username, null, null));

                var packages = JsonConvert.DeserializeObject<IEnumerable<MetaPackage>>(packageBuilderApi.Get(token, "/packages/true", null, null));
                var metaPackages = packages as IList<MetaPackage> ?? packages.ToList();

                var customers = new List<Customer>();
                var clients = new List<Client>();

                foreach (var metaCustomer in consumerMeta.Customers)
                {
                    var contracts = new List<Contract>();
                    foreach (var contract in metaCustomer.Contracts)
                    {
                        var products = new List<Product>();
                        foreach (var metaPackage in metaPackages)
                        {
                            foreach (var package in contract.Packages.Where(package => package.PackageId == metaPackage.PackageId))
                            {
                                var subList = new List<SubMenu>
                                    {
                                        new SubMenu
                                        {
                                            PackageId = package.PackageId,
                                            PackageName = package.PackageName
                                        }
                                    };

                                package.PackageEventType = metaPackage.PackageEventType.ToString();

                                var productIndex = products.FindIndex(x => x.ProductName == package.PackageEventType);

                                if (productIndex < 0)
                                {
                                    products.Add(new Product
                                    {
                                        ProductName = package.PackageEventType,
                                        SubMenus = subList
                                    });

                                    continue;
                                }

                                subList.AddRange(products[productIndex].SubMenus.DistinctBy(x => x.PackageId));
                                products[productIndex].SubMenus = subList;
                            }
                        }

                        contracts.Add(new Contract
                        {
                            ContractId = contract.Id,
                            ContractName = contract.Name,
                            Menu = new Menu
                            {
                                Products = products
                            }
                        });
                    }

                    if (contracts.Count >= 1)
                    customers.Add(new Customer
                    {
                        Id = metaCustomer.Id,
                        Name = metaCustomer.Name,
                        Contracts = contracts
                    });
                }

                foreach (var metaClient in consumerMeta.Clients)
                {
                    var contracts = new List<Contract>();
                    foreach (var contract in metaClient.Contracts)
                    {
                        var products = new List<Product>();
                        foreach (var metaPackage in metaPackages)
                        {
                            foreach (var package in contract.Packages.Where(package => package.PackageId == metaPackage.PackageId))
                            {
                                var subList = new List<SubMenu>
                                    {
                                        new SubMenu
                                        {
                                            PackageId = package.PackageId,
                                            PackageName = package.PackageName
                                        }
                                    };

                                package.PackageEventType = metaPackage.PackageEventType.ToString();

                                var productIndex = products.FindIndex(x => x.ProductName == package.PackageEventType);

                                if (productIndex < 0)
                                {
                                    products.Add(new Product
                                    {
                                        ProductName = package.PackageEventType,
                                        SubMenus = subList
                                    });

                                    continue;
                                }

                                subList.AddRange(products[productIndex].SubMenus);
                                products[productIndex].SubMenus = subList;
                            }
                        }

                        contracts.Add(new Contract
                        {
                            Menu = new Menu
                            {
                                Products = products
                            }
                        });
                    }

                    if (contracts.Count >= 1)
                    clients.Add(new Client
                    {
                        Id = metaClient.Id,
                        Name = metaClient.Name,
                        Contracts = contracts
                    });
                }

                return Response.AsJson( new Consumer
                {
                    UserId = consumerMeta.UserId, 
                    UserName = consumerMeta.UserName, 
                    Token = token,
                    Customers = customers
                });
            };

            Post["/forgotPassword"] = _ =>
            {
                var dto = this.Bind<AuthDto>();
                ViewBag.Message = userManagementApi.Put("", UserManagementApiRoute.User.RequestResetPassword, new[] { new KeyValuePair<string, string>("username", dto.UserName + "") }, null, null);
                return Response.AsText("Password reset mail sent");
            };
        }

        public class AuthDto
        {
            public string UserName { get; set; }
        }
    }
}