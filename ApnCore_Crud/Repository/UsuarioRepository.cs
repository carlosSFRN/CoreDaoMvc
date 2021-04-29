using System;
using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ApnCore_Crud.Data;

namespace ApnCore_Crud.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString = DataContext.GetConnection();

        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                        NomeUsuario = rdr["NomeUsuario"].ToString(),
                        Cpf = rdr["Cpf"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Telefone = rdr["Telefone"].ToString()
                    };

                    listaUsuario.Add(usuario);
                }
                con.Close();
            }
            return listaUsuario;
        }

        public void Add(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Usuario GetId(int? id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuario", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorId");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                    usuario.NomeUsuario = rdr["NomeUsuario"].ToString();
                    usuario.Cpf = rdr["Cpf"].ToString();
                    usuario.Email = rdr["Email"].ToString();
                    usuario.Telefone = rdr["Telefone"].ToString();
                }
            }
            return usuario;
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idUsuario", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
