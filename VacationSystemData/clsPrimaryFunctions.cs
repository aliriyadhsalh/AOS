using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VacationSystemData
{
    internal class clsPrimaryFunctions
    {


        public static void EntireInfoToEventLoge(string Information)
        {
            //Attendance And OverTime System
            string SourceName = "AAOTS";
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, Information, EventLogEntryType.Error);

        }
        public static async Task <int?> Add(SqlCommand command)
        {
            int? ID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (command.Connection = connection) {
                    try
                    {
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ID = insertedID;
                        }

                    }

                    catch (Exception ex)
                    {
                        EntireInfoToEventLoge(ex.Message);
                    }

                    return ID;
                }
            }
        }
        public static async Task<DataTable> Get(SqlCommand command)
        {
            DataTable GetData = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (command.Connection = connection)
                {

                    try
                    {
                       await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {

                            if (reader.HasRows)

                            {
                                GetData.Load(reader);

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        EntireInfoToEventLoge(ex.Message);
                    }
                }
            }

            return GetData;
        }
        public static async Task<bool?> Update(SqlCommand command)
        {
            int? RowsAffected = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (command.Connection = connection)
                {

                    try
                    {
                        await connection.OpenAsync();

                        RowsAffected = await command.ExecuteNonQueryAsync();

                    }
                    catch (Exception ex)
                    {
                        EntireInfoToEventLoge(ex.Message);
                    }
                }

                return (RowsAffected > 0);
            }
        }
        public static async Task<bool> Delete(SqlCommand command)
        {
            int? RowsAffected = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (command.Connection = connection)
                {

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        EntireInfoToEventLoge(ex.Message);
                    }

                    return (RowsAffected > 0);
                }
            }
        }
        public static async Task <bool> Exist(SqlCommand command)
        {

            bool? isFound = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (command.Connection = connection)
                {
                    try
                    {
                       await connection.OpenAsync();
                        using (SqlDataReader reader =await command.ExecuteReaderAsync())
                        {
                            isFound = reader.HasRows;

                        }
                    }
                    catch (Exception ex)
                    {
                        EntireInfoToEventLoge(ex.Message);
                    }
                }
            }

                return isFound.Value;
            }
    
    }


}


    

