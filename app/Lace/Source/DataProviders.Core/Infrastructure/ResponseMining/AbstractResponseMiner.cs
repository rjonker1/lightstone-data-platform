namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining
{
    public interface IMineDataProviderResponse
    {
        string MineVin();
        string MineEngineNumber();
        int MineCarId();
    }
    public abstract class AbstractDataProviderResponseMiner : IMineDataProviderResponse
    {
        private readonly IMineDataProviderResponse _nextMiner;
        private readonly string _stringValue;
        private readonly int _intValue;

        protected AbstractDataProviderResponseMiner(string stringValue)
        {
            _stringValue = stringValue;
        }

        protected AbstractDataProviderResponseMiner(int intValue)
        {
            _intValue = intValue;
        }

        protected AbstractDataProviderResponseMiner(IMineDataProviderResponse nextMiner, string value)
            : this(value)
        {
            _nextMiner = nextMiner;
        }

        protected AbstractDataProviderResponseMiner(IMineDataProviderResponse nextMiner, int value)
            : this(value)
        {
            _nextMiner = nextMiner;
        }

        public string MineVin()
        {
            return !string.IsNullOrEmpty(_stringValue) ? _stringValue : _nextMiner != null ? _nextMiner.MineVin() : string.Empty;
        }

        public int MineCarId()
        {
            return _intValue > 0 ? _intValue : _nextMiner != null ? _nextMiner.MineCarId() : 0;
        }
        public string MineEngineNumber()
        {
            return !string.IsNullOrEmpty(_stringValue) ? _stringValue : _nextMiner != null ? _nextMiner.MineEngineNumber() : string.Empty;
        }
    }
}
