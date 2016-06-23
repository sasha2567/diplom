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
            dataGridView1.ColumnCount = tT[0].Count;
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
            dataGridView2.ColumnCount = tS[0].Count;
            for (int k = 0; k < tS.Count; k++)
                for (int i = 0; i < numericTypeCount.Value; i++)
                    for (int j = 0; j < numericTypeCount.Value; j++)
                    {
                        int str = k * tS[0].Count + i;
                        dataGridView2[j, str].Value = tS[k][i][j];
                        //dataGridView2[j, k].Value = tS[k][i][j];
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.l = (int)numericUpDown1.Value;
            this.tz = Convert.ToInt32(textBox1.Text);
            this.maxT = Convert.ToInt32(textBox2.Text);
            this.maxS = Convert.ToInt32(textBox3.Text);
            SecondLevel.Tz = this.tz;
            SecondLevel.countL = this.l;
            Shedule.L = this.l;
            Shedule.maxTimeSwitching = this.maxS;
            Shedule.maxTimeTreatment = this.maxT;
            Shedule.TSwitching = this.tS;
            Shedule.TTreatment = this.tT;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.maxS = Convert.ToInt32(textBox2.Text);
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
                this.maxT = Convert.ToInt32(textBox3.Text);
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
                this.tz = Convert.ToInt32(textBox1.Text);
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
                this.l = (int)numericUpDown1.Value;
                this.RandomTime();
                this.PrintTime();
            }
            catch
            {

            }
        }
    }
}
