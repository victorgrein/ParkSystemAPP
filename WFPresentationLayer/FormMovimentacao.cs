using BusinessLogicalLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class txtPlacaSaida : Form
    {
        public txtPlacaSaida()
        {
            InitializeComponent();
        }
        private MovimentacaoBLL bll = new MovimentacaoBLL();

        private void dtpEntrada_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            dateTimePicker1.Enabled = false;
            btnColor.Click += btnColor_Click;
            txtPlaca.Mask = ">LLL-0000";
            cmbVagas.DisplayMember = "Codigo";
            cmbVagas.ValueMember = "ID";
            cmbVagas.DataSource = new VagaBLL().GetAll(); 
        }

        void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDiaolog = new ColorDialog();
            DialogResult result = colorDiaolog.ShowDialog();
            if(result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            btnColor.BackColor = colorDiaolog.Color;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movimentacao movimentacao = new Movimentacao();
            movimentacao.Cor = btnColor.BackColor.ToArgb();
            movimentacao.Modelo = textBox1.Text;
            movimentacao.Placa = txtPlaca.Text;
            movimentacao.VagaID = (int)cmbVagas.SelectedValue;
            try
            {
                bll.RegistrarEntrada(movimentacao);
                MessageBox.Show("Inserido com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            Movimentacao movimentacao = new Movimentacao();
            movimentacao.Placa = txtBoxPLaca.Text;
            try
            {
                double valor = bll.RegistrarSaida(movimentacao);
                MessageBox.Show("Valor: " + valor.ToString("C2"));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
