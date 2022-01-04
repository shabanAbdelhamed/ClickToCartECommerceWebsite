using AutoMapper;
using CickToCart.DTOS;
using CickToCart.Models;
using CickToCart.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Controllers
{
    [Authorize]
    public class Product_colorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public Product_colorController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            webHostEnvironment = hostEnvironment;
        }
        private string UploadedFile(Product_colorDto model)
        {
            string uniqueFileName = null;

            if (model.Img != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Img.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Img.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet]
        public async Task<IEnumerable<Product_colorDto>> GetAllProduct_color()
        {

            var list = _mapper.Map<IEnumerable<Product_colorDto>>(_unitOfWork.product_ColorRepos.GetAllAsync());
            return list;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct_color([FromForm] Product_colorDto product_ColorDto)
        {
            string uniqueFileName = UploadedFile(product_ColorDto);
            var parsed = _mapper.Map<Product_color>(product_ColorDto);
            parsed.img = (uniqueFileName != null) ? uniqueFileName : "";
            await _unitOfWork.product_ColorRepos.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            //return View();
            //return Redirect("/Product_color/AddProduct_color");
            return RedirectToAction("AddProduct_color");
            //, parsed.productID
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct_color([FromRoute] int id)
        {
            ViewBag.ProductID = id;
            Product prodcut = await _unitOfWork.ProductsRepos.GetAsync(id);
            ViewBag.ProdName = prodcut.Name;
            var prod = _unitOfWork.product_ColorRepos.GetProductColor().Where(s => s.productID == id).ToList();
            ViewBag.Colors = await _unitOfWork.ColorRepo.GetAllAsync();
            ViewBag.liColor = prod;
            return View();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct_color([FromForm] Product_colorDto product_ColorDto)
        {
            var parsed = _mapper.Map<Product_color>(product_ColorDto);
            await _unitOfWork.product_ColorRepos.Update(parsed);
            await _unitOfWork.CommitAsync();
            return Ok("Succufull update Product color");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct_color([FromRoute] int id)
        {
            var Product = await _unitOfWork.product_ColorRepos.GetAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _unitOfWork.product_ColorRepos.Remove(Product);
            await _unitOfWork.CommitAsync();

            return Ok("Successfull deleted product Color");
        }



    }
}
