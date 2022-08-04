namespace ManufacturerApp.Models
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddManufacturer(Manufacturer manufacturer);
        Task<List<Manufacturer>> GetManufacturers();
        Task<Manufacturer> GetManufacturer(int id);
        Task<Manufacturer> EditGetManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(int id);

    }
}
