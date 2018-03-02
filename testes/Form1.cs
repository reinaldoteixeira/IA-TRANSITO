using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testes
{
    public partial class Form1 : Form
    {
        List<Carro> lista = new List<Carro>();
        
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.Add(new Carro(this, 784, 163));
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < lista.Count; i++)
            {
                lista[i].andar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista[Convert.ToInt32(numericUpDown1.Value)].virar();
        }
    }
}
