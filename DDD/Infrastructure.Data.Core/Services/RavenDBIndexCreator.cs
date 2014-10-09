using System.Reflection;
using Raven.Client;
using Raven.Client.Indexes;
using Topics.Radical.Bootstrapper;

namespace WebApi.Data.Services
{
    internal class RavenDBIndexCreator : IRequireToStart
    {
        private readonly IDocumentStore store;

        public RavenDBIndexCreator(IDocumentStore store)
        {
            this.store = store;
        }

        public void Start()
        {
            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), store);
        }
    }
}