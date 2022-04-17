using FeriaVirtual.Database.Entities;
using FeriaVirtual.Database;
using FeriaVirtual.API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FeriaVirtual.API.Repositories
{
    public interface IProductRepository
    {
        PagedList<Product> GetAll(ItemParameters parameters);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly FeriaVirtualContext _context;
        public ProductRepository(FeriaVirtualContext context)
        {
            _context = context;
        }

        public PagedList<Product> GetAll(ItemParameters parameters)
        {
            return PagedList<Product>.ToPagedList(_context.Products, parameters.PageNumber, parameters.PageSize);
        }
    }
}
