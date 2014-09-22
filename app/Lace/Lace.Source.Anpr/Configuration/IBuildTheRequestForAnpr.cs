using Lace.Source.Anpr.AnprWebService;

namespace Lace.Source.Anpr.Configuration
{
    public interface IBuildTheRequestForAnpr
    {
        AnprSubComplexType AnprRequest { get; }
        IBuildTheRequestForAnpr Build();
    }
}