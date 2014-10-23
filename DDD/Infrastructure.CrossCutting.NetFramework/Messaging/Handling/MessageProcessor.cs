using System;
using System.Diagnostics;
using System.IO;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Handling
{
    /// <summary>
    ///     Provides basic common processing code for components that handle
    ///     incoming messages from a receiver.
    /// </summary>
    public abstract class MessageProcessor : IProcessor, IDisposable
    {
        private readonly IMessageReceiver _receiver;
        private readonly ITextSerializer _serializer;
        private readonly object _lockObject = new object();
        private bool _disposed;
        private bool _started;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageProcessor" /> class.
        /// </summary>
        protected MessageProcessor(IMessageReceiver receiver, ITextSerializer serializer)
        {
            _receiver = receiver;
            _serializer = serializer;
        }

        /// <summary>
        ///     Starts the listener.
        /// </summary>
        public virtual void Start()
        {
            ThrowIfDisposed();
            lock (_lockObject)
            {
                if (!_started)
                {
                    _receiver.MessageReceived += OnMessageReceived;
                    _receiver.Start();
                    _started = true;
                }
            }
        }

        /// <summary>
        ///     Stops the listener.
        /// </summary>
        public virtual void Stop()
        {
            lock (_lockObject)
            {
                if (_started)
                {
                    _receiver.Stop();
                    _receiver.MessageReceived -= OnMessageReceived;
                    _started = false;
                }
            }
        }

        /// <summary>
        ///     Disposes the resources used by the processor.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void ProcessMessage(object payload, string correlationId);

        /// <summary>
        ///     Disposes the resources used by the processor.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Stop();
                    _disposed = true;

                    using (_receiver as IDisposable)
                    {
                        // Dispose receiver if it's disposable.
                    }
                }
            }
        }

        ~MessageProcessor()
        {
            Dispose(false);
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Trace.WriteLine(new string('-', 100));

            try
            {
                object body = Deserialize(args.Message.Body);

                TracePayload(body);
                Trace.WriteLine("");

                ProcessMessage(body, args.Message.CorrelationId);

                Trace.WriteLine(new string('-', 100));
            }
            catch (Exception e)
            {
                // NOTE: we catch ANY exceptions as this is for local 
                // development/debugging. The Windows Azure implementation 
                // supports retries and dead-lettering, which would 
                // be totally overkill for this alternative debug-only implementation.
                Trace.TraceError("An exception happened while processing message through handler/s:\r\n{0}", e);
                Trace.TraceWarning("Error will be ignored and message receiving will continue.");
            }
        }

        protected object Deserialize(string serializedPayload)
        {
            using (var reader = new StringReader(serializedPayload))
            {
                return _serializer.Deserialize(reader);
            }
        }

        protected string Serialize(object payload)
        {
            using (var writer = new StringWriter())
            {
                _serializer.Serialize(writer, payload);
                return writer.ToString();
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("MessageProcessor");
        }


        [Conditional("TRACE")]
        private void TracePayload(object payload)
        {
            Trace.WriteLine(Serialize(payload));
        }
    }
}
