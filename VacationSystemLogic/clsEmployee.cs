using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSystemData;

namespace VacationSystemLogic
{
    public class clsEmployee
    {
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string JobTitle { get; set; } // العنصر الجديد
        public float PriceForOneHour { get; set; } // العنصر الجديد
        public float PriceForDailyMeal { get; set; } // العنصر الجديد

        enum enMode { AddNew = 1, Update = 2 }
        enMode Mode = enMode.AddNew;

        public clsEmployee()
        {
            EmployeeId = null;
            Name = null;
            Position = null;
            JobTitle = null;
            PriceForOneHour = 0;
            PriceForDailyMeal = 0;
            Mode = enMode.AddNew;
        }

        public clsEmployee(int? id, string name, string position, string jobTitle, float priceForOneHour, float priceForDailyMeal)
        {
            this.EmployeeId = id;
            this.Name = name;
            this.Position = position;
            this.JobTitle = jobTitle;
            this.PriceForOneHour = priceForOneHour;
            this.PriceForDailyMeal = priceForDailyMeal;
            Mode = enMode.Update;
        }

        public static async Task<DataTable> GetAll()
        {
            return await clsEmployeeData.GetAll();
        }

        public static clsEmployee Find(int ID)
        {
            string Name = "";
            string Position = "";
            string JobTitle = "";
            float PriceForOneHour = 0;
            float PriceForDailyMeal = 0;

            bool IsFind = clsEmployeeData.Find(ID, ref Name, ref Position, ref JobTitle, ref PriceForOneHour, ref PriceForDailyMeal);

            if (IsFind)
                return new clsEmployee(ID, Name, Position, JobTitle, PriceForOneHour, PriceForDailyMeal);
            else
                return null;
        }

        public static clsEmployee Find(string Name)
        {
            int ID = 0; 
            string Position = "";
            string JobTitle = "";
            float PriceForOneHour = 0;
            float PriceForDailyMeal = 0;

            bool IsFind = clsEmployeeData.Find(Name, ref ID, ref Position, ref JobTitle, ref PriceForOneHour, ref PriceForDailyMeal);

            if (IsFind)
                return new clsEmployee(ID, Name, Position, JobTitle, PriceForOneHour, PriceForDailyMeal);
            else
                return null;

        }

        public static async Task<DataTable> GetEmployeeList()
        {
            return await clsEmployeeData.GetEmployeeList();
        }

        private async Task<bool?> _Add()
        {
            return (this.EmployeeId = await clsEmployeeData.Add(this.Name, this.Position, this.JobTitle, this.PriceForOneHour, this.PriceForDailyMeal)) != null;
        }

        private async Task<bool?> _Update()
        {
            bool? update = await (clsEmployeeData.Update(this.EmployeeId.Value, this.Name, this.Position, this.JobTitle, this.PriceForOneHour, this.PriceForDailyMeal));
            return update.Value;
        }

        public async Task<bool?> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    Mode = enMode.Update;
                    return await _Add();

                case enMode.Update:
                    return await _Update();
            }

            return false;
        }

        public static async Task<bool?> Delete(int ID)
        {
            return await clsEmployeeData.Delete(ID);
        }
    }
}
