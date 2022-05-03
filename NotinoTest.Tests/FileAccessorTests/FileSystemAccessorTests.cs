using NotinoTest.Business.FileTools;
using NotinoTest.Business.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NotinoTest.Data.Models;
using NotinoTest.Shared.Helpers;

namespace NotinoUnitTests
{
    [TestClass]
    public class FileSystemAccessorTests
    {
        private FileSystemAccessor fileAccessor;

        [TestInitialize]
        public void TestInitialize()
        {
            fileAccessor = new FileSystemAccessor();
        }


        [TestMethod]
        public void LoadFileSuccessfully()
        {
            // Prepare
            var source = new FileLocationDescriptor("./FileAccessorTests/Examples/SimpleExample.json", Constants.FileStorageTypes.File);
            var expectedResult = new RawDocument(@"{
                ""text"": ""testingText"",
                ""title"": ""testDocument"",
                ""randomProperty"": ""random""
            }", ".json");

            //Act
            var result = fileAccessor.LoadFile(source);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(JToken.DeepEquals(JToken.Parse(result.Content), JToken.Parse(expectedResult.Content)), true);
            Assert.AreEqual(result.Format, expectedResult.Format);
        }

        //... check all validations and some edge cases
    }
}