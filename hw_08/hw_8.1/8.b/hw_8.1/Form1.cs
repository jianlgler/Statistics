using Microsoft.VisualBasic.ApplicationServices;

namespace hw_8._1
{
    public partial class Form1 : Form
    {

        Graphics g1;
        Rectangle rect1, rect2, rect3, rect4, rect5;

        Bitmap b1;

        List<double> normals;
        Dictionary<HistItem, int> normal_distr;

        List<double> chi;
        Dictionary<HistItem, int> chi_distr;

        List<double> tstudent;
        Dictionary<HistItem, int> student_distr;

        List<double> fisher;
        Dictionary<HistItem, int> fisher_distr;

        List<double> cauchy;

        Dictionary<HistItem, int> cauchy_distr;

        

        Pen blackPen = new Pen(Color.Black, 3);
   
        public Form1()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g1.Clear(BackColor);
            generate();
          
            drawHistogram(normal_distr, rect1);
            drawHistogram(chi_distr, rect2);
            drawHistogram(student_distr, rect3);
            drawHistogram(cauchy_distr, rect4);
            drawHistogram(fisher_distr, rect5);

            
            g1.DrawString("Normal", DefaultFont, Brushes.White, rect1.Location);
            g1.DrawString("Chi Square", DefaultFont, Brushes.White, rect2.Location);
            g1.DrawString("T-Student", DefaultFont, Brushes.White, rect3.Location);
            g1.DrawString("Cauchy", DefaultFont, Brushes.White, rect4.Location);
            g1.DrawString("Fisher", DefaultFont, Brushes.White, rect5.Location);
        }

        public void InitializeGUI()
        {
            b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(b1);

            
            rect1 = new Rectangle(0, 0, b1.Width / 2 - 10, b1.Height / 2 - 10); 
            rect2 = new Rectangle(b1.Width / 2 + 10, 0, b1.Width / 2 - 10, b1.Height / 2 - 10);
            rect3 = new Rectangle(0, b1.Height / 2, b1.Width / 3 - 10, b1.Height / 2 - 10);
            rect4 = new Rectangle(b1.Width / 3, b1.Height / 2, b1.Width / 3 - 10, b1.Height / 2 - 10);
            rect5 = new Rectangle((2*b1.Width) / 3, b1.Height / 2, b1.Width / 3 - 10, b1.Height / 2 - 10);

            g1.FillRectangle(Brushes.Black, rect1);
            g1.DrawString("Normal", DefaultFont, Brushes.White, rect1.Location);
            g1.FillRectangle(Brushes.Black, rect2);
            g1.DrawString("Chi Square", DefaultFont, Brushes.White, rect2.Location);
            g1.FillRectangle(Brushes.Black, rect3);
            g1.DrawString("T-Student", DefaultFont, Brushes.White, rect3.Location);
            g1.FillRectangle(Brushes.Black, rect4);
            g1.DrawString("Cauchy", DefaultFont, Brushes.White, rect4.Location);
            g1.FillRectangle(Brushes.Black, rect5);
            g1.DrawString("Fisher", DefaultFont, Brushes.White, rect5.Location);

            this.pictureBox1.Image = b1; 
        }
        private void generate()
        {
            normals = new List<double>();
            chi = new List<double>();
            tstudent = new List<double>();
            cauchy = new List<double>();
            fisher = new List<double>();

            int n = 10000;

            NormalRandomVariableGenerator gen = NormalRandomVariableGenerator.getStdGenerator();
            for (int i = 0; i < n; i++)
            {
                double x = gen.X(); double y = gen.Y();

                normals.Add(x); 
                chi.Add(x * x); 
                cauchy.Add(x / y); 
                fisher.Add((x * x) / (y * y));
                tstudent.Add(x / (y * y)); 
            }
            
            double c_avg = cauchy.Average();
            cauchy = cauchy.Where(x => (x >= c_avg - 50 && x <= c_avg + 50)).ToList();

            fisher = fisher.Where(x => (x <= 50)).ToList();
            
            tstudent = tstudent.Where(x => (x >= - 50 && x <= 50)).ToList();
            
            normal_distr = getDistribution(normals, 0.3);
            chi_distr = getDistribution(chi, 0.4);
            student_distr = getDistribution(tstudent, 1);
            cauchy_distr = getDistribution(cauchy, 5);
            fisher_distr = getDistribution(fisher, 1);
        }

        private Dictionary<HistItem, int> getDistribution(List<double> l, double offset)
        {
            Dictionary<HistItem, int> items = new Dictionary<HistItem, int>();
            
            for (double i = Math.Floor(l.Min()); i < (int)Math.Ceiling(l.Max()); i += offset)
            {
                HistItem item = new HistItem();
                item.lower_bound = i;
                item.upper_bound = i + offset;

                items[item] = 0;
            } //istogramma con intervalli

            List<HistItem> chiavi = items.Keys.ToList();

            foreach (double real in l)
            {
                Boolean ins = false;
                foreach (HistItem item in chiavi)
                {
                    if (item.contains(real) && !ins)
                    {
                        ins = true;
                        items[item]++;
                    }
                }
            }
            return items;
        }

        private void drawHistogram(Dictionary<HistItem, int> items, Rectangle r)
        {
            
            g1.FillRectangle(Brushes.Black, r);

            int max = items.Values.Max();
            int space_height = (r.Bottom - r.Top) - 20; //altezza max per rettangolo contenente istogramma
            int start = r.Left;
            int size = r.Width / items.Count;

            foreach (KeyValuePair<HistItem, int> k in items)
            {
                HistItem item = k.Key;

                int r_height = (int)(((double)k.Value / (double)max) * ((double)space_height));

                Rectangle hr = new Rectangle(start, r.Bottom - r_height, size, r_height);
                g1.DrawRectangle(blackPen, hr);
                g1.FillRectangle(Brushes.Green, hr);

                start += size;
            }

            pictureBox1.Image = b1;
        }
    }
}