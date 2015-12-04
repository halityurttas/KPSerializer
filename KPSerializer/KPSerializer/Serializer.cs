using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KPSerializer
{
    public static class Serializer
    {
        public static string Serialize(List<KPModel> model)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<KPModel>));
            StringBuilder tempSB = new StringBuilder();
            StringWriter stringStream = new StringWriter(tempSB);
            serializer.Serialize(stringStream, model);
            return tempSB.ToString();
        }

        public static List<KPModel> Deserialize(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<KPModel>));
            StringReader stringStrem = new StringReader(data);
            return serializer.Deserialize(stringStrem) as List<KPModel>;
        }
    }
}
