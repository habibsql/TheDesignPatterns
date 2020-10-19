using System.IO;

namespace TheDesignPatterns.Decorator
{
    /// <summary>
    /// Source class interface
    /// </summary>
    public interface IWriter
    {
        void Write(string data);
    }

    /// <summary>
    /// Source class which functionality need to extend using Decorators.
    /// </summary>
    public class TextWriter : IWriter
    {
        private FileInfo fileInfo = new FileInfo("ReportFile.txt");

        public void Write(string data)
        {
            byte[] dataBytes = System.Text.UTF8Encoding.UTF8.GetBytes(data);

            using (FileStream fileStream = fileInfo.OpenWrite())
            {
                fileStream.Write(dataBytes);
            }
        }
    }

    /// <summary>
    /// Abstract Decorator class
    /// </summary>
    public abstract class WriterDecorator : IWriter
    {
        protected readonly IWriter Writer;
        protected readonly Transformer Transformer = new Transformer();

        public WriterDecorator(IWriter writer)
        {
            this.Writer = writer;
        }

        public void Write(string data)
        {
            Writer.Write(data);
        }
    }

    /// <summary>
    /// Concreate Decorator class which extend functionality of original/source class
    /// </summary>
    public class JsonWriterDecorator : WriterDecorator
    {
        public JsonWriterDecorator(IWriter writer) : base(writer)
        {
        }

        /// <summary>
        /// Extended feature
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteToJson(string data)
        {
            string json = Transformer.TrasnformJson(data);

            Writer.Write(json);

            return true;
        }
    }


    /// <summary>
    /// Concreat Decorator class which extend functionality of original/source class
    /// </summary>
    public class XmlWriterDecorator : WriterDecorator
    {
        public XmlWriterDecorator(IWriter writer) : base(writer)
        {
        }

        /// <summary>
        /// Extended feature
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteToXml(string data)
        {
            string xml = Transformer.TrasnformXml(data);
            Writer.Write(xml);

            return true;
        }
    }

    /// <summary>
    /// Helper class
    /// </summary>
    public class Transformer
    {
        public static string TrasnformXml(string data)
        {
            return $"<root><message>{data}</message></root>";
        }

        public static string TrasnformJson(string data)
        {
            return $@"{"message"}: ""{data}""";
        }
    }
}
