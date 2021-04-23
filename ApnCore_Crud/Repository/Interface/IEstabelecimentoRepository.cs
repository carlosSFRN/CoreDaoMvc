using ApnCore_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository.Interface
{
    public interface IEstabelecimentoRepository
    {
        IEnumerable<Estabelecimento> GetAll();
        void Add(Estabelecimento estabelecimento);
        void Edit(Estabelecimento estabelecimento);
        Estabelecimento Get(int? id);
        void Delete(int? id);
    }
}
