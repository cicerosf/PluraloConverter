using Converter.Entities;
using Converter.IO.Exporters;
using Converter.IO.Importers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter
{
    public static class Program
    {
        private static List<Person> _listPerson;

        public static List<Person> ListPerson
        { 
            get => _listPerson == null? new List<Person>() : _listPerson;
            set => _listPerson = value;
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                ExecureCommands(Console.ReadLine());
            };
        }

        private static void ExecureCommands(string input)
        {
            if (!ValidateInput(input)) return;
            
            var command = input.Split(' ')[0];
            var path = input.Split(' ')[1];

            switch (command)
            {
                case "1":
                    {
                        Program.ListPerson = new ImportFromCSV().Execute(path).ToList();
                        break;
                    }

                case "2":
                    {
                        new ExportToJson().Execute(Program.ListPerson, path);
                        break;
                    }

                case "3":
                    {
                        new ExportToXml().Execute(Program.ListPerson, path);
                        break;
                    }
             default:
                    {
                        break;
                    }
              
            }
        }

        private static bool ValidateInput(string input)
        {
            var inputChecking = input.Split(' ');

            if (inputChecking[0] == "4")
            {
                Console.WriteLine("Goodbye and have a nice day.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (inputChecking.Count() == 1)
            {
                return false;
            }

            return true;
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.Title = "File converter Menu";
            Console.WriteLine("Welcome,  What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("[1] Import CSV File");
            Console.WriteLine("[2] Convert file to Json (Only after Import action is done)");
            Console.WriteLine("[3] Convert file to XML (Only after Import action is done)");
            Console.WriteLine("[4] Exit");
            Console.WriteLine("");
            Console.WriteLine("*************************************************");
            Console.WriteLine("***Please, follow the syntax => number pathToFile");
            Console.WriteLine("*************************************************");
        }
    }
}
