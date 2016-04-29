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
        private List<Batch> temp;
        private BatchesGroup group;
        private FirstLevel firstLevel;

        public Form1()
        {
            InitializeComponent();
            Batch x1 = new Batch(10, 1);
            Batch x2 = new Batch(2, 1);
            Batch x3 = new Batch(2, 1);
            Batch x4 = new Batch(2, 1);

            temp = new List<Batch>();
            temp.Add(x1);
            temp.Add(x2);
            temp.Add(x3);
            temp.Add(x4);
            group = new BatchesGroup(temp);
            List<int> tmp = new List<int>();
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            tmp.Add(16);
            firstLevel = new FirstLevel(4,tmp);
            firstLevel.GenerateStartSolution();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            group.modificationBatches(3,0,2);
            MessageBox.Show(group.printList());
        }
    }
}
