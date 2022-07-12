using Aviation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Aviation.Repository
{
    public class SpoterRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Aircraft details    
        public bool AddAircraft(AircraftModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewAircraftDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Make", obj.Make);
            com.Parameters.AddWithValue("@Model", obj.Model);
            com.Parameters.AddWithValue("@Registration", obj.Registration);
            com.Parameters.AddWithValue("@Location", obj.Location);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view Aircraft details with generic list     
        public List<AircraftModel> GetAllAircraftDetails()
        {
            connection();
            List<AircraftModel> AircraftList = new List<AircraftModel>();


            SqlCommand com = new SqlCommand("GetAircrafts", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                AircraftList.Add(

                    new AircraftModel
                    {

                        ID = Convert.ToInt32(dr["ID"]),
                        Make = Convert.ToString(dr["Make"]),
                        Model = Convert.ToString(dr["Model"]),
                        Registration = Convert.ToString(dr["Registration"]),
                        Location = Convert.ToString(dr["Location"]),
                        TimeStamp = Convert.ToString(dr["Timestamp"])

                    }
                    );
            }

            return AircraftList;
        }
        public List<AircraftModel> SearchAircraftDetails(string option,string search)
        {
            connection();
            List<AircraftModel> AircraftList = new List<AircraftModel>();


            SqlCommand com = new SqlCommand("SearchAircrafts", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@option", option);
            com.Parameters.AddWithValue("@search", search);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind AircraftModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                AircraftList.Add(

                    new AircraftModel
                    {

                        ID = Convert.ToInt32(dr["ID"]),
                        Make = Convert.ToString(dr["Make"]),
                        Model = Convert.ToString(dr["Model"]),
                        Registration = Convert.ToString(dr["Registration"]),
                        Location = Convert.ToString(dr["Location"]),
                        TimeStamp = Convert.ToString(dr["Timestamp"])

                    }
                    );
            }

            return AircraftList;
        }
        //To Update Aircraft details    
        public bool UpdateAircraft(AircraftModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateAircraftDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", obj.ID);
            com.Parameters.AddWithValue("@Make", obj.Make);
            com.Parameters.AddWithValue("@Model", obj.Model);
            com.Parameters.AddWithValue("@Registration", obj.Registration);
            com.Parameters.AddWithValue("@Location", obj.Location);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Aircraft details    
        public bool DeleteAircraft(int ID)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteAircraftById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", ID);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}