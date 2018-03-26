using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class Transito
    {
        private Timer tempo;

        public Form form;
        public Gerenciador gerenciador;
        public List<Posicao> pontos = new List<Posicao>();
        public List<Carro> carros = new List<Carro>();

        int cont;

        public Transito(Form form)
        {
            this.form = form;
            gerenciador = new Gerenciador(carros);

            tempo = new Timer();
            tempo.Interval = 30;
            tempo.Tick += new EventHandler(Tick);

            cont = 40;
         
        }

        public void iniciar()
        {
            tempo.Start();
        }

        private void Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < carros.Count; i++)
            {
                carros[i].andar();
                
                    
            }

            if (cont == 0)
            {
                for(int i=0; i< gerenciador.semafaros.Count; i++)
                {
                    gerenciador.semafaros[i].contarCarros();
                }
                
                addCarro();
                cont = 25;//25
                for (int i = 0; i < carros.Count; i++)
                {
                   if (passouDoLimite(carros[i]) == true)
                    {
                        carros[i].destruir();
                        carros.RemoveAt(i);
                    }
                        
                }
                for (int i = 0; i < gerenciador.semafaros.Count; i++)
                {
                    gerenciador.semafaros[i].contarCarros();
                }
            }
            else
            {
                cont -= 1;
            }

           

        }

        private void addCarro()
        {

            Random r = new Random();
            int i = r.Next(0, 4);
            carros.Add(new Carro(this, pontos[i]));


        }
        
        private bool passouDoLimite(Carro car)
        {
            System.Drawing.Point p = car.Traseiro();
            if (car.getSentido() == AnchorStyles.Top && p.Y <= 0)       
                return true;
            if (car.getSentido() == AnchorStyles.Bottom && p.Y >= form.Size.Height)
                return true;
            if (car.getSentido() == AnchorStyles.Right && p.X >= form.Size.Width)
                return true;
            if (car.getSentido() == AnchorStyles.Left && p.X <= 0)
                return true;
            return false;
        }
    }
}
