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
       static  String connectionString = "";
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
                    cmd.CommandText = "getLanguages";

                    try
                    {
                        con.Open();
                        using (reader = cmd.ExecuteReader())
                        {
                            t.Add(reader["languageName"], reader["languageGUID"]);
                        }
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
                        cmd.Parameters.AddWithValue("@languageGUID", languageGUID);
                        cmd.Parameters.AddWithValue("@variableName", entry.Key);
                        try
                        {
                            con.Open();
                            using (reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    t[entry.Key] = reader["value"];
                                }
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

}