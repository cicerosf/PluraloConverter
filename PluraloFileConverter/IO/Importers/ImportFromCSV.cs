using ChoETL;
using Converter.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Converter.IO.Importers
{
    public class ImportFromCSV : IImportData<StreamReader>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ImportFromCSV()
        {
            Name = "ImportFromCSV";
            Description = "Method to import CSV files.";
        }

        public StreamReader Execute(string path)
        {
            StreamReader csvToJson = new StreamReader(path);
          
            return csvToJson;
        }
    }
}
