using CommandDotNet;
using Converter.IO.Exporters;
using Converter.IO.Importers;
using Converter.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Converter
{
    public static class Program
    {
        private static StreamReader _csv;

        public static StreamReader Csv { get; set; }

        public static void Main()
        {
            var args = new List<string>();
            while (true)
            {
                new AppRunner<Commands>().Run(args.ToArray());
                Console.WriteLine("\n\nEnter the command:");
                args.Clear();
                args.AddRange(Console.ReadLine().Split(" "));
            }
        }
    }
}
