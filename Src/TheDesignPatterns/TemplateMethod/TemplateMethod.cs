using System.Text;

namespace TheDesignPatterns.TemplateMethod
{
    public abstract class Document
    {
        protected StringBuilder Docuemnt;

        public Document(StringBuilder docuemnt)
        {
            this.Docuemnt = docuemnt;
        }

        public string GenerateDocument()
        {
            CreateHeaderSection();
            CreateBodySection();
            CreateFooterSection();

            return Docuemnt.ToString();
        }    

        protected abstract void CreateHeaderSection();

        protected abstract void CreateBodySection();


        protected abstract void CreateFooterSection();

    }

    public class XmlDocument : Document
    {
        public XmlDocument(StringBuilder docuemnt) : base(docuemnt)
        {
        }

        protected override void CreateBodySection()
        {
            Docuemnt.Append($"<body>This is Document Body.</body>");
        }

        protected override void CreateFooterSection()
        {
            Docuemnt.Append($"<footer>This is Document Footer.</footer></root>");
        }

        protected override void CreateHeaderSection()
        {
            Docuemnt.Append($"<root><header>This is Document Header.</header>");
        }
    }

    public class JsonDocument : Document
    {
        public JsonDocument(StringBuilder docuemnt) : base(docuemnt)
        {
        }

        protected override void CreateBodySection()
        {
            Docuemnt.Append(@"""body"":""This is Document Body."",");
        }

        protected override void CreateFooterSection()
        {
            Docuemnt.Append(@"""footer"": ""This is Document Footer.""}");
        }

        protected override void CreateHeaderSection()
        {
            Docuemnt.Append(@"{""header"": ""This is Document Header."",");
        }
    }
}
