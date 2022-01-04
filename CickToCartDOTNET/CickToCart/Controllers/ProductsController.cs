using CickToCart.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.Models;
using CickToCart.DTOS;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CickToCart.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {

        //[Route("api/[controller]")]
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            webHostEnvironment = hostEnvironment;
        }
        private string UploadedFile(ProductDto model)
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
        public ActionResult All()
        {
            var list =  _unitOfWork.ProductsRepos.GetAll().Where(p =>p.Qunatity>0).ToList();
            return View(list);
        }
        [HttpGet]
        public async Task<ActionResult> AddProduct()
        {
            //ViewBag.Discounts = await _unitOfWork.DiscountRepo.GetAllAsync();
            ViewBag.Categories = await _unitOfWork.CategoryRepo.GetAllAsync();
            //ViewBag.Tags = await _unitOfWork.TagRepo.GetAllAsync();
            return View();
            
        }
        [HttpGet]
        public ActionResult FillSubCategory( [FromQuery]int catid)
        {
            var Subcategories =_mapper.Map<IEnumerable<SubCategoryViewModel>>( _unitOfWork.SubCategoryRepo.GetAll().Where(s => s.CategoryID == catid).ToList());
            return Json(Subcategories);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto productDto)
        {
            string uniqueFileName = UploadedFile(productDto);
            var parsed = _mapper.Map<Product>(productDto);
            parsed.ImgCoverURl = (uniqueFileName != null) ? uniqueFileName : "";
            await _unitOfWork.ProductsRepos.AddAsync(parsed);
            await _unitOfWork.CommitAsync();
            ViewBag.ProductID = parsed.ID;
            return Redirect("/Products/All");
            //return View("~/Views/Product_color/_Product_color.cshtml");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id)
        {
            var list = _mapper.Map<ProductEditDTO>(await _unitOfWork.ProductsRepos.GetAsync(id));

            //var product = await _unitOfWork.ProductsRepos.GetAsync(id);
            if (list == null)
            {
                return Redirect("/Admin/All");
            }
            //ViewBag.Discounts = await _unitOfWork.DiscountRepo.GetAllAsync();
            ViewBag.SubCategories = await _unitOfWork.SubCategoryRepo.GetAllAsync();
            ViewBag.Categories = await _unitOfWork.CategoryRepo.GetAllAsync();
            //ViewBag.Tags = await _unitOfWork.TagRepo.GetAllAsync();
            //ViewData["Product"] = product;
             
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductDto productDto)
        {
            
            string uniqueFileName =(productDto.Img!=null)? UploadedFile(productDto):productDto.ImgCoverURl;
            var parsed = _mapper.Map<Product>(productDto);
            parsed.ImgCoverURl = uniqueFileName;
            await _unitOfWork.ProductsRepos.Update(parsed);
            await _unitOfWork.CommitAsync();
            return Redirect("/Products/All");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            Product Product = await _unitOfWork.ProductsRepos.GetAsync(id);
            if (Product == null)
            {
                 return Redirect("/Admin/All");
            }

            _unitOfWork.ProductsRepos.Remove(Product);
            await _unitOfWork.CommitAsync();

            return Redirect("/Products/All");
        }
        [HttpGet]
        public ActionResult Details([FromRoute] int id)
        {
            Product product =  _unitOfWork.ProductsRepos.GetProduct(id);
            var Rataing = _unitOfWork.product_RatingRepos.GetAll().Where(r =>  r.product.ID == product.ID).ToList();
            ViewBag.Rataing = Rataing;
            return View(product);
        }

    }
}
