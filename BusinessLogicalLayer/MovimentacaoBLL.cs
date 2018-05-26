using DataAccessLayer.Impl;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class MovimentacaoBLL : BaseValidator<Movimentacao>, IMovimentacaoService
    {
        private TipoVagaBLL tipoVagaBll = new TipoVagaBLL();
        private VagaBLL vagaBll = new VagaBLL();
        private MovimentacaoDAL movimentacaoDAL = new MovimentacaoDAL();

        public override void Validate(Movimentacao entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Modelo))
            {
                AddError("Modelo deve ser informado.");
            }
            else if (entity.Modelo.Length > 50)
            {
                AddError("O modelo deve ter no máximo 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(entity.Placa))
            {
                AddError("A placa deve ser informada.");
            }
            else
            {
                entity.Placa = entity.Placa.Replace("-", "");
                entity.Placa = entity.Placa.ToUpper();
                Regex regex = new Regex(@"^[A-Z]{3}\d{4}$");
                if (!regex.IsMatch(entity.Placa))
                {
                    AddError("Placa inválida.");
                }
            }
            Vaga vaga = vagaBll.GetById(entity.VagaID);
            if (vaga == null || vaga.Ocupada)
            {
                AddError("Vaga indisponível.");
            }
            base.Validate(entity);
        }

        public void RegistrarEntrada(DTO.Movimentacao m)
        {
            Validate(m);
            m.Entrada = DateTime.Now;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //Insere a movimentação no banco de dados
                    movimentacaoDAL.RegistrarEntrada(m);
                    //Altera o status da vaga no banco de dados
                    vagaBll.Ocupar(m.VagaID);
                    //Se a linha debaixo for executada,
                    //as operações SQL são CONFIRMADAS no banco de dados,
                    //caso contrário, uma REVERSÃO das operações é executada
                    scope.Complete();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public double RegistrarSaida(DTO.Movimentacao m)
        {
            m.Placa = m.Placa.ToUpper().Replace("-", "");
            //Ler dados da movimentação através da placa
            Movimentacao movimentacao = LerMovimentacao(m.Placa);
            //Calcular o tempo da movimentação
            movimentacao.Saida = DateTime.Now;
            TimeSpan tempoNoLocal =
                movimentacao.Saida.Value - movimentacao.Entrada;
            //Calcular o valor da vaga de acordo com o tipo do veiculo
            Vaga vaga = vagaBll.GetById(movimentacao.VagaID);
            TipoVaga tipoVaga = tipoVagaBll.GetById(vaga.TipoVagaID);

            //Calcular o preço a pagar
            movimentacao.Valor =
                CalcularPrecoFinalEstadia(tempoNoLocal, vaga, tipoVaga.Valor);
            using (TransactionScope scope = new TransactionScope())
            {
                //Efetuar a Saida 
                movimentacaoDAL.RegistrarSaida(movimentacao);
                //Desocupar a Vaga
                vagaBll.Desocupar(movimentacao.VagaID);
                scope.Complete();
            }
            return movimentacao.Valor.Value;
        }

        private double CalcularPrecoFinalEstadia(TimeSpan tempoNoLocal,
                                                 Vaga vaga, 
                                                 double preco)
        {
            double precoBase = preco;
            if(tempoNoLocal.TotalMinutes < 15)
            {
                return precoBase;
            }
            if(vaga.Coberta)
            {
                precoBase += 2;
            }
            if(vaga.Idoso)
            {
                precoBase -= 1;
            }
            return preco * ((int)tempoNoLocal.TotalHours + 1) + precoBase;
        }

        public DTO.Movimentacao LerMovimentacao(string placa)
        {
            return movimentacaoDAL.LerMovimentacao(placa);
        }
    }
}


