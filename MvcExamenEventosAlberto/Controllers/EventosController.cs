using Microsoft.AspNetCore.Mvc;
using MvcExamenEventosAlberto.Models;
using MvcExamenEventosAlberto.Services;

namespace MvcExamenEventosAlberto.Controllers
{
    public class EventosController : Controller
    {
        private ServiceEventos service;
        public EventosController(ServiceEventos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Eventos> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> Categorias()
        {
            List<CategoriasEvento> cateventos = await this.service.GetCategoriasAsync();
            return View(cateventos);
        }

        public async Task<IActionResult> FindCategoriasEventos(int id)
        {
            List<Eventos> eventos = await this.service.FindEventoCategoria(id);
            return View(eventos);
        }
    }
}
