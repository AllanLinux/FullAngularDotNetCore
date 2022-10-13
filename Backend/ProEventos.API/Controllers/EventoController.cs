using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;

    // private IEnumerable<Evento> _evento = new Evento[] {
    //         new Evento()
    //         {
    //             EventoId = 1,
    //             Tema = "Angular 11 e .NET 6",
    //             Local = "Sao Paulo",
    //             Lote = "1 Lote",
    //             QtdPessoas = 250,
    //             DataEvento = DateTime.Now.AddDays(2).ToString(),
    //             ImagemURL = "foto.png"
    //         },
    //         new Evento()
    //         {
    //             EventoId = 2,
    //             Tema = "Angular 11 e Novidades",
    //             Local = "Joao Pessoa",
    //             Lote = "2 Lote",
    //             QtdPessoas = 350,
    //             DataEvento = DateTime.Now.AddDays(3).ToString(),
    //             ImagemURL = "foto1.png"
    //         }
    // };

    public EventoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _context.Eventos.Where(x => x.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo de Post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"Exemplo de Put - {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id) 
    {
        return $"Exemplo de Delete - {id}";
    }
}
