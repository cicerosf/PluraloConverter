using ChoETL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.IO.Exporters
{
    public static class ExportHelper
    {
        public static ChoCSVReader<dynamic> GetReadCsv(StreamReader source)
        {
            source.DiscardBufferedData();
            source.Seek(0, SeekOrigin.Begin);

            return ChoCSVReader.LoadText(source.ReadToEnd())
                                .WithFirstLineHeader()
                                .WithDelimiter(",")
                                .Configure(c => c.NestedColumnSeparator = '_');
        }
    }
}
