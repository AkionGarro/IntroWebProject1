using SpecialTicket.BLL.Services.Interfaces;
using SpecialTicket.DAL.Repositorio;
using SpecialTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTicket.BLL.Services.Implementations
{
    public class TipoEventoService : ITipoEventoService
    {
        private readonly IGenericRepository<TipoEvento> _TipoEventoRepo;
        public TipoEventoService(IGenericRepository<TipoEvento> TipoEventoRepo) {
            _TipoEventoRepo = TipoEventoRepo;
        
        }


        public Task<bool> Add(TipoEvento entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoEvento> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TipoEvento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TipoEvento entity)
        {
            throw new NotImplementedException();
        }
    }
}
