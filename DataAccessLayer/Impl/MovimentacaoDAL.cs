using DataAccessLayer.Infrastructure;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class MovimentacaoDAL : IMovimentacaoService
    {
        public void RegistrarEntrada(DTO.Movimentacao m)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText =
                @"INSERT INTO MOVIMENTACOES 
                    (PLACA,ENTRADA,VAGAID,MODELO,COR) VALUES
                    (@PLACA,@ENTRADA,@VAGAID,@MODELO,@COR)";
            command.Parameters.AddWithValue("@PLACA", m.Placa);
            command.Parameters.AddWithValue("@ENTRADA", m.Entrada);
            command.Parameters.AddWithValue("@VAGAID", m.VagaID);
            command.Parameters.AddWithValue("@MODELO", m.Modelo);
            command.Parameters.AddWithValue("@COR", m.Cor);
            new DbExecuter().Execute(command);
        }

        public double RegistrarSaida(Movimentacao movimentacao)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText =
                    @"UPDATE MOVIMENTACOES SET VALOR = @VALOR,
                                               SAIDA = @SAIDA
                      WHERE ID = @ID";
            command.Parameters.AddWithValue("@VALOR", movimentacao.Valor);
            command.Parameters.AddWithValue("@SAIDA", movimentacao.Saida);
            command.Parameters.AddWithValue("@ID", movimentacao.ID);
            return new DbExecuter().Execute(command);
        }

        public DTO.Movimentacao LerMovimentacao(string placa)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = 
                @"SELECT * FROM MOVIMENTACOES 
                    WHERE PLACA = @PLACA AND VALOR IS NULL";
            command.Parameters.AddWithValue("@PLACA", placa);
            DataTable table = new DbExecuter().GetData(command);
            if(table.Rows.Count == 0)
            {
                return null;
            }
            return new Movimentacao()
            {
                ID = (int)table.Rows[0]["ID"],
                Cor = (int)table.Rows[0]["COR"],
                Entrada = (DateTime)table.Rows[0]["ENTRADA"],
                Modelo = (string)table.Rows[0]["MODELO"],
                Placa = (string)table.Rows[0]["PLACA"],
                VagaID = (int)table.Rows[0]["VAGAID"],
            };
        }
    }
}
