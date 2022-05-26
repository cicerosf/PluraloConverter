using System.Collections;
using System.Collections.Generic;

namespace Converter.Interfaces
{
    public interface IExportData<T> : IDataIO where T : class
    {
        bool Execute(T source, string destination);
    }
}
