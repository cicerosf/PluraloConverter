using System.Collections.Generic;

namespace Converter.Interfaces
{
    public interface IExportData<T> : IDataIO where T : class
    {
        bool Execute(IEnumerable<T> entityList, string path);
    }
}
