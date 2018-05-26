using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    internal class DbFactory
    {
        //Variáveis estáticas só serão desalocadas
        //da memória quando o programa encerrar
        private static DbProviderFactory _factory;
        private static string _connectionString;

        //Construtor estático:
        //Será executado quando a classe
        //for referenciada em qualquer lugar.
        //O construtor estático roda apenas 
        //uma ÚNICA vez por execução
        //e sempre é executado antes do
        //construtor normal da classe
        static DbFactory()
        {
            string currentProvider = 
            ConfigurationManager.AppSettings["CurrentProvider"];

            ConnectionStringSettings settings = 
            ConfigurationManager.ConnectionStrings[currentProvider];

            _factory = DbProviderFactories.GetFactory(settings.ProviderName);
            _connectionString = settings.ConnectionString;
        }

        public static DbConnection GetConnection()
        {
            DbConnection dbConnection = _factory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;
            return dbConnection;
        }

        public static DbCommand GetCommand()
        {
            return _factory.CreateCommand();
        }

    }
}
