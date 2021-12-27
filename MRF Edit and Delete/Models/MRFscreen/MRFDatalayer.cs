using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_Edit_and_Delete.Models.MRFscreen
{
    public class MRFDatalayer
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;

        public int Add(MRFModel MRFAdd)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("[Sp_insertT_MRFTrs]", con);
                    com.CommandType = CommandType.StoredProcedure;
                    //com.Parameters.AddWithValue("@Id", MRFAdd.id);
                    com.Parameters.AddWithValue("@PositionName", MRFAdd.PositionName);
                    com.Parameters.AddWithValue("@MRF_Created_By", MRFAdd.Created_By);
                    com.Parameters.AddWithValue("@MRF_Created_Date", MRFAdd.MRF_Created_Date);
                    com.Parameters.AddWithValue("@Position_to_be_filled_before", MRFAdd.Position_to_be_filled_before);
                    com.Parameters.AddWithValue("@Vacancy_For", MRFAdd.Vacancy_For);
                    com.Parameters.AddWithValue("@Vacancy_Type", MRFAdd.Vacancy_Type);
                    com.Parameters.AddWithValue("@TerritoryHQ", MRFAdd.TerritoryHQ);
                    com.Parameters.AddWithValue("@DivisionName", MRFAdd.DivisionName);
                    com.Parameters.AddWithValue("@Min_Yrs", MRFAdd.Min_Yrs);
                    com.Parameters.AddWithValue("@Max_yrs", MRFAdd.Max_yrs);
                    com.Parameters.AddWithValue("@MaxCTC", MRFAdd.MaxCTC);
                    com.Parameters.AddWithValue("@MinCTC", MRFAdd.MinCTC);
                    com.Parameters.AddWithValue("@Additional_Requirement", MRFAdd.Additional_Requirement);
                    com.Parameters.AddWithValue("@Userid", MRFAdd.Created_By);


                    i = com.ExecuteNonQuery();
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