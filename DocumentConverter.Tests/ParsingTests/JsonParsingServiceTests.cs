using DocumentConverter.Shared.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentConverter.Data.Models;
using DocumentConverter.Business.Services;

namespace DocumentConverter.Tests
{
    [TestClass]
    public class JsonParsingServiceTests
    {
        private JsonParsingService? ParsingService;

        [TestInitialize]
        public void TestInitialize()
        {
            ParsingService = new JsonParsingService();
        }


        [TestMethod]
        public void ParseJsonDocumentSuccessfully()
        {
            // Prepare
            var sourceDocument = new RawDocumentModel(@"{
            ""text"": ""testingText"",
            ""title"": ""testDocument"",
            ""randomProperty"": ""random""
            }", ".json");

            //Act
            var result = ParsingService?.ParseDocument(sourceDocument);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, "testDocument");
            Assert.AreEqual(result.Text, "testingText");
        }

        [TestMethod]
        [ExpectedException(typeof(DocumentConverterValidationNullException), nameof(RawDocument.Content))]
        public void ParseNullJsonDocumentThrowsException()
        {
            // Prepare

            //Act
            ParsingService?.ParseDocument(null);

            //Assert in decorator
        }

        //... check all validations and some edge cases
    }
}