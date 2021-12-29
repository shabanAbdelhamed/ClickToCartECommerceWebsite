using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClickToCartWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private IMapper mapper;

        public SubCategoryController(IUnitOfWork unitOfWork,IMapper Mapper)
        {
            _unitOfWork = unitOfWork;
            mapper = Mapper;
    }
        // GET: api/<SubCategoryController>
        [HttpGet]
        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            var list = await _unitOfWork.SubCategoryRepo.GetAllAsync();
            return list;
        }
        [HttpGet("{id}")]
        public async Task<SubCategoryViewModel>GetSubCatByID(int id)
        {
            var sub =mapper.Map<SubCategoryViewModel> (await _unitOfWork.SubCategoryRepo.GetAsync(id));
            if (sub == null)
            {
                return null;
            }
            return sub;
        }

        // GET api/<SubCategoryController>/5

        //[Route("Product/{Id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCatByCatID(int id)
        {
            //for each all 
            //all sub by category id                          
            var SubCat = mapper.Map<IEnumerable<SubCategoryViewModel>>(_unitOfWork.SubCategoryRepo.GetAll().Where(s => s.Category.ID == id).ToList());
              
            if (SubCat == null)
            {
                return NotFound();
            }
            ////foreach (var item in SubCat)
            ////{
            ////    return Ok(item);
            ////}
            return Ok(SubCat);
        }
        [HttpGet("{id}")]
        public async Task<int> getcat(int id)
        {
            var cat = await _unitOfWork.SubCategoryRepo.FindAsync(item => item.ID == id);
            return cat.FirstOrDefault().CategoryID;
        }
        [HttpPost]
        //[HttpGet]
        public async Task<IActionResult> GetProdBySubCatID(List<CategoryListIds> CategoryListIds)
        {

            var li = mapper.Map<IEnumerable<ProductShowDto>>(_unitOfWork.SubCategoryRepo.GetAllProdBySubCat(CategoryListIds).ToList());
            if (li == null)
            {
                return NotFound();
            }

            return Ok(li);
        }

        // POST api/<SubCategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SubCategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SubCategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
