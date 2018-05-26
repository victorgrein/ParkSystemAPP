using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public static class SqlExtensions
    {
        public static void AddWithValue(this DbParameterCollection collection, 
                                        string parameterName,
                                        object parameterValue)
        {
            DbParameter parameter = DbFactory.GetCommand().CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            collection.Add(parameter);
        }
    }
}
