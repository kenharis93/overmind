using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1ExpenseManagment.Utilities
{
   public class Validator
    {
       public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox.Tag);
                sb.Append(" is a required field.");
                MessageBox.Show(sb.ToString(), "Field Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsPresent(ComboBox comboBox)
        {
            if (comboBox.Text == "")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(comboBox.Tag);
                sb.Append(" is a required field.");
                MessageBox.Show(sb.ToString(), "Field Error");
                comboBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox.Tag);
                sb.Append(" must be numerical.");
                MessageBox.Show(sb.ToString(), "Field Error");
                textBox.Focus();
                return false;
            }
        }
    }
}
