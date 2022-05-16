using System.Collections.Generic;

namespace Converter.Interfaces
{
    public interface IImportData<T> : IDataIO where T : class
    {
        IEnumerable<T> Execute(string path);
    }
}
