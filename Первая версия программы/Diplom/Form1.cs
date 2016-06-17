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
    public partial class Form1 : Form
    {
        private FirstLevel firstLevel;
        private int countClaims = 16;
        private bool timeFlag = true;
        private List<List<List<int>>> tS;
        private List<List<int>> tT;
        private int l;
        private int tz;
        private int maxT;
        private int maxS;

        public Form1()
        {
            InitializeComponent();
            CountTypeDGV[0, 0].Value = this.countClaims;
            l = 4;
            tz = 100;
            maxS = 2;
            maxT = 2;
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

        private void PrintTime()
        {
            dataGridView1.Columns.Clear();
            for (int i = 0; i < l; i++)
            {
                dataGridView1.Columns.Add("col" + i, "Прибор " + (i + 1));
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1[i, j].Value = tT[i][j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timeFlag == true)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < numericTypeCount.Value; i++)
                {
                    tmp.Add(Convert.ToInt32(CountTypeDGV[i, 0].Value));
                }
                //tmp.Add(16);
                //tmp.Add(16);
                //tmp.Add(16);
                firstLevel = new FirstLevel(tmp.Count, tmp);
                firstLevel.GenerateSolution();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         SecondLevel  secondLevel=new SecondLevel();
         secondLevel.InitialConditions(Convert.ToInt16(numericTypeCount.Value));
         
   
            List<List<int>> A=new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                List<int> w = new List<int>();
                A.Add(w);
            }
            A[0].Add(12); A[0].Add(12); A[0].Add(2); A[0].Add(2);
            A[1].Add(12); A[1].Add(12); A[1].Add(2); A[1].Add(2);
            A[2].Add(12); A[2].Add(13); A[2].Add(3);
            A[3].Add(12); A[3].Add(10); A[3].Add(2); A[3].Add(2); A[3].Add(2);
            A[4].Add(12); A[4].Add(8); A[4].Add(2); A[4].Add(2); A[4].Add(2); A[4].Add(2);

            secondLevel.GenerateSolution(A);


        }

        private void numericTypeCount_ValueChanged(object sender, EventArgs e)
        {
            CountTypeDGV.Columns.Clear();
            for (int i = 0; i < numericTypeCount.Value; i++)
            {
                CountTypeDGV.Columns.Add("col" + i, "Тип " + (i + 1));
                CountTypeDGV[i, 0].Value = this.countClaims;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SecondLevel.c = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            FirstLevel.flag = checkBox2.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TimeForm tForm = new TimeForm();
            tForm.Show();
            timeFlag = true;
            this.maxS = TimeForm.maxS;
            this.maxT = TimeForm.maxT;
            this.l = TimeForm.l;
            this.tz = TimeForm.tz;
            this.tS = TimeForm.tS;
            this.tT = TimeForm.tT;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l = (int)numericUpDown1.Value;
            tz = Convert.ToInt32(textBox1.Text);
            maxT = Convert.ToInt32(textBox2.Text);
            maxS = Convert.ToInt32(textBox3.Text);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tz = Convert.ToInt32(textBox1.Text);
            this.RandomTime();
            //this.PrintTime();
        }
    }
}
