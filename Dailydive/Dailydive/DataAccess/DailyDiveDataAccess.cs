using System.Data.SqlClient;
using Dailydive.Contracts.Constants;

namespace Dailydive.DataAccess
{
    public partial class DailyDiveDataAccess
    {
        protected SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(DatabaseConstants.ConnectionStrings.RonaldDb);
            connection.Open();

            return connection;
        }
    }
}
