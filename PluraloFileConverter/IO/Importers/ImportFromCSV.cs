using Converter.Entities;
using Converter.Helpers;
using Converter.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Converter.IO.Importers
{
    public class ImportFromCSV : IImportData<Person>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ImportFromCSV()
        {
            Name = "ImportFromCSV";
            Description = "Method to import CSV files.";
        }

        public IEnumerable<Person> Execute(string path)
        {
            System.Console.WriteLine("Importing file has started...");

            CsvConfiguration config = CsvImporterCOnfiguration();

            var Lista = ExtractDataFromFile(path, config);

            System.Console.WriteLine("Imported done!");

            return Lista;
        }

        private static IEnumerable<Person> ExtractDataFromFile(string path, CsvConfiguration config)
        {
            var Lista = new List<Person>();
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<StoredataMap>();
                    var records = csv.GetRecords<Person>();
                    foreach (var item in records)
                    {
                        Lista.Add(item);
                    }
                }
            }

            return Lista;
        }

        private static CsvConfiguration CsvImporterCOnfiguration()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                HasHeaderRecord = true,
                Delimiter = ",",
            };
        }
    }
}
