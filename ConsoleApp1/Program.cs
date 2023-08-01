using System.Net;
using System.Xml;

internal class Program
{
    public static void Execute()
    {
        HttpWebRequest request = CreateWebRequest();
        XmlDocument soapEnvelopeXml = new XmlDocument();
        soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <HelloWorld xmlns=""http://tempuri.org/"">
                      <bytes>base64Binary</bytes>
                    </HelloWorld>
                  </soap:Body>
                </soap:Envelope>");

        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }

        using (WebResponse response = request.GetResponse())
        {
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                Console.WriteLine(soapResult);
            }
        }
    }
    /// <summary>
    /// Create a soap webrequest to [Url]
    /// </summary>
    /// <returns></returns>
    public static HttpWebRequest CreateWebRequest()
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:64750/SoapDemo.asmx");
        webRequest.Headers.Add(@"SOAP:Action");
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    static void Main(string[] args)
    {
        Execute();
        Console.ReadLine();
    }

}