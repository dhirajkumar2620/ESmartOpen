using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class SMS
    {
        Dal_Common ObjDal_Common = new Dal_Common();
        public string SendSMS(string mobileNumber, string message)
        {
            string sUserID = ConfigurationManager.AppSettings["sUserID"];
            string sPwd = ConfigurationManager.AppSettings["sPwdSMS"];
            string sNumber = mobileNumber;
            string sSID = ConfigurationManager.AppSettings["senderid"];
            string sMessage = message;
            string sURL = " http://sms.auurumdigital.com/api/mt/SendSms?user="
                + sUserID + "&password="
                + sPwd + "&senderid="
                + sSID + "&channel=Trans&DCS=0&flashsms=0&number="
                + sNumber + "&text="
                + sMessage + "&route=00";
            string sResponse = GetResponse(sURL);
            //Response.Write(sResponse);
            return sResponse;
        }

        public string SendOTP(string mobileNumber , string message)
        {
            
            string sUserID = ConfigurationManager.AppSettings["sUserID"];
            string sPwd = ConfigurationManager.AppSettings["sPwdOTP"];
            string sNumber = mobileNumber;
            string sSID = ConfigurationManager.AppSettings["sSID"];
            string sChannel = ConfigurationManager.AppSettings["sChannel"];
            string sDCS = ConfigurationManager.AppSettings["sDCS"];
            string sFlashsms = ConfigurationManager.AppSettings["sFlashsms"];
            string sMessage = message;
            string sURL = " http://otp.auurumdigital.com/api/mt/SendSMS?user="
            + sUserID + "&password="
                 + sPwd + "&senderid="
                 + sSID + "&channel="
                 + sChannel + "&DCS="
                 + sDCS + "&Flashsms="
                 + sFlashsms + "&number="
                 + sNumber + "&text="
                 + sMessage + "&fl=0&gwid=2";
            string sResponse = GetResponse(sURL);
            //Response.Write(sResponse);
            return sResponse;
        }
        public string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request
                .GetResponse();
                Stream receiveStream = response.GetResponseStream(
                );
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RandomOTP()
        {

            Random generator = new Random();
            String newOTP = generator.Next(0, 999999).ToString("D6");
            return newOTP;
        }

        public DataTable Get_ExportToExcel(int flag, int HospitalId, string StartDate, string EndDate)
        {
            return ObjDal_Common.Get_ExportToExcel(flag, HospitalId, StartDate, EndDate);

        }
    }
}
