using System.Drawing;
using System.Security;
using System.Security.Authentication;
using System.Windows.Forms;

namespace hw5
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;

        MyRectangle r1;

        Pen pen = new Pen(Color.Orange, 2);
        Random ra = new Random();

        List<Dataframe> frames;
        Dictionary<String, int> protocols;
        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new MyRectangle(pictureBox1.Width / 4, pictureBox1.Height / 8, pictureBox1.Width / 2, 600, pictureBox1, this);

            this.g.DrawRectangle(Pens.Black, r1.r);
            this.pictureBox1.Image = b;
        }
     
        //PREMERE IL BOTTONE FA APRIRE UN FILE SELECTOR, SI SELEZIONA IL CSV DI WIRESHARK
        //E IL PROGRAMMA LO FORMATTA CREANDO UNA LISTA DI PACCHETTI
        //E UN DIZIONARIO DI PROTOCOLLI
        private void button1_Click(object sender, EventArgs e)
        {
            frames = new List<Dataframe>();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    
                    String labels = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        String[] token = line.Replace(@"\", "").Split(",");
                        frames.Add(new Dataframe()
                        {
                            Id = int.Parse(token[0].Trim('"')),
                            Time = token[1],
                            Source = token[2],
                            Destination = token[3],
                            Protocol = token[4],
                            Lenght = token[5],
                            Info = token[6]
                        });
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            protocols = new Dictionary<string, int>();

            foreach (Dataframe f in frames)
            {
               if(!protocols.ContainsKey(f.Protocol)) protocols.Add(f.Protocol, 1);
               else protocols[f.Protocol]++;
            }

            //Console.WriteLine("hey");
            this.button1.Enabled = false;
            timer1.Start();
            g.Clear(BackColor);
            if (this.checkBox1.Checked) redrawH();
            else redrawV();
        }

        private void redrawH()
        {
            int space_height = r1.r.Bottom - r1.r.Top - 20;
            int space_width = r1.r.Right - r1.r.Left - 20;

            g.FillRectangle(Brushes.Black, r1.r);
            g.DrawRectangle(Pens.Black, r1.r);

            int hist_width = space_height / protocols.Count;
            int start = r1.r.Y;

            foreach (KeyValuePair<String, int> k in protocols)
            {
                int rect_height = (int)(((double)k.Value / (double)protocols.Values.Max()) * ((double)space_width));
                Rectangle hr = new Rectangle(r1.r.Left, start, rect_height, hist_width);

                g.FillRectangle(Brushes.Lime, hr);
                g.DrawRectangle(Pens.Black, hr);

                Rectangle stringPos = new Rectangle(r1.r.Left - (hist_width * 5 + 10), start, hist_width * 7, hist_width);
                Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                Font goodFont = reFont(g, k.Key, stringPos.Size, font1);

                g.DrawString(k.Key, goodFont, Brushes.Black, stringPos, stringFormat);

                start += hist_width;
            }

            pictureBox1.Image = b;
        }
        private void redrawV()
        {
            int space_height = r1.r.Bottom - r1.r.Top - 20;
            int space_width = r1.r.Right - r1.r.Left - 20;

            g.FillRectangle(Brushes.Black, r1.r);
            g.DrawRectangle(Pens.Black, r1.r);

            int hist_width = (r1.r.Width) / protocols.Count;
            int start = r1.r.X;

            foreach (KeyValuePair<String, int> k in protocols)
            {
                int r_height = (int)(((double) k.Value / (double) protocols.Values.Max()) * ((double)space_width/2));
                //int rect_height = (int)(((double)p.counter / (double)max) * ((double)space_width));
                Rectangle hr = new Rectangle(start, r1.r.Bottom - r_height, hist_width, r_height);

                g.FillRectangle(Brushes.Lime, hr);
                g.DrawRectangle(Pens.Black, hr);

                Rectangle stringPos = new Rectangle(start, r1.r.Bottom, hist_width, hist_width + 20);
                Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                Font goodFont = reFont(g, k.Key, stringPos.Size, font1);

                g.DrawString(k.Key, goodFont, Brushes.Black, stringPos, stringFormat);

                start += hist_width;
            }
            pictureBox1.Image = b;
        }

        private Font reFont(Graphics g, string myString, Size Room, Font PreferedFont)
        {
            SizeF RealSize = g.MeasureString(myString, PreferedFont);
            float HeightScaleRatio = Room.Height / RealSize.Height;
            float WidthScaleRatio = Room.Width / RealSize.Width;

            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;

            float ScaleFontSize = PreferedFont.Size * ScaleRatio / (2);

            return new Font(PreferedFont.FontFamily, ScaleFontSize/2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            if (this.checkBox1.Checked) redrawH();
            else redrawV();
        }
    }
}