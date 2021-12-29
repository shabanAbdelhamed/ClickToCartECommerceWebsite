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
    public class DiscountController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET: api/<DiscountController>
        [HttpGet]
        public async Task<IEnumerable<ProductShowDto>> All()
        {
            var list = _mapper.Map<IEnumerable<ProductShowDto>>( _unitOfWork.ProductsRepos.GetAll().Where(d=>d.Discount!=null).ToList());
            return list;
        }
        [HttpGet("{name}")]
        public  DiscountViewModel GetDiscountByName(string name)

        {
            
            var Discount = _mapper.Map<DiscountViewModel>(_unitOfWork.DiscountRepo.GetAll().FirstOrDefault(d => d.Name == name));
            if (Discount == null)
            {
                return null;
            }
            return Discount;
        }
        //// GET api/<DiscountController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<DiscountController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DiscountController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DiscountController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
