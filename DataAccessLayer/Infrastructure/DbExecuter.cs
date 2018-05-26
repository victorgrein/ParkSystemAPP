using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    internal class DbExecuter
    {
        private ConnectionHelper _helper =
            new ConnectionHelper();


        public int Execute(DbCommand command)
        {
            _helper.SetupCommand(command);
            try
            {
                return command.ExecuteNonQuery();
            }
            finally
            {
                //Finally é sempre executado
                //independentemente se a exceção
                //foi lançada
                _helper.Close();
            }
        }

        public DataTable GetData(DbCommand command)
        {
            _helper.SetupCommand(command);
            try
            {
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
            finally
            {
                _helper.Close();
            }
        }

    }
}
