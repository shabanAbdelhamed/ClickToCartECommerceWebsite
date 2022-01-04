using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Controllers
{
    [Authorize]
    public class Product_RatingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public Product_RatingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IEnumerable<Product_RatingDto>> GetAllProduct_Rating()
        {

            var list = _mapper.Map<IEnumerable<Product_RatingDto>>(_unitOfWork.product_RatingRepos.GetAllAsync());
            return list;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct_Rating([FromBody] Product_RatingDto product_RatingDto)
        {
            var parsed = _mapper.Map<Product_Rating>(product_RatingDto);
            await _unitOfWork.product_RatingRepos.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct_Rating([FromBody] Product_RatingDto product_RatingDto)
        {
            var parsed = _mapper.Map<Product_Rating>(product_RatingDto);
            await _unitOfWork.product_RatingRepos.Update(parsed);
            await _unitOfWork.CommitAsync();
            return Ok("Succufull update Product");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct_Rating([FromRoute] int id)
        {
            var Product = await _unitOfWork.product_RatingRepos.GetAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _unitOfWork.product_RatingRepos.Remove(Product);
            await _unitOfWork.CommitAsync();

            return Ok("Successfull deleted Product");
        }





    }
}
