﻿using System;
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
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            firstLevel = new FirstLevel(tmp.Count, tmp);
            firstLevel.GenerateStartSolution(4);
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
