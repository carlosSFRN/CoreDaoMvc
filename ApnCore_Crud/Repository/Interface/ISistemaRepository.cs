using ApnCore_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Repository.Interface
{
    public interface ISistemaRepository
    {
        IEnumerable<Sistema> GetAll();
    }
}
