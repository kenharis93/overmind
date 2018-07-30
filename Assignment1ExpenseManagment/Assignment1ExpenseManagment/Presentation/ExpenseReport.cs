using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment1ExpenseManagment;
using Assignment1ExpenseManagment.Business;
using Assignment1ExpenseManagment.Data;

namespace Assignment1ExpenseManagment.Presentation
{
    public partial class ExpenseReport : Form
    {
        public decimal expTotal;
        public decimal expTotalTrans;
        public decimal expTotalLiving;
        public decimal expTotalEnt;
        public decimal expTotalEdu;
        public decimal expTotalMisc;

        private void FillExpenseListView()
        {
            expTotal = 0;
            listViewAll.Items.Clear();
            foreach (var item in Form1.items)
            {
                if(dateTimePickerFrom.Value.AddDays(-1) < DateTime.Parse(item.Date) && DateTime.Parse(item.Date) < dateTimePickerTo.Value)
                {
                    listViewAll.Items.Add(new ListViewItem(new[] {item.Date, item.Type, item.Description, item.Cost.ToString()}));
                    expTotal += item.Cost;
                }
            }
        }

        private decimal FillExpenseTab(ListView listview, String type, decimal exptotals)
        {
            exptotals = 0;
            listview.Items.Clear();
            foreach (var item in Form1.items)
            {
                if ((dateTimePickerFrom.Value.AddDays(-1) < DateTime.Parse(item.Date) && DateTime.Parse(item.Date) < dateTimePickerTo.Value) && (item.Type==type))
                {
                        listview.Items.Add(new ListViewItem(new[] { item.Date, item.Type, item.Description, item.Cost.ToString() }));
                        exptotals += item.Cost;
                }
            }
            return exptotals;
        }

    

        public ExpenseReport()
        {
            InitializeComponent();
        }

        private void ExpenseReport_Load(object sender, EventArgs e)
        {
            listViewColumns(listViewAll);
            listViewColumns(listViewTrans);
            listViewColumns(listViewLiving);
            listViewColumns(listViewEnt);
            listViewColumns(listViewEdu);
            listViewColumns(listViewMisc);
            FillAllListViews();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            FillAllListViews();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            FillAllListViews();
        }

        private void listViewColumns(ListView listview)
        {
            listview.Columns.Add("Date", 100);
            listview.Columns.Add("Type", 110, HorizontalAlignment.Left);
            listview.Columns.Add("Description", 150, HorizontalAlignment.Left);
            listview.Columns.Add("Cost", 100, HorizontalAlignment.Left);
        }

        private void FillAllListViews()
        {
            FillExpenseListView();
           expTotalTrans= FillExpenseTab(listViewTrans, "Transportation", expTotalTrans);
           expTotalLiving= FillExpenseTab(listViewLiving, "Living", expTotalLiving);
           expTotalEnt= FillExpenseTab(listViewEnt, "Entertainment", expTotalEnt);
           expTotalEdu= FillExpenseTab(listViewEdu, "Education", expTotalEdu);
           expTotalMisc= FillExpenseTab(listViewMisc, "Miscellaneous", expTotalMisc);
           expTotal = expTotalTrans + expTotalLiving + expTotalEnt + expTotalEdu + expTotalMisc;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Total Expenses:" +" $"+ expTotal.ToString());
            sb.Append("\nTransportation Expenses:" + " $" + expTotalTrans.ToString());
            sb.Append("\nLiving Expenses:" + " $" + expTotalLiving.ToString());
            sb.Append("\nEntertainment Expenses:" + " $" + expTotalEnt.ToString());
            sb.Append("\nEducation Expenses:" + " $" + expTotalEdu.ToString());
            sb.Append("\nMisc. Expenses:" + " $" + expTotalMisc.ToString());
            MessageBox.Show(sb.ToString(), "Expense Totals",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt";
            savefile.FileName = dateTimePickerFrom.Value.ToShortDateString() + "to" + dateTimePickerTo.Value.ToShortDateString();

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var filePath = savefile.FileName;
                StreamWriter sw = new StreamWriter(filePath);
                        sw.WriteLine("All Expenses");
                        sw.WriteLine("Date, Expense Type, Description, Cost");
                        foreach (ListViewItem item in listViewAll.Items)
                        {
                            sw.WriteLine(item.SubItems[0].Text + "," + item.SubItems[1].Text + "," + item.SubItems[2].Text + "," + item.SubItems[3].Text);
                        }
                        sw.WriteLine(" ");
                        sw.WriteLine("Transportation Total ," + expTotalTrans);
                        sw.WriteLine("Living Total ," + expTotalLiving);
                        sw.WriteLine("Entertainment Total ," + expTotalEnt);
                        sw.WriteLine("Education Total ," + expTotalEdu);
                        sw.WriteLine("Misc. Total ," + expTotalMisc);
                        sw.WriteLine(" ");
                        sw.WriteLine("Total ," + expTotal);
                        sw.Close();

            }
        }
    }
}
