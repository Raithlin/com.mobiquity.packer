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
        [TestCase("8 : (1,15.3,€34)")]
        public void Package_WithSingleItem_ReturnsPackage(string input)
        {
            var package = new PackageModel(input);
            Assert.AreEqual(8, package.PackageWeight);
            Assert.AreEqual(1, package.Items.Count);
            Assert.AreEqual(1, package.Items[0].Index);
            Assert.AreEqual(15.3, package.Items[0].Weight);
            Assert.AreEqual(34, package.Items[0].Cost);
        }

        [Test]
        [TestCase("81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)", 81)]
        [TestCase("75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52) (6,76.25,€75) (7,60.02,€74) (8,93.18,€35) (9,89.95,€78)", 75)]
        [TestCase("56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36) (6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)", 56)]
        public void Package_WithMultipleItems_ReturnsPackage(string input, int weight)
        {
            var package = new PackageModel(input);
            var itemCount = input.Count(x => x == '('); // Count the number of packages in the input string
            Assert.AreEqual(weight, package.PackageWeight);
            Assert.AreEqual(itemCount, package.Items.Count);
        }
    }
}
