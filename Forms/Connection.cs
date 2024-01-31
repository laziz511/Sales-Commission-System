using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_work.Forms
{
    public class Connection
    {
        public static NpgsqlConnection connect()
        {
            string env = ConfigurationManager.AppSettings["environment"];

            string connection_string;

            if (string .IsNullOrEmpty(env) || env.Equals("prod"))
            {
                connection_string = 
                @"Server=localhost;
                Port=5432;
                Database=pdp;
                User Id=postgres;
                Password=postgres";
            }
            else
            {
                connection_string =
                @"Server=localhost;
                Port=5432;
                Database=pdpTest;
                User Id=postgres;
                Password=postgres";
            }

            return new NpgsqlConnection(connection_string);
        }
    }
}
