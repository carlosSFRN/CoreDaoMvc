using System;
using ApnCore_Crud.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository.Interface
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        void Add(Usuario usuario);
        void Edit(Usuario usuario);
        Usuario Get(int? id);
        void Delete(int? id);
    }
}
