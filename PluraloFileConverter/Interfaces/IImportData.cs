using System.Collections;
using System.Collections.Generic;

namespace Converter.Interfaces
{
    public interface IImportData<T> : IDataIO where T : class
    {
        T Execute(string path);
    }
}
