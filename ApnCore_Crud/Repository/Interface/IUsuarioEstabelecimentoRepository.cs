using ApnCore_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository.Interface
{
    public interface IUsuarioEstabelecimentoRepository
    {
        IEnumerable<UsuarioEstabelecimento> GetAll(int id);
        IEnumerable<UsuarioEstabelecimento> GetAllEstabelecimentos();
        void Add(UsuarioEstabelecimento usuarioEstabelecimento);
        void Edit(UsuarioEstabelecimento usuarioEstabelecimento);
        UsuarioEstabelecimento GetId(int? id);
        void Delete(int? id);
    }
}
