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
    public class Product_SizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public Product_SizeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IEnumerable<Product_SizeDto>> GetAllProduct_Size()
        {

            var list = _mapper.Map<IEnumerable<Product_SizeDto>>(_unitOfWork.product_SizeRepos.GetAllAsync());
            return list;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct_Size([FromForm] Product_SizeDto product_SizeDto)
        {
            var parsed = _mapper.Map<Product_Size>(product_SizeDto);
            await _unitOfWork.product_SizeRepos.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("AddProduct_Size");

            //return Redirect("/Product/All");
            //return redirec
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct_Size([FromRoute] int id)
        {
            ViewBag.ProdColorID = id;
            Product_color colr = await _unitOfWork.product_ColorRepos.GetAsync(id);
            Product prd = await _unitOfWork.ProductsRepos.GetAsync(colr.productID);
            Color clr = await _unitOfWork.ColorRepo.GetAsync(colr.colorID);
            ViewBag.colrName = clr.Name;
            ViewBag.prdName = prd.Name;
            var prod = _unitOfWork.product_SizeRepos.GetProductSize().Where(s => s.Product_ColorID == id).ToList();
            ViewBag.liSizes = prod;
            ViewBag.Sizes = await _unitOfWork.SizeRepo.GetAllAsync();
            return View();

        }
        //[HttpGet]
        //public async Task<IActionResult> AddProduct_Size()
        //{
        //    //var list = _mapper.Map<IEnumerable<OrderViewModels>>(await _unitOfWork.OrderRepo.GetAllAsync());

        //    //var parsed = _mapper.Map<Product_Size>(product_SizeDto);
        //    //await _unitOfWork.product_SizeRepos.AddAsync(parsed);
        //    //await _unitOfWork.CommitAsync();
        //    //return Ok();
        //    return PartialView("_Product_Size");

        //}
        [HttpPut]
        public async Task<IActionResult> UpdateProduct_Size([FromBody] Product_SizeDto product_SizeDto)
        {
            var parsed = _mapper.Map<Product_Size>(product_SizeDto);
            await _unitOfWork.product_SizeRepos.Update(parsed);
            await _unitOfWork.CommitAsync();
            return Ok("Succufull update Product size");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct_Size([FromRoute] int id)
        {
            var Product = await _unitOfWork.product_SizeRepos.GetAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _unitOfWork.product_SizeRepos.Remove(Product);
            await _unitOfWork.CommitAsync();

            return Ok("Successfull deleted Product size");
        }






    }
}
