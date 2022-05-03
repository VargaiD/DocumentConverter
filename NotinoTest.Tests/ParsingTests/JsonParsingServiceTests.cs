using NotinoTest.Business.Documents;
using NotinoTest.Shared.Exceptions;
using NotinoTest.Business.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotinoTest.Data.Models;

namespace NotinoUnitTests
{
    [TestClass]
    public class JsonParsingServiceTests
    {
        private JsonParsingService parsingService;

        [TestInitialize]
        public void TestInitialize()
        {
            parsingService = new JsonParsingService();
        }


        [TestMethod]
        public void ParseJsonDocumentSuccessfully()
        {
            // Prepare
            var sourceDocument = new RawDocument(@"{
            ""text"": ""testingText"",
            ""title"": ""testDocument"",
            ""randomProperty"": ""random""
            }", "json");

            //Act
            var result = parsingService.ParseDocument(sourceDocument);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, "testDocument");
            Assert.AreEqual(result.Text, "testingText");
        }

        [TestMethod]
        [ExpectedException(typeof(NotinoValidationNullException), nameof(RawDocument.Content))]
        public void ParseNullJsonDocumentThrowsException()
        {
            // Prepare

            //Act
            parsingService.ParseDocument(null);

            //Assert in decorator
        }

        //... check all validations and some edge cases
    }
}