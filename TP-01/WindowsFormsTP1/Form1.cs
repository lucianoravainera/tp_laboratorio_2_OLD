using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculadoraTP1;


namespace WindowsFormsTP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
            lblResultado.Text = "0";
            cmbOperacion.Items.Add("+");
            cmbOperacion.Items.Add("-");
            cmbOperacion.Items.Add("*");
            cmbOperacion.Items.Add("/");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero(txtNumero1.Text);
            Numero n2 = new Numero(txtNumero2.Text);
            string auxstr =  Calculadora.ValidarOperador(cmbOperacion.Text);
            double aux;

            aux = Calculadora.Operar(n1, n2,auxstr);
            cmbOperacion.Text = auxstr; 
            lblResultado.Text = aux.ToString();
        }

    }
}
