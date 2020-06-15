using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
   public class Dal_StaffDetails
    {
        public int ManageStaffDetails(ReceptionStaffReg PD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[20];
                sqlparam[0] = new SqlParameter("@ReceptionId", PD.ReceptionId);
                sqlparam[1] = new SqlParameter("@ParentId", PD.ParentId);
                sqlparam[2] = new SqlParameter("@HospitalId", PD.HospitalId);
                sqlparam[3] = new SqlParameter("@HostClincName", PD.HostClincName);
                sqlparam[4] = new SqlParameter("@HospClinicAddess", PD.HospClinicAddess);
                sqlparam[5] = new SqlParameter("@HospClinicNumber", PD.HospClinicNumber);
                sqlparam[6] = new SqlParameter("@Name", PD.Name);
                sqlparam[7] = new SqlParameter("@Gender", PD.Gender);
                sqlparam[8] = new SqlParameter("@DateOfBirth", PD.DateOfBirth);
                sqlparam[9] = new SqlParameter("@WhatsAppNumber", PD.WhatsAppNumber);
                sqlparam[10] = new SqlParameter("@OtherNumber", PD.OtherNumber);
                sqlparam[11] = new SqlParameter("@Education", PD.Education);
                sqlparam[12] = new SqlParameter("@Department", PD.Department);
                sqlparam[13] = new SqlParameter("@Designation", PD.Designation);
                sqlparam[14] = new SqlParameter("@EmailId", PD.EmailId);
                sqlparam[15] = new SqlParameter("@Password", "staf123");
                sqlparam[16] = new SqlParameter("@Remark", PD.Remark);
                sqlparam[17] = new SqlParameter("@Address", PD.Address);
                sqlparam[18] = new SqlParameter("@RoleId", PD.RoleId);
                sqlparam[19] = new SqlParameter("@CreatedBy", PD.CreatedBy);
                //sqlparam[17] = new SqlParameter("@@isActive", PD.isActive = (PD.HospitalId == null) ? "1" : PD.isActive);
                return CommonFunction.Save("USP_MANGE_RECEPTIONSTAFFDETAILS", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ReceptionStaffReg> GetStaffDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Flag", "1");

                DataTable ds = CommonFunction.GetDataTable("USP_Get_StaffDeatilsByAdmin", sqlparam, "");
                List<ReceptionStaffReg> lst = new List<ReceptionStaffReg>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ReceptionStaffReg Model = new ReceptionStaffReg();
                        CommonFunction.ReflectSingleData(Model, dr);
                        lst.Add(Model);
                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ReceptionStaffReg GetStaffDetailsByAdmin(int rId)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@ReceptionID", rId);

                DataTable ds = CommonFunction.GetDataTable("USP_Get_StaffDeatilsByAdmin", sqlparam, "");
                ReceptionStaffReg lst = new ReceptionStaffReg();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //PatientDetails Model = new PatientDetails();
                        CommonFunction.ReflectSingleData(lst, dr);

                    }
                }
                return lst;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
