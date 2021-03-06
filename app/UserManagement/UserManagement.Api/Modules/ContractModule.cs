﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using MemBus;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Enums;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class ContractModule : SecureModule
    {
        private static int _defaultJsonMaxLength;

        public ContractModule(IBus bus, IContractRepository contracts, IContractBundleRepository contractBundles)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/Contracts"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var dto =
                    (IEnumerable<ContractDto>) Mapper.Map<IEnumerable<Contract>, IEnumerable<ContractDto>>(contracts);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.Where(x => x.IsActive).ToList() });
            };

            Get["/Contracts/Add"] = parameters =>
            {
                return View["Save", new ContractDto
                {
                    CommencementDate = DateTime.Today, 
                    OnlineAcceptance = DateTime.Today,
                    ContractBundleList = contractBundles.OrderBy(x => x.TransactionLimit)
                }];
            };

            Post["/Contracts"] = _ =>
            {
                var dto = this.BindAndValidate<ContractDto>();
                dto.CreatedBy = Context.CurrentUser.UserName;
                dto.IsActive = true;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, contracts.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Contracts/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Contract, ContractDto>(contracts.Get(guid));
                dto.ContractBundleList = contractBundles.OrderBy(x => x.TransactionLimit);

                return View["Save", dto];
            };

            Get["/Contracts/Details/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Contract, ContractDto>(contracts.Get(guid));

                return Response.AsJson(dto);
            };
            
            Put["/Contracts/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<ContractDto>();
                dto.ModifiedBy = Context.CurrentUser.UserName;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, contracts.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            //Post["/Contracts/GetPackage"] = _ =>
            //{
            //    var dto = this.Bind<ContractPackageRequestDto>();
            //    if (dto == null)
            //        return Response.AsJson(new { });

            //    var handler = new GetContractPackageHandler(contracts);
            //    handler.Handle(new GetPackageOnContract(dto.ContractId));

            //    return Response.AsJson(handler.Response);
            //};

            Delete["/Contracts/{id}"] = _ =>
            {
                this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

                var dto = this.Bind<ContractDto>();
                var entity = contracts.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Contract has been soft deleted");
            };
        }
    }
}