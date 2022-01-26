using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer.test
{
    public class PackageTests
    {
        [Test]
        public void Package_Constructor_WithEmptyParams_Throws()
        {
            Assert.Throws<APIException>(() => new PackageModel(null));
        }

        [Test]
        public void Package_Constructor_ReturnsPackage()
        {
            var input = "8 : (1,15.3,€34)";
            var package = new PackageModel(input);
            Assert.AreEqual(8, package.PackageWeight);
            Assert.AreEqual(1, package.Items.Count);
            Assert.AreEqual(1, package.Items[0].Index);
            Assert.AreEqual(15.3, package.Items[0].Weight);
            Assert.AreEqual(34, package.Items[0].Cost);
        }
    }
}
