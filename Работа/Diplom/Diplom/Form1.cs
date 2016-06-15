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

        public Form1()
        {
            InitializeComponent();
            CountTypeDGV[0, 0].Value = this.countClaims;
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
