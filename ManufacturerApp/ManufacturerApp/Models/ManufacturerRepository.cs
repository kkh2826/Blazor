using ManufacturerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ManufacturerApp.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext _context;
        public ManufacturerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();

            return manufacturer;
        }
        public async Task<List<Manufacturer>> GetManufacturers()
        {
            return await _context.Manufacturers.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturer(int id)
        {
            return await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
        }
        public async Task<Manufacturer> EditGetManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return manufacturer;
        }
        public async Task DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
            
        }



    }
}
