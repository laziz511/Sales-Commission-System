using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment_work
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        string employee_id;

        NpgsqlConnection connect()
        {
            string connection_string = @"
                Server=localhost;
                Port=5432;
                Database=pdp;
                User Id=postgres;
                Password=postgres";
            return new NpgsqlConnection(connection_string);
        }

        void reloadTable()
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "select * from employee";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    dataGridView1.DataSource = new DataTable();
                }

                connection.Close();
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
           reloadTable();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "INSERT INTO employee(id,name) values (@id,@name)";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                string id = Guid.NewGuid().ToString();

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", tbxName.Text);

                try
                {
                    command.ExecuteNonQuery();
                    reloadTable();
                    MessageBox.Show("Employee inserted ");
                    tbxName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "UPDATE employee SET name = @name WHERE id = @id";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                string id = Guid.NewGuid().ToString();

                command.Parameters.AddWithValue("id", employee_id);
                command.Parameters.AddWithValue("name", tbxName.Text);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee edited "); 
                    reloadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "DELETE FROM employee WHERE id = @id";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {

                command.Parameters.AddWithValue("id", employee_id);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted ");
                    reloadTable();
                    tbxName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            employee_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

    }
}
