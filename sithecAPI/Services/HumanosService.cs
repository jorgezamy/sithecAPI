
using Microsoft.EntityFrameworkCore;
using sithecAPI.Data;
using sithecAPI.Models.Entities;
using sithecAPI.Services.interfaces;

namespace sithecAPI.Services
{
    public class HumanosService: IHumanosService
    {
        private readonly ApiContext _context;

        public HumanosService(ApiContext context)
        {
            _context = context;
        }

        public List<Humano> GetHumanosMock()
        {
            List<Humano> humanos = HumanosData.GetHumanos();

            return humanos;
        }

        public async Task<List<Humano>> GetHumanosAsync()
        {
            var humanos = await _context.Humanos.ToListAsync();

            return humanos;
        }

        public async Task<Humano> GetHumanoByIdAsync(Guid id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                throw new KeyNotFoundException($"Humano con Id ${id} no encontrado");
            }

            return humano;
        }

        public async Task<Humano> CreateHumanoAsync(Humano newHumano)
        {
            _context.Humanos.Add(newHumano);

            await _context.SaveChangesAsync();

            return newHumano;
        }

        public async Task<bool> UpdateHumanoByIdAsync(Guid id, Humano humano)
        {
            var humanoUpdated = await _context.Humanos.FindAsync(id);

            if (humanoUpdated == null)
            {
                return false;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Humanos.Any(c => c.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteHumanoByIdAsync(Guid id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                return false;
            }

            _context.Humanos.Remove(humano);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Humanos.Any(c => c.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
    }
}
