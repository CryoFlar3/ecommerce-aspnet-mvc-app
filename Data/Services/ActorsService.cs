using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsServices
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Actor actor) {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeletAsynce(int id) {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync() {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id) {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor) {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}
