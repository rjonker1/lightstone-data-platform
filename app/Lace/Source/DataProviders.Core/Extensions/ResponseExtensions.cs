using System.Collections.Generic;
using System.Linq;
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
    }

    //public sealed class ResponseDataMiner
    //{
    //    static ResponseDataMiner()
    //    {

    //    }

    //    private ResponseDataMiner()
    //    {
    //    }

    //    public static ResponseDataMiner Mine()
    //    {
    //        return new ResponseDataMiner();
    //    }

    //    public string ForVin(ICollection<IPointToLaceProvider> response)
    //    {
    //        var vinnumber = string.Empty;

    //        foreach (var provider in _vinProviders)
    //        {
    //            vinnumber = provider.Value(response);
    //            if (!string.IsNullOrEmpty(vinnumber))
    //                break;
    //        }

    //        return vinnumber;
    //    }

    //    public int ForCarId(ICollection<IPointToLaceProvider> response)
    //    {
    //        var carid = 0;
    //        foreach (var provider in _carIdProviders)
    //        {
    //            carid = provider.Value(response);
    //            if (carid > 0)
    //                break;
    //        }

    //        return carid;
    //    }


    //    //private readonly IDictionary<int, Func<ICollection<IPointToLaceProvider>, string>> _vinProviders = new Dictionary
    //    //    <int, Func<ICollection<IPointToLaceProvider>, string>>()
    //    //{
    //    //    {0, VinFromLighstoneAuto},
    //    //    {1, VinFromIvid},
    //    //    {2, VinFromRgtVin}
    //    //};

    //    //private readonly IDictionary<int, Func<ICollection<IPointToLaceProvider>, int>> _carIdProviders = new Dictionary
    //    //    <int, Func<ICollection<IPointToLaceProvider>, int>>()
    //    //{
    //    //    {0, CarIdFromLighstoneAuto},
    //    //    {1, CarIdFromRgtVin}
    //    //};

    //    //private static int GetNumber(int? value)
    //    //{
    //    //    return value.HasValue ? value.Value : 0;
    //    //}

    //    //private static readonly Func<ICollection<IPointToLaceProvider>, string> VinFromLighstoneAuto =
    //    //    (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
    //    //        ? response.OfType<IProvideDataFromLightstoneAuto>().First().Vin
    //    //        : string.Empty;

    //    //private static readonly Func<ICollection<IPointToLaceProvider>, string> VinFromIvid =
    //    //    (response) => response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
    //    //        ? response.OfType<IProvideDataFromIvid>().First().Vin
    //    //        : string.Empty;

    //    //private static readonly Func<ICollection<IPointToLaceProvider>, string> VinFromRgtVin =
    //    //    (response) => response.Exists<IProvideDataFromRgtVin>() && response.OfType<IProvideDataFromRgtVin>().First().Handled
    //    //        ? response.OfType<IProvideDataFromRgtVin>().First().Vin
    //    //        : string.Empty;

    //    //private static readonly Func<ICollection<IPointToLaceProvider>, int> CarIdFromLighstoneAuto =
    //    //    (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
    //    //        ? GetNumber(response.OfType<IProvideDataFromLightstoneAuto>().First().CarId)
    //    //        : 0;

    //    //private static readonly Func<ICollection<IPointToLaceProvider>, int> CarIdFromRgtVin =
    //    //    (response) => response.Exists<IProvideDataFromRgtVin>() && response.OfType<IProvideDataFromRgtVin>().First().Handled && response.OfType<IProvideDataFromRgtVin>().First().RgtCode.HasValue
    //    //        ? GetNumber(response.OfType<IProvideDataFromRgtVin>().First().RgtCode)
    //    //        : 0;
    //}



}