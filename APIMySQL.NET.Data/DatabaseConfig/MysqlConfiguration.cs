using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMySQL.NET.Data.DatabaseConfig
{
    public class MysqlConfiguration
    {
        public MysqlConfiguration(string stringConnection)
        {
            StringConnection = stringConnection;
        }
        public string StringConnection { get; set; }
    }
}
