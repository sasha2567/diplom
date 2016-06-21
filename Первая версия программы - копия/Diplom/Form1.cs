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
            this.PrintTime();
            textBox1.Text = tz.ToString();
            textBox2.Text = maxT.ToString();
            textBox3.Text = maxS.ToString();
            numericUpDown1.Value = l;
            checkBox2.Checked = true;
            FirstLevel.flag = checkBox2.Checked;
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
                for (int j = 0; j < numericTypeCount.Value; j++)
                {
                    int temp = rand.Next(2, maxT);
                    temptT[i].Add(temp);
                    temptS[i].Add(new List<int>());
                    for (int k = 0; k < numericTypeCount.Value; k++)
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
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.RowCount = tT.Count;
            for (int i = 0; i < tT.Count; i++)
            {
                dataGridView1.Columns.Add("col" + i, "Тип " + (i + 1));
            }
            for (int i = 0; i < tT.Count; i++)
            {
                for (int j = 0; j < numericTypeCount.Value; j++)
                {
                    dataGridView1[j, i].Value = tT[i][j];
                }
            }
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.RowCount = tS.Count * tS[0].Count;
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
            this.RandomTime();
            this.PrintTime();
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
            SecondLevel.Tz = tz;
            SecondLevel.countL = l;
            Shedule.L = l;
            Shedule.maxTimeSwitching = maxS;
            Shedule.maxTimeTreatment = maxT;
            Shedule.TSwitching = tS;
            Shedule.TTreatment = tT;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Random t=new Random();

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            try
            {
                for (int i = 0; i < numericTypeCount.Value; i++)
                {
                    dataGridView2.Columns.Add("прибор", "прибор " + (i+1).ToString());
                    dataGridView2.Rows.Add();
                }
                for (int i = 0; i < numericTypeCount.Value; i++)
                    for (int j = 0; j < numericTypeCount.Value; j++)
                {
                    dataGridView2[i, j].Value = t.Next(10);
                }

                maxS = Convert.ToInt32(textBox2.Text);
                this.RandomTime();
                this.PrintTime();
            }
            catch
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                maxT = Convert.ToInt32(textBox3.Text);
                this.RandomTime();
                this.PrintTime();

            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tz = Convert.ToInt32(textBox1.Text);
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SecondLevel.c = false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                l = (int)numericUpDown1.Value;
                this.RandomTime();
                this.PrintTime();
            }
            catch
            {

            }
        }
    }
}
