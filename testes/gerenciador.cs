using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class Gerenciador
    {
        private Timer tempo;
        public List<Semafaro> semafaros = new List<Semafaro>();
        private List<Carro> carros;

        private int tLimite;

        public Gerenciador(List<Carro> carros)
        {
            this.carros = carros;

            tLimite = 6;
            tempo = new Timer();
            tempo.Interval = 900;
            tempo.Tick += new EventHandler(Tick);

            
        }

        private void Tick(object sender, EventArgs e)
        {
            //semafaroPadrao();
            semafaroIA();
            
        }
        private void semafaroIA()
        {
            // semafaros 
            // 0 - baixo
            // 1 - cima
            // 2 - direita
            // 3 - esquerda

            if (semafaros[0].quantidade() >= semafaros[2].quantidade() &&
                semafaros[0].quantidade() >= semafaros[3].quantidade() ||
                semafaros[1].quantidade() >= semafaros[2].quantidade() &&
                semafaros[1].quantidade() >= semafaros[3].quantidade())
            {
                if(((semafaros[0].getSinal() == cor.Vermelho && semafaros[1].getSinal() == cor.Vermelho) &&
                    (semafaros[2].getSinal() == cor.Verde && semafaros[3].getSinal() == cor.Verde)) ||
                    (semafaros[0].getSinal() == cor.Amarelo && semafaros[1].getSinal() == cor.Amarelo) &&
                    (semafaros[2].getSinal() == cor.Vermelho && semafaros[3].getSinal() == cor.Vermelho))
                {
                    semafaros[0].vermelho();
                    semafaros[1].vermelho();
                    semafaros[2].amerelo();
                    semafaros[3].amerelo();

                    tLimite = 1;
                }
                else if((semafaros[0].getSinal() == cor.Vermelho && semafaros[1].getSinal() == cor.Vermelho) &&
                        (semafaros[2].getSinal() == cor.Amarelo && semafaros[3].getSinal() == cor.Amarelo))
                {
                    if(tLimite == 0)
                    {
                        semafaros[0].verde();
                        semafaros[1].verde();
                        semafaros[2].vermelho();
                        semafaros[3].vermelho();
                        
                        //tLimite = 15;
                    }
                    tLimite -= 1;
                }
                else
                {
                    //tLimite -= 1;
                }
            }
            else
            {
                if (((semafaros[0].getSinal() == cor.Verde && semafaros[1].getSinal() == cor.Verde) &&
                  (semafaros[2].getSinal() == cor.Vermelho && semafaros[3].getSinal() == cor.Vermelho)) ||
                  ((semafaros[0].getSinal() == cor.Vermelho && semafaros[1].getSinal() == cor.Vermelho) &&
                  (semafaros[2].getSinal() == cor.Amarelo && semafaros[3].getSinal() == cor.Amarelo)))
                {
                    semafaros[0].amerelo();
                    semafaros[1].amerelo();
                    semafaros[2].vermelho();
                    semafaros[3].vermelho();

                    tLimite = 1;
                }
                else if ((semafaros[0].getSinal() == cor.Amarelo && semafaros[1].getSinal() == cor.Amarelo) &&
                        (semafaros[2].getSinal() == cor.Vermelho && semafaros[3].getSinal() == cor.Vermelho))
                {
                    if (tLimite == 0)
                    {
                        semafaros[0].vermelho();
                        semafaros[1].vermelho();
                        semafaros[2].verde();
                        semafaros[3].verde();

                        //tLimite = 15;
                    }
                    tLimite -= 1;
                }
                else
                {
                    //tLimite -= 1;
                }
            }

           

        }
        private void semafaroPadrao()
        {
            if (semafaros[0].getSinal() == cor.Verde)
            {
                if (tLimite == 0)
                {
                    semafaros[0].amerelo();
                    semafaros[1].amerelo();
                    semafaros[2].vermelho();
                    semafaros[3].vermelho();
                    tLimite = 2;
                }
                else
                    tLimite -= 1;
                
            }
            else if (semafaros[0].getSinal() == cor.Amarelo)
            {
                if (tLimite == 0)
                {
                    semafaros[0].vermelho();
                    semafaros[1].vermelho();
                    semafaros[2].verde();
                    semafaros[3].verde();
                    tLimite = 6;
                }
                else
                    tLimite -= 1;
            }
            else if (semafaros[2].getSinal() == cor.Verde)
            {
                if (tLimite == 0)
                {
                    semafaros[0].vermelho();
                    semafaros[1].vermelho();
                    semafaros[2].amerelo();
                    semafaros[3].amerelo();
                    tLimite = 2;
                }
                else
                    tLimite -= 1;
            }
            else if (semafaros[2].getSinal() == cor.Amarelo)
            {
                if (tLimite == 0)
                {
                    semafaros[0].verde();
                    semafaros[1].verde();
                    semafaros[2].vermelho();
                    semafaros[3].vermelho();
                    tLimite = 6;
                }
                else
                    tLimite -= 1;
            }
        }

        public void iniciar()
        {
            semafaros[0].verde();
            semafaros[1].verde();
            tempo.Start();
        }

        public void addSemafaro(PictureBox semafaro, ProgressBar barra, System.Drawing.Point p1, System.Drawing.Point p2, System.Drawing.Point faixa1, System.Drawing.Point faixa2)
        {
            semafaros.Add(new Semafaro(semafaro, barra, p1, p2,faixa1,faixa2,carros));
        }
    }
}
