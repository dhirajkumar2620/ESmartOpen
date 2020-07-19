using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
   
    public class BAL_Log
    {
        DAL_Log DL = new DAL_Log();
        public int SetLOG(string Action, string Controller, string ActionMethod, string Description)
        {
            return DL.SetLOG(Action, Controller, ActionMethod, Description);
        }
    }
}
