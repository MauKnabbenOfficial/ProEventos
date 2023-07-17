using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersist
    {
        Task<List<Palestrante>> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<List<Palestrante>> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}