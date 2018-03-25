using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class Semafaro
    {
        private PictureBox semafaro;
        private cor sinal;
        private ProgressBar barra;
        private System.Drawing.Point p1, p2; // Ponto aonde começa a rua e aonde termina
        private System.Drawing.Point f1, f2; // Ponto aonde começa faixa e aonde termina

        private List<Carro> carros;

        public Semafaro(PictureBox semafaro,ProgressBar barra, System.Drawing.Point p1, System.Drawing.Point p2, System.Drawing.Point f1, System.Drawing.Point f2, List<Carro> carros)
        {
            this.semafaro = semafaro;
            this.barra = barra;
            this.p1 = p1;
            this.p2 = p2;
            this.f1 = f1;
            this.f2 = f2;
            this.carros = carros;

            vermelho();

        }
        public cor getSinal()
        {
            return sinal;
        }
        public void vermelho()
        {
            semafaro.Image = testes.Properties.Resources.sinal_vermelho;
            sinal = cor.Vermelho;
        }
        public void amerelo()
        {
            semafaro.Image = testes.Properties.Resources.sinal_amarelo;
            sinal = cor.Amarelo;
        }
        public void verde()
        {
            semafaro.Image = testes.Properties.Resources.sinal_verde;
            sinal = cor.Verde;
        }

        public System.Drawing.Point getFaixaP1()
        {
            return f1;
        }
        public System.Drawing.Point getFaixaP2()
        {
            return f2;
        }
    }
    
}
