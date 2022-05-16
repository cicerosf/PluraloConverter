using Converter.Entities;
using CsvHelper.Configuration;

namespace Converter.Helpers
{
    public class StoredataMap : ClassMap<Person>
    {
        public StoredataMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Name).Name("name");
            Map(m => m.Address.StreetName).Name("address_streetname");
            Map(m => m.Address.City).Name("address_city");
        }
    }
}
