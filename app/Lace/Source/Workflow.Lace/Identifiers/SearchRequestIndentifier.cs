﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Workflow.Lace.Identifiers
{
    [DataContract]
    public class SearchRequestIndentifier
    {

        private SearchRequestIndentifier(int dataProvider, string package, long packageVersion)
        {
            NumberOfDataProviders = dataProvider;
            PackageName = package;
            PackageVersion = packageVersion;
        }

        public static SearchRequestIndentifier Determine(ICollection<IPointToLaceRequest> request)
        {
            return new SearchRequestIndentifier(request.First().Package.DataProviders.Count(), request.First().Package.Name,
                request.First().Package.Version);
        }


        [DataMember]
        public int NumberOfDataProviders { get; private set; }

        [DataMember]
        public string PackageName { get; private set; }

        [DataMember]
        public long PackageVersion { get; private set; }



        private static SearchType _searchType = SearchType.Undefined;

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Type { get; private set; }

        [DataMember]
        public string SearchTerm { get; private set; }

        private SearchRequestIndentifier(int id, string type, string searchTerm)
        {
            Id = id;
            Type = type;
            SearchTerm = searchTerm;
        }

        public SearchRequestIndentifier()
        {

        }
        //TODO: Need to redefine based on package requesets
        private static bool IsLicenseRequest(IPointToLaceRequest request)
        {
            if (request == null)
                return false;

            return true; // !string.IsNullOrEmpty(request.Vehicle.LicenceNo);
            //return !string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof (IAmLicenseNumberRequestField)));
        }

        private static bool IsVinRequest(IPointToLaceRequest request)
        {
            if (request == null)
                return false;

            return false; // !string.IsNullOrEmpty(request.Vehicle.Vin);
            //return !string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof(IAmVinNumberRequest)));
        }

        private static bool IsRegRequest(IPointToLaceRequest request)
        {
            if (request == null)
                return false;

            return false; // !string.IsNullOrEmpty(request.Vehicle.RegisterNo);
            //return string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof(IAmRegisterNumberRequestField)));
        }

        public static SearchRequestIndentifier GetSearchRequest(ICollection<IPointToLaceRequest> request)
        {
            DetermineRequestSearchType(request);
            return new SearchRequestIndentifier((int)_searchType, _searchType.ToString(), string.Empty); // GetSerchTerm(request));
        }

        private static void DetermineRequestSearchType(ICollection<IPointToLaceRequest> request)
        {
            _searchType = SearchType.LicenseSearch;
            //if (!IsVehicleRequestType(request))
            //    return;

            //_searchType = IsVinRequest(request.OfType<IPointToLaceRequest>().First())
            //    ? SearchType.VinSearch
            //    : IsLicenseRequest(request.OfType<IPointToLaceRequest>().First())
            //        ? SearchType.LicenseSearch
            //        : IsRegRequest(request.OfType<IPointToLaceRequest>().First())
            //            ? SearchType.RegSearch
            //            : SearchType.Undefined;

        }

        //private static string GetSerchTerm(IEnumerable<IPointToLaceRequest> request)
        //{
        //    switch (_searchType)
        //    {
        //        case SearchType.LicenseSearch:
        //            return request.OfType<IPointToLaceRequest>().First().Vehicle.LicenceNo;
        //        case SearchType.RegSearch:
        //            return request.OfType<IPointToLaceRequest>().First().Vehicle.RegisterNo;
        //        case SearchType.VinSearch:
        //            return request.OfType<IPointToLaceRequest>().First().Vehicle.Vin;
        //        default:
        //            return "not available";
        //    }
        //}

        //private static bool IsVehicleRequestType(ICollection<IPointToLaceRequest> request)
        //{
        //    try
        //    {
        //        return request.OfType<IPointToVehicleRequest>().First() != null &&
        //           request.OfType<IPointToVehicleRequest>().First().Vehicle != null;
        //    }
        //    catch
        //    {

        //    }
        //    return false;
        //}
    }
}
