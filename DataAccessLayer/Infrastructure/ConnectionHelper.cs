using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    internal class ConnectionHelper
    {
        private DbConnection _connection;

        public ConnectionHelper()
        {
            _connection = DbFactory.GetConnection();
        }

        public void Open()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                //lock{}
                _connection.Open();
            }
        }

        public void Close()
        {
            if(_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void SetupCommand(DbCommand command)
        {
            Open();
            command.Connection = _connection;
        }



    }
}
