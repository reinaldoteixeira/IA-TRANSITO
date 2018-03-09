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
        private int pixelSeg = 2;
        private AnchorStyles sentido;

        
        //private Timer timer;
        


        public Carro(Form form,int x,int y, AnchorStyles sentido)
        {
            //timer = new Timer();
            //timer.Interval =30;
            //timer.Tick += new EventHandler(tick); //uma ação a cada tempo
            
            car = new PictureBox();
            car.Location = new System.Drawing.Point(x, y);
            car.Size = new System.Drawing.Size(80, 80);

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
            form.Controls.Add(car);
            definir_sentido(sentido);


            //timer.Start();
        }
        public void andar()
        {
            if(sentido == AnchorStyles.Right)
                car.Location = new System.Drawing.Point(car.Location.X + pixelSeg, car.Location.Y);
            else if(sentido == AnchorStyles.Left)
                car.Location = new System.Drawing.Point(car.Location.X - pixelSeg, car.Location.Y);
            else if (sentido == AnchorStyles.Top)
                car.Location = new System.Drawing.Point(car.Location.X, car.Location.Y - pixelSeg);
            else
                car.Location = new System.Drawing.Point(car.Location.X, car.Location.Y + pixelSeg);
        }

        private void tick(object sender, EventArgs e)
        {
            andar();
        }
        public void definir_sentido(AnchorStyles sentido)
        {
            //Começa sempre no sentido Left
            //Rotate sempre vira sentido horario ->
            
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
    }
}
