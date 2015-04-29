using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class SearchRequestIndentifier
    {
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

        private static bool IsLicenseRequest(IPointToVehicleRequest request)
        {
            if (request == null)
                return false;

            return !string.IsNullOrEmpty(request.Vehicle.LicenceNo);
            //return !string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof (IAmLicenseNumberRequestField)));
        }

        private static bool IsVinRequest(IPointToVehicleRequest request)
        {
            if (request == null)
                return false;

            return !string.IsNullOrEmpty(request.Vehicle.Vin);
            //return !string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof(IAmVinNumberRequest)));
        }

        private static bool IsRegRequest(IPointToVehicleRequest request)
        {
            if (request == null)
                return false;

            return !string.IsNullOrEmpty(request.Vehicle.RegisterNo);
            //return string.IsNullOrEmpty(request.Vehicle.RequestField.Field) &&
            //       (request.Vehicle.RequestField.GetType().IsInstanceOfType(typeof(IAmRegisterNumberRequestField)));
        }

        public static SearchRequestIndentifier GetSearchRequest(ICollection<IPointToLaceRequest> request)
        {
            DetermineRequestSearchType(request);
            return new SearchRequestIndentifier((int) _searchType, _searchType.ToString(), GetSerchTerm(request));
        }

        private static void DetermineRequestSearchType(ICollection<IPointToLaceRequest> request)
        {
            if (!IsVehicleRequestType(request))
                return;

            _searchType = IsVinRequest(request.OfType<IPointToVehicleRequest>().First())
                ? SearchType.VinSearch
                : IsLicenseRequest(request.OfType<IPointToVehicleRequest>().First())
                    ? SearchType.LicenseSearch
                    : IsRegRequest(request.OfType<IPointToVehicleRequest>().First())
                        ? SearchType.RegSearch
                        : SearchType.Undefined;

        }

        private static string GetSerchTerm(IEnumerable<IPointToLaceRequest> request)
        {
            switch (_searchType)
            {
                case SearchType.LicenseSearch:
                    return request.OfType<IPointToVehicleRequest>().First().Vehicle.LicenceNo;
                case SearchType.RegSearch:
                    return request.OfType<IPointToVehicleRequest>().First().Vehicle.RegisterNo;
                case SearchType.VinSearch:
                    return request.OfType<IPointToVehicleRequest>().First().Vehicle.Vin;
                default:
                    return "not available";
            }
        }

        private static bool IsVehicleRequestType(ICollection<IPointToLaceRequest> request)
        {
            try
            {
                return request.OfType<IPointToVehicleRequest>().First() != null &&
                   request.OfType<IPointToVehicleRequest>().First().Vehicle != null;
            }
            catch
            {
               
            }
            return false;
        }
    }
}
