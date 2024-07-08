using Soneta.Business;
using Soneta.Business.App;
using System.Xml;

public class TestContext : Context
{
    public TestContext(Session session) : base(CreateXmlReader(), session) { }

    private static XmlReader CreateXmlReader()
    {
        using (var stringReader = new System.IO.StringReader("<Context></Context>"))
        {
            return XmlReader.Create(stringReader);
        }
    }
}
