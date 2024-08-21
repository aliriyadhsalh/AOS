using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace VacationSystemData
{
    public class clsUserData
    {
       
        public static bool GetUserInfoByUserID(int UserID, ref int EmployeeID, ref string UserName,
            ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EmployeeID = (int)reader["EmployeeID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetUserInfoByEmployeeID(int EmployeeID, ref int UserID, ref string UserName,
          ref string Password,ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetUserInfoByUsernameAndPassword(string UserName,  string Password, 
            ref int UserID, ref int EmployeeID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    UserID= (int)reader["UserID"];
                    EmployeeID = (int)reader["EmployeeID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static async Task <int?> AddNewUser(int EmployeeID,  string UserName,
             string Password,  bool IsActive)
        {

            string query = @"INSERT INTO Users (EmployeeID,UserName,Password,IsActive)
                             VALUES (@EmployeeID, @UserName,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            return await clsPrimaryFunctions.Add(command);

        }


        public static async Task<bool?> UpdateUser(int UserID, int EmployeeID, string UserName,
             string Password, bool IsActive)
        {

            string query = @"Update  Users  
                            set EmployeeID = @EmployeeID,
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            return await clsPrimaryFunctions.Update(command);

        }


        public static async Task<DataTable> GetAllUsers()
        {

            string query = @"SELECT  Users.UserID, Users.EmployeeID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.EmployeeID = People.EmployeeID";

            return await clsPrimaryFunctions.Get(new SqlCommand(query));


        }

        public static async Task <bool?> DeleteUser(int UserID)
        {


            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UserID", UserID);

            return await clsPrimaryFunctions.Delete(command);

        }

        public static async Task<bool?> IsUserExist(int UserID)
        {

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UserID", UserID);

            return await clsPrimaryFunctions.Exist(command);

        }

        public static async Task<bool?> IsUserExist(string UserName)
        {

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UserName", UserName);

            return await clsPrimaryFunctions.Exist(command);
        }

        public static async Task <bool?> IsUserExistForEmployeeID(int EmployeeID)
        {
            string query = "SELECT Found=1 FROM Users WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query);

            return await clsPrimaryFunctions.Exist(command);

        }


    }
}
