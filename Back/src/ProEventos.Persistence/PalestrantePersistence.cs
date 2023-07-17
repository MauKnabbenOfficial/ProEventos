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
    public class PalestrantePersistence : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            this._context = context;
        }

        public async Task<List<Palestrante>> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(s => s.RedesSociais);

            if(includeEventos) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            query = query.OrderBy(s => s.Id);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<Palestrante>> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(s => s.RedesSociais);

            if(includeEventos) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            query = query.OrderBy(s => s.Nome.ToLower().Contains(Nome.ToLower()));
            query = query.OrderBy(s => s.Id);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(s => s.RedesSociais);

            if(includeEventos) query = query.Include(s => s.PalestrantesEventos).ThenInclude(pe => pe.Evento);

            return await query.AsNoTracking().FirstOrDefaultAsync(s => s.Id == palestranteId);
        }

    }
}