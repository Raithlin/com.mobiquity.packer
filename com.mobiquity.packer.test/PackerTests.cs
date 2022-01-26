using NUnit.Framework;
using System;

namespace com.mobiquity.packer.test
{
    public class PackerTests
    {
        string inputPath = string.Empty;
        [SetUp]
        public void Setup()
        {
            inputPath = Environment.CurrentDirectory + @"\..\..\..\TestFiles\example_input";
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Pack_EmptyParam_Throws(string input)
        {
            Assert.Throws<APIException>(() => Packer.Pack(input));
        }
        [Test]
        public void Pack_SingleLineWithEnoughSpace_ReturnsId()
        {
            Assert.AreEqual("", Packer.Pack(inputPath));
        }
    }
}