using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;

namespace VacationSystemData
{
    public class clsOverTimeData
    {
        public static async Task<bool?> UpdateNumberOfHoursPerDay(short NewNumberOfHours, byte DayNumber, short MonthNumber)
        {
            string Query = @"UPDATE OverTimeAttendance
                          SET NumberOfHours = @NewNumberOfHours
                          WHERE YEAR(Date) = @Year AND MONTH(Date) = @Month 
                          And DayNumber = @DayNumber;";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@NewNumberOfHours", NewNumberOfHours);
                command.Parameters.AddWithValue("@DayNumber", DayNumber);
                command.Parameters.AddWithValue("@Month", MonthNumber);
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year);

                return await clsPrimaryFunctions.Update(command);
            }

        }

        public static async Task<bool?> UpdateHoursBasedAttendance(int EmployeeID,DateTime DateFrom,DateTime DateTo)
        {
            string Query = @"UPDATE OverTimeAttendance
SET NumberOfHours = 
CASE 
    WHEN DATEPART(WEEKDAY, Date) = 6 THEN 0  -- يوم الجمعة
    WHEN DATEPART(WEEKDAY, Date) = 7 THEN 7  -- يوم السبت
    ELSE 3   -- باقي الأيام
END
WHERE CAST(Date AS DATE) >= CAST(@DateFrom AS DATE)
AND CAST(Date AS DATE) <= CAST(@DateTo AS DATE)
AND EmployeeID = @EmployeeID;
";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);


                return await clsPrimaryFunctions.Update(command);
            }


        }

        public static async Task<bool?> SetZeroHourWhenEmployeeNoAttend(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            string Query = @"UPDATE OverTimeAttendance
                          SET NumberOfHours = 0
                          WHERE CAST(Date AS DATE) >= CAST(@DateFrom AS DATE)
                          AND CAST(Date AS DATE) <= CAST(@DateTo AS DATE)
                          And EmployeeID = @EmployeeID;";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@DateFrom", DateFrom);
                command.Parameters.AddWithValue("@DateTo", DateTo);
                return await clsPrimaryFunctions.Update(command);
            }

        }

        public static async Task<DataTable> GetMonthlyOverTime()
        {
            using (SqlCommand command = new SqlCommand("GetEmployeeOverTimeReport"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MonthNumber", DateTime.Now.Month);
                return await clsPrimaryFunctions.Get(command);
            }
        }
        public static async Task<bool?> FilldefaultMonthlyData()
        {
            using (SqlCommand command = new SqlCommand("MonthlyCopyDataToOverTimetable"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);

                return await clsPrimaryFunctions.Update(command);
            }


        }
        public static async Task<bool?> FilldefaultMonthlyData(int EmployeeID)
        {
            using (SqlCommand command = new SqlCommand("MonthlyCopyDataToOverTimetable"))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                return await clsPrimaryFunctions.Update(command);
            }


        }

        public static async Task<bool?> IsDataExist()
        {
            string Query = @"select * from OverTimeAttendance where MONTH(Date) = @Month";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);

                return await clsPrimaryFunctions.Exist(command);
            }
        }

        public static async Task<bool?> IsDataExist(int EmployeeID)
        {
            string Query = @"select * from OverTimeAttendance where MONTH(Date) = @Month And EmployeeID = @EmployeeID";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                return await clsPrimaryFunctions.Exist(command);
            }
        }

        public static async Task<bool?> Delete(int EmployeeID)
        {
            string Query = @"DELETE FROM [dbo].[OverTimeAttendance]
                           WHERE EmployeeID = @EmployeeID";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                return await clsPrimaryFunctions.Delete(command);
            }
        }



    }
}
