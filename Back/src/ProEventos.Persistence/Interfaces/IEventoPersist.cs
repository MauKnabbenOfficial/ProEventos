using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersist
    {
        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
    }
}