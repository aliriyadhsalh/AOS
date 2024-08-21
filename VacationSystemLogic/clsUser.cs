using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VacationSystemData;
namespace VacationSystemLogic
{
    public  class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? UserID { set; get; }
        public int EmployeeID { get; set; }            
        //public clsPerson PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
     
        public clsUser()

        {     
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int EmployeeID, string Username,string Password,
            bool IsActive)

        {
            this.UserID = UserID; 
            this.EmployeeID = EmployeeID;
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private async Task <bool?> _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = await clsUserData.AddNewUser(this.EmployeeID,this.UserName,
                this.Password,this.IsActive);

            return (this.UserID != -1);
        }
        private async Task <bool?> _UpdateUser()
        {
            //call DataAccess Layer 

            return await clsUserData.UpdateUser(this.UserID.Value,this.EmployeeID,this.UserName,
                this.Password,this.IsActive);
        }
        public static clsUser FindByUserID(int UserID)
        {
            int EmployeeID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID
                                ( UserID,ref EmployeeID, ref UserName,ref Password,ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID,EmployeeID,UserName,Password,IsActive);
            else
                return null;
        }
        public static clsUser FindByEmployeeID(int EmployeeID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByEmployeeID
                                (EmployeeID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string UserName,string Password)
        {
            int UserID = -1;
            int EmployeeID=-1;

            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName , Password,ref UserID,ref EmployeeID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, EmployeeID, UserName, Password, IsActive);
            else
                return null;
        }

        public Task <bool?> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
           
                   Mode = enMode.Update;
                   return _AddNewUser();
               

                case enMode.Update:

                    return _UpdateUser();

            }

            return null;
        }

        public static async Task<DataTable> GetAllUsers() => await clsUserData.GetAllUsers();
        public static Task <bool?> DeleteUser(int UserID) => clsUserData.DeleteUser(UserID);
        public static async Task<bool?> isUserExist(int UserID) => await clsUserData.IsUserExist(UserID);
        public static async Task<bool?> isUserExist(string UserName) => await clsUserData.IsUserExist(UserName);
        public static async Task <bool?> isUserExistForEmployeeID (int EmployeeID) => await clsUserData.IsUserExistForEmployeeID(EmployeeID);


    }
}
