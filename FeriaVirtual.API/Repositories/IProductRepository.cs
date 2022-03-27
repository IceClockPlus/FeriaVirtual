using FeriaVirtual.Database.Entities;
using FeriaVirtual.Database;
using FeriaVirtual.API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FeriaVirtual.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(ItemParameters parameters);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly FeriaVirtualContext _context;
        public ProductRepository(FeriaVirtualContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll(ItemParameters parameters)
        {
            return await _context.Products.Skip((parameters.PageNumber -1) * parameters.PageSize )
                                    .Take(parameters.PageSize).ToListAsync();
        }
    }
}
