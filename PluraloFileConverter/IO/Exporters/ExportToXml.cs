using Converter.Entities;
using Converter.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Converter.IO.Exporters
{
    public class ExportToXml : IExportData<Person>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ExportToXml()
        {
            Name = "ExportToXml";
            Description = "Method to export into XML files.";
        }

        public bool Execute(IEnumerable<Person> entityList, string path)
        {
            try
            {
                System.Console.WriteLine("Exporting to XML...");

                using (TextWriter writer = new StreamWriter(path))
                {
                    var xml = new XmlSerializer(typeof(List<Person>));
                    xml.Serialize(writer, entityList);
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }

            System.Console.WriteLine("The file has been converted.");
            return true;
        }
    }
}
