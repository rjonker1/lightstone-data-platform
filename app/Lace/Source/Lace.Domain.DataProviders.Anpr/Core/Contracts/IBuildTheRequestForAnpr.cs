using Lace.Domain.DataProviders.Anpr.AnprServiceReference;

namespace Lace.Domain.DataProviders.Anpr.Core.Contracts
{
    public interface IBuildTheRequestForAnpr
    {
        AnprSubComplexType AnprRequest { get; }
        IBuildTheRequestForAnpr Build();
    }
}