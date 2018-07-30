using Assignment1ExpenseManagment.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1ExpenseManagment.Data
{
    class ExpenseDB
    {

        private List<ExpenseItem> list = new List<ExpenseItem>();

        public void Dbtolist()
        {
            list.Clear();
            string connection;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader sdr;
            string sql;
            
            connection = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ExpenseDB;Integrated Security=True";
            sql = "Select * from expenses";
            cnn = new SqlConnection(connection);
            command = new SqlCommand(sql, cnn);

            cnn.Open();

            sdr = command.ExecuteReader();

            while (sdr.Read())
            {
                list.Add(new ExpenseItem(sdr.GetValue(1).ToString(), sdr.GetValue(2).ToString(), sdr.GetValue(3).ToString(), (Decimal)sdr.GetValue(4)));
            }
            cnn.Close();
        }

        public List<ExpenseItem> GetListItems()
        {
            return list;
        }

        public void SaveListItems(List<ExpenseItem> items)
        {
            list = items;
        }


    }
}
