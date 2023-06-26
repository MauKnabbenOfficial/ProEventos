using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento(){
                    EventoID = 1,
                    Tema = "Angular 11 e .NET 5",
                    Local = "Caxias do Sul",
                    Lote = "1º lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemURL = "photo.png"
                },
            new Evento(){
                EventoID = 2,
                Tema = "Angular 11 e .NET 5",
                Local = "Caxias do Sul",
                Lote = "1º lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "photo.png"
            }
        };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _evento.FirstOrDefault(s => s.EventoID == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id: {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id: {id}";
        }
    }
}
