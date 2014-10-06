using System;
using System.Collections.Generic;
using System.ServiceModel;
using LightstoneApp.Application.MainModule.SalesManagement;
using LightstoneApp.DistributedServices.Core.ErrorHandlers;
using LightstoneApp.DistributedServices.MainModule.DTO;
using LightstoneApp.DistributedServices.MainModule.Resources;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.IoC;
using LightstoneApp.Infrastructure.CrossCutting.Logging;

namespace LightstoneApp.DistributedServices.MainModule
{
    public partial class MainModuleService
    {
        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="orderInformation">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Order> GetOrdersByOrderInformation(OrderInformation orderInformation)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                return salesManagement.FindOrdersByOrderInformation(orderInformation.CustomerId,
                    orderInformation.DateTimeFrom, orderInformation.DateTimeTo);
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="fromDate">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <param name="toDate">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Order> GetOrdersByDates(DateTime? fromDate, DateTime? toDate)
        {
            //Resolve root dependencies and perform operations
            var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

            return salesManagement.FindOrdersByDates(fromDate, toDate);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="pagedCriteria">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Order> GetPagedOrders(PagedCriteria pagedCriteria)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                return salesManagement.FindPagedOrders(pagedCriteria.PageIndex, pagedCriteria.PageCount);
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="shippingData">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Order> GetOrdersByShippingData(ShippingInformation shippingData)
        {
            //Resolve root dependencies and perform operation
            var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

            return salesManagement.FindOrdersByShippingData(shippingData.ShippingName,
                shippingData.ShippingAddress,
                shippingData.ShippingCity,
                shippingData.ShippingZip);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="order">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void ChangeOrder(Order order)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                salesManagement.ChangeOrder(order);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="order">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void AddOrder(Order order)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();
                salesManagement.AddOrder(order);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="product">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void AddProduct(Product product)
        {
            try
            {
                //Resolve root dependencies and perform query
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                salesManagement.AddProduct(product);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="product">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void ChangeProduct(Product product)
        {
            try
            {
                //Resolve root dependencies and perform query
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                salesManagement.ChangeProduct(product);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="publisherInformation">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Product> GetProductByPublisherInformation(PublisherInformation publisherInformation)
        {
            //Resolve root dependencies and perform query
            var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

            return salesManagement.FindProductBySpecification(publisherInformation.PublisherName,
                publisherInformation.Description);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="pagedCriteria">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Product> GetPagedProducts(PagedCriteria pagedCriteria)
        {
            try
            {
                //Resolve root dependencies and perform query
                var salesManagement = IoCFactory.Instance.CurrentContainer.Resolve<ISalesManagementService>();

                return salesManagement.FindPagedProducts(pagedCriteria.PageIndex, pagedCriteria.PageCount);
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
            catch (NullReferenceException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }
    }
}