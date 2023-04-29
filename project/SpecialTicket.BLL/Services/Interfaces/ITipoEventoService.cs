using SpecialTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTicket.BLL.Services.Interfaces
{
    public interface ITipoEventoService
    {
        Task<bool> Add( TipoEvento entity);
        Task<bool> Update(TipoEvento entity);
        Task<bool> Delete(int id);
        Task<TipoEvento> Get(int id);
        Task<IQueryable<TipoEvento>> GetAll();
    }
}
