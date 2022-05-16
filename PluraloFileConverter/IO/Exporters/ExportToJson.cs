using Converter.Entities;
using Converter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Converter.IO.Exporters
{
    public class ExportToJson : IExportData<Person>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ExportToJson()
        {
            Name = "ExportToJson";
            Description = "Method to export into Json files.";
        }

        public bool Execute(IEnumerable<Person> entityList, string path)
        {
            try
            {
                Console.WriteLine("Exporting to Json...");

                using (TextWriter writer = new StreamWriter(path))
                {
                    var json = JsonSerializer.Serialize(entityList);
                    writer.Write(json);
                }

                Console.WriteLine("The file has been converted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
    }
}
