using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Extensions
{
    public static class ResponseExtensions
    {
        public static bool Exists<T>(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;

            return response.OfType<T>().Any() && response.OfType<T>().First() != null;
        }

        public static bool HasRecords<T>(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;
            return response.OfType<T>().Any() && response.OfType<T>().First() != null &&
                   response.OfType<T>().OfType<IProvideResponseState>().First().ResponseState != DataProviderResponseState.NoRecords;
        }


        public static bool HasAllRecords(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(
                           s => s.Handled && (s.ResponseState == DataProviderResponseState.NoRecords || 
                               s.ResponseState == DataProviderResponseState.TechnicalError || s.ResponseState == DataProviderResponseState.VinShort)) == null;
        }

        public static DataProviderResponseState State(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return DataProviderResponseState.TechnicalError;

            return response.HasAllRecords()
                ? DataProviderResponseState.Successful
                : response.HasVinShort()
                    ? DataProviderResponseState.VinShort
                    : response.IsPartial()
                        ? DataProviderResponseState.Partial
                        : response.IsTechnicalErrorsOnly() ? DataProviderResponseState.TechnicalError : DataProviderResponseState.NoRecords;
        }

        public static bool IsTechnicalErrorsOnly(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null || !response.Any()) return true;
            return response.FirstOrDefault(s => s.Handled && s.ResponseState == DataProviderResponseState.TechnicalError) != null;
        }

        public static bool HasVinShort(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(s => s.Handled && s.ResponseState == DataProviderResponseState.VinShort) != null;
        }
        
        public static bool IsPartial(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;
            var partial =
                response.Where(w => w.Handled)
                    .Select(s => s.ResponseState).ToArray();
            return (partial.Contains(DataProviderResponseState.Successful) && partial.Contains(DataProviderResponseState.NoRecords)) ||
                   (partial.Contains(DataProviderResponseState.Successful) && partial.Contains(DataProviderResponseState.TechnicalError));
        }

        public static bool HasPartial(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(s => s.Handled && s.ResponseState == DataProviderResponseState.Partial) != null;
        }

        public static bool IsAbandoned(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(s => s.Handled && s.ResponseState == DataProviderResponseState.Abandoned) != null;
        }
    }
}