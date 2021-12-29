using AutoMapper;
using CickToCart.Models;
using CickToCart.DTOS;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.Models.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClickToCartWebApi.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductRateController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private readonly ContextDataBase _context;


        public ProductRateController(IUnitOfWork unitOfWork, IMapper mapper, ContextDataBase context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;


        }
        // GET: api/<ProductRateController>
        [HttpGet("{id}")]
        public async Task<IEnumerable<Product_RatingDto>> GetRateByProdId(int id)
        {
            var list = _mapper.Map<IEnumerable<Product_RatingDto>>(_unitOfWork.product_RatingRepos.GetRateByProdId(id));
            return list;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product_RatingDto prodRateView)
        {
            Product prod = await _unitOfWork.ProductsRepos.GetAsync(prodRateView.productID);
            AppUser User = _context.AppUsers.FirstOrDefault(x => x.Id == prodRateView.UserId);
            var parsed = _mapper.Map<Product_Rating>(prodRateView);
            parsed.product= prod;
            parsed.User= User;
            await _unitOfWork.product_RatingRepos.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        // GET api/<ProductRateController>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        ////// POST api/<ProductRateController>
        ////[HttpPost]
        ////public void Post([FromBody] string value)
        ////{
        ////}

        ////// PUT api/<ProductRateController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////// DELETE api/<ProductRateController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
    }
}
