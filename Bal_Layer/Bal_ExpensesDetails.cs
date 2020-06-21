﻿using App_Layer;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_ExpensesDetails
    {
        Dal_ExpensesDetails DP = new Dal_ExpensesDetails();

        public int ManageExpensesDetails(ExpensesDetails MD)
        {
            return DP.ManageExpensesDetails(MD);
        }

        public ExpensesDetails ViewAllExpenses(int hId)
        {
            return DP.ViewAllExpenses(hId);
        }
        public int DeleteExpences(int MedicineId)
        {
            return DP.DeleteExpences(MedicineId);
        }
    }
}