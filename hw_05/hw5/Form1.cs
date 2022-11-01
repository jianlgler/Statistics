namespace hw5
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        int x_down;
        int y_down;
        int x_up;
        int y_up;
        int x_mouse;
        int y_mouse;
        int r_width , r_height;
        Rectangle r;
        Boolean drag = false;
        Boolean rsize = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r = new Rectangle(20, 20, 800, 500);
            g.DrawRectangle(Pens.Red, r);
            pictureBox1.Image = b;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_mouse = e.X;
                y_mouse = e.Y;

                x_down = r.X;
                y_down = r.Y;

                if (e.Button == MouseButtons.Left) drag = true;
                
                if (e.Button == MouseButtons.Right) rsize = true;
                
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            rsize = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int d_x = (int)e.X - x_mouse;
            int d_y = (int)e.Y - y_mouse;
            
            r_width = r.Width; r_height = r.Height;
            if (drag)
            {
                r.X = x_down + d_x;
                r.Y = y_down + d_y;

                redraw(r, g);
            }
            if (rsize)
            {
                r.Height = r_height + d_y;
                r.Width = r_width + d_x;

                redraw(r, g);
            }
                
            
        }

        private void redraw(Rectangle r, Graphics g)
        {
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Red, r);
            pictureBox1.Image = b;
        }
    }
}