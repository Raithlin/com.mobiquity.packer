using NUnit.Framework;

namespace com.mobiquity.packer.test
{
    public class PackerTest
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
    }
}