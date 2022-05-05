using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Helpers;
using DocumentConverter.Data.Accessors;

namespace DocumentConverter.Tests
{
    [TestClass]
    public class FileSystemAccessorTests
    {
        private FileSystemAccessor? FileAccessor;

        [TestInitialize]
        public void TestInitialize()
        {
            FileAccessor = new FileSystemAccessor();
        }


        [TestMethod]
        public void LoadFileSuccessfully()
        {
            // Prepare
            var source = new FileLocationDescriptor("SimpleExample.json");
            var expectedResult = new RawDocument(@"{
                ""text"": ""testingText"",
                ""title"": ""testDocument"",
                ""randomProperty"": ""random""
            }", ".json");

            //Act
            var result = FileAccessor?.LoadFile(source);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(JToken.DeepEquals(JToken.Parse(result.Content), JToken.Parse(expectedResult.Content)), true);
            Assert.AreEqual(result.Format, expectedResult.Format);
        }

        //... check all validations and some edge cases
    }
}