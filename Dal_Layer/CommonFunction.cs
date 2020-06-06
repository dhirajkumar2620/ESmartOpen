using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace DataLayer
{
    public static class CommonFunction
    {
        #region ReflectSingleData
        public static void ReflectSingleData(object objSource, DataRow drSource)
        {
            try
            {
                Type typeSource = objSource.GetType();
                PropertyInfo[] propSource = typeSource.GetProperties();

                foreach (PropertyInfo propInfo in propSource)
                {
                    if (drSource.Table.Columns[propInfo.Name] != null && propInfo.CanWrite)
                    {
                        if (drSource[propInfo.Name] != DBNull.Value)
                        {
                            switch (propInfo.PropertyType.FullName.ToLower())
                            {
                                case "system.int32":
                                    propInfo.SetValue(objSource, Convert.ToInt32(drSource[propInfo.Name]), null);
                                    break;
                                case "system.double":
                                    propInfo.SetValue(objSource, Convert.ToDouble(drSource[propInfo.Name]), null);
                                    break;
                                case "system.decimal":
                                    propInfo.SetValue(objSource, Convert.ToDecimal(drSource[propInfo.Name]), null);
                                    break;
                                case "system.char":
                                    propInfo.SetValue(objSource, Convert.ToChar(drSource[propInfo.Name]), null);
                                    break;
                                case "system.boolean":
                                    propInfo.SetValue(objSource, Convert.ToBoolean(drSource[propInfo.Name]), null);
                                    break;
                                case "system.string":
                                    propInfo.SetValue(objSource, drSource[propInfo.Name].ToString(), null);
                                    break;
                                case "system.datetime":
                                    if (drSource[propInfo.Name] != DBNull.Value)
                                        propInfo.SetValue(objSource, Convert.ToDateTime(drSource[propInfo.Name]), null);
                                    break;
                                case "system.collections.arraylist":
                                    if (drSource[propInfo.Name] != DBNull.Value && drSource[propInfo.Name].ToString().Length > 0)
                                    {
                                        string strValue = drSource[propInfo.Name].ToString();
                                        char chrDelim = strValue.ToCharArray()[0];
                                        string[] arrValues = strValue.Split(chrDelim);
                                        ArrayList arrList = new ArrayList();
                                        for (int i = 1; i < arrValues.Length; i++)
                                        {
                                            arrList.Add(arrValues[i]);
                                        }
                                        propInfo.SetValue(objSource, arrList, null);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion
        public static int Save(String procedureName, SqlParameter[] sqlparam, String errorMsg)
        {
            
            SqlConnection objConnection4Trans4ANDAUDIT1_DEV = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand();
                objConnection4Trans4ANDAUDIT1_DEV.Open();
                cmd = new SqlCommand(procedureName, objConnection4Trans4ANDAUDIT1_DEV);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlparam);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message.ToString();
                DateTime dateEx = DateTime.Now;
                return 0;
            }
            finally
            {
                objConnection4Trans4ANDAUDIT1_DEV.Close();
            }

        }
        public static DataTable GetDataTable(String procedureName, SqlParameter[] sqlparam, String errorMsg)
        {
            SqlConnection objConnection4Trans4ANDAUDIT1_DEV = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
            //SqlConnection objConnection4Trans4ANDAUDIT1_DEV = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["cn"]);
            //SqlConnection objConnection4Trans4ANDAUDIT1_DEV1 =(SqlConnection)System.Configuration.ConfigurationManager.AppSettings["PFUserName"].ToString();
            try
            {
                DataTable st = new DataTable();
                SqlCommand cmd = new SqlCommand();
                objConnection4Trans4ANDAUDIT1_DEV.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand(procedureName, objConnection4Trans4ANDAUDIT1_DEV);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlparam != null)
                {
                    cmd.Parameters.AddRange(sqlparam);
                }
                da.SelectCommand = cmd;
                da.Fill(st);
                // cmd = null;
                return st;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message.ToString();
                DateTime dateEx = DateTime.Now;
                return null;
            }
            finally
            {
                objConnection4Trans4ANDAUDIT1_DEV.Close();
            }

        }
        public static DataSet GetDataSet(String procedureName, SqlParameter[] sqlparam, String errorMsg)
        {
            SqlConnection objConnection4Trans4ANDAUDIT1_DEV = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
            try
            {

                DataSet st = new DataSet();
                SqlCommand cmd = new SqlCommand();
                objConnection4Trans4ANDAUDIT1_DEV.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand(procedureName, objConnection4Trans4ANDAUDIT1_DEV);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlparam != null)
                {
                    cmd.Parameters.AddRange(sqlparam);
                }
                da.SelectCommand = cmd;
                da.Fill(st);
                // cmd = null;
                return st;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message.ToString();
                DateTime dateEx = DateTime.Now;
                return null;
            }
            finally
            {
                objConnection4Trans4ANDAUDIT1_DEV.Close();
            }

        }

        public static DataSet GetMailConfig(String procedureName, String errorMsg)
        {
            SqlConnection objConnection4Trans4ANDAUDIT1_DEV = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
            try
            {

                DataSet st = new DataSet();
                SqlCommand cmd = new SqlCommand();
                objConnection4Trans4ANDAUDIT1_DEV.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand(procedureName, objConnection4Trans4ANDAUDIT1_DEV);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(st);
                // cmd = null;
                return st;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message.ToString();
                DateTime dateEx = DateTime.Now;
                return null;
            }
            finally
            {
                objConnection4Trans4ANDAUDIT1_DEV.Close();
            }

        }


        public static Boolean SendMail(string EmailTo, out string ErrorMessage, string Subject = "Email Subject", string EmailBody = "Email Body", string EmailFrom = "", string[] EmailToCC = null, string[] EmailToBCC = null, NetworkCredential objNC = null,string AttachmentPath="")
        {
            Boolean _IsMailSent = false;
            //EmailTo = EmailFrom;
            ErrorMessage = string.Empty;
            try
            {
                string _EmailFrom = string.Empty;
                _EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EMAIL_FROM"].ToString(); // (string.IsNullOrEmpty(EmailFrom) ? 

                if (!IsValidMail(_EmailFrom, out ErrorMessage))
                {
                    return false;
                }
                if ((!EmailTo.Contains(",")) && (!EmailTo.Contains(";")))
                {
                    if (!IsValidMail(EmailTo, out ErrorMessage))
                    {
                        return false;
                    }
                }

                using (MailMessage mm = new MailMessage())
                {
                    string SMTPHostAddress = System.Configuration.ConfigurationManager.AppSettings["SMTPHostAddress"];
                    string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];
                    //  string MailURL = System.Configuration.ConfigurationManager.AppSettings["MailURL"];
                    //string MailURL = System.Configuration.ConfigurationManager.AppSettings["MailURL"];
                    if (AttachmentPath!="")
                    {
                        mm.Attachments.Add(new Attachment(AttachmentPath));
                    }
                   // mm.Attachments.Add(new Attachment(PathToAttachment));
                    mm.Subject = Subject;
                    EmailBody = "<!DOCTYPE html> <html> <body> " + EmailBody + "</body> </html>";
                    mm.Body = EmailBody;
                    mm.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(EmailTo))
                    {
                        string[] MailTo = EmailTo.Replace(',', ';').Split(';');
                        foreach (object m in MailTo)
                        {
                            if (m != null)
                            {
                                if (IsValidMail(m.ToString(), out ErrorMessage))
                                {
                                    mm.To.Add(m.ToString());
                                }
                            }
                        }
                    }

                    if (EmailToCC != null)
                    {
                        foreach (object m in EmailToCC)
                        {
                            if (m != null)
                            {
                                if (IsValidMail(m.ToString(), out ErrorMessage))
                                {
                                    mm.CC.Add(m.ToString());
                                }
                            }
                        }
                    }

                    if (EmailToBCC != null)
                    {
                        foreach (object m in EmailToBCC)
                        {
                            if (m != null)
                            {
                                if (IsValidMail(m.ToString(), out ErrorMessage))
                                {
                                    mm.Bcc.Add(m.ToString());
                                }
                            }
                        }
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = SMTPHostAddress;
                    if (objNC != null)
                    {
                        System.Net.Mail.MailAddress ma = new System.Net.Mail.MailAddress(objNC.UserName);
                        mm.From = ma;
                        smtp.Credentials = objNC;
                    }
                    else
                    {
                        System.Net.Mail.MailAddress ma = new System.Net.Mail.MailAddress(_EmailFrom);
                        mm.From = ma;
                        smtp.Credentials = new System.Net.NetworkCredential(_EmailFrom, ConfigurationManager.AppSettings["PASS"]);
                    }
                    smtp.EnableSsl = true;
                    //smtp.Timeout = 300000;
                    smtp.Port = Convert.ToInt32(Port);
                    smtp.Send(mm);
                    _IsMailSent = true;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
            }
            return _IsMailSent;
        }

        public static bool IsValidMail(string emailaddress, out string ErrorMessage)
        {
            Boolean _result = true;
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                ErrorMessage = string.Empty;
            }
            catch (FormatException ex)
            {
                ErrorMessage = ex.Message;
                _result = false;
            }
            return _result;
        }

    }
}