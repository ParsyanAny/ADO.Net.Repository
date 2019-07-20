using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mic.Repository
{
    public static class DataReaderExtensions
    {
        public static DateTime? ToNullableDateTime(this IDataReader reader, string name)
        {
            object value = reader[name];
            if (value == null || value == DBNull.Value)
                return null;

            return (DateTime)value;
        }
    }
}