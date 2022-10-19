using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace homework_3
{
    public partial class Form1 : Form
    {
        public Random R = new Random();
        
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int stud_n = 100;
            richTextBox1.AppendText("DATASET - Cryptography exam: Student's Grades" + Environment.NewLine + Environment.NewLine);
            richTextBox1.AppendText("Total count: " + stud_n + "\n\n");

            List<Student> l = new List<Student>();
            for (int i = 0; i < stud_n; i++)
            {
                int n = R.Next(0, 31);
                richTextBox1.AppendText("Student " + i + "\t" + n + Environment.NewLine);
                l.Add(new Student() { Name = "Student " + i, Grade = n });
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private int i = 0;
        private double c_mean = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            int n = R.Next(0, 31);
            c_mean += (n - c_mean) / i;
            richTextBox1.AppendText("Student " + i + "\t" + n + "\tMean = " + c_mean + "\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        List<Frame> frames;
        private void button1_Click_1(object sender, EventArgs e)
        {
            frames = new List<Frame>();
            richTextBox2.Clear();
            button3.Enabled = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Clear();
                    String labels = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        String[] token = line.Replace(@"\", "").Split(",");
                        frames.Add(new Frame() { No = int.Parse(token[0].Trim('"')), Time = token[1], Source = token[2], 
                                                Destination = token[3],  Protocol = token[4],  
                                                Lenght = token[5], Info = token[6]});
                    }
                    
                    foreach (Frame frame in frames)
                    {
                        richTextBox1.AppendText("Num:"+frame.No + "\tSrc:" + frame.Source + "\tDest:" 
                                    + frame.Destination + "\tProt:" + frame.Protocol + "\tL:"+ frame.Lenght + "\n");
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

        }
        List<String> prots;
        private void button2_Click_1(object sender, EventArgs e)
        {
            prots = new List<String>();
            richTextBox2.Clear();
            foreach (Frame frame in frames)
            {
                if (!prots.Contains(frame.Protocol))
                {
                    prots.Add(frame.Protocol);
                    richTextBox2.AppendText(frame.Protocol.Trim('"') + "\t");
                } 
            }
            button3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            double tot = frames.Count;
            var g = frames.GroupBy(x => x.Protocol);
            foreach(var grp in g)
            {
                double num = grp.Count();
                double freq = (num/tot);
                richTextBox2.AppendText(grp.Key.Trim('"') + "_freq: " + Math.Round(freq, 2) + "--> " + Math.Round(freq, 2)*100 + "%\n");
            }
        }
    }
}