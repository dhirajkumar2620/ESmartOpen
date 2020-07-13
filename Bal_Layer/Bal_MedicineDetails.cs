using App_Layer;
using Dal_Layer;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Layer
{
    public class Bal_MedicineDetails
    {
        Dal_MedicineDetails DP = new Dal_MedicineDetails();

        public int ManageMedicineDetails(MedicineDetails MD)
        {
            return DP.ManageMedicineDetails(MD);
        }

        public MedicineDetails ViewAllMedicine(int hId)
        {
            return DP.ViewAllMedicine(hId);
        }
        public int DeleteMedicine(int MedicineId)
        {
            return DP.DeleteMedicine(MedicineId);
        }

        public List<MedicineDetails> GetDataFromCSVFile(Stream stream , int Hid)
        {
            var lstMedicineDetails = new List<MedicineDetails>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names  
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            lstMedicineDetails.Add(new MedicineDetails()
                            {
                                MedicineId = Convert.ToInt32(objDataRow["MedicineId"].ToString()),
                                MedicineName = objDataRow["MedicineName"].ToString(),
                                MedicineType = objDataRow["MedicineType"].ToString(),
                                GenericName = objDataRow["GenericName"].ToString(),
                                Range = objDataRow["Range"].ToString(),
                                Other = objDataRow["Other"].ToString(),
                                HospitalId = Hid
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstMedicineDetails;
        }
        private IDisposable CreateCsvReader(Stream stream)
        {
            throw new NotImplementedException();
        }

        public int ImportAll(Stream inputStream, int Hid)
        {
            List<MedicineDetails> fileData = GetDataFromCSVFile(inputStream ,Hid);
            //convert fileData into DataTable
            var dtImportMedicines = fileData.ToDataTable();
            return DP.BulkImportMedicines(dtImportMedicines);
        }
    }
    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties  
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table   
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows  
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            dataTable.Columns.Remove("lst");
            return dataTable;
        }
    }
}
