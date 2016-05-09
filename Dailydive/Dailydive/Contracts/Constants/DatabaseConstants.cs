using System;
using System.Configuration;

namespace Dailydive.Contracts.Constants
{
    class DatabaseConstants
    {
        public struct ConnectionStrings
        {
             public static string RonaldDb = ConfigurationManager.ConnectionStrings["DailyDiveConString"].ConnectionString;
        }

    }
}
