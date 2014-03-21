using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Logging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks.Consumers
{
    public class ConsumerRegistration
    {
        private readonly Dictionary<Type, List<Func<object>>> creationRegistry = 
            new Dictionary<Type, List<Func<object>>>();

        private readonly Dictionary<string, Assembly> assemblyRegistry = new Dictionary<string, Assembly>();

        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public ConsumerRegistration AddConsumer<TConsumer, TMessage>(Func<TConsumer> creation)
            where TMessage : class
            where TConsumer: IConsume<TMessage>
        {
            var messageType = typeof (TMessage);
            var consumerType = typeof (TConsumer);

            AddConsumerCreation<TConsumer, TMessage>(creation, messageType);
            AddAssemblyCreation(consumerType);

            return this;
        }

        private void AddAssemblyCreation(Type consumerType)
        {
            var fullName = consumerType.Assembly.FullName;

            if (!assemblyRegistry.ContainsKey(fullName))
            {
                assemblyRegistry.Add(fullName, consumerType.Assembly);
            }
        }

        private void AddConsumerCreation<TConsumer, TMessage>(Func<TConsumer> creation, Type messageType) where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            if (!creationRegistry.ContainsKey(messageType))
                creationRegistry.Add(messageType, new List<Func<object>>());

            Func<object> wrappedCreation = () => creation();

            creationRegistry[messageType].Add(wrappedCreation);
        }

        public IEnumerable<IConsume<TMessageType>> GetConsumers<TMessageType>() where TMessageType : class
        {
            var messageType = typeof (TMessageType);
            var found = creationRegistry.ContainsKey(messageType);

            if (!found)
            {
                log.DebugFormat("Did not find any consumers for message of type {0}", messageType);
                yield break;
            }

            var creationList = creationRegistry[messageType];
            foreach (var consumerCreation in creationList)
            {
                object blankConsumer = consumerCreation();
                var consumer = blankConsumer as IConsume<TMessageType>;

                if (consumer != null)
                {
                    log.InfoFormat("Found {0} as consumer for message {1}", consumer.GetType(), messageType);
                    yield return consumer;
                }

                string failureMessage =
                    string.Format(
                        "Failed to create consumer for message {0}. The supposed consumer is {1}. Moving to next consumer is available",
                        messageType, blankConsumer.GetType());

                log.ErrorFormat(failureMessage);

                throw new Exception(failureMessage);
            }
        }

        public Assembly[] GetAssemblies()
        {
            return assemblyRegistry.Select(r => r.Value).ToArray();
        }
    }
}