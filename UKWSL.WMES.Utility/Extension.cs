using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Utility
{
    public static class Extenstion
    {
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return row.GetValueOrDefault<T>(ordinal);
        }

        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }

        public static T GetValueOrDefault<T>(this object value)
        {
            return (T)(value == null ? default(T) : value);
        }
    }
}
