using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class SMS
    {
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
            string sMessage = message;
            string sURL = " http://2fa.atsithub.com/vendorsms/pushsms.aspx?user="
                 + sUserID + "&password="
                 + sPwd + "&msisdn="
                 + sNumber + "&sid="
                 + sSID + "&msg="
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
    }
}
