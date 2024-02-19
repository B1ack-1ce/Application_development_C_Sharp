using System.Text.Json;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;

namespace HomeWork_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = string.Empty;

            using FileStream stream = new FileStream("Person.json", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(stream))
                json = sr.ReadToEnd();

            Console.WriteLine(json);

            XmlDictionaryReaderQuotas xmlDictionaryReader = new XmlDictionaryReaderQuotas();
            XmlDictionaryReader xmlReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(json), xmlDictionaryReader);

            XDocument xmlDocument = XDocument.Load(xmlReader);

            Console.WriteLine(xmlDocument.ToString());

            using (StreamWriter writer = new StreamWriter(new FileStream("Personn.xml", FileMode.Create, FileAccess.Write)))
            {
                writer.WriteLine(xmlDocument);
            }

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
        
    }
}
