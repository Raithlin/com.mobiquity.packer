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
            inputPath = Environment.CurrentDirectory + @"\..\..\..\TestFiles\";
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Pack_EmptyParam_Throws(string input)
        {
            Assert.Throws<APIException>(() => Packer.Pack(input));
        }
        [Test]
        public void Pack_EmptyFile_Throws()
        {
            Assert.Throws<APIException>(() => Packer.Pack($"{inputPath}empty_input"));
        }

        [Test]
        public void Pack_FileDoesNotExist_Throws()
        {
            Assert.Throws<APIException>(() => Packer.Pack($"{inputPath}bad_input"));
        }

    }
}