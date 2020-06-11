using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_StaffDetails
    {

        Dal_StaffDetails DP = new Dal_StaffDetails();
        public int ManageStaffDetails(ReceptionStaffReg PD)
        {
            return DP.ManageStaffDetails(PD);
        }

        public List<ReceptionStaffReg> GetStaffDetails()
        {
            return DP.GetStaffDetails();
        }

        public ReceptionStaffReg GetStaffDetailsByAdmId(int rId)
        {
            return DP.GetStaffDetailsByAdmin(rId);
        }
    }
}
