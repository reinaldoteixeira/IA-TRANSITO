using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class Posicao
    {

        private int x, y;
        private Form1 form;
        private AnchorStyles sentido;

        List<Carro> lista = new List<Carro>();

        public Posicao(Form1 form, int x, int y, AnchorStyles sentido)
        {
            this.form = form;
            this.x = x;
            this.y = y;
            this.sentido = sentido;
        }


        private void addCarro()
        {


            lista.Add(new Carro(form, x, y, sentido));

        }

    }
}
