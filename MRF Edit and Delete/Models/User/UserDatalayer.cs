using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_Edit_and_Delete.Models.User
{
    public class UserDatalayer
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;
        public List<UserModel> ListAll(string Userid)
        {
            List<UserModel> objMRFmodels = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("[Sp_Getmymrfdetails]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Userid",Userid);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    objMRFmodels.Add(new UserModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        Userid = Convert.ToString(rdr["Userid"]),
                        PositionName = Convert.ToString(rdr["PositionName"]),                       
                        VacancyField = Convert.ToString(rdr["VacancyName"]),                      
                        TerritoryHQ = Convert.ToString(rdr["TerritoryHQ"]),
                    });

                }
                return objMRFmodels;

            }
        }
        public int Update(MRFModel user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_Update", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", user.id);
                com.Parameters.AddWithValue("@PositionName", user.PositionName);
                com.Parameters.AddWithValue("@MRF_Created_Date", user.MRF_Created_Date);
                com.Parameters.AddWithValue("@Position_to_be_filled_before", user.Position_to_be_filled_before);
                com.Parameters.AddWithValue("@Vacancy_For", user.Vacancy_For);
                com.Parameters.AddWithValue("@Vacancy_Type", user.Vacancy_Type);
                com.Parameters.AddWithValue("@TerritoryHQ", user.TerritoryHQ);
                com.Parameters.AddWithValue("@DivisionName", user.DivisionName);
                com.Parameters.AddWithValue("@Min_Yrs", user.Min_Yrs);
                com.Parameters.AddWithValue("@Max_yrs", user.Max_yrs);
                com.Parameters.AddWithValue("@MinCTC", user.MinCTC);
                com.Parameters.AddWithValue("@MaxCTC", user.MaxCTC);
                com.Parameters.AddWithValue("@Additional_Requirement", user.Additional_Requirement);


                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_DeleteUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;

        }
        public List<MRFModel> MRFdetails()
        {
            List<MRFModel> objMRFmodels = new List<MRFModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("[Sp_Getmymrfdetails]", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    objMRFmodels.Add(new MRFModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        PositionName = Convert.ToString(rdr["PositionName"]),
                        Created_By = Convert.ToString(rdr["MRF_Created_By"]),
                        MRF_Created_Date = Convert.ToDateTime(rdr["MRF_Created_Date"]),
                        Position_to_be_filled_before = Convert.ToDateTime(rdr["Position_to_be_filled_before"]),
                        Vacancy_For = Convert.ToInt32(rdr["Vacancy_For"]),
                        Vacancy_Type = Convert.ToInt32(rdr["Vacancy_Type"]),
                        TerritoryHQ = Convert.ToString(rdr["TerritoryHQ"]),
                        DivisionName = Convert.ToString(rdr["DivisionName"]),
                        Min_Yrs = Convert.ToInt32(rdr["Min_yrs"]),
                        Max_yrs = Convert.ToInt32(rdr["Max_Yrs"]),
                        MinCTC = Convert.ToInt32(rdr["MinCTC"]),
                        MaxCTC = Convert.ToInt32(rdr["MaxCTC"]),
                        Additional_Requirement = Convert.ToString(rdr["Additional_Requirement"]),
                       
                    });

                }
                return objMRFmodels;

            }
        }
    }
}