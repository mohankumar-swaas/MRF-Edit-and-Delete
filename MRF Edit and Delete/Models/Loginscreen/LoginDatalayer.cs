using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_Edit_and_Delete.Models.Loginscreen
{
    public class LoginDatalayer
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;

        public int Loginvalidation(LoginModel Log)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("[LoginValidate]", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Userid", Log.Userid);
                    com.Parameters.AddWithValue("@Password", Log.Password);

                    i = (Int32)com.ExecuteScalar();
                }
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}