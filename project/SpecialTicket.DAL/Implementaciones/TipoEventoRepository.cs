using SpecialTicket.DAL.DataContext;
using SpecialTicket.DAL.Repositorio;
using SpecialTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTicket.DAL.Implementaciones
{
    public class TipoEventoRepository : IGenericRepository<TipoEvento>
    {
        private readonly ProjectTicketContext _ticketContext;
        public TipoEventoRepository(ProjectTicketContext context) {
            _ticketContext = context;
        }
        public async Task<bool> Add(TipoEvento entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoEvento> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TipoEvento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TipoEvento entity)
        {
            throw new NotImplementedException();
        }
    }
}
