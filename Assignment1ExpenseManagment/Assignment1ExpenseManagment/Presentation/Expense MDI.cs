using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment1ExpenseManagment;
using Assignment1ExpenseManagment.Business;

namespace Assignment1ExpenseManagment.Presentation
{
    public partial class Expense_MDI : Form
    {

        public Expense_MDI()
        {
            InitializeComponent();
        }

        private void expenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
                Form1 form = new Form1();
                form.MdiParent = this;
                form.Show();
            
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Expense_MDI_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.MdiParent = this;
            form.Show();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseReport form = new ExpenseReport();
            form.MdiParent = this;
            form.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Expense Manager \nDesigned By: Kenneth Harischandra \nAssignment#2", "About", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
