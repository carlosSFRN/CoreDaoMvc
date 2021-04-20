using ApnCore_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository.Interface
{
    public interface ITimeRepository
    {
        IEnumerable<Time> GetAll();
        void Add(Time funcionario);
        void Update(Time funcionario);
        Time Get(int? id);
        void Delete(int? id);
    }
}
