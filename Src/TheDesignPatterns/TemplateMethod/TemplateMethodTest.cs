using FluentAssertions;
using System.Text;
using System.Xml.Linq;
using Xunit;

namespace TheDesignPatterns.TemplateMethod
{
    public class TemplateMethodTest
    {
        [Fact]
        public void ShouldCreateXmlDocument()
        {
            var documentBuilder = new StringBuilder();
            Document document = new XmlDocument(documentBuilder);

            var xmlData = document.GenerateDocument();

            xmlData.Should().NotBeNullOrEmpty();
            var xDoc = XDocument.Parse(xmlData);
            xDoc.Should().NotBeNull();
        }


        [Fact]
        public void ShouldCreateJsonDocument()
        {
            var documentBuilder = new StringBuilder();
            Document document = new JsonDocument(documentBuilder);

            var jsonData = document.GenerateDocument();

            jsonData.Should().NotBeNullOrEmpty();
            var jsonDoc= System.Text.Json.JsonDocument.Parse(jsonData);
            jsonDoc.Should().NotBeNull();
        }
    }
}
