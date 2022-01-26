using NUnit.Framework;

namespace com.mobiquity.packer.test
{
    public class PackageItemTests
    {
        [Test]
        public void PackageItem_EmptyParam_Throws()
        {
            Assert.Throws<APIException>(() => new PackageItemModel(null));
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

    }
}
