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
        Transito t;
       
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Transito(this);

            //Adicionar Pontos de entrada de carros
            t.pontos.Add(new Posicao(814, 165, AnchorStyles.Left));
            t.pontos.Add(new Posicao(-80, 255, AnchorStyles.Right));
            t.pontos.Add(new Posicao(320, -80, AnchorStyles.Bottom));
            t.pontos.Add(new Posicao(420, 488, AnchorStyles.Top));

            t.gerenciador.addSemafaro(semBaixo, barBaixo, new Point(410, 310), new Point(500, 500), new Point(410, 310), new Point(500, 335));
            t.gerenciador.addSemafaro(semCima, barCima, new Point(300, 0), new Point(390, 160), new Point(300, 130), new Point(390, 160));
            t.gerenciador.addSemafaro(semDireita, barDireita, new Point(500, 160), new Point(810, 225), new Point(500, 160), new Point(530, 225));
            t.gerenciador.addSemafaro(semEsquerda, barEsquerda, new Point(0, 245), new Point(295, 313), new Point(260,250), new Point(296, 310));

            t.gerenciador.iniciar();
            t.iniciar();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


           

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void cboSentido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
