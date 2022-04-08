using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMATVRAnalysis;

namespace EMATVRAnalysis.UnitTests
{
    [TestClass]
    public class ImportTests
    {
        [TestMethod]
        public void Test_IsAGreaterThanB_True()
        {
            // Arrange
            var import = new Import();

            // Act
            var result = import.IsAGreaterThanB(2, 1);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}