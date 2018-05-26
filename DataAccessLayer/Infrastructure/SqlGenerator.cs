using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DTO.DataAnnotations;

namespace DataAccessLayer.Infrastructure
{
    class SqlGenerator<T>
    {
        public DbCommand GenerateInsertCommand(T item)
        {
            DbCommand command = DbFactory.GetCommand();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendFormat("INSERT INTO {0} {1} VALUES {2}",
                                   GetTableName(), 
                                   GetInsertFields(false),
                                   GetInsertFields(true));
            foreach (var property in typeof(T).GetProperties())
            {
                if(property.Name != "ID")
                {
                    command.Parameters.AddWithValue("@"+property.Name, 
                                                    property.GetValue(item));
                }
            }
            command.CommandText = sBuilder.ToString();
            return command;
        }

        /// <summary>
        /// Retorna o nome da tabela especificado
        /// no Attribute TableName. Caso T não possua
        /// este Attribute, retorna o nome da própria classe
        /// </summary>
        /// <returns></returns>
        private string GetTableName()
        {
            TableName tableName =
                typeof(T).GetCustomAttribute<TableName>();
            return tableName != null ? tableName.Name :
                   typeof(T).Name;
        }

        private string GetInsertFields(bool isParameter)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("(");
            foreach (var item in typeof(T).GetProperties())
            {
                if (item.Name != "ID")
                {
                    sBuilder.Append("@" + item.Name + ",");
                }
            }
            sBuilder = sBuilder.Remove(sBuilder.Length - 1, 1).Append(")");
            if (!isParameter)
            {
                sBuilder = sBuilder.Replace("@", "");
            }
            return sBuilder.ToString();
        }


    }
}
