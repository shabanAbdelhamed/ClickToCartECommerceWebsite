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
    public class DiscountController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper _mapper;
        public IActionResult Index()
        {
            return View();
        }
       public DiscountController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create New Discount";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DiscountViewModel _discount)
        {

            ViewBag.Title = "Create User Page";

            var dicount = _mapper.Map<Discount>(_discount);
            await UnitOfWork.DiscountRepo.AddAsync(dicount);
            await UnitOfWork.CommitAsync();
            return Redirect("~/Discount/All");
        }

        //[HttpPost]
        //public async Task<IActionResult> AddDiscount([FromBody]DiscountViewModel _discount)
        //{
        //    //var dicount = _mapper.Map<Discount>(_discount);
        //    //await UnitOfWork.DiscountRepo.AddAsync(dicount);
        //    //await UnitOfWork.CommitAsync();
        //    //return Ok("Successfull Add New Discount!");
        //}
        [HttpGet]
        public async Task<ActionResult> All()
        {
            var list = _mapper.Map<IEnumerable<DiscountViewModel>>( await UnitOfWork.DiscountRepo.GetAllAsync());
            return View("~/Views/Discount/All.cshtml", list);
        }
        public async Task<ActionResult> Details([FromRoute] int id)
        {
            var comp = _mapper.Map<DiscountViewModel>(await UnitOfWork.DiscountRepo.GetAsync(id));
            return View("~/Views/Shipping/Details.cshtml", comp);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int id)
        {
            Discount Discount = await UnitOfWork.DiscountRepo.GetAsync(id);
            if (Discount == null)
            {
                return Redirect("/Discount/All");
            }
            UnitOfWork.DiscountRepo.Remove(Discount);
            await UnitOfWork.CommitAsync();
            return Redirect("/Discount/All");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateDiscount([FromRoute] int id)
        {
            //Discount discount = await UnitOfWork.DiscountRepo.GetAsync(id);
            var list = _mapper.Map<DiscountViewModel>(await UnitOfWork.DiscountRepo.GetAsync(id));
            //ViewData["Discount"] = discount;
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount([FromForm] DiscountViewModel _Discount)
        {
            Discount Discount = _mapper.Map<Discount>(_Discount);
            await UnitOfWork.DiscountRepo.Update(Discount);
            await UnitOfWork.CommitAsync();
            return Redirect("/Discount/All");
        }
    }
}
