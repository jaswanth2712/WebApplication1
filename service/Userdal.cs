using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.service
{
    public class Userdal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        
        public List<Usermodel>GetUsers()
        {
            cmd = new SqlCommand("tselect",con);
            cmd.CommandType = CommandType.StoredProcedure;                                   
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Usermodel> list = new List<Usermodel>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Usermodel
                {
                    id = Convert.ToInt32(dr["id"]),
                    name = dr["fname"].ToString(),
                    email = dr["email"].ToString(),
                    age=Convert.ToInt32(dr["age"])
                });
            }
            return list;
        }

        public bool Insertusers(Usermodel user)
        {
            try
            {
                cmd = new SqlCommand("tinsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", user.name);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@age", user.age);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception )
            {
                throw;
            }

        }

        public bool Updateusers(Usermodel user)
        {
            try
            {
                cmd = new SqlCommand("tupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", user.name);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@age", user.age);
                cmd.Parameters.AddWithValue("@id", user.id);

                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public int Deleteusers(int id)
        {
            try
            {


                cmd = new SqlCommand("tdelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@id",id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}