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
            List<int> tmp = new List<int>();
            tmp.Add(3);
            tmp.Add(17);
            tmp.Add(3);
            tmp.Add(19);
            firstLevel = new FirstLevel(tmp.Count, tmp);
            firstLevel.GenerateStartSolution();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         SecondLevel  sl=new SecondLevel();
         sl.nach_uslov(Convert.ToInt16(textBox1.Text));
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
