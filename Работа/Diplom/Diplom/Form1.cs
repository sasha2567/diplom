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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> tmp = new List<int>();
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            firstLevel = new FirstLevel(tmp.Count, tmp);
            firstLevel.GenerateSolution();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         SecondLevel  secondLevel=new SecondLevel();
         secondLevel.InitialConditions(Convert.ToInt16(textBox1.Text));
         secondLevel.Algoritm_2();
         
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
