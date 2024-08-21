using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSystemData;

namespace VacationSystemLogic
{
    public class clsAttendance
    {

        public static async Task<bool?>Delete(int EmployeeID)
        {
            return await clsAttendanceData.Delete(EmployeeID);
        }

        public static async Task<DataTable> GetMonthlyAttendance()
        {
            return await clsAttendanceData.GetMonthlyAttend();
        }
        public static async Task <bool?> UpdateAttendStatus(int EmployeeID,DateTime DateFrom,DateTime DateTo ,byte AttendStatus)
        {
            return await clsAttendanceData.UpdateAttendStatus(EmployeeID, DateFrom, DateTo, AttendStatus);
        }

        public static async Task<bool?> FillDefaultData()
        {
            return await clsAttendanceData.FilldefaultMonthlyData();
        }
        public static async Task<bool?> FillDefaultData(int EmployeeID)
        {
            return await clsAttendanceData.FilldefaultMonthlyData(EmployeeID);
        }


        public static async Task<bool?> IsDataExist()
        {
            return await clsAttendanceData.IsDataExist();
        }
        public static async Task<bool?> IsDataExist(int EmployeeID)
        {
            return await clsAttendanceData.IsDataExist(EmployeeID);
        }

    }
}
