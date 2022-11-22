using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace hw_08
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        
        Pen black_pen = new Pen(Color.Black, 2);
        Pen orange;

        List<Point> points;
        List<(double, double)> reals;
        Dictionary<int, int> xs;
        Dictionary<int, int> ys;

        Random r = new Random();

        MyRectangle r1;

        double minX;
        double maxX;
        double minY;
        double maxY;

        public Form1()
        {
            InitializeComponent();

            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new MyRectangle(0, b.Height/3, b.Width / 2, b.Height / 2, pictureBox1, this);
            
            orange = new Pen(Color.OrangeRed, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);

            draw(); drawVerticalHistogram(); drawHorizontallHistogram();
            pictureBox1.Image = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            minX = -100;
            maxX = 100;
            minY = -100;
            maxY = 100;

            reals = new List<(double, double)>();
            xs = new Dictionary<int, int>();
            ys = new Dictionary<int, int>();

            generate();

            timer1.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "points: " + trackBar1.Value;
            
        }

        private int X_Normalization(double x, int w, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + (int)(w * ((x - min) / (max - min)));
        }

        private int Y_Normalization(double y, int h, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + (int)(h - h * ((y - min) / (max - min)));
        }

        private void draw()
        {
            g.FillRectangle(Brushes.White, r1.r);
            points = new List<Point>();
            foreach ((double, double) real in reals)
            {
                int x_norm = X_Normalization(real.Item1, r1.r.Width, maxX, minX, r1.r.Left);
                int y_norm = Y_Normalization(real.Item2, r1.r.Height, maxY, minY, r1.r.Top);

                if (!xs.ContainsKey(x_norm)) xs.Add(x_norm, 1);
                else xs[x_norm]++;

                if (!ys.ContainsKey(y_norm)) ys.Add(y_norm, 1);
                else ys[y_norm]++;

                points.Add(new Point(x_norm, y_norm));
                

            }
            foreach (Point p in points)
            {
                Rectangle r = new Rectangle(p.X, p.Y, 10, 10);
                g.FillEllipse(Brushes.Orange, r);
            }
        }

        private void generate()
        {
            for(int i = 0; i < trackBar1.Value; i++)
            {
                double mod = (r.NextDouble() * 100);
                double theta = r.NextDouble() * 2 * Math.PI;

                double x = (int) (mod * Math.Cos(theta)); double y = (int)(mod * Math.Sin(theta));
                reals.Add((x, y));
            }
        }

        private void drawVerticalHistogram()
        {
            Dictionary<HistItem, int> items = new Dictionary<HistItem, int>();
            int offset = 10;

            for(int i = (int) Math.Floor(minX); i < (int) Math.Ceiling(maxX); i += offset)
            {
                HistItem item = new HistItem();
                item.lower_bound = i;
                item.upper_bound = i + offset;

                items[item] = 0;
            } //istogramma con intervalli

            List<HistItem> chiavi = items.Keys.ToList();

            foreach ((double, double) real in reals)
            {
                Boolean ins = false;
                foreach (HistItem item in chiavi)
                {
                    if(item.contains(real.Item1) && !ins)
                    {
                        ins = true;
                        items[item]++;
                    }
                }
            }

            int max = items.Values.Max();
            int space_height = (r1.r.Bottom - r1.r.Top) / 2; //altezza max per rettangolo contenente istogramma
            
            foreach (KeyValuePair<HistItem, int> k in items)
            {
                HistItem item = k.Key;

                int r_height = (int)(((double)k.Value / (double)max) * ((double)space_height));

                int lower = X_Normalization(item.lower_bound, r1.r.Width, maxX, minX, r1.r.Left);
                int upper = X_Normalization(item.upper_bound, r1.r.Width, maxX, minX, r1.r.Left);

                int size = Math.Abs(lower - upper);

                Rectangle hr = new Rectangle(lower, r1.r.Top - r_height, size, r_height);
                g.DrawRectangle(black_pen, hr);
                g.FillRectangle(Brushes.BlueViolet, hr);
            }

            pictureBox1.Image = b;
        }

        private void drawHorizontallHistogram()
        {
            Dictionary<HistItem, int> items = new Dictionary<HistItem, int>();
            int offset = 10;

            for (int i = (int)Math.Floor(minY); i < (int)Math.Ceiling(maxY); i += offset)
            {
                HistItem item = new HistItem();
                item.lower_bound = i;
                item.upper_bound = i + offset;

                items[item] = 0;
            } //istogramma con intervalli

            List<HistItem> chiavi = items.Keys.ToList();

            foreach ((double, double) real in reals)
            {
                Boolean ins = false;
                foreach (HistItem item in chiavi)
                {
                    if (item.contains(real.Item1) && !ins)
                    {
                        ins = true;
                        items[item]++;
                    }
                }
            }

            int max = items.Values.Max();
            int space_height = (r1.r.Right - r1.r.Left) / 2; //altezza max per rettangolo contenente istogramma

            foreach (KeyValuePair<HistItem, int> k in items)
            {
                HistItem item = k.Key;

                int r_height = (int)(((double)k.Value / (double)max) * ((double)space_height));

                int lower = Y_Normalization(item.lower_bound, r1.r.Height, maxY, minY, r1.r.Top);
                int upper = Y_Normalization(item.upper_bound, r1.r.Height, maxY, minY, r1.r.Top);

                int size = Math.Abs(lower - upper);

                Rectangle hr = new Rectangle(r1.r.Right, upper, r_height, size);
                g.DrawRectangle(black_pen, hr);
                g.FillRectangle(Brushes.BlueViolet, hr);
            }

            pictureBox1.Image = b;
        }


    }
}