using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testes
{
    class Carro
    {
        private PictureBox car;
        private int pixelSeg = 5;
        private int tamanho = 50;
        private int visao = 10;
        private AnchorStyles sentido;
        private  Transito t;
        

        public Carro(Transito transito, Posicao posicao)
        {
            this.t = transito;
            
            car = new PictureBox();
            car.Location = new System.Drawing.Point(posicao.x, posicao.y);
            car.Size = new System.Drawing.Size(tamanho,tamanho);

            Random r = new Random();
            int cor = r.Next(1, 4);
            if (cor == 1)
            {
                car.Image = testes.Properties.Resources.amarelo;
            }
            else if(cor == 2)
            {
                car.Image = testes.Properties.Resources.azul;
            }
            else
            {
                car.Image = testes.Properties.Resources.vermelho;
            }

            car.BackColor = System.Drawing.Color.Transparent;
            
            
            car.SizeMode = PictureBoxSizeMode.Zoom;
            t.form.Controls.Add(car);
            definir_sentido(posicao.sentido);


            
        }

        public void andar()
        {
            if (carroNaFrente() == true)
                return;

            if (semafaroVermelho() == true)  
                return;
            

            if (sentido == AnchorStyles.Right)
                car.Location = new System.Drawing.Point(car.Location.X + pixelSeg, car.Location.Y);
            else if(sentido == AnchorStyles.Left)
                car.Location = new System.Drawing.Point(car.Location.X - pixelSeg, car.Location.Y);
            else if (sentido == AnchorStyles.Top)
                car.Location = new System.Drawing.Point(car.Location.X, car.Location.Y - pixelSeg);
            else
                car.Location = new System.Drawing.Point(car.Location.X, car.Location.Y + pixelSeg);

            
        }

        public void definir_sentido(AnchorStyles sentido)
        {
            
            this.sentido = sentido;

            System.Drawing.Image temp = car.Image;

            if (sentido == AnchorStyles.Right)
            {
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            }
            else if (sentido == AnchorStyles.Left)
            {

            }
            else if (sentido == AnchorStyles.Top)
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            else
            {
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            }
                 
            car.Image = temp;
        }

        public void virar(int i)
        {
            
            System.Drawing.Image temp = car.Image;

            if (sentido == AnchorStyles.Right)
            {
                if (i == 1)
                {
                    sentido = AnchorStyles.Top;
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                    sentido = AnchorStyles.Bottom;
                }
                    

            }
            else if (sentido == AnchorStyles.Left)
            {
                if (i == 1)
                {
                    sentido = AnchorStyles.Bottom;
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                    sentido = AnchorStyles.Top;
                }
            }
            else if (sentido == AnchorStyles.Top)
            {
                if (i == 1)
                {
                    sentido = AnchorStyles.Left;
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                    sentido = AnchorStyles.Right;
                }
            }
            else
            {
                if (i == 1)
                {
                    sentido = AnchorStyles.Right;
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                    sentido = AnchorStyles.Left;
                }
            }

            car.Image = temp;
        }

        public AnchorStyles getSentido()
        {
            return sentido;
        }

        public System.Drawing.Point getPointInicio()
        {
            return car.Location;
        }

        public System.Drawing.Point getPointFim()
        {
            return new System.Drawing.Point(car.Location.X + tamanho,car.Location.Y + tamanho);
        }

        public System.Drawing.Point getPointVisao()
        {
            
            if (sentido == AnchorStyles.Top)
                return new System.Drawing.Point(car.Location.X + (tamanho/2), car.Location.Y - visao);
            else if (sentido == AnchorStyles.Bottom)
                return new System.Drawing.Point(car.Location.X + (tamanho / 2), car.Location.Y +tamanho + visao);
            else if (sentido == AnchorStyles.Right)
               return new System.Drawing.Point(car.Location.X + tamanho + visao, car.Location.Y + (tamanho / 2));
            else
                return new System.Drawing.Point(car.Location.X - visao, car.Location.Y + (tamanho / 2));
        }
      
        private bool carroNaFrente()
        {
            System.Drawing.Point p1, p2, v1;

            v1 = getPointVisao();

            for (int i = 0; i < t.carros.Count; i++)
            {
                p1 = t.carros[i].getPointInicio();
                p2 = t.carros[i].getPointFim();
                if ((v1.X > p1.X && v1.Y > p1.Y) & (v1.X < p2.X && v1.Y < p2.Y))
                    return true;
            }
            return false;
        }

        private bool semafaroVermelho()
        {
            System.Drawing.Point p1, p2, v1;
            List<Semafaro> s = t.gerenciador.semafaros;
            v1 = getPointVisao();

            for (int i = 0; i < s.Count; i++)
            {
                p1 = s[i].getFaixaP1();
                p2 = s[i].getFaixaP2();
                if ((v1.X > p1.X && v1.Y > p1.Y) & (v1.X < p2.X && v1.Y < p2.Y))
                {
                    if(s[i].getSinal() == cor.Vermelho || s[i].getSinal() == cor.Amarelo)
                    {
                        return true;
                    }
                }
                    
            }
            return false;
        }

        public System.Drawing.Point Traseiro()
        {
            if (sentido == AnchorStyles.Top)
                return new System.Drawing.Point(car.Location.X + (tamanho / 2), car.Location.Y + tamanho);
            else if (sentido == AnchorStyles.Bottom)
                return new System.Drawing.Point(car.Location.X + (tamanho / 2), car.Location.Y);
            else if (sentido == AnchorStyles.Right)
                return new System.Drawing.Point(car.Location.X, car.Location.Y + (tamanho / 2));
            else
                return new System.Drawing.Point(car.Location.X + tamanho, car.Location.Y + (tamanho / 2));
        }

        public void destruir()
        {
            t.form.Controls.Remove(car);
        }
        
    }
}
