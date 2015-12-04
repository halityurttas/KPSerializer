using System;
using System.Xml.Serialization;

namespace KPSerializer
{
    [Serializable]
    public class KPModel
    {
        [XmlElement]
        public string Key { get; set; }
        [XmlElement]
        public string Value { get; set; }
    }
}
