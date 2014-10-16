using System;
using LightstoneApp.Infrastructure.CrossCutting.IoC;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.CrossCutting.NetFramework.Tests
{
    [TestClass]
    public class TraceManagerTest
    {
        public void TraceStartLogicalOperation_Invoke_Test()
        {
            //Arrange and Act            
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStartLogicalOperation("Operation Name");
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceStartLogicalOperation_Invoke_NullOperationNameThrowNewArgumentNullException()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStartLogicalOperation(null);
        }
        public void TraceStopLogicalOperation_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStopLogicalOperation();
        }
        public void TraceStart_Invoke_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStart();
        }
        public void TraceStop_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStop();
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceInfo_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceInfo(null);
        }
        public void TraceInfo_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceInfo("Message");
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceWarning_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceWarning(null);
        }
        public void TraceWarning_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceWarning("Message");
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceError_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError(null);
        }
        public void TraceError_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError("Message");
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceCritical_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError(null);
        }
        public void TraceCritical_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError("Message");
        }
    }
}