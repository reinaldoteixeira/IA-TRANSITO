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

        public int x, y;
        public AnchorStyles sentido;

        public Posicao(int x, int y, AnchorStyles sentido)
        {
            this.x = x;
            this.y = y;
            this.sentido = sentido;
        }
        

    }
}
