using CommandDotNet;
using Converter.Interfaces;
using Converter.IO.Exporters;
using Converter.IO.Importers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Converter.Utils
{
    public class Commands
    {
        public void ImportFromCsv(string Source)
        {
            try
            {
                Program.Csv = new ImportFromCSV().Execute(Source);
                Console.WriteLine("File imported!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again, please.");
            }
        }

        public void ConvertCsvToJson(string destination)
        {
            if (Program.Csv == null)
            {
                Console.WriteLine("Please, import the csv file first");
                return;
            }
            try
            {
                new ExportCsvToJson().Execute(Program.Csv, destination);
                Console.WriteLine("File exported!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again, please.");
            }
        }

        public void ConvertCsvToXml(string destination)
        {
            if (Program.Csv == null)
            {
                Console.WriteLine("Please, import the csv file first");
                return;
            }
            try
            {
                new ExportCsvToXml().Execute(Program.Csv, destination);
                Console.WriteLine("File exported!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again, please.");
            }
        }

        [Command("sair")]
        public void Exit()
        {
            Environment.Exit(0);
        }

    }
}
