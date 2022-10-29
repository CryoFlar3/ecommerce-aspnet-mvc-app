using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service) {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync() {
            var data = await _service.GetAllAsync(n => n.Cinema);
            return View(data);
        }

        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id) {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //Get: Movies/Create
        public IActionResult Create() {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            return View();
        }
    }
}
