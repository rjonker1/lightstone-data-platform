using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Extensions
{
    public sealed class ResponseDataDigger
    {
        static ResponseDataDigger()
        {
            
        }

        private ResponseDataDigger()
        {
        }

        public static ResponseDataDigger Dig()
        {
            return new ResponseDataDigger();
        }

        public string ForVin(ICollection<IPointToLaceProvider> response)
        {
            var vinnumber = string.Empty;

            foreach (var provider in VinProviders)
            {
                vinnumber = provider.Value(response);
                if (!string.IsNullOrEmpty(vinnumber))
                    break;
            }

            return vinnumber;
        }

        public int ForCarId(ICollection<IPointToLaceProvider> response)
        {
            var carid = 0;
            foreach (var provider in CarIdProviders)
            {
                carid = provider.Value(response);
                if (carid > 0)
                    break;
            }

            return carid;
        }


        private readonly IDictionary<int, Func<ICollection<IPointToLaceProvider>, string>> VinProviders = new Dictionary
            <int, Func<ICollection<IPointToLaceProvider>, string>>()
        {
            {0, VinFromLighstoneAuto},
            {1, VinFromIvid}
        };

        private readonly IDictionary<int, Func<ICollection<IPointToLaceProvider>, int>> CarIdProviders = new Dictionary
            <int, Func<ICollection<IPointToLaceProvider>, int>>()
        {
            {0, CarIdFromLighstoneAuto}
        };

        private static int GetNumber(int? value)
        {
            return value.HasValue ? value.Value : 0;
        }

        private static readonly Func<ICollection<IPointToLaceProvider>, string> VinFromLighstoneAuto =
            (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
                ? response.OfType<IProvideDataFromLightstoneAuto>().First().Vin
                : string.Empty;

        private static readonly Func<ICollection<IPointToLaceProvider>, string> VinFromIvid =
            (response) => response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
                ? response.OfType<IProvideDataFromIvid>().First().Vin
                : string.Empty;

        private static readonly Func<ICollection<IPointToLaceProvider>, int> CarIdFromLighstoneAuto =
            (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
                ? GetNumber(response.OfType<IProvideDataFromLightstoneAuto>().First().CarId)
                : 0;
    }


    public static class ResponseExtensions
    {
        public static bool Exists<T>(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;

            return response.OfType<T>().Any() && response.OfType<T>().First() != null;
        }
    }
}