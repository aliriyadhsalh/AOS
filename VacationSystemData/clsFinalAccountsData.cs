using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystemData
{
    public class clsFinalAccountsData
    {

        public static async Task<DataTable> Get()
        {

            using (SqlCommand Command = new SqlCommand("sp_GetEmployeeAttendanceAndOvertimeReport"))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@MonthNumber", DateTime.Now.Month);
                return await clsPrimaryFunctions.Get(Command);
            }
        }

    }
}
