using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<bool> AddEventos(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);
        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
    }
}