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
    public class MenuSistemaRepository : IMenuSistemaRepository
    {
        private readonly string connectionString = DataContext.GetConnection();

        public IEnumerable<Sistema> GetAll()
        {
            List<Sistema> listaSistema = new List<Sistema>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("stp_MenuSistema_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Sistema sistema = new Sistema
                    {
                        IdSistema = Convert.ToInt32(rdr["IdSistema"]),
                        Codigo = rdr["Codigo"].ToString(),
                        Caption = rdr["Caption"].ToString(),
                        Icone = rdr["Icone"].ToString(),
                        Bloqueio = Convert.ToBoolean(rdr["Bloqueio"]),
                        Ordem = Convert.ToInt32(rdr["Ordem"])
                    };

                    listaSistema.Add(sistema);
                }
                con.Close();
            }
            return listaSistema;
        }
    }
}
