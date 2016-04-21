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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Batch x1 = new Batch(10, 1);
            Batch x2 = new Batch(2, 1);
            Batch x3 = new Batch(2, 1);
            Batch x4 = new Batch(2, 1);
            List<Batch> temp = new List<Batch>();
            temp.Add(x1);
            temp.Add(x2);
            temp.Add(x3);
            temp.Add(x4);
            BatchesGroup group = new BatchesGroup(temp);
            group.modificationBatches(3,0,2);
            MessageBox.Show(group.printList());
        }
    }
}
