using App_Layer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
    public class Dal_LaboratoryDetails
    {
        public int ManageLaboratoryDetails(LaboratoryDetails MD)
        {
            try
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[66];
                sqlparam[0] = new SqlParameter("@Id", MD.Id);
                sqlparam[1] = new SqlParameter("@ParientId", MD.ParientId);
                sqlparam[2] = new SqlParameter("@HospitalId", MD.HospitalId);
                sqlparam[3] = new SqlParameter("@PatientName", MD.PatientName);
                sqlparam[4] = new SqlParameter("@Gender", MD.Gender);
                sqlparam[5] = new SqlParameter("@Age", MD.Age);
                sqlparam[6] = new SqlParameter("@Addres", MD.Addres);
                sqlparam[7] = new SqlParameter("@Date", MD.Date);
                sqlparam[8] = new SqlParameter("@ReferedByDoctor", MD.ReferedByDoctor);
                sqlparam[9] = new SqlParameter("@ContactNo", MD.ContactNo);
                sqlparam[10] = new SqlParameter("@HB", MD.HB);
                sqlparam[11] = new SqlParameter("@CBCPlateletCount", MD.@CBCPlateletCount);
                sqlparam[12] = new SqlParameter("@CBCwithESR", MD.@CBCwithESR);
                sqlparam[13] = new SqlParameter("@MalarialParasite", MD.@MalarialParasite);
                sqlparam[14] = new SqlParameter("@AbsoluteEoslnophilicCunt", MD.@AbsoluteEoslnophilicCunt);
                sqlparam[15] = new SqlParameter("@ReticCountLDH", MD.@ReticCountLDH);
                sqlparam[16] = new SqlParameter("@BloodGroupRHtype", MD.@BloodGroupRHtype);
                sqlparam[17] = new SqlParameter("@BleedingTimeClttingTime", MD.@BleedingTimeClttingTime);
                sqlparam[18] = new SqlParameter("@ProthrombinTime", MD.@ProthrombinTime);
                sqlparam[19] = new SqlParameter("@UrineRoutineMicro", MD.@UrineRoutineMicro);
                sqlparam[20] = new SqlParameter("@BilealtsBilePigments", MD.@BilealtsBilePigments);
                sqlparam[21] = new SqlParameter("@PregnancyTest", MD.@PregnancyTest);
                sqlparam[22] = new SqlParameter("@StoolRoutineRS", MD.@StoolRoutineRS);
                sqlparam[23] = new SqlParameter("@SoolForOccBlood", MD.@SoolForOccBlood);
                sqlparam[24] = new SqlParameter("@TTTSH", MD.@TTTSH);
                sqlparam[25] = new SqlParameter("@LHFSHProTestosterone", MD.@LHFSHProTestosterone);
                sqlparam[26] = new SqlParameter("@WidalTest", MD.@WidalTest);
                sqlparam[27] = new SqlParameter("@VDRL", MD.@VDRL);
                sqlparam[28] = new SqlParameter("@ASO", MD.@ASO);
                sqlparam[29] = new SqlParameter("@HIVTest", MD.@HIVTest);
                sqlparam[30] = new SqlParameter("@AustraliaAntigen", MD.@AustraliaAntigen);
                sqlparam[31] = new SqlParameter("@HCVTest", MD.@HCVTest);
                sqlparam[32] = new SqlParameter("@TBTest", MD.@TBTest);
                sqlparam[33] = new SqlParameter("@DengueFeverTest", MD.@DengueFeverTest);
                sqlparam[34] = new SqlParameter("@ChikunGunyaTest", MD.@ChikunGunyaTest);
                sqlparam[35] = new SqlParameter("@WeilFelixTest", MD.@WeilFelixTest);
                sqlparam[36] = new SqlParameter("@CrucellaTest", MD.@CrucellaTest);
                sqlparam[37] = new SqlParameter("@RATest", MD.@RATest);
                sqlparam[38] = new SqlParameter("@CRP", MD.@CRP);
                sqlparam[39] = new SqlParameter("@TirchIgGIgm", MD.@TirchIgGIgm);
                sqlparam[40] = new SqlParameter("@UrineCultureSensitivity", MD.@UrineCultureSensitivity);
                sqlparam[41] = new SqlParameter("@SputumRoutinAfbCS", MD.@SputumRoutinAfbCS);
                sqlparam[42] = new SqlParameter("@BloodSugar", MD.@BloodSugar);
                sqlparam[43] = new SqlParameter("@HBAC", MD.@HBAC);
                sqlparam[44] = new SqlParameter("@BloodUrea", MD.@BloodUrea);
                sqlparam[45] = new SqlParameter("@SrCreatinine", MD.@SrCreatinine);
                sqlparam[46] = new SqlParameter("@TropTCpkMb", MD.@TropTCpkMb);
                sqlparam[47] = new SqlParameter("@AllCardiacMarkers", MD.@AllCardiacMarkers);
                sqlparam[48] = new SqlParameter("@SrAmylaseLipaseAmmonia", MD.@SrAmylaseLipaseAmmonia);
                sqlparam[49] = new SqlParameter("@SrPhosphorous", MD.@SrPhosphorous);
                sqlparam[50] = new SqlParameter("@SrUricAcid", MD.@SrUricAcid);
                sqlparam[51] = new SqlParameter("@SrMangnesium", MD.@SrMangnesium);
                sqlparam[52] = new SqlParameter("@SrBilirubin", MD.@SrBilirubin);
                sqlparam[53] = new SqlParameter("@SGPT", MD.@SGPT);
                sqlparam[54] = new SqlParameter("@SProteins", MD.@SProteins);
                sqlparam[55] = new SqlParameter("@SGOT", MD.@SGOT);
                sqlparam[56] = new SqlParameter("@AlkPhosphatase", MD.@AlkPhosphatase);
                sqlparam[57] = new SqlParameter("@SrUSrChlesterolricAcid", MD.@SrUSrChlesterolricAcid);
                sqlparam[58] = new SqlParameter("@SrTriglyceride", MD.@SrTriglyceride);
                sqlparam[59] = new SqlParameter("@HDL", MD.@HDL);
                sqlparam[60] = new SqlParameter("@NaK", MD.@NaK);
                sqlparam[61] = new SqlParameter("@SrCalcium", MD.@SrCalcium);
                sqlparam[62] = new SqlParameter("@CSFExamination", MD.@CSFExamination);
                sqlparam[63] = new SqlParameter("@AsciticPleuralFluidCytology", MD.@AsciticPleuralFluidCytology);
                sqlparam[64] = new SqlParameter("@IsActive", MD.@IsActive);
                sqlparam[65] = new SqlParameter("@string ClinicalHistory", MD.@ClinicalHistory);

                return CommonFunction.Save("USP_LaboratoryDetails", sqlparam,"" );
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
