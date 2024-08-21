using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSystemData;

namespace VacationSystemLogic
{
    public class clsOverTime
    {
        public static async Task<bool?> Delete(int EmployeeID)
        {
            return await clsOverTimeData.Delete(EmployeeID);
        }


        public static async Task <bool?> UpdateNumberOfHoursPerDay(short NumberOfHours,byte DayNmber,short MonthNumber)
        {
            return await clsOverTimeData.UpdateNumberOfHoursPerDay(NumberOfHours, DayNmber, MonthNumber);
        }

        public static async Task<bool?> UpdateHoursBasedAttendance(int EmployeeID ,DateTime DateFrom,DateTime DateTo)
        {
            return await clsOverTimeData.UpdateHoursBasedAttendance (EmployeeID , DateFrom,DateTo);
        }

        public static async Task<bool?> setZerohourWhenEmployeeNitAttend(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            return await clsOverTimeData.SetZeroHourWhenEmployeeNoAttend(EmployeeID, DateFrom, DateTo);
        }


        public static async Task<DataTable> GetMonthlyOverTime()
        {
            return await clsOverTimeData.GetMonthlyOverTime();
        }
        public static async Task<bool?> FilldefaultData()
        {
            return await clsOverTimeData.FilldefaultMonthlyData();
        }

        public static async Task<bool?> FilldefaultData(int EmployeeID)
        {
            return await clsOverTimeData.FilldefaultMonthlyData(EmployeeID);
        }


        public static async Task<bool?> IsDataExist()
        {
            return await clsOverTimeData.IsDataExist();
        }

        public static async Task<bool?> IsDataExist(int EmployeeID)
        {
            return await clsOverTimeData.IsDataExist(EmployeeID);
        }

    }
}
