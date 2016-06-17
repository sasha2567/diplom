using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class TimeForm : Form
    {
        public static List<List<List<int>>> tS;
        public static List<List<int>> tT;
        public static int l;
        public static int tz;
        public static int maxT;
        public static int maxS;

        public TimeForm()
        {
            l = 4;
            tz = 100;
            maxS = 2;
            maxT = 2;
            InitializeComponent();
            this.RandomTime();
            //this.PrintTime();
            textBox1.Text = tz.ToString();
            textBox2.Text = maxT.ToString();
            textBox3.Text = maxS.ToString();
            numericUpDown1.Value = l;
        }
        
        private void RandomTime()
        {
            List<List<List<int>>> temptS = new List<List<List<int>>>();
            List<List<int>> temptT = new List<List<int>>();
            Random rand = new Random();
            for (int i = 0; i < l; i++)
            {
                temptT.Add(new List<int>());
                temptS.Add(new List<List<int>>());
                for (int j = 0; j < 4; j++)
                {
                    int temp = rand.Next(2, maxT);
                    temptT[i].Add(temp);
                    temptS[i].Add(new List<int>());
                    for (int k = 0; k < 4; k++)
                    {
                        temp = rand.Next(2, maxS);
                        temptS[i][j].Add(temp);
                    }
                }
            }
            tT = temptT;
            tS = temptS;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            l = (int)numericUpDown1.Value;
            tz = Convert.ToInt32(textBox1.Text);
            maxT = Convert.ToInt32(textBox2.Text);
            maxS = Convert.ToInt32(textBox3.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            l = (int)numericUpDown1.Value;
            this.RandomTime();
            //this.PrintTime();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            maxT = Convert.ToInt32(textBox2.Text);
            this.RandomTime();
            //this.PrintTime();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            maxS = Convert.ToInt32(textBox3.Text);
            this.RandomTime();
            //this.PrintTime();
        }
    }
}
