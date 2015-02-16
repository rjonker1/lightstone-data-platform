using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Resolution
{
    public class DefaultResolver : IResolver
    {
        private readonly Dictionary<ResolverType, List<Func<object>>> factories = new Dictionary<ResolverType, List<Func<object>>>();

        public DefaultResolver Register<TType>(Func<TType> creation)
        {
            var match = factories.Any(f => f.Key.Type == typeof(TType));

            var resolverType = new ResolverType(typeof(TType));
            if (!match)
                factories.Add(resolverType, new List<Func<object>>());

            Func<object> wrappedCreation = () => creation();
            factories[resolverType].Add(wrappedCreation);

            return this;
        }

        public TType Resolve<TType>() where TType : class
        {
            var resolverType = new ResolverType(typeof(TType));

            if(!factories.ContainsKey(resolverType))
                throw new Exception(string.Format("Could not find {0} in the resolver", typeof(TType)));

            var firstMatch = factories[resolverType].FirstOrDefault();
            return firstMatch as TType;
        }

        public IEnumerable<TType> ResolveAll<TType>() where TType : class
        {
            var resolverType = new ResolverType(typeof(TType));

            if(!factories.ContainsKey(resolverType))
                throw new Exception(string.Format("Could not find {0} in the resolver", typeof(TType)));

            return factories[resolverType].Select(creation => creation() as TType);
        }
    }
}