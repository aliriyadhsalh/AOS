using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystemData
{
    public class clsEmployeeData
    {
        public static async Task<int?> Add(
            string EmployeeName,
            string Position,
            string JobTitle,
            float PriceForOneHour,
            float PriceForDailyMeal)
        {
            string Query = @"
        INSERT INTO [dbo].[Employees]
            ([EmployeeName]
            ,[Position]
            ,[JobTitle]
            ,[PriceForOneHour]
            ,[PriceForDailyMeal])
        VALUES
            (@EmployeeName, @Position, @JobTitle, @PriceForOneHour, @PriceForDailyMeal);
        SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                command.Parameters.AddWithValue("@Position", Position);
                command.Parameters.AddWithValue("@JobTitle", JobTitle);
                command.Parameters.AddWithValue("@PriceForOneHour", PriceForOneHour);
                command.Parameters.AddWithValue("@PriceForDailyMeal", PriceForDailyMeal);

                return await clsPrimaryFunctions.Add(command);
            }
        }
        public static async Task<bool?> Update(
            int EmployeeID,
            string Name,
            string Position,
            string JobTitle,
            float PriceForOneHour,
            float PriceForDailyMeal)
        {
            string Query = @"
        UPDATE [dbo].[Employees]
        SET [EmployeeName] = @Name
           ,[Position] = @Position
           ,[JobTitle] = @JobTitle
           ,[PriceForOneHour] = @PriceForOneHour
           ,[PriceForDailyMeal] = @PriceForDailyMeal
        WHERE EmployeeID = @EmployeeID";

            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Position", Position);
                command.Parameters.AddWithValue("@JobTitle", JobTitle);
                command.Parameters.AddWithValue("@PriceForOneHour", PriceForOneHour);
                command.Parameters.AddWithValue("@PriceForDailyMeal", PriceForDailyMeal);

                return await clsPrimaryFunctions.Update(command);
            }
        }
        public static async Task <bool?> Delete(int EmployeeID)
        {

            string Query = @"
DELETE FROM [dbo].[Employees]
      WHERE EmployeeID = @EmployeeID";
            using (SqlCommand command = new SqlCommand(Query))
            {
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                return await clsPrimaryFunctions.Delete(command);
            }
        }
        public static async Task <DataTable> GetAll()
        {
            string Query = @"select * from  Employees";
            using (SqlCommand command = new SqlCommand(Query))
            {
                return await clsPrimaryFunctions.Get(command);
            }
        }
        public static async Task<DataTable> GetEmployeeList()
        {
            string Query = @"select * from  Employees";
            using (SqlCommand command = new SqlCommand(Query))
            {
                return await clsPrimaryFunctions.Get(command);
            }
        }

        public static bool Find(int ID, ref string Name, ref string Position, ref string JobTitle, ref float PriceForOneHour, ref float PriceForDailyMeal)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT [EmployeeID]
                  ,[EmployeeName]
                  ,[Position]
                  ,[JobTitle]
                  ,[PriceForOneHour]
                  ,[PriceForDailyMeal]
            FROM [dbo].[Employees]
            WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", ID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                Name = reader["EmployeeName"].ToString();
                                Position = reader["Position"].ToString();
                                JobTitle = reader["JobTitle"].ToString();
                                PriceForOneHour = Convert.ToSingle(reader["PriceForOneHour"]);
                                PriceForDailyMeal = Convert.ToSingle(reader["PriceForDailyMeal"]);
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsPrimaryFunctions.EntireInfoToEventLoge(ex.Message);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static bool Find( string Name,ref int ID, ref string Position, ref string JobTitle, ref float PriceForOneHour, ref float PriceForDailyMeal)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT [EmployeeID]
                  ,[EmployeeName]
                  ,[Position]
                  ,[JobTitle]
                  ,[PriceForOneHour]
                  ,[PriceForDailyMeal]
            FROM [dbo].[Employees]
            WHERE EmployeeName = @EmployeeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", Name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                ID = (int)reader["EmployeeID"];
                                Position = reader["Position"].ToString();
                                JobTitle = reader["JobTitle"].ToString();
                                PriceForOneHour = Convert.ToSingle(reader["PriceForOneHour"]);
                                PriceForDailyMeal = Convert.ToSingle(reader["PriceForDailyMeal"]);
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsPrimaryFunctions.EntireInfoToEventLoge(ex.Message);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

    }
}
