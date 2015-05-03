using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using System.Data.SqlClient;
using System.Diagnostics;
namespace excelImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_i = 2;
            int cn_j = 2;

            int fn_j = 3;


            int type_j = 4;


            int capital_j = 7;


            int cc_j = 8;
            int currname_j = 9;

            int itu_j = 10;
            int lc12_j = 11;
            int lc13_j = 12;
            int ccltd_j = 14;



            string filePath = @"C:\Users\ozbegi\Documents\GitHub\SMA\excelImporter\excelImporter\iso_3166_2_countries.csv";
            Microsoft.Office.Interop.Excel.Application xlApplication = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook = new Microsoft.Office.Interop.Excel.Workbook();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApplication.Workbooks.Add();
           
            
            Microsoft.Office.Interop.Excel.Range xlRange;

            xlWorkBook=xlApplication.Workbooks.Open(filePath);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = xlWorkBook.ActiveSheet;
            xlRange = xlWorkSheet.UsedRange;

            string commanName = "";
            string formalName = "";
            string type = "";
            string capital = "";
            string currencyCode = "";
            string currencyName = "";
            string telephoneCode = "";
            string letterCode12 = "";
            string letterCode13 = "";
            string countryCodeLTD = "";
            for(int i =i_i;i<xlRange.Rows.Count;i++)
            {
                if((xlRange.Cells[i,cn_j] as Microsoft.Office.Interop.Excel.Range).Value!= null)
                {
                    commanName = (string)(xlRange.Cells[i, cn_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(commanName);
                }
                if ((xlRange.Cells[i, fn_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    formalName = (string)(xlRange.Cells[i, fn_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(formalName);
                }
                ///////////////////////////////////
                if ((xlRange.Cells[i, type_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    type = (string)(xlRange.Cells[i, type_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(type);
                }
                ///////////////////
                if ((xlRange.Cells[i, capital_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    capital = (string)(xlRange.Cells[i, capital_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(capital);
                }
                /////////////////////////
                if ((xlRange.Cells[i, cc_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    currencyCode = (string)(xlRange.Cells[i, cc_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(currencyCode);
                }
                /////////////////////////
                if ((xlRange.Cells[i, cn_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    currencyName = (string)(xlRange.Cells[i, currname_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(currencyName);
                }
                if ((xlRange.Cells[i, itu_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    telephoneCode = ""+(xlRange.Cells[i, itu_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(telephoneCode);
                }///////////////////////////
                if ((xlRange.Cells[i, lc12_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    letterCode12 = (string)(xlRange.Cells[i, lc12_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(letterCode12);
                }
                if ((xlRange.Cells[i, lc13_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    letterCode13 = (string)(xlRange.Cells[i, lc13_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(letterCode13);
                }
                if ((xlRange.Cells[i, ccltd_j] as Microsoft.Office.Interop.Excel.Range).Value != null)
                {
                    countryCodeLTD = (string)(xlRange.Cells[i, ccltd_j] as Microsoft.Office.Interop.Excel.Range).Value;
                    Debug.WriteLine(countryCodeLTD);
                }
                writetoDataBase(commanName, formalName, type, capital, currencyCode, currencyName, telephoneCode, letterCode12, letterCode13, countryCodeLTD);
                commanName = "";
                formalName = "";
                type = "";
                capital = "";
                currencyCode = "";
                currencyName = "";
                telephoneCode = "";
                letterCode12 = "";
                letterCode13 = "";
                countryCodeLTD = "";
            }
            {

            }




        }

        public static void  writetoDataBase(string commanName,string formalName,string type, string capital,string currencyCode
                        ,string currencyName,string telephoneCode,string letterCode12,string letterCode13,string countryCodeLTD)
        {
            SqlConnection con;
            SqlCommand cmd;
            string connectionString = "Data Source=tcp:78.139.172.254,1973;Initial Catalog=smaDataBase;User ID=sa;Password=12qwert12";
            using(con=new SqlConnection(connectionString))
            {
                using (cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    string command="insert into  [countriesIso]([countryGUID]"+
                                                  ",[Comman Name]"+
                                                  ",[Formal Name]"+
                                                  ",[Type]"+
                                                  ",[Capital]"+
                                                  ",[ISO 4217 Currency Code]"+
                                                  ",[ISO 4217 Currency Name]"+
                                                 " ,[ITU-T Telephone Code]"+
                                                  ",[ISO 3166-12 Letter Code]"+
                                                  ",[ISO 3166-13 Letter Code]"+
                                                  ",[IANA Country Code TLD])"+
                                            "SELECT"+" newid(),"+
                                                     "'" +commanName + "',"+
                                                     "'"+formalName+"',"+
                                                     "'" + type + "',"+
                                                     "'" + capital + "',"+
                                                     "'" + currencyCode + "',"+
                                                     "'" + currencyName + "',"+
                                                     "'" + telephoneCode + "',"+
                                                     "'" + letterCode12 + "',"+
                                                     "'" + letterCode13 + "',"+
                                                      "'" + countryCodeLTD + "'";
                    cmd.CommandText = command;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }catch(Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                    
                }
            }
        }
    }
}
