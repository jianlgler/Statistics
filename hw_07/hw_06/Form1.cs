using hw6;
using System.Collections.Generic;
using System.Globalization;

namespace hw_06
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Pen pen = new Pen(Color.LightGreen, 2);

        MyRectangle r1;

        Dictionary<int, List<Point>> all;
        Dictionary<int, int> interarrival_times;

        Random ra = new Random();
        Rectangle window;



        List<Point> last;
        



        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new MyRectangle(pictureBox1.Width / 2, 0, (pictureBox1.Width / 2) - 10, (pictureBox1.Height) - 100, pictureBox1, this);
           

            this.pictureBox1.Image = b;

            //last = new List<Point>();
            //all = new List<List<Point>>();
        }

        private double X_Normalization(double x, double w, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + w * (x - min) / (max - min);
        }

        private double Y_Normalization(double y, double h, double max, double min, int offset)
        {
            if ((max - min) == 0) return 0;
            return offset + h - h * (y - min) / (max - min);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            all = new Dictionary<int, List<Point>>();
            interarrival_times = new Dictionary<int, int>();

            int traj = (int) trackBar1.Value;
            int trials = (int) trackBar2.Value;
            double succ = (double) trackBar3.Value / trials;

            double min_x = 0; double min_y = 0; double max_x = trials; double max_y = trials;
            last = new List<Point>();
            window = new Rectangle(0, 0, (pictureBox1.Width / 2) - 10, (pictureBox1.Height) - 10);
            
            for (int i = 0; i < traj; i++)
            {
                List<Point> punti = new List<Point>();
                double y = 0;
                int interval = 0;
                for (int x = 0; x < trials; x++)
                {

                    ra.NextDouble();

                    if (ra.NextDouble() < succ)
                    {
                        y++;
                        if (!interarrival_times.ContainsKey(interval)) interarrival_times.Add(interval, 1);
                        else interarrival_times[interval]++;
                        interval = 0;
                    }
                    else interval++;

                    int x_var = (int)X_Normalization(x, window.Width, max_x, min_x, window.Left);

                    int y_var = (int)Y_Normalization(y, window.Height, max_y, min_y, window.Top);

                    Point p = new Point(x_var, y_var);
                    punti.Add(p);
                    //all.Add(punti);
                    if (x == trials - 1)
                    {
                        last.Add(p);
                    }
                }
                all.Add(i, punti);
                g.DrawLines(pen, punti.ToArray());
                
                
            }
            timer1.Start();
            draw();

            pictureBox1.Image = b;
        }

        private void draw()
        {
            g.FillRectangle(Brushes.Black, window);
            g.DrawRectangle(Pens.Black, window);
            foreach (var l in all.Values)
            {
                g.DrawLines(pen, l.ToArray());
            }
            

            g.FillRectangle(Brushes.Black, r1.r);
            g.DrawRectangle(Pens.Black, r1.r);

            int space_height = r1.r.Bottom - r1.r.Top - 20;
            int space_width = r1.r.Right - r1.r.Left - 20;


            int hist_width = space_width / interarrival_times.Keys.Count;

            int start = r1.r.X + 10;

            foreach (KeyValuePair<int, int> k in interarrival_times)
            {
                int r_height = (int)(((double)k.Value / (double)interarrival_times.Values.Max()) * ((double)space_height));

                Rectangle hr = new Rectangle(start, r1.r.Bottom - r_height, hist_width, r_height);

                g.FillRectangle(Brushes.Lime, hr);
                g.DrawRectangle(Pens.Black, hr);

                Rectangle stringPos = new Rectangle(start, r1.r.Bottom - 10, hist_width, hist_width + 20);
                Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                Font goodFont = reFont(g, k.Key.ToString(), stringPos.Size, font1);

                g.DrawString(k.Key.ToString(), goodFont, Brushes.Black, stringPos, stringFormat);

                start += hist_width;
            }

            pictureBox1.Image = b;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Trajectories: " + trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Trials: " + trackBar2.Value;
            trackBar3.Maximum = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Arrival rate: " + trackBar3.Value;
        }

        private Font reFont(Graphics g, string myString, Size Room, Font PreferedFont)
        {
            SizeF RealSize = g.MeasureString(myString, PreferedFont);
            float HeightScaleRatio = Room.Height / RealSize.Height;
            float WidthScaleRatio = Room.Width / RealSize.Width;

            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;

            float ScaleFontSize = PreferedFont.Size * ScaleRatio / (2);

            return new Font(PreferedFont.FontFamily, ScaleFontSize );
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            draw(); 

        }

        
    }
}