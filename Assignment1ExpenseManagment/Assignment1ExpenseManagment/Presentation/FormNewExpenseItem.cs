using Assignment1ExpenseManagment.Business;
using Assignment1ExpenseManagment.Utilities;
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

namespace Assignment1ExpenseManagment.Presentation
{
    public partial class FormNewExpenseItem : Form
    {
        public ExpenseItem Item { get; set; }

        public FormNewExpenseItem()
        {
            InitializeComponent();
        }

        private void FormNewExpenseItem_Load(object sender, EventArgs e)
        {
            if (Item == null)
            {
                comboBoxType.Items.Insert(0, "");
                comboBoxType.SelectedIndex = 0;
                txtDescription.Text = "";
                txtCost.Text = "";
            }
            else
            {
                FillExpenseForm(Item);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (Form1.control == "update") {
                    string connection = @"data source = (localdb)\mssqllocaldb; initial catalog = expensedb; integrated security = true";
                    SqlConnection cnn = new SqlConnection(connection);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = "update expenses set datei =" + "'" + dateTimePicker1.Value.ToShortDateString() + "'" +", typei =" + "'" + comboBoxType.Text + "'" + ", descriptioni =" + "'" + txtDescription.Text + "'" + ", costi =" + "'" + Convert.ToDecimal(txtCost.Text) + "'" + "where datei=" + "'" + Form1.udate + "'" + "and typei=" + "'" + Form1.utype + "'" + "and descriptioni=" + "'" + Form1.udescription + "'" + "and costi=" + "'" + Form1.ucost + "'";

                    command = new SqlCommand(sql, cnn);
                    adapter.UpdateCommand = command;
                    adapter.UpdateCommand.ExecuteNonQuery();
                    cnn.Close();
                }
                else
                {
                    string connection = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = ExpenseDB; Integrated Security = True"; ;
                    SqlConnection cnn = new SqlConnection(connection);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = "Insert into expenses (datei, typei, descriptioni, costi) values(" + "'" + dateTimePicker1.Value.ToShortDateString() + "'" + ",'" + comboBoxType.Text + "','" + txtDescription.Text + "'," + Convert.ToDecimal(txtCost.Text) + ")";

                    command = new SqlCommand(sql, cnn);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    cnn.Close();
                }
                //Item = new ExpenseItem(dateTimePicker1.Value.ToShortDateString(), comboBoxType.Text, txtDescription.Text, Convert.ToDecimal(txtCost.Text));
                DialogResult = DialogResult.OK;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(comboBoxType) &&Validator.IsPresent(txtDescription) &&
                Validator.IsPresent(txtCost) && Validator.IsDecimal(txtCost);
        }

        private void FillExpenseForm(ExpenseItem Item)
        {
            dateTimePicker1.Value = DateTime.Parse(Item.Date);
            comboBoxType.Text = Item.Type;
            txtDescription.Text = Item.Description;
            txtCost.Text = Item.Cost.ToString();
        }

    }
}
