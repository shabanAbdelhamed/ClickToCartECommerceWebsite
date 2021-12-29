using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.DTOS;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClickToCartWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task <IEnumerable<Category>> GetAll()
        {


            var list = await _unitOfWork.CategoryRepo.GetAllAsync();
            return list;
        }

        // GET api/<CategoryController>/5
       // [Route("api/[controller]/[action]")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatByID(int id)
        {
            Category category = await _unitOfWork.CategoryRepo.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok (category);

        }
        [HttpGet("{id}")]
        //[HttpGet]
        public async Task<IActionResult> GetProdByCatID(int id)
        {

            var li = _mapper.Map<IEnumerable<ProductDto>>(_unitOfWork.CategoryRepo.GetAllProdByCat(id));
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }

        [HttpPost]
        //[HttpGet]
        public async Task<IActionResult> GetProdByCatID(List<CategoryListIds> CategoryListIds)
        {

            var li = _mapper.Map<IEnumerable<ProductShowDto>>(_unitOfWork.CategoryRepo.GetAllProdByCat(CategoryListIds));
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

            var li = _mapper.Map<IEnumerable<ProductDto>>(_unitOfWork.CategoryRepo.GetFirst5ProdByCat(id));
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }

        // POST api/<CategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
