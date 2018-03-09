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
        List<Posicao> lista = new List<Posicao>();


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lista.Add(new Posicao(this, 814, 150, AnchorStyles.Left));
            lista.Add(new Posicao(this, -80, 240, AnchorStyles.Right));
            lista.Add(new Posicao(this, 422, -80, AnchorStyles.Top));
            lista.Add(new Posicao(this, 309, 488, AnchorStyles.Bottom));

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnchorStyles sentido = AnchorStyles.Left;
            if (cboSentido.Text == "Up")
                sentido = AnchorStyles.Top;
            else if (cboSentido.Text == "Down")
                sentido = AnchorStyles.Bottom;
            else if (cboSentido.Text == "Right")
                sentido = AnchorStyles.Right;
            else if (cboSentido.Text == "Left")
                sentido = AnchorStyles.Left;


           

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
            
        }

        private void cboSentido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lista[Convert.ToInt32(numericUpDown1.Value)].virar(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lista[Convert.ToInt32(numericUpDown1.Value)].virar(2);
        }


    }
}
