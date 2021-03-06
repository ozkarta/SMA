﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace SMA.CS
{
    public static class Comunication
    {
        //static String connectionString = "Data Source=tcp:78.139.172.254,1973;Initial Catalog=smaDataBase;User ID=sa;Password=12qwert12";
       static string connectionString = "Data Source=.;Initial Catalog=smaDataBase;Integrated Security=True";
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
    

       
        public static bool existsUserName(string userName)
        {
            bool result=true;
            using (con=new SqlConnection(connectionString))
            {
                using(cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "userNameValidation";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userName",userName);
                    try
                    {
                        con.Open();
                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader[0].ToString() == "-1")
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                        }
                        con.Close();
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
            return result;
        }


        public static bool existsEMail(string mail)
        {
            bool result = true;
            using (con = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "mailValidation";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mail", mail);
                    try
                    {
                        con.Open();
                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader[0].ToString() == "-1")
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
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
            return result;
        }


        public static bool generalRegistration(string defaultLanguage,string userName,string firstName ,string lastName,string phone 
                                            ,string email ,string password ,string salt)
        {
            string userGUID = "";
            using (con=new SqlConnection(connectionString))
            {
                using(cmd=new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandText = "registerUser";
                    cmd.Parameters.AddWithValue("@defaultLanguage", defaultLanguage);
                    cmd.Parameters.AddWithValue("@userName",userName);
                    cmd.Parameters.AddWithValue("@firstName",firstName);
                    cmd.Parameters.AddWithValue("@lastName",lastName);
                    cmd.Parameters.AddWithValue("@phone",phone);
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@passwordHash", password);
                    cmd.Parameters.AddWithValue("@salt", salt);

                    try
                    {
                        con.Open();

                        userGUID=cmd.ExecuteScalar().ToString();
                        con.Close();
                        sendEmailConfirmation(userGUID, email, firstName, lastName);
                        return true;
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return false;
                    }
                }
            }            
        }


        private static void sendEmailConfirmation(string userGUID,string mail,string fname,string lname)
        {
            using (MailMessage mm = new MailMessage("ozbegi1@gmail.com", mail))
            {
                mm.Subject = "Account Activation  for www.ozzle.com";
                string body = "Hello " + fname+"  "+lname + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + "http://localhost:50869/Account/EmailConfirmation?" + "userGUID=" + userGUID + "" + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("ozbegi1@gmail.com", "1donozok1");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

        public static void activateUser(string userGUID)
        {
            using (con = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "activateUser";
                    cmd.Parameters.AddWithValue("@userGUID", userGUID);                    
                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        cmd.ExecuteScalar();
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