using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApnCore_Crud.Data;

namespace ApnCore_Crud.Repository
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly string connectionString = DataContext.GetConnection();

        public IEnumerable<Estabelecimento> GetAll()
        {
            List<Estabelecimento> listaEstabelecimento = new List<Estabelecimento>();

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
                    Estabelecimento estabelecimento = new Estabelecimento();

                    estabelecimento.IdEstabelecimento = Convert.ToInt32(rdr["IdEstabelecimento"]);
                    estabelecimento.NomeEstabelecimento = rdr["NomeEstabelecimento"].ToString();
                    estabelecimento.NomeFantasia = rdr["NomeFantasia"].ToString();
                    estabelecimento.Cep = rdr["Cep"].ToString();
                    estabelecimento.Endereco = rdr["Endereco"].ToString();
                    estabelecimento.Numero = rdr["Numero"].ToString();
                    estabelecimento.Bairro = rdr["Bairro"].ToString();
                    estabelecimento.Uf = rdr["Uf"].ToString();
                    estabelecimento.Cnpj = rdr["Cnpj"].ToString();
                    estabelecimento.Email = rdr["Email"].ToString();
                    estabelecimento.Telefone = rdr["Telefone"].ToString();

                    listaEstabelecimento.Add(estabelecimento);
                }
                con.Close();
            }
            return listaEstabelecimento;
        }

        public void Add(Estabelecimento estabelecimento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Estabelecimento_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeEstabelecimento", estabelecimento.NomeEstabelecimento);
                cmd.Parameters.AddWithValue("@NomeFantasia", estabelecimento.NomeFantasia);
                cmd.Parameters.AddWithValue("@Cep", estabelecimento.Cep);
                cmd.Parameters.AddWithValue("@Endereco", estabelecimento.Endereco);
                cmd.Parameters.AddWithValue("@Numero", estabelecimento.Numero);
                cmd.Parameters.AddWithValue("@Bairro", estabelecimento.Bairro);
                cmd.Parameters.AddWithValue("@Uf", estabelecimento.Uf);
                cmd.Parameters.AddWithValue("@Cnpj", estabelecimento.Cnpj);
                cmd.Parameters.AddWithValue("@Email", estabelecimento.Email);
                cmd.Parameters.AddWithValue("@Telefone", estabelecimento.Telefone);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Estabelecimento estabelecimento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Estabelecimento_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idEstabelecimento", estabelecimento.IdEstabelecimento);
                cmd.Parameters.AddWithValue("@NomeEstabelecimento", estabelecimento.NomeEstabelecimento);
                cmd.Parameters.AddWithValue("@NomeFantasia", estabelecimento.NomeFantasia);
                cmd.Parameters.AddWithValue("@Cep", estabelecimento.Cep);
                cmd.Parameters.AddWithValue("@Endereco", estabelecimento.Endereco);
                cmd.Parameters.AddWithValue("@Numero", estabelecimento.Numero);
                cmd.Parameters.AddWithValue("@Bairro", estabelecimento.Bairro);
                cmd.Parameters.AddWithValue("@Uf", estabelecimento.Uf);
                cmd.Parameters.AddWithValue("@Cnpj", estabelecimento.Cnpj);
                cmd.Parameters.AddWithValue("@Email", estabelecimento.Email);
                cmd.Parameters.AddWithValue("@Telefone", estabelecimento.Telefone);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Estabelecimento GetId(int? id)
        {
            Estabelecimento estabelecimento = new Estabelecimento();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Estabelecimento_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEstabelecimento", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorId");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    estabelecimento.IdEstabelecimento = Convert.ToInt32(rdr["IdEstabelecimento"]);
                    estabelecimento.NomeEstabelecimento = rdr["NomeEstabelecimento"].ToString();
                    estabelecimento.NomeFantasia = rdr["NomeFantasia"].ToString();
                    estabelecimento.Cep = rdr["Cep"].ToString();
                    estabelecimento.Endereco = rdr["Endereco"].ToString();
                    estabelecimento.Numero = rdr["Numero"].ToString();
                    estabelecimento.Bairro = rdr["Bairro"].ToString();
                    estabelecimento.Uf = rdr["Uf"].ToString();
                    estabelecimento.Cnpj = rdr["Cnpj"].ToString();
                    estabelecimento.Email = rdr["Email"].ToString();
                    estabelecimento.Telefone = rdr["Telefone"].ToString();
                }
            }
            return estabelecimento;
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_Estabelecimento_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idEstabelecimento", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
