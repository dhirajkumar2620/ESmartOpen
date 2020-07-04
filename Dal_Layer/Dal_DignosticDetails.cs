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
   public class Dal_DignosticDetails
    {
        

        public int ManageDignosticDetails(DignosticDetails MD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[47];
                sqlparam[0] = new SqlParameter("@Id", MD.Id);
                sqlparam[1] = new SqlParameter("@ParientId", MD.ParientId);
                sqlparam[2] = new SqlParameter("@HospitalId", MD.HospitalId);
                sqlparam[3] = new SqlParameter("@PatientName", MD.PatientName);
                sqlparam[4] = new SqlParameter("@Gender", MD.Gender);
                sqlparam[5] = new SqlParameter("@Age", MD.Age);
                sqlparam[6] = new SqlParameter("@Addres", MD.Addres);
                sqlparam[7] = new SqlParameter("@Date", DateTime.Now);
                sqlparam[8] = new SqlParameter("@ReferedByDoctor", MD.ReferedByDoctor);
                sqlparam[9] = new SqlParameter("@ContactNo", MD.ContactNo);
                sqlparam[10] = new SqlParameter("@AbdomenPelvis", MD.AbdomenPelvis);
                sqlparam[11] = new SqlParameter("@Pelvis", MD.Pelvis);
                sqlparam[12] = new SqlParameter("@KUB", MD.KUB);
                sqlparam[13] = new SqlParameter("@Chest", MD.Chest);
                sqlparam[14] = new SqlParameter("@RoutineObsUSG", MD.RoutineObsUSG);
                sqlparam[15] = new SqlParameter("@NTScan", MD.NTScan);
                sqlparam[16] = new SqlParameter("@AnomalyUsgWithDoppler", MD.AnomalyUsgWithDoppler);
                sqlparam[17] = new SqlParameter("@ObstretricUSG", MD.ObstretricUSG);
                sqlparam[18] = new SqlParameter("@VenousSystem", MD.VenousSystem);
                sqlparam[19] = new SqlParameter("@UpperKimbVS", MD.UpperKimbVS);
                sqlparam[20] = new SqlParameter("@LowerLimbVS", MD.LowerLimbVS);
                sqlparam[21] = new SqlParameter("@ArterialSystem", MD.ArterialSystem);
                sqlparam[22] = new SqlParameter("@UpperLimbAS", MD.UpperLimbAS);
                sqlparam[23] = new SqlParameter("@LowerLimbAS", MD.LowerLimbAS);
                sqlparam[24] = new SqlParameter("@CaeotidDoppler", MD.CaeotidDoppler);
                sqlparam[25] = new SqlParameter("@RenalDoppler", MD.RenalDoppler);
                sqlparam[26] = new SqlParameter("@Thyroid", MD.Thyroid);
                sqlparam[27] = new SqlParameter("@Neck", MD.Neck);
                sqlparam[28] = new SqlParameter("@Scrotum", MD.Scrotum);
                sqlparam[29] = new SqlParameter("@Orbit", MD.Orbit);
                sqlparam[30] = new SqlParameter("@Muskeulokeletal", MD.Muskeulokeletal);
                sqlparam[31] = new SqlParameter("@BreastSono", MD.BreastSono);
                sqlparam[32] = new SqlParameter("@LocalParts", MD.LocalParts);
                sqlparam[33] = new SqlParameter("@ChestPaAp", MD.ChestPaAp);
                sqlparam[34] = new SqlParameter("@SpineCsDlLs", MD.SpineCsDlLs);
                sqlparam[35] = new SqlParameter("@Xray_KUB", MD.Xray_KUB);
                sqlparam[36] = new SqlParameter("@AbdomenErectSupine", MD.AbdomenErectSupine);
                sqlparam[37] = new SqlParameter("@JointBone", MD.JointBone);
                sqlparam[38] = new SqlParameter("@PNS", MD.PNS);
                sqlparam[39] = new SqlParameter("@Other", MD.Other);
                sqlparam[40] = new SqlParameter("@IvuRguMcuHsg", MD.IvuRguMcuHsg);
                sqlparam[41] = new SqlParameter("@SinogramFistulogram", MD.SinogramFistulogram);
                sqlparam[42] = new SqlParameter("@PleuralFluidTapping", MD.PleuralFluidTapping);
                sqlparam[43] = new SqlParameter("@AsciticFluidTapping", MD.AsciticFluidTapping);
                sqlparam[44] = new SqlParameter("@FnacBiopsy", MD.FnacBiopsy);
                sqlparam[45] = new SqlParameter("@IsActive", "1");
                sqlparam[46] = new SqlParameter("@ClinicalHistory", MD.ClinicalHistory);


                return CommonFunction.Save("USP_DiagnosisDetails", sqlparam, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DignosticDetails GetDignosticDetails(int id)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@Flag", "1");
                sqlparam[1] = new SqlParameter("@UserId", id);
                DataTable ds = CommonFunction.GetDataTable("USP_GET_TEST", sqlparam, "");
                DignosticDetails Ob = new DignosticDetails();
                if (ds != null && ds.Rows.Count > 0)
                {
                    DataTable dt = ds;
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        CommonFunction.ReflectSingleData(Ob, dr);
                        
                    }
                }
               
                return Ob;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
