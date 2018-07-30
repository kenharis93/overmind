using Assignment1ExpenseManagment.Business;
using Assignment1ExpenseManagment.Data;
using Assignment1ExpenseManagment.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1ExpenseManagment
{
    public partial class Form1 : Form
    {
        ExpenseDB db = new ExpenseDB();
        FormNewExpenseItem newExpenseItem = new FormNewExpenseItem();
        public static List<ExpenseItem> items;
        public static string control;
        public static string udate;
        public static string utype;
        public static string udescription;
        public static decimal ucost;

        private void FillExpenseListBox()
        {
            listBoxExpenses.Items.Clear();
            db.Dbtolist();
            items = db.GetListItems();
            foreach (var item in items)
            {
                listBoxExpenses.Items.Add(item.GetDisplayText());
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillExpenseListBox();
            txtFind.Text = "Find an Item using Item name (Eg. Gas)...";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            newExpenseItem.Item = null;
            DialogResult result = newExpenseItem.ShowDialog();
            if (result == DialogResult.OK)
            {
                //ExpenseItem item = newExpenseItem.Item;
                //items.Add(item);

                FillExpenseListBox();
            }

        }
   
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxExpenses.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select an item to delete. ", "Delete Item", MessageBoxButtons.OK);
            }
            else
            {
                //List<ExpenseItem> items = db.GetListItems();
                string name = items[listBoxExpenses.SelectedIndex].Date + " " + items[listBoxExpenses.SelectedIndex].Description;
                DialogResult result = MessageBox.Show(this, "Would you like to delete " + name, "Delete Item", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //items.RemoveAt(listBoxExpenses.SelectedIndex);
                    /////
                    string connection = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = ExpenseDB; Integrated Security = True"; 
                    SqlConnection cnn = new SqlConnection(connection);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = "Delete expenses where datei=" +"'"+ items[listBoxExpenses.SelectedIndex].Date +"'" + " and descriptioni=" + "'" + items[listBoxExpenses.SelectedIndex].Description + "'" + " and costi=" + "'" + items[listBoxExpenses.SelectedIndex].Cost + "'";

                    command = new SqlCommand(sql, cnn);
                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    cnn.Close();
                    /////
                    FillExpenseListBox();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            control = "update";
            if (listBoxExpenses.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select an item to update. ", "Update Item", MessageBoxButtons.OK);
            }
            else
            {
                //List<ExpenseItem> items = db.GetListItems();
                string name = items[listBoxExpenses.SelectedIndex].Date + " " + items[listBoxExpenses.SelectedIndex].Description;
                DialogResult result = MessageBox.Show(this, "Would you like to update " + name, "Update Item", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    newExpenseItem.Item = items[listBoxExpenses.SelectedIndex];
                    /////
                    // Using Below Static values to pass to other form to be utilized in SQL statement
                    udate = items[listBoxExpenses.SelectedIndex].Date;
                    utype = items[listBoxExpenses.SelectedIndex].Type;
                    udescription = items[listBoxExpenses.SelectedIndex].Description;
                    ucost = items[listBoxExpenses.SelectedIndex].Cost;
                    
                    /////
                    DialogResult result1 = newExpenseItem.ShowDialog(this);
                    if (result1 == DialogResult.OK)
                    {
                        
                        // items[listBoxExpenses.SelectedIndex] = newExpenseItem.Item;

                        /////2
                        //string connection = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = ExpenseDB; Integrated Security = True";
                        //SqlConnection cnn = new SqlConnection(connection);
                        //cnn.Open();
                        //SqlCommand command;
                        //SqlDataAdapter adapter = new SqlDataAdapter();
                        //string sql = "update expenses set datei =, typei = where expenseid=" + "'" + (listBoxExpenses.SelectedIndex + 1) + "'";

                        //command = new SqlCommand(sql, cnn);
                        //adapter.DeleteCommand = command;
                        //adapter.DeleteCommand.ExecuteNonQuery();
                        //cnn.Close();
                        ///////

                        FillExpenseListBox();
                    }
                }
            }
            control = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findItem();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtFind_MouseClick(object sender, MouseEventArgs e)
        {
            txtFind.Clear();
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(this, new EventArgs());
            }
        }

        private void findItem()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ExpenseItem item in items)
            {
                if (txtFind.Text.ToLower().Equals(item.Description.ToLower().ToString()))
                {
                    sb.Append(item.Date);
                    sb.Append("  ");
                    sb.Append(item.Type);
                    sb.Append("  ");
                    sb.Append(item.Description);
                    sb.Append("  ");
                    sb.Append(item.Cost);
                    sb.Append("\n");
                }
            }
            if (sb.Length != 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show("The item was not found.");
            }
        }

        private void listBoxExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

