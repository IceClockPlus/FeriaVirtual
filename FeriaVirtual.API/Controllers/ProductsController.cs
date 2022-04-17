using AutoMapper;
using FeriaVirtual.API.Models;
using FeriaVirtual.API.Repositories;
using FeriaVirtual.APIModels.Product;
using FeriaVirtual.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            try
            {
                var productList =  _repository.GetAll(parameters);

                //Mapper List to Response Model
                var result = _mapper.Map<List<Product>,List<ProductResponse>>(productList.ToList());

                //Get Pagination data and add it to the headers
                var metadata = new
                {
                    productList.TotalCount,
                    productList.PageSize,
                    productList.CurrentPage,
                    productList.TotalPages,
                    productList.HasNext,
                    productList.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
