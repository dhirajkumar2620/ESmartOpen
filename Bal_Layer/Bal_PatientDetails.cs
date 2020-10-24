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
    
    public class Bal_PatientDetails
    {
        Dal_PatientDetails DP = new Dal_PatientDetails();

        public int ManagePatientDetails(PatientDetails PD)
        {
            return DP.ManagePatientDetails(PD);
        }

        public List<PatientDetails> GetPatientDetails(string Role,int HospitalId, int UserId)
        {
            return DP.GetPatientDetails(Role, HospitalId,  UserId);
        }
        public AdminDetails GetDoctorDetailsById( int UserId)
        {
            return DP.GetDoctorDetailsById( UserId);
        }
        

        public PatientDetails GetDetailsById(int id)
        {
            return DP.GetPatientDetailsById(id);
        }

        public List<PatientDetails> SetPatientAppoinment(string Id, DateTime AppoinmentDate, string AppoinmentTime, string Note)
        {
            return DP.SetPatientAppoinment( Id,  AppoinmentDate,  AppoinmentTime,  Note);
        }
        public List<QueueDetails> GetQueueList(int hospitalId , int UserId, string Date)
        { 
            return DP.GetQueueList(hospitalId, UserId,  Date);
        }
        public List<QueueDetails> DeleteAppoinment(int hospitalId, int Id,string Note, string LoginUserRole)
        {
            return DP.DeleteAppoinment(hospitalId, Id , Note, LoginUserRole);
        }

        public DataSet CountForCards(int hospitalId, int UserId, int flag)
        {
            return DP.CountForCards(hospitalId,  UserId,  flag);
        }
        public PatientAllDetails GetPatientDetailsByCPno(string CPno)
        {
            return DP.GetPatientDetailsByCPno(CPno);
        }
        public int SetStatus(int Queueid,string CPno, float Bill, float paidBill, string Status)
        {
            return DP.SetStatus(Queueid, CPno,  Bill,  paidBill,  Status);
        }

        public int SetDueAmount(string CPno, float DueAmount)
        {
            return DP.SetDueAmount(CPno, DueAmount);
        }

      

        public AdminDetails GetDoctorUserDetails(int UserId)
        {
            return DP.GetDoctorUserDetails(UserId);
        }
        public IList<AdminDetails> GetDoctorListByHID(int Hid)
        {
            return DP.GetDoctorListByHID(Hid);
        }
        public BillPrint PrintBill(int QueueId, string CPno)
        {
            return DP.PrintBill( QueueId,  CPno);
        }
    }
}
