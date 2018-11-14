using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TestNetCoreSample.Models;

namespace TestNetCoreSample.Classes
{
    public class Utility
    {
        public static PatientViewModel DeserializePatient(string stuXML)
        {
            StringReader stringReader = new StringReader(stuXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PatientViewModel));
            PatientViewModel obj = ((PatientViewModel)(xmlSerializer.Deserialize(xmlReader)));
            stringReader.Close();
            xmlReader.Close();
            return obj;
        }

        public static string SerializePatient(PatientViewModel model)
        {
            StringWriter stringWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PatientViewModel));
            xmlSerializer.Serialize(xmlWriter, model);
            string students = stringWriter.ToString();
            xmlWriter.Close();
            stringWriter.Close();
            return students;
        }

    }
}
