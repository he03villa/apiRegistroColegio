using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Data
{
    public class MySqlCofiguration
    {
        public MySqlCofiguration(string connectionStrin) { 
            ConnectionString = connectionStrin;
        }
        public string ConnectionString { get; set; }
    }
}
