﻿using App_Layer;
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
    public class Dal_PatientDetails
    {
        public int ManagePatientDetails(PatientDetails PD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[20];
                sqlparam[0] = new SqlParameter("@Id", PD.Id);
                sqlparam[1] = new SqlParameter("@PatientName", PD.PatientName);
                sqlparam[2] = new SqlParameter("@Gender", PD.Gender);
                sqlparam[3] = new SqlParameter("@DOB", PD.DOB);
                sqlparam[4] = new SqlParameter("@Age", PD.Age);
                sqlparam[5] = new SqlParameter("@MaritalStatus", PD.MaritalStatus);
                sqlparam[6] = new SqlParameter("@BloodGroup", PD.BloodGroup);
                sqlparam[7] = new SqlParameter("@WhatsAppNo", PD.WhatsAppNo);
                sqlparam[8] = new SqlParameter("@OtherNo", PD.WhatsAppNo);
                sqlparam[9] = new SqlParameter("@EmailId", PD.EmailId);
                sqlparam[10] = new SqlParameter("@Address", PD.Address);
                sqlparam[11] = new SqlParameter("@ReferedByDoctor", PD.ReferedByDoctor);
                sqlparam[12] = new SqlParameter("@DoctorAddress", PD.DoctorAddress);
                sqlparam[13] = new SqlParameter("@MediClmCompany", PD.MediClmCompany);
                sqlparam[14] = new SqlParameter("@AppliedForMediclam", "0");
                sqlparam[15] = new SqlParameter("@CasePaperFees", PD.CasePaperFees);
                sqlparam[16] = new SqlParameter("@Role", PD.Role);
                sqlparam[17] = new SqlParameter("@HospitalId", PD.HospitalId);
                sqlparam[18] = new SqlParameter("@DoctorReceptionId", PD.DoctorReceptionId);
                sqlparam[19] = new SqlParameter("@CreatedBy", PD.CreatedBy);
                return CommonFunction.Save("USP_ManagePatientDetails", sqlparam, "");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PatientDetails> GetPatientDetails()
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Flag", "1");

                DataTable ds = CommonFunction.GetDataTable("USP_GET_PATIENTDETAILS", sqlparam, "");
                List<PatientDetails> lst = new List<PatientDetails>();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        PatientDetails Model = new PatientDetails();
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

        public PatientDetails GetPatientDetailsById(int id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Id", id);

                DataTable ds = CommonFunction.GetDataTable("USP_GET_PATIENTDETAILS", sqlparam, "");
                PatientDetails lst = new PatientDetails();
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
