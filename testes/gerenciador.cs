using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class gerenciador
    {
        private Timer tempo;
        ProgressBar bar;

        public Form form;
        List<Posicao> pontos = new List<Posicao>();
        List<Carro> carros = new List<Carro>();
        int cont;

        public gerenciador(Form form,ProgressBar bar)
        {
            this.form = form;
            this.bar = bar;

            tempo = new Timer();
            tempo.Interval = 30;
            tempo.Tick += new EventHandler(Tick);

            pontos.Add(new Posicao( 814, 165, AnchorStyles.Left));
            pontos.Add(new Posicao( -80, 255, AnchorStyles.Right));
            pontos.Add(new Posicao( 435, -80, AnchorStyles.Bottom));
            pontos.Add(new Posicao( 309, 488, AnchorStyles.Top));

            cont = 40;
            
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
                addCarro();
                cont = 25;
            }
            else
            {
                cont -= 1;
            }

            bar.Value = contarCarro(297, 315,392, 503);

        }
        private void addCarro()
        {

            Random r = new Random();
            int i = r.Next(0, 4);
            carros.Add(new Carro(form, pontos[i]));


        }
        
        public int contarCarro(int x1,int y1,int x2, int y2)
        {

            int contCarro = 0;
            
            for(int i =0; i < carros.Count(); i++)
            {

                if (carros[i].getX() > x1 && carros[i].getX() < x2 && carros[i].getY() > y1 && carros[i].getY() < y2)
                {

                    contCarro++;

                }

            }

            return contCarro;
        }

    }
}
