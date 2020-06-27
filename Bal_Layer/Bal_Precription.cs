using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_Precription
    {
        Dal_Precriptipn DP = new Dal_Precriptipn();
        public Precription ViewPricripion(int QueueId, string CPno)
        {
           return DP.ViewPricripion(QueueId, CPno);
        }
    }
}
