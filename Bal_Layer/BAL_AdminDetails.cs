using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{

    public class Bal_AdminDetails
    {
        Dal_AdminDetails DP = new Dal_AdminDetails();

        public int ManagePatientDetails(AdminDetails PD)
        {
            return DP.ManageAdminDetails(PD);
        }

        public List<AdminDetails> GetAllAdminDetails()
        {
            return DP.GetAllAdminDetails();
        }
        public AdminDetails GetAdminById(int id)
        {
            return DP.GetAdminById(id);
        }
    }
}

