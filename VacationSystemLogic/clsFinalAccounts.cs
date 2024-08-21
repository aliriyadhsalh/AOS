using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VacationSystemData;

namespace VacationSystemLogic
{
    public class clsFinalAccounts
    {
        public static async Task<DataTable> GetAll()
        {
            return await clsFinalAccountsData.Get();
        }

    }


}
