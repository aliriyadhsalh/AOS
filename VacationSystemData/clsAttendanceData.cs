using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlTypes;

namespace VacationSystemData
{
    public class clsAttendanceData
    {
        public static async Task<bool?> UpdateAttendStatus(int EmployeeID, DateTime DateFrom,DateTime DateTo,byte AttendStatus)
        {
            string Query = @"UPDATE Attend
SET IsAttend = 
CASE 
    WHEN DATEPART(WEEKDAY, Date) = 6 THEN 0  -- يوم الجمعة
    ELSE @AttendStatus
END
WHERE EmployeeID = @EmployeeID 
AND CAST(Date AS DATE) >= CAST(@DateFrom AS DATE)
AND CAST(Date AS DATE) <= CAST(@DateTo AS DATE);
";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@AttendStatus", AttendStatus);
                return await clsPrimaryFunctions.Update(command);
            }

        }

        public static async Task<bool?>Delete(int EmployeeID)
        {
            string Query = @"DELETE FROM [dbo].[Attend]
             WHERE EmployeeID = @EmployeeID";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

                return await clsPrimaryFunctions.Delete(command);
            }
        }
        public static async Task<DataTable> GetMonthlyAttend()
        {
            using (SqlCommand command = new SqlCommand("GetEmployeeAttendanceByMonth"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MonthNumber", DateTime.Now.Month);
                return await clsPrimaryFunctions.Get(command);
            }
        }

        public static async Task<bool?> FilldefaultMonthlyData(int EmployeeID)
        {
            using (SqlCommand command = new SqlCommand("MonthlyCopyDataToAttendtable"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);

                return await clsPrimaryFunctions.Update(command);
            }


        }
        public static async Task<bool?> FilldefaultMonthlyData()
        {
            using (SqlCommand command = new SqlCommand("MonthlyCopyDataToAttendtable"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);

                return await clsPrimaryFunctions.Update(command);
            }


        }

        public static async Task<bool?> IsDataExist()
        {
            string Query = @"select * from Attend where MONTH(Date) = @Month";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@Month",DateTime.Now.Month);

                return await clsPrimaryFunctions.Exist(command);
            }
        }

        public static async Task<bool?> IsDataExist(int EmployeeID)
        {
            string Query = @"select * from Attend where MONTH(Date) = @Month And EmployeeID = @EmployeeID";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                return await clsPrimaryFunctions.Exist(command);
            }
        }

    }
}
