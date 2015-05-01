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
       static String connectionString = "Data Source=.;Initial Catalog=smaDataBase;Integrated Security=True";
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

                    int counter = 0;
                        try
                        {
                            con.Open();
                            List<string> keys = new List<string>();

                            foreach (string key in t.Keys)
                                keys.Add(key);
                            foreach(string key in keys)
                                {
                                    
                                    
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@languageGUID",languageGUID);
                                    cmd.Parameters.AddWithValue("@variableName",key);
                                    using (reader = cmd.ExecuteReader())
                                    {
                                        while(reader.Read())
                                        {
                                            t[key] = reader[0].ToString();
                                            counter++;
                                            Debug.WriteLine(reader[0].ToString());
                                        }
                                    }
                                    Debug.WriteLine(key+ "   -------  "+t[key].ToString());
                                }
                            con.Close();
                            if (counter == 0)
                            {
                                GlobalVariables.rollBackLanguage();
                            }
                            else
                            {
                                GlobalVariables.updateLanguage();
                            }
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