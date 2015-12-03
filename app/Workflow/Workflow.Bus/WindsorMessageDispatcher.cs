using System;
using System.Threading.Tasks;
using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Messaging;
using EasyNetQ.AutoSubscribe;

namespace Workflow.Bus
{
    public class WindsorMessageDispatcher : IAutoSubscriberMessageDispatcher
    {
        private readonly IWindsorContainer _container;
        private static readonly ILog Log = LogManager.GetLogger<WindsorMessageDispatcher>();

        public WindsorMessageDispatcher(IWindsorContainer container)
        {
            _container = container;
        }

        public void Dispatch<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            var consumer = _container.Resolve<IConsume<TMessage>>();
            try
            {
                consumer.Consume(message);
            }
            catch (Exception e)
            {
                HandleException(message, e);
                throw;
            }
            finally
            {
                _container.Release(consumer);
            }
        }

        public Task DispatchAsync<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>
        {
            var consumer = _container.Resolve<TConsumer>();
            return consumer.Consume(message).ContinueWith(t => _container.Release(consumer));
        }

        public void Dispatch<TMessage>(TMessage message)
        {
            var consumerType = typeof(IHandleMessages<>).MakeGenericType(message.GetType());
            var consumer = _container.Resolve(consumerType) as IHandleMessages;

            try
            {
                consumer.Handle(message);
            }
            catch (Exception e)
            {
                HandleException(message, e);
                throw;
            }
            finally
            {
                _container.Release(consumer);
            }
        }

        private void HandleException<TMessage>(TMessage message, Exception exception)
        {
            var exceptionMessage = string.Format("Failure during the processing of message '{0}'. Reason: {1}", message.GetType(), new ExceptionPrettyPrinter().Print(exception));

            Log.ErrorFormat(exceptionMessage);
            //var consumers = _container.ResolveAll<IConsumeMessages<FailMessage>>();

            try
            {
                //foreach (var consumer in consumers)
                //    consumer.Consume(new FailWorkflowTaskMessage());
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Failed to send failure message. Failure was {0}", new ExceptionPrettyPrinter().Print(e));
            }
            finally
            {
                //foreach (var consumer in consumers)
                //    _container.Release(consumer);
            }
        }
    }
}