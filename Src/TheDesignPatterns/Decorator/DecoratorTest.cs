using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.Decorator
{
    public class DecoratorTest
    {
        [Fact]
        public void ShouldWriteToJsonUsingDecorator()
        {
            string data = "Good Morning";
            IWriter writer = new TextWriter();
            var jsonWriter = new JsonWriterDecorator(writer);

            bool succeed = jsonWriter.WriteToJson(data);

            succeed.Should().BeTrue();
        }

        [Fact]
        public void ShouldWriteToXmlUsingDecorator()
        {
            string data = "Good Morning";
            IWriter writer = new TextWriter();
            var jsonWriter = new XmlWriterDecorator(writer);

            bool succeed = jsonWriter.WriteToXml(data);

            succeed.Should().BeTrue();
        }
    }
}
