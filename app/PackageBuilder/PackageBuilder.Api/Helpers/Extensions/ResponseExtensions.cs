using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using Shared.BuildingBlocks.Api.ExceptionHandling;

namespace PackageBuilder.Api.Helpers.Extensions
{
    public static class ResponseExtensions
    {
        public static Response AsError(this IResponseFormatter formatter, string message)
        {
            return ErrorResponse.FromException(new LightstoneAutoException(message));
        }

        public static DataProviderResponseState ResponseState(this List<IDataProvider> response)
        {
            if (response == null) return DataProviderResponseState.TechnicalError;

            return response.HasAllRecords()
                ? DataProviderResponseState.Successful
                : response.IsPartial()
                    ? DataProviderResponseState.Partial
                    : response.IsVinShortOnly()
                        ? DataProviderResponseState.VinShort
                        : response.IsTechnicalErrorsOnly() ? DataProviderResponseState.TechnicalError : DataProviderResponseState.NoRecords;
        }

        private static bool HasAllRecords(this List<IDataProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(
                           s => (s.ResponseState == DataProviderResponseState.NoRecords ||
                               s.ResponseState == DataProviderResponseState.TechnicalError || s.ResponseState == DataProviderResponseState.VinShort)) == null;
        }

        private static bool IsTechnicalErrorsOnly(this List<IDataProvider> response)
        {
            if (response == null || !response.Any()) return true;
            return response.FirstOrDefault(s => s.ResponseState == DataProviderResponseState.TechnicalError) != null;
        }

        private static bool IsVinShortOnly(this List<IDataProvider> response)
        {
            if (response == null || !response.Any()) return false;
            return response.FirstOrDefault(s => s.ResponseState == DataProviderResponseState.VinShort) != null;
        }

        private static bool IsPartial(this List<IDataProvider> response)
        {
            if (response == null) return false;
            var partial =
                response.Select(s => s.ResponseState).ToArray();
            return (partial.Contains(DataProviderResponseState.Successful) && partial.Contains(DataProviderResponseState.NoRecords)) ||
                   (partial.Contains(DataProviderResponseState.Successful) && partial.Contains(DataProviderResponseState.TechnicalError));
        }
    }
}