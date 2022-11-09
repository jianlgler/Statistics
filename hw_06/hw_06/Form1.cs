using hw6;
using System.Globalization;

namespace hw_06
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Pen pen = new Pen(Color.Orange, 2);

        MyRectangle r1, r2;

        Dictionary<int, int> means;
        Dictionary<int, int> vars;

        double[] vmeans;
        double[] vvariances;
        double[][] a;

        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new MyRectangle(0, 0, pictureBox1.Width / 3, pictureBox1.Height / 3, pictureBox1, this);
            r2 = new MyRectangle((pictureBox1.Width / 3) + 20, (pictureBox1.Height / 3) + 20, 
                                pictureBox1.Width / 3, pictureBox1.Height / 3, pictureBox1, this);

            this.pictureBox1.Image = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sample = (int) trackBar1.Value;
            int size = (int) trackBar2.Value;

            means = new Dictionary<int, int>();
            vars = new Dictionary<int, int>();

            vmeans = new double[sample];
            vvariances = new double[sample];
            a = new double[sample][];

            for (int i = 0; i < sample; i++) //computing "sample" samples of size "size" each one.
            {
                Sample s = new Sample(size);

                a[i] = new double[size];
                for(int j = 0; j < size; j++)
                {
                    a[i][j] = s.getBatch().ElementAt(j).getValue();
                }

                vmeans[i] = s.getMean();
                vvariances[i] = s.getVariance();

                if(!means.ContainsKey((int) s.getMean())) means.Add((int) s.getMean(), 1);
                else means[(int) s.getMean()]++;

                if (!vars.ContainsKey((int) s.getVariance())) vars.Add((int) s.getVariance(), 1);
                else vars[(int) s.getVariance()]++;
            }

            timer1.Start();
            draw_mean();
            draw_variance();

            double pop_mean = 0;
            for(int i = 0; i < sample; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    pop_mean += a[i][j];
                }
            }
            pop_mean /= size*sample;

            double pop_var = calc_variance(a, pop_mean);

            double sampmean_exp = calc_mean(vmeans); double sampvariance_exp = calc_mean(vvariances);
            double sampmean_var = calc_variance(vmeans);  double sampvariance_var = calc_variance(vvariances);

            richTextBox1.AppendText("population_mean: " + pop_mean + "\t"); richTextBox1.AppendText("sampling_mean_mean: " + sampmean_exp + "\t"); richTextBox1.AppendText("sampling_variance_variance: " + sampvariance_exp + "\n");
            richTextBox1.AppendText("population_variance: " + pop_var + "\t"); richTextBox1.AppendText("sampling_mean_variance: " + sampmean_var + "\t"); richTextBox1.AppendText("sampling_variance_variance: " + sampvariance_var + "\n");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "sample: " + trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "size: " + trackBar2.Value;
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

        private void draw_mean()
        {
            g.FillRectangle(Brushes.Black, r1.r);
            g.DrawRectangle(Pens.Black, r1.r);

            int space_height = r1.r.Bottom - r1.r.Top - 20;
            int space_width = r1.r.Right - r1.r.Left - 20;

            
            int hist_width = space_width / means.Keys.Count;

            int start = r1.r.X + 10;
            
            foreach (KeyValuePair<int, int> k in means)
            {
                int r_height = (int)(((double)k.Value / (double)means.Values.Max()) * ((double)space_height));
                
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

        private void draw_variance()
        {
            g.FillRectangle(Brushes.Black, r2.r);
            g.DrawRectangle(Pens.Black, r2.r);

            int space_height = r2.r.Bottom - r2.r.Top - 20;
            int space_width = r2.r.Right - r2.r.Left - 20;


            int hist_width = space_width / vars.Keys.Count;

            int start = r2.r.X + 10;

            foreach (KeyValuePair<int, int> k in vars)
            {
                int r_height = (int)(((double)k.Value / (double)vars.Values.Max()) * ((double)space_height));

                Rectangle hr = new Rectangle(start, r2.r.Bottom - r_height, hist_width, r_height);

                g.FillRectangle(Brushes.Lime, hr);
                g.DrawRectangle(Pens.Black, hr);

                Rectangle stringPos = new Rectangle(start, r2.r.Bottom - 10, hist_width, hist_width + 20);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            draw_mean(); draw_variance();
        }

        private double calc_mean(double[] x)
        {
            return x.Average();
        }

        private double calc_variance(double[] x)
        {

            if (x.Length > 1)
            {
                double avg = calc_mean(x);
                double variance = 0.0;
                foreach (double value in x)
                {
                    // Math.Pow to calculate variance? 
                    variance += Math.Pow(value - avg, 2.0);
                }
                return variance / x.Length; // For sample variance
            }
            else
            {
                return 0.0;
            }
        }

        private double calc_variance(double[][] x, double avg)
        {

            if (x.Length > 1)
            {
                double variance = 0.0;
                for(int i = 0; i < x.Length; i++)
                {
                    for(int j = 0; j < x[i].Length; j++)
                    {
                        // Math.Pow to calculate variance? 
                        variance += Math.Pow(x[i][j] - avg, 2.0);
                    }
                }
                return variance / (x.Length * x[0].Length); // For sample variance
            }
            else
            {
                return 0.0;
            }
        }
    }
}