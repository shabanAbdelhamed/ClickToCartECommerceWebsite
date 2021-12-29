using AutoMapper;
using CickToCart.Models;
using CickToCart.Repositories;
using CickToCart.Repositories.ProductsRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.DTOS;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClickToCartWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }
        // GET: api/<ProductController>
        [HttpGet]
        //[Route("Product/GetAll")]
        public async Task <IEnumerable<Product>> GetAll()
        {
            var list = await  _unitOfWork.ProductsRepos.GetAllAsync();
            return list;
        }
        //// GET api/<ProductController>/5
        //[Route("api/[controller]")]
        //[Route("Product/{Id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdByID ( int id)
        {
           
            Product prod = await _unitOfWork.ProductsRepos.GetAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            return Ok(prod);
        }        
        [HttpGet("{id}")]
        //[HttpGet]
        public async Task<IActionResult> GetProdByCatID (int id )
        {
            
            var li = _mapper.Map<IEnumerable<ProductShowDto>>( _unitOfWork.ProductsRepos.GetAllProdByCat(id));
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }

        [HttpGet("{id}")]
        //[HttpGet]
        public async Task<IActionResult> GetFirst5ProdByCatID(int id)
        {

            var li = _mapper.Map<IEnumerable<ProductDto>>(_unitOfWork.ProductsRepos.GetFirst5ProdByCat(id));
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }
        [HttpGet("{id}")]
        //[HttpGet]
        public IActionResult GetProdBySubCatID(int id)
        {

            var li = _mapper.Map<IEnumerable<ProductShowDto>>(_unitOfWork.ProductsRepos.GetAll().Where(p=>p.SubCategory.ID==id));
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }

        ////public async Task<IActionResult> GetProdDetails()
        ////{
        ////    var prod = _unitOfWork.ProductsRepos.GetAll();
        ////    return prod;

        ////}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
