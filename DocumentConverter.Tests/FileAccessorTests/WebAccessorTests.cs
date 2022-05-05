using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Helpers;
using DocumentConverter.Data.Accessors;

namespace DocumentConverter.Tests
{
    [TestClass]
    public class WebAccessorTests
    {
        private WebAccessor? FileAccessor;

        [TestInitialize]
        public void TestInitialize()
        {
            FileAccessor = new WebAccessor();
        }


        [TestMethod]
        public void LoadFileSuccessfully()
        {
            // Prepare
            var source = new UrlLocationDescriptor("https://tools.learningcontainer.com/sample-json.json");
            var expectedResult = new RawDocument(@"{
                ""firstName"": ""Rajesh"",
                ""lastName"": ""Kumar"",
                ""gender"": ""man"",
                ""age"": 24,
                ""address"": {
                            ""streetAddress"": ""126 Udhna"",
                    ""city"": ""Surat"",
                    ""state"": ""GJ"",
                    ""postalCode"": ""394221""
                },
                ""phoneNumbers"": [
                    {
                        ""type"": ""home"", ""number"": ""7383627627"" }
                ]
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