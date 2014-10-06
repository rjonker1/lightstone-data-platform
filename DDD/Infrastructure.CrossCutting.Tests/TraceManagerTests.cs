using System;
using LightstoneApp.Infrastructure.CrossCutting.IoC;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.CrossCutting.NetFramework.Tests
{
    [TestClass]
    public class TraceManagerTest
    {
        [TestMethod]
        public void TraceStartLogicalOperation_Invoke_Test()
        {
            //Arrange and Act            
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStartLogicalOperation("Operation Name");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceStartLogicalOperation_Invoke_NullOperationNameThrowNewArgumentNullException()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStartLogicalOperation(null);
        }

        [TestMethod]
        public void TraceStopLogicalOperation_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStopLogicalOperation();
        }

        [TestMethod]
        public void TraceStart_Invoke_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStart();
        }

        [TestMethod]
        public void TraceStop_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceStop();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceInfo_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceInfo(null);
        }

        [TestMethod]
        public void TraceInfo_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceInfo("Message");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceWarning_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceWarning(null);
        }

        [TestMethod]
        public void TraceWarning_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceWarning("Message");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceError_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError(null);
        }

        [TestMethod]
        public void TraceError_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError("Message");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TraceCritical_Invoke_NullMessageThrowNewArgumentNullException_Test()
        {
            //Arrange and act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError(null);
        }

        [TestMethod]
        public void TraceCritical_Invoke_Test()
        {
            //Arrange and Act
            var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
            traceManager.TraceError("Message");
        }
    }
}