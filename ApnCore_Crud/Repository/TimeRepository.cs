using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository
{
    public class TimeRepository : ITimeRepository
    {
        const string connectionString = @"Data Source=192.168.0.1;Initial Catalog=dbEli; User Id=70235347418;Password=Log@1234"; //ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<Time> GetAll()
        {
            List<Time> listaTime = new List<Time>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Time_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Time time = new Time();

                    time.idTime = Convert.ToInt32(rdr["idTime"]);
                    time.Nome = rdr["Nome"].ToString();

                    listaTime.Add(time);
                }
                con.Close();
            }
            return listaTime;
        }

        public void Add(Time time)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Time_ins", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.AddWithValue("@Nome", time.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Update(Time time)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Time_upd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.AddWithValue("@FuncionarioId", time.idTime);
                cmd.Parameters.AddWithValue("@Nome", time.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Time Get(int? id)
        {
            Time time = new Time();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Time_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (id == Convert.ToInt32(rdr["idTime"]))
                    {
                        time.idTime = Convert.ToInt32(rdr["idTime"]);
                        time.Nome = rdr["Nome"].ToString();
                        break;
                    }
                }
            }
            return time;
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Time_del", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.AddWithValue("@idTime", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
