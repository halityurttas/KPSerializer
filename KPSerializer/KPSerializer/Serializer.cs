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
        public static string Serialize(Dictionary<string, string> dict)
        {
            List<KPModel> model = dict.Select(p => new KPModel { Key = p.Key, Value = p.Value }).ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(List<KPModel>));
            StringBuilder tempSB = new StringBuilder();
            StringWriter stringStream = new StringWriter(tempSB);
            serializer.Serialize(stringStream, model);
            return tempSB.ToString();
        }

        public static Dictionary<string, string> Deserialize(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<KPModel>));
            StringReader stringStrem = new StringReader(data);
            List<KPModel> model = serializer.Deserialize(stringStrem) as List<KPModel>;
            Dictionary<string, string> result = new Dictionary<string,string>();
            model.ForEach(a => { result.Add(a.Key, a.Value); });
            return result;
        }
    }
}
