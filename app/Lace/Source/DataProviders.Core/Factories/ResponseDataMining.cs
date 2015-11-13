using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;

namespace Lace.Domain.DataProviders.Core.Factories
{
    public sealed class ResponseDataMiningFactory : AbstractResponseFactory<ICollection<IPointToLaceProvider>>
    {
        public override int MineCarId(ICollection<IPointToLaceProvider> response)
        {
            var carid = 0;
            foreach (var provider in CarIdDataProviders.OrderBy(o => (int) o.Key))
            {
                carid = provider.Value(response);
                if (carid > 0)
                    break;
            }

            return carid;
        }

        public override string MineVinNumber(ICollection<IPointToLaceProvider> response)
        {
            var vinnumber = string.Empty;

            foreach (var provider in VinNumberDataProviders.OrderBy(o => (int) o.Key))
            {
                vinnumber = provider.Value(response);
                if (!string.IsNullOrEmpty(vinnumber))
                    break;
            }

            return vinnumber;
        }

        public override string MineEngineNumber(ICollection<IPointToLaceProvider> response)
        {
            var engineNumber = response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
                ? response.OfType<IProvideDataFromIvid>().First().Engine
                : string.Empty;
            return engineNumber;
        }

        private static int GetNumber(int? value)
        {
            return value ?? 0;
        }

        private static readonly IDictionary<Order, Func<ICollection<IPointToLaceProvider>, string>> VinNumberDataProviders = new Dictionary
            <Order, Func<ICollection<IPointToLaceProvider>, string>>()
        {
            {
                Order.First,
                (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
                    ? response.OfType<IProvideDataFromLightstoneAuto>().First().Vin
                    : string.Empty
            },
            {
                Order.Second, (response) => response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
                    ? response.OfType<IProvideDataFromIvid>().First().Vin
                    : string.Empty
            },
            {
                Order.Third, (response) => response.Exists<IProvideDataFromRgtVin>() && response.OfType<IProvideDataFromRgtVin>().First().Handled
                    ? response.OfType<IProvideDataFromRgtVin>().First().Vin
                    : string.Empty
            }
        };

        private static readonly IDictionary<Order, Func<ICollection<IPointToLaceProvider>, int>> CarIdDataProviders = new Dictionary
            <Order, Func<ICollection<IPointToLaceProvider>, int>>()
        {
            {
                Order.First,
                (response) => response.Exists<IProvideDataFromLightstoneAuto>() && response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
                    ? GetNumber(response.OfType<IProvideDataFromLightstoneAuto>().First().CarId)
                    : 0
            },
            {
                Order.Second,
                (response) =>
                    response.Exists<IProvideDataFromRgtVin>() && response.OfType<IProvideDataFromRgtVin>().First().Handled
                        ? GetNumber(response.OfType<IProvideDataFromRgtVin>().First().CarId)
                        : 0
            }
        };
    }

    public abstract class AbstractResponseFactory<T> : IMineResponseData<T>
    {
        public abstract string MineVinNumber(T response);
        public abstract string MineEngineNumber(T response);
        public abstract int MineCarId(T response);

        public string MineVinNumber(object response)
        {
            return MineVinNumber((T)response);
        }

        public int MineCarId(object response)
        {
            return MineCarId((T) response);
        }

        public string MineEngineNumber(object response)
        {
            return MineEngineNumber((T)response);
        }
    }

    public interface IMineResponseData
    {
        string MineVinNumber(object response);
        string MineEngineNumber(object response);
        int MineCarId(object response);
    }

    public interface IMineResponseData<in T> : IMineResponseData
    {
        string MineVinNumber(T response);
        string MineEngineNumber(T response);
        int MineCarId(T response);
    }

    public enum Order
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4
    }
}
