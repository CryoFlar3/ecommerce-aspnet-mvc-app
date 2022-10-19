using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsServices _service;

        public ActorsController(IActorsServices service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var data = await _service.GetAll();
            return View(data);
        }
    }
}
