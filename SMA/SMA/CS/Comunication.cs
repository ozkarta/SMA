using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace SMA.CS
{
    public static class Comunication
    {
       static  String connectionString = "";
       static  SqlConnection con;
       static  SqlDataAdapter adapter;
       static  SqlCommand cmd;
       static  SqlDataReader reader;


        public static DataSet getLanguages()
        {
            DataSet ds = null;

            using (con=new SqlConnection(connectionString))
            {
                using (cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getLanguages";

                    using (adapter = new SqlDataAdapter(cmd))
                    {
                        ds=new DataSet();
                        adapter.Fill(ds);
                    }

                }
            }

            return ds;

        }
    }

}