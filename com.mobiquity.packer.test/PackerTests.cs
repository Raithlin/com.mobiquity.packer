using NUnit.Framework;

namespace com.mobiquity.packer.test
{
    public class PackerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Pack_EmptyParam_ReturnsEmptyString()
        {
            Assert.AreEqual(string.Empty, Packer.Pack(string.Empty));
        }
        [Test]
        public void Pack_SingleLineWithEnoughSpace_ReturnsId()
        {
            var input = "8 : (1,15.3,€34)";
            var expectedResult = "8";

            Assert.AreEqual(expectedResult, Packer.Pack(input));
        }
    }
}