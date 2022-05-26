using ChoETL;
using Converter.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Converter.IO.Exporters
{
    public class ExportCsvToXml : IExportData<StreamReader>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ExportCsvToXml()
        {
            Name = "ExportToXml";
            Description = "Method to export into XML files.";
        }

        public bool Execute(StreamReader source, string destination)
        {

            try
            {
                using (var ReadCsv = ExportHelper.GetReadCsv(source))
                {
                    using (var WriteXml = new ChoXmlWriter(destination)
                                            .Configure(c => c.UseXmlSerialization = true)
                                            .Configure(c => c.RootName = "Root")
                                            .Configure(c => c.NodeName = "Items"))
                    {
                        WriteXml.Write(ReadCsv);
                    }
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
