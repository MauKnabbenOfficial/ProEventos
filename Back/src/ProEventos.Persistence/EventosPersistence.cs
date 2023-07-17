using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventosPersistence : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventosPersistence(ProEventosContext context)
        {
            this._context = context;
        }
        public async Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(s => s.Lotes).Include(s => s.RedesSociais);

            if(includePalestrantes) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            query = query.OrderBy(s => s.Id);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos.Include(s => s.Lotes).Include(s => s.RedesSociais);

            if(includePalestrantes) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            query = query.Where(s => s.Tema.ToLower().Contains(tema.ToLower()));
            query = query.OrderBy(s => s.Id);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos.Include(s => s.Lotes).Include(s => s.RedesSociais);

            if(includePalestrantes) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

            return await query.AsNoTracking().FirstOrDefaultAsync(s => s.Id == eventoId);
        }

    }
}