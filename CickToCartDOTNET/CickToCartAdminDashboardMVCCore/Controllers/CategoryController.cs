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
    [ModelMetadataType(typeof(CategoryViewModel))]
    public class CategoryController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> UpdateCategory([FromRoute]int id)
        {
            Category category = await UnitOfWork.CategoryRepo.GetAsync(id);
            //var list = await UnitOfWork.DiscountRepo.GetAllAsync();
            //ViewBag.Discounts = list;
            ViewData["Category"] = category;
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> AddCategory()
        {
            //var list = await UnitOfWork.DiscountRepo.GetAllAsync();
            //ViewBag.Discounts = list;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] CategoryViewModel _Category)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Category/AddCategory");
            }
            var Category = _mapper.Map<Category>(_Category);
            await UnitOfWork.CategoryRepo.AddAsync(Category);
            await UnitOfWork.CommitAsync();
            return Redirect("/Category/All");
        }
        public  ActionResult All()
        {

            var list = _mapper.Map<IEnumerable<CategoryViewModel>>( UnitOfWork.CategoryRepo.GetAll().Where(s => s.IsDeleted == false).ToList());
            return View("~/Views/Category/All.cshtml", list);
        }

        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            Category category = await UnitOfWork.CategoryRepo.GetAsync(id);
            if (category == null)
            {
                return View("/Admin/Dashboard");
            }
            category.IsDeleted = true;
            await UnitOfWork.CategoryRepo.Update(category);
            
            await UnitOfWork.CommitAsync();

            return Redirect("/Category/All");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromForm] CategoryViewModel _Category)
        {
            
            Category Category = _mapper.Map<Category>(_Category);
            await UnitOfWork.CategoryRepo.Update(Category);
            await UnitOfWork.CommitAsync();
            return Redirect("/Category/All");
        }
    }
}
