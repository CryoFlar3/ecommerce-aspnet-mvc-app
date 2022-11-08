using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service) {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index() {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: producers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id) {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Get: producers/create
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer) {

            if (!ModelState.IsValid) return View(producer);
            

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: producers/edit/1
        public async Task<IActionResult> Edit(int id) {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer) {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id) {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Get: producers/Delete/1
        public async Task<IActionResult> Delete(int id) {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeletAsynce(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
