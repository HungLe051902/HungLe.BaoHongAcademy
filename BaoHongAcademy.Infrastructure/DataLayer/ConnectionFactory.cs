using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.DataLayer
{
    public static class ConnectionFactory
    {
        public static IDatabaseConnection GetConnection()
        {
            return new DatabaseConnection();
        }

        public static IDatabaseConnection GetConnection(string connectionString)
        {
            return new DatabaseConnection(connectionString);
        }
    }
}
