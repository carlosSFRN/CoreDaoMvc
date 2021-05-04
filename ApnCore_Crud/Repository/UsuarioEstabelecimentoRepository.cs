using ApnCore_Crud.Controllers;
using ApnCore_Crud.Data;
using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository
{
    public class UsuarioEstabelecimentoRepository : IUsuarioEstabelecimentoRepository
    {
        private readonly string connectionString = DataContext.GetConnection();

        public IEnumerable<UsuarioEstabelecimento> GetAll(int id)
        {
            List<UsuarioEstabelecimento> listaUsuarioEstabelecimento = new List<UsuarioEstabelecimento>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_UsuarioEstabelecimento_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuario", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsuarioEstabelecimento usuarioEstabelecimento = new UsuarioEstabelecimento
                    {
                        IdUsuarioEstabelecimento = Convert.ToInt32(rdr["IdOperadorEstabelecimento"]),
                        IdEstabelecimento = Convert.ToInt32(rdr["IdEstabelecimento"]),
                        NomeEstabelecimento = rdr["NomeEstabelecimento"].ToString(),
                        IdUsuario = Convert.ToInt32(rdr["IdEstabelecimento"])
                    };

                    listaUsuarioEstabelecimento.Add(usuarioEstabelecimento);
                }
                con.Close();
            }
            return listaUsuarioEstabelecimento;
        }

        public IEnumerable<UsuarioEstabelecimento> GetAllEstabelecimentos()
        {
            List<UsuarioEstabelecimento> listaUsuarioEstabelecimento = new List<UsuarioEstabelecimento>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Estabelecimento_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsuarioEstabelecimento usuarioEstabelecimento = new UsuarioEstabelecimento
                    {
                        IdEstabelecimento = Convert.ToInt32(rdr["IdEstabelecimento"]),
                        NomeEstabelecimento = rdr["NomeEstabelecimento"].ToString()
                    };

                    listaUsuarioEstabelecimento.Add(usuarioEstabelecimento);
                }
                con.Close();
            }
            return listaUsuarioEstabelecimento;
        }


        public void Add(UsuarioEstabelecimento usuarioEstabelecimento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_UsuarioEstabelecimento_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEstabelecimento", usuarioEstabelecimento.IdEstabelecimento);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioEstabelecimento.IdUsuario);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(UsuarioEstabelecimento usuarioEstabelecimento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEstabelecimento", usuarioEstabelecimento.IdEstabelecimento);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioEstabelecimento.IdUsuario);
                cmd.Parameters.AddWithValue("@IdUsuarioEstabelecimento", usuarioEstabelecimento.IdUsuarioEstabelecimento);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public UsuarioEstabelecimento GetId(int? id)
        {
            UsuarioEstabelecimento usuarioEstabelecimento = new UsuarioEstabelecimento();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_UsuarioEstabelecimento_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuarioEstabelecimento", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorIdUsuarioEstabelecimento");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    usuarioEstabelecimento.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                    usuarioEstabelecimento.IdEstabelecimento = Convert.ToInt32(rdr["IdEstabelecimento"]);
                    usuarioEstabelecimento.NomeEstabelecimento = rdr["NomeEstabelecimento"].ToString();
                    usuarioEstabelecimento.IdUsuarioEstabelecimento = Convert.ToInt32(rdr["IdOperadorEstabelecimento"]);
                }
            }
            return usuarioEstabelecimento;
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_UsuarioEstabelecimento_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuarioEstabelecimento", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
