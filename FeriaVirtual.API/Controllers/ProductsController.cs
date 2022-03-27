using AutoMapper;
using FeriaVirtual.API.Models;
using FeriaVirtual.API.Repositories;
using FeriaVirtual.APIModels.Product;
using FeriaVirtual.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeriaVirtual.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper; 
        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ItemParameters parameters)
        {
            var productList = await _repository.GetAll(parameters);
            List<ProductResponse> response = _mapper.Map<IEnumerable<Product>, List<ProductResponse>>(productList);
            return Ok(response);
        }
    }
}
