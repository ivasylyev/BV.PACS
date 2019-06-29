using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;

namespace BV.PACS.Server.Services
{
    public static class SqlMapperEx
    {
        public static void InitMapper<T>()
        {
            SqlMapper.SetTypeMap(
                typeof(T),
                new CustomPropertyTypeMap(
                    typeof(T),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.Name == columnName ||
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }

    }
}