using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Diagnostics;

namespace SMA.CS
{
    public static class Comunication
    {
        static String connectionString = "Data Source=tcp:78.139.172.254,1973;Initial Catalog=smaDataBase;Persist Security Info=True;User ID=sa;Password=12qwert12";
       static  SqlConnection con;
       static  SqlDataAdapter adapter;
       static  SqlCommand cmd;
       static  SqlDataReader reader;


        public static void getLanguages(Hashtable t)
        {
            using (con=new SqlConnection(connectionString))
            {
                using (cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getLanguageList";

                    try
                    {
                        con.Open();
                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t.Add(reader["languageName"], reader["languageGUID"]);
                            }
                            
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
            }
        }

        public static void setVariables(string languageGUID,Hashtable t)
        {
            using (con = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getTranslatedVariableValue";
                    foreach (DictionaryEntry entry in t)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@languageGUID", "'"+languageGUID+"'");
                        cmd.Parameters.AddWithValue("@variableName", "'" + entry.Key.ToString()+"'");
                        Debug.WriteLine(entry.Key.ToString());
                        try
                        {
                            con.Open();
                            using (reader = cmd.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    t[entry.Key.ToString()] = reader[0];
                                }
                            }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.ToString());
                        }
                        
                    }
                }
            }
        }
    }

}