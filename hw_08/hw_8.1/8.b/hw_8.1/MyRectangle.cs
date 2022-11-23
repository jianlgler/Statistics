using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_8._1
{
    class MyRectangle
    {
        public Rectangle r;
        PictureBox p;
        Form f;

        int x_down, y_down;
        int x_mouse, y_mouse;
        int r_width, r_height;

        Boolean drag = false;
        Boolean rsize = false;

        double coeff = 0.1d;
        public MyRectangle(int X, int Y, int Width, int Heigth, PictureBox pb, Form fo)
        {
            r = new Rectangle(X, Y, Width, Heigth);
            p = pb;
            f = fo;

            pb.MouseUp += new MouseEventHandler(MyRect_up);
            pb.MouseDown += new MouseEventHandler(MyRect_down);
            pb.MouseMove += new MouseEventHandler(MyRect_move);

            f.MouseWheel += new MouseEventHandler(MyRect_zoom);
        }

        private void MyRect_down(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_mouse = e.X;
                y_mouse = e.Y;

                x_down = r.X;
                y_down = r.Y;

                r_width = r.Width;
                r_height = r.Height;

                if (e.Button == MouseButtons.Left) drag = true;

                if (e.Button == MouseButtons.Right) rsize = true;

            }
        }

        private void MyRect_up(object sender, MouseEventArgs e)
        {
            drag = false;
            rsize = false;
        }

        private void MyRect_move(object sender, MouseEventArgs e)
        {
            int d_x = (int)e.X - x_mouse;
            int d_y = (int)e.Y - y_mouse;

            if (drag)
            {
                r.X = x_down + d_x;
                r.Y = y_down + d_y;

                //redraw(r, g);
            }
            else if (rsize)
            {
                r.Height = r_height + d_y;
                r.Width = r_width + d_x;

                //redraw(r, g);
            }
        }

        private void MyRect_zoom(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_down = r.X;
                y_down = r.Y;

                r.Width = r.Width + (int)(e.Delta * coeff);
                r.Height = r.Height + (int)(e.Delta * coeff);

                r.X = x_down - (int)((e.Delta * coeff) / 2);
                r.Y = y_down - (int)((e.Delta * coeff) / 2);
            }
        }
    }
}
