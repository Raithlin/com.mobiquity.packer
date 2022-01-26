using NUnit.Framework;

namespace com.mobiquity.packer.test
{
    public class PackageItemTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PackageItem_EmptyParam_Throws(string input)
        {
            Assert.Throws<APIException>(() => new PackageItemModel(input));
        }

        [Test]
        public void PackageItem_ReturnsPackage()
        {
            var input = "(1,15.3,€34)";
            var package = new PackageItemModel(input);
            Assert.AreEqual(1, package.Index);
            Assert.AreEqual(15.3, package.Weight);
            Assert.AreEqual(34, package.Cost);
        }
        [Test]
        [TestCase("(B,15.3,€34)")]
        [TestCase("(1,15%3,€34)")]
        [TestCase("(1,15.3,$€34)")]
        [TestCase("(1,15.3,$)")]
        [TestCase("(1,15.3)")]
        [TestCase("(1,15.3,€34,24)")]
        public void PackageItem_BadParam_Throws(string input)
        {
            Assert.Throws<APIException>(() => new PackageItemModel(input));
        }
    }
}
