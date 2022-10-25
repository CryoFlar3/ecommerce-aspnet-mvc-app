﻿using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: producers/details/1
        public async Task<IActionResult> Details(int id) {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
    }
}
