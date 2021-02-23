using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Carro meuCarro;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            meuCarro = new Carro();
            meuCarro.cor = "vermelho";
            meuCarro.modelo = "peugeout";
            meuCarro.portas = 2;
            meuCarro.rodas = 4;
            meuCarro.velocida = 160;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(meuCarro.Ligar());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(meuCarro.Acelarar());

        }
    }
}
