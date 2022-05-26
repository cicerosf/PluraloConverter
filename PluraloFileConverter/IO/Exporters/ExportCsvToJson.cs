using ChoETL;
using Converter.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Converter.IO.Exporters
{
    public class ExportCsvToJson : IExportData<StreamReader>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ExportCsvToJson()
        {
            Name = "ExportToJson";
            Description = "Method to export into Json files.";
        }

        public bool Execute(StreamReader source, string destination)
        {
            try
            {
                using (var ReadCsv = ExportHelper.GetReadCsv(source))
                {
                    using (var WriteJson = new ChoJSONWriter(destination)
                                            .Configure(c => c.DefaultArrayHandling = true))
                    {
                        WriteJson.Write(ReadCsv);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
