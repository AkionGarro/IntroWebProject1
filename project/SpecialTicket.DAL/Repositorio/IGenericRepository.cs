using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTicket.DAL.Repositorio
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
      Task<bool> Add(TEntityModel entity);
      Task <bool> Update(TEntityModel entity);
      Task<bool>  Delete(int id);
      Task<TEntityModel> Get(int id);
      Task<IQueryable<TEntityModel>> GetAll();

    }
}
