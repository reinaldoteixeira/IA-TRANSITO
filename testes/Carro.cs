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
        //private Timer timer;
        


        public Carro(Form form,int x,int y)
        {
            //timer = new Timer();
            //timer.Interval =30;
            //timer.Tick += new EventHandler(tick); //uma ação a cada tempo


            car = new PictureBox();
            car.Location = new System.Drawing.Point(x, y);
            car.Size = new System.Drawing.Size(100, 100);
            car.BackColor = System.Drawing.Color.Transparent;
            car.Image = testes.Properties.Resources.interior_color_1;
            car.SizeMode = PictureBoxSizeMode.Zoom;
            form.Controls.Add(car);

            



            //timer.Start();
        }
        public void andar()
        {
            car.Location = new System.Drawing.Point(car.Location.X - 2 , car.Location.Y);
        }

        private void tick(object sender, EventArgs e)
        {
            andar();
        }
        public void virar()
        {
            System.Drawing.Image temp = car.Image;
            temp.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipX);
            car.Image = temp;
        }
    }
}
