using BusinessLogicalLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class FormCadastroTipoVaga : Form
    {
        public FormCadastroTipoVaga()
        {
            InitializeComponent();
        }

        private TipoVagaBLL tipoBLL = new TipoVagaBLL();

        private void btnInserir_Click(object sender, EventArgs e)
        {
            TipoVaga tipoVaga = new TipoVaga();
            tipoVaga.Nome = txtNome.Text;
            tipoVaga.Valor = txtValor.Text.ToDouble();
            try
            {
                tipoBLL.Insert(tipoVaga);
                MessageBox.Show("Cadastrado com sucesso!");
                LimparCampos();
                AtualizarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AtualizarDados()
        {
            gdvDados.DataSource = tipoBLL.GetAll();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtValor.Clear();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
