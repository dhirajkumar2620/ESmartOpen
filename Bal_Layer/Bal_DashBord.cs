using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_DashBord
    {
        Dal_DashBord DL = new Dal_DashBord();
        public Dashbord ViewDashbord(string HospitalId)
        {
            return DL.ViewDashbord(HospitalId);
        }
    }
}
