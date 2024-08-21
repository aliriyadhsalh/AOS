using System;
using System.Configuration;


namespace VacationSystemData
{
    static class clsDataAccessSettings
    {

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["VacationSystem"].ConnectionString;
    }
}
