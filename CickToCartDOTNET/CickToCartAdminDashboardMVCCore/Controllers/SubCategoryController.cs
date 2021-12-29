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
    public class SubCategoryController : Controller
    {
        
        IUnitOfWork unitOfWork;
        private IMapper _mapper;
        public IActionResult Index()
        {
            return View();
        }
        public SubCategoryController(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult> All()
        {
            
            var list = unitOfWork.SubCategoryRepo.GetAll().Where(s=>s.IsDeleted==false).ToList();
            return View(list);
        }
        public async Task<ActionResult> AddSubCategory()
        {
            ViewBag.Categories = await unitOfWork.CategoryRepo.GetAllAsync();
            ViewBag.Discounts = await unitOfWork.DiscountRepo.GetAllAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddSubCategory([FromForm]SubCategoryViewModel subCategoryViewModel)
        {
           
            var parsed = _mapper.Map<SubCategory>(subCategoryViewModel);
            await unitOfWork.SubCategoryRepo.AddAsync(parsed);
            await unitOfWork.CommitAsync();
            return Redirect("/SubCategory/All");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory([FromRoute]int id)
        {
            SubCategory Subcategory = await unitOfWork.SubCategoryRepo.GetAsync(id);
            if (Subcategory == null)
            {
                return Redirect("/Admin/Dashboard");
            }
            Subcategory.IsDeleted = true;
            await unitOfWork.SubCategoryRepo.Update(Subcategory);
             await unitOfWork.CommitAsync();
            return Redirect("/SubCategory/All");
        }
        public async Task<ActionResult> UpdateSubCategory([FromRoute]int id)
        {
            var sub =_mapper.Map<SubCategoryViewModel>( await unitOfWork.SubCategoryRepo.GetAsync(id));
            
            ViewBag.Categories = await unitOfWork.CategoryRepo.GetAllAsync();
            return View(sub);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory([FromForm] SubCategory Sub)
        {
           await unitOfWork.SubCategoryRepo.Update(Sub);
             await unitOfWork.CommitAsync();
            return Redirect("/SubCategory/All");
        }
    }
}
