using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlooringOrdering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void displayOrderBtn_Click(object sender, EventArgs e)
        {
            var form = new displayOrderFrm();
            form.ShowDialog();
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            var form = new AddOrderFrm();
            form.ShowDialog();
        }
    }
}
