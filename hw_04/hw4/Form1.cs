using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hw4
{
    public partial class Form1 : Form
    {
        private Bitmap b;
        private Graphics g;
        Pen pen = new Pen(Color.Orange, 2);
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "0,5";
        }

        private double X_Normalization(double x, double w, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + w * (x - min) / (max - min);
        }

        private double Y_Normalization(double y, double h, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + h - h * (y - min)  / (max - min);
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //RELATIVE
            b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            double n = (double) trackBar1.Value;
            double m = (double) trackBar2.Value;
            double succ;
            if (!Double.TryParse(comboBox1.Text, out succ)) succ = 0.5;
            if (succ > 1 || succ < 0) succ = 0.5;
            comboBox1.Text = succ.ToString();
            double min_x = 0; double min_y = 0; double max_x = n; double max_y = 1;

            Rectangle window = new Rectangle(20, 20, b.Width - 300, b.Height - 40);

            g.DrawRectangle(Pens.DarkSlateGray, window);
            List<Point> last = new List<Point>();
            for (int i = 0; i < m; i++)
            {
                List<Point> punti = new List<Point>();
                double y = 0;
                for(int x = 0; x < n; x++)
                {
                    double var = r.NextDouble();
                    if (var > succ) y++;

                    double x_var = X_Normalization(x, window.Width, max_x, min_x, window.Left);
                    double y_var = Y_Normalization(y / (x + 1), window.Height, max_y, min_y, window.Top);

                    punti.Add(new Point((int) x_var, (int) y_var));
                    if (x == n - 1) last.Add(new Point((int)x_var, (int)y_var));
                }
                g.DrawLines(pen, punti.ToArray());
            }
            double min_y_1 = last.Min(p => p.Y); double max_y_1 = last.Max(p => p.Y); //numero minimo e massimo di croci uscite
            
            Rectangle window2 = new Rectangle(window.Right + 10, 20, 260, b.Height - 40);
            g.DrawRectangle(Pens.Black, window2);
            
            if(m == 1)
            {
                foreach(Point p in last)
                {
                    Rectangle r = new Rectangle(window2.Left + 10, p.Y - 10, window2.Right - window2.Left - 20, 20);
                    g.FillRectangle(Brushes.Orange, r);
                    g.DrawRectangle(Pens.White, r);
                }
            }
            else
            {
                double intervals = m / 2;

                if (m > 15) intervals = 15;
                if (m <= 0) intervals = 1;

                double lenght = max_y_1 - min_y_1;
                double size = lenght / intervals;

                while(min_y_1 + size * intervals < max_y_1 + 1) intervals++;

                double min = min_y_1;

                Dictionary<Interval, int> d = new Dictionary<Interval, int>();

                for(int j = 0; j < intervals; j++)
                {
                    Interval intervall = new Interval(min, min + size);
                    min += size;
                    d[intervall] = 0; //inizializzazione
                }
                foreach(Point p in last)
                {
                    List<Interval> inter = d.Keys.ToList();
                    int ipsilon = (int)p.Y;
                    foreach(Interval i in inter)
                    {
                        if(ipsilon >= i.down && ipsilon < i.up)
                        {
                            d[i]++;
                        }
                    }
                }
                List<Rectangle> chart = new List<Rectangle>();
                int dim = window2.Right - window2.Left - 20;
                int maxv = d.Values.Max();

                foreach(var v in d)
                {
                    double intensity = ((double)v.Value / (double)maxv) * dim;
                    Rectangle rect = new Rectangle(window2.Left + 10, (int)v.Key.down, (int)intensity, (int)size);
                    chart.Add(rect);
                }
                foreach (Rectangle re in chart)
                {
                    g.FillRectangle(Brushes.Orange, re);
                    g.DrawRectangle(Pens.White, re);
                }
            }

            pictureBox1.Image = b;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //NORMALIZED
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            //trajectory generation ----------------------------------------------

            int n = trackBar1.Value; int m = trackBar2.Value;
            double succ;
            if (!Double.TryParse(comboBox1.Text, out succ)) succ = 0.5;
            if (succ > 1 || succ < 0) succ = 0.5;
            comboBox1.Text = succ.ToString();

            double min_x = 0; double min_y = 0; double max_x = n;
           
            double max_y = ((double)n) * succ;

            Rectangle rr = new Rectangle(20, 20, b.Width - 300, b.Height - 40);

            g.DrawRectangle(Pens.Black, rr);

            List<Point> last = new List<Point>();

            for (int i = 0; i < m; i++)
            {
                List<Point> punti = new List<Point>();
                double y = 0;

                for (int x = 0; x < n; x++)
                {
                    r.NextDouble();

                    if (r.NextDouble() < succ) y++;

                    
                    int x_var = (int) X_Normalization(x, rr.Width, max_x, min_x, rr.Left);
                    
                    int y_var = (int) Y_Normalization(y/ Math.Sqrt(x + 1), rr.Height, max_y, min_y, rr.Top);

                    Point p = new Point(x_var, y_var);
                    punti.Add(p);

                    if (x == n - 1)
                    {
                        last.Add(p);
                    }
                }
                g.DrawLines(pen, punti.ToArray());
            }

            int min_y_1 = last.Min(p => p.Y); int max_y_1 = last.Max(p => p.Y);

            Rectangle window2 = new Rectangle(rr.Right + 10, 20, 260, b.Height - 40);
            g.DrawRectangle(Pens.Black, window2);

            if (m == 1)
            {
                foreach (Point p in last)
                {
                    Rectangle r = new Rectangle(window2.Left + 10, p.Y - 10, window2.Right - window2.Left - 20, 20);
                    g.FillRectangle(Brushes.Orange, r);
                    g.DrawRectangle(Pens.White, r);
                }
            }
            else
            {
                int intervals = m / 6;
                if (intervals > 15)
                {
                    intervals = 15;
                }
                else if (intervals <= 0)
                {
                    intervals = 1;
                }

                int lenght = max_y_1 - min_y_1;
                int interval_size = lenght / intervals;

                while (min_y + interval_size * intervals < max_y + 1)
                {
                    intervals++;
                }

                int min = min_y_1;

                Dictionary<Interval, int> intervalli = new Dictionary<Interval, int>();

                for (int j = 0; j < intervals; j++)
                {
                    Interval intervallo = new Interval(min, min + interval_size);
                    min = min + interval_size;
                    intervalli[intervallo] = 0;
                }

                foreach (Point p in last)
                {
                    List<Interval> inter = intervalli.Keys.ToList();
                    int intY = (int)p.Y;

                    foreach (Interval i in inter)
                    {
                        if (intY >= i.down && intY < i.up)
                        {
                            intervalli[i]++;
                        }
                    }
                }

                List<Rectangle> chart = new List<Rectangle>();

                int dimdisp = window2.Right - window2.Left - 20;
                int maxValue = intervalli.Values.Max();

                foreach (var v in intervalli)
                {
                    double intensity = ((double)v.Value / (double)maxValue) * dimdisp;
                    Rectangle rect = new Rectangle(window2.Left + 10, (int)v.Key.down, (int)intensity, interval_size);
                    chart.Add(rect);
                }

                foreach (Rectangle re in chart)
                {
                    g.FillRectangle(Brushes.Orange, re);
                    g.DrawRectangle(Pens.White, re);
                }

            }

            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //abs
            b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            double n = (double)trackBar1.Value;
            double m = (double)trackBar2.Value;
            double succ;
            if (!Double.TryParse(comboBox1.Text, out succ)) succ = 0.5;
            if (succ > 1 || succ < 0) succ = 0.5;
            comboBox1.Text = succ.ToString();
            double min_x = 0; double min_y = 0; double max_x = n; double max_y = n;

            Rectangle window = new Rectangle(20, 20, b.Width - 300, b.Height - 40);

            g.DrawRectangle(Pens.DarkSlateGray, window);
            List<Point> last = new List<Point>();
            for (int i = 0; i < m; i++)
            {
                List<Point> punti = new List<Point>();
                double y = 0;
                for (int x = 0; x < n; x++)
                {
                    double var = r.NextDouble();
                    if (var > succ) y++;

                    double x_var = X_Normalization(x, window.Width, max_x, min_x, window.Left);
                    double y_var = Y_Normalization(y , window.Height, max_y, min_y, window.Top);

                    punti.Add(new Point((int)x_var, (int)y_var));
                    if (x == n - 1) last.Add(new Point((int)x_var, (int)y_var));
                }
                g.DrawLines(pen, punti.ToArray());
            }
            double min_y_1 = last.Min(p => p.Y); double max_y_1 = last.Max(p => p.Y); //numero minimo e massimo di croci uscite

            Rectangle window2 = new Rectangle(window.Right + 10, 20, 260, b.Height - 40);
            g.DrawRectangle(Pens.Black, window2);

            if (m == 1)
            {
                foreach (Point p in last)
                {
                    Rectangle r = new Rectangle(window2.Left + 10, p.Y - 10, window2.Right - window2.Left - 20, 20);
                    g.FillRectangle(Brushes.Orange, r);
                    g.DrawRectangle(Pens.White, r);
                }
            }
            else
            {
                double intervals = m / 2;

                if (m > 15) intervals = 15;
                if (m <= 0) intervals = 1;

                double lenght = max_y_1 - min_y_1;
                double size = lenght / intervals;

                while (min_y_1 + size * intervals < max_y_1 + 1) intervals++;

                double min = min_y_1;

                Dictionary<Interval, int> d = new Dictionary<Interval, int>();

                for (int j = 0; j < intervals; j++)
                {
                    Interval intervall = new Interval(min, min + size);
                    min += size;
                    d[intervall] = 0; //inizializzazione
                }
                foreach (Point p in last)
                {
                    List<Interval> inter = d.Keys.ToList();
                    int ipsilon = (int)p.Y;
                    foreach (Interval i in inter)
                    {
                        if (ipsilon >= i.down && ipsilon < i.up)
                        {
                            d[i]++;
                        }
                    }
                }
                List<Rectangle> chart = new List<Rectangle>();
                int dim = window2.Right - window2.Left - 20;
                int maxv = d.Values.Max();

                foreach (var v in d)
                {
                    double intensity = ((double)v.Value / (double)maxv) * dim;
                    Rectangle rect = new Rectangle(window2.Left + 10, (int)v.Key.down, (int)intensity, (int)size);
                    chart.Add(rect);
                }
                foreach (Rectangle re in chart)
                {
                    g.FillRectangle(Brushes.Orange, re);
                    g.DrawRectangle(Pens.White, re);
                }
            }

            pictureBox1.Image = b;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Trials: " + trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Trajectories: " + trackBar2.Value;
        }
    }
}