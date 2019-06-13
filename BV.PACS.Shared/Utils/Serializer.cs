using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BV.PACS.Shared.Utils
{
    public class Serializer<T> where T : class
    {
        private readonly XmlSerializer _serializer;
        private readonly XmlSerializerNamespaces _namespace;

        public Serializer()
        {
            _namespace = new XmlSerializerNamespaces();
            _namespace.Add(string.Empty, string.Empty);

            _serializer = new XmlSerializer(typeof(T));
        }

        public string Serialize(T obj)
        {
            using (var stream = new MemoryStream())
            {
                _serializer.Serialize(stream, obj, _namespace);
                stream.Flush();

                stream.Position = 0;
                var sr = new StreamReader(stream);
                var xml = sr.ReadToEnd();
                return xml;
            }
        }

        public T Deserialize(string xml)
        {
            var rdr = new StringReader(xml);
            var obj = (T) _serializer.Deserialize(rdr);
            return obj;
        }

        public T DeserializeFromFile(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var rdr = new StreamReader(fs, new UTF8Encoding());
                var obj = (T) _serializer.Deserialize(rdr);
                return obj;
            }
        }
    }
}