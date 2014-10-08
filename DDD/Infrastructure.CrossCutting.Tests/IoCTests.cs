using LightstoneApp.Infrastructure.CrossCutting.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.CrossCutting.Tests
{
    [TestClass]
    public class IoCTests
    {
        public void ShortLivedManager_IsTransient_Test()
        {
            //Arrange
            var actual = IoCFactory.Instance.CurrentContainer.Resolve<ShortLivedObject>();

            //Act
            actual.Dispose();
            var newShortLivedObject = IoCFactory.Instance.CurrentContainer.Resolve<ShortLivedObject>();
            //Assert
            Assert.AreNotEqual(actual, newShortLivedObject);
            Assert.IsFalse(newShortLivedObject.IsDisposed);
        }
    }
}