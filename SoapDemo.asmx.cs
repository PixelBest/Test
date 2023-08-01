using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace Test
{
    /// <summary>
    /// Сводное описание для SoapDemo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapDemo : System.Web.Services.WebService
    {

        [WebMethod]
        public async Task<string> HelloWorld(byte[] bytes)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream(@"C:\Users\Nikita\Desktop\ApiTest-master\test1.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bytes);
            }

            return "bytes";
        }
    }
}
