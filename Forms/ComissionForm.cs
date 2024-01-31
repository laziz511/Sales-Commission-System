using Assignment_work.Models;
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

namespace Assignment_work
{
    public partial class ComissionForm : Form
    {
        public ComissionForm()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection connect()
        {
            string connection_string = @"
                Server=localhost;
                Port=5432;
                Database=pdp;
                User Id=postgres;
                Password=postgres";
            return new NpgsqlConnection(connection_string);
        }

        void populateCombobox()
        {
            List<Employee> employees = getEmployees();
            cmbxEmployee.ValueMember = "id";
            cmbxEmployee.DisplayMember = "name";

            cmbxEmployee.DataSource = employees;
        }

        List<Employee> getEmployees()
        {
            List<Employee> list = new List<Employee>();

            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "select * from employee";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee()
                        {
                            id = reader["id"] as string,
                            name = reader["name"] as string,

                        });
                    }
                }

                connection.Close();

            }
            return list;
        }

        List<Comission> GetComissonByWeek(int week)
        {
            List<Comission> list = new List<Comission>();
            NpgsqlConnection connection = connect();
            connection.Open();

            string sql = "SELECT * FROM comission WHERE week = @week";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("week", week);

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Comission()
                        {
                            id = reader["id"] as string,
                            employee_id = reader["employee_id"] as string,
                            number_of_properties = Int32.Parse(reader["number_of_properties"].ToString()),
                            week = Int32.Parse(reader["week"].ToString()),
                            comission_amount = Decimal.Parse(reader["comission_amount"].ToString()),
                            bonus_applied = Int32.Parse(reader["bonus_applied"].ToString()),
                        });
                    }
                }
            }
            return (list);
        }

        public static bool EntriesExceed(int week, int limit)
        {
            bool check = false;
            NpgsqlConnection connection = connect();
            connection.Open();

            string sql = "SELECT count(0) as cnt FROM comission WHERE week = @week";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("week", week);

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long i = Int64.Parse(reader["cnt"].ToString());
                        check = i >= limit;
                        break;
                    }
                }
            }
            connection.Close();

            return check;
        }

        public static bool EmployeeAndWeekExistAlready(string employee_id, int week)
        {
            bool check = false;
            NpgsqlConnection connection = connect();
            connection.Open();

            string sql = "SELECT * FROM comission WHERE employee_id = @employee_id AND week = @week";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {

                command.Parameters.AddWithValue("employee_id", employee_id);
                command.Parameters.AddWithValue("week", week);

                NpgsqlDataReader reader = command.ExecuteReader();

                check = reader.HasRows;
            }
            connection.Close();
            return check;
        }


        void reloadTable()
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            string sql = "SELECT * FROM comission ORDER BY week ASC, number_of_properties DESC";

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
            showStats();
        }

        void ApplyBonus(List<string> employee_ids, int week)
        {

            string sql = @"UPDATE comission 
                        SET  comission_amount = 1.15 * comission_amount,
                             bonus_applied = @bonus_applied 
                        WHERE week = @week  AND employee_id IN ({0})";

            var cmd = new NpgsqlCommand();

            cmd.Parameters.AddWithValue("week", week);
            cmd.Parameters.AddWithValue("bonus_applied", 1);


            // creaate list of paremeters
            var employee_ids_params = new string[employee_ids.Count];
            for (int i = 0; i < employee_ids.Count; i++)
            {
                employee_ids_params[i] = string.Format("@employee_id{0}", i);
                cmd.Parameters.AddWithValue(employee_ids_params[i], employee_ids[i]);
            }

            sql = string.Format(sql, string.Join(", ", employee_ids_params));


            cmd.CommandText = sql;
            cmd.Connection = connect();

            cmd.Connection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employees with ids: " + string.Join(", ", employee_ids.ToArray()) + " where given a bonus");

                nudWeek.Value = 1;
                nudNumberOfProperties.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmd.Connection.Close();
            reloadTable();
        }


        void showStats()
        {
            totalComission();
            totalNumberOfProperties();
        }

        void totalComission()
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            var sql = "SELECT SUM(comission_amount) AS sum FROM comission";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();  

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        lblTotalComission.Text = "Total comission: " + reader["sum"].ToString();
                    }
                }
            }
            connection.Close();

        }

        void totalNumberOfProperties()
        {
            NpgsqlConnection connection = connect();

            connection.Open();

            var sql = "SELECT SUM(number_of_properties) AS sum FROM comission";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblTotalNumberOfProperties.Text = "Total number of properties: " + reader["sum"].ToString();
                    }
                }
            }
            connection.Close();

        }

        private void ComissionForm_Load(object sender, EventArgs e)
        {
            showStats();
            reloadTable();
            populateCombobox();
        }


            private void btnInsert_Click(object sender, EventArgs e)
            {

                string id = Guid.NewGuid().ToString();
                string employee_id = cmbxEmployee.SelectedValue.ToString();
                int number_of_properties = (int)nudNumberOfProperties.Value;
                int week = (int)nudWeek.Value;
                decimal comission_amount = ((int)nudNumberOfProperties.Value) * 50000;
                int bonus_applied = 0;

                int limit = 5;
                if (EntriesExceed(week, limit))
                {
                    MessageBox.Show("You have already more than or equals to " + limit + " entries for this week: " + week);
                    return;
                }

                if (EmployeeAndWeekExistAlready(employee_id, week))
                {
                    MessageBox.Show("Choose unique combination for employee and week");
                    return;
                }

                NpgsqlConnection connection = connect();

                connection.Open();

                string sql = @"INSERT INTO comission(id, employee_id, week, number_of_properties, comission_amount, bonus_applied) 
                    VALUES (@id, @employee_id, @week, @number_of_properties, @comission_amount, @bonus_applied)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("employee_id", employee_id);
                    command.Parameters.AddWithValue("week", week);
                    command.Parameters.AddWithValue("number_of_properties", number_of_properties);
                    command.Parameters.AddWithValue("comission_amount", comission_amount);
                    command.Parameters.AddWithValue("bonus_applied", bonus_applied);


                    try
                    {
                        command.ExecuteNonQuery();
                        reloadTable();
                        MessageBox.Show("Comission inserted ");
                        nudWeek.Value = 1;
                        nudNumberOfProperties.Value = 1;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                connection.Close();
            }

        private void btnBonus_Click(object sender, EventArgs e)
        {
            int bonus_week = (int)nudBonusWeek.Value;

            // get comissions by bonus week
            List<Comission> list = GetComissonByWeek(bonus_week);

            // check if any bonuses given for this week
            bool exists = list.Where(x => x.bonus_applied == 1).ToList().Count > 0;
            if (exists)
            {
                MessageBox.Show("Bonuses are already given for this week");
                return;
            }

            // get  max number of properties
            int max_number_of_properties = list.Max(x => x.number_of_properties);

            // find people (employee_id) with the most amount of properties sold
            List<Comission> comissions_max_props = list.Where(x => x.number_of_properties == max_number_of_properties).ToList();
            List<string> employees_id = comissions_max_props.Select(o => o.employee_id).ToList();

            ApplyBonus(employees_id, bonus_week);
        }


    }
}
