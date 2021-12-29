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
    public class ShippingController : Controller
    {

        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public ShippingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<ActionResult> All()
        {
            var list = _mapper.Map<IEnumerable<ShippingViewModels>>(await _unitOfWork.ShippingRepo.GetAllAsync());
            return View("~/Views/Shipping/All.cshtml", list);
        }
        //public async Task<IEnumerable<Shipping>> Post(Shipping shipping)
        //{
        //    //await shippingrepo.AddAsync(shipping);
        //    //await _unitOfWork.CommitAsync();
        //    //return await shippingrepo.GetAllAsync();
        //}
        public ActionResult Create()
        {
            ViewBag.Title = "Create New Shipping";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ShippingViewModels _shipping)
        {

            ViewBag.Title = "Create User Page";

            var shipping = _mapper.Map<Shipping>(_shipping);
            await _unitOfWork.ShippingRepo.AddAsync(shipping);
            await _unitOfWork.CommitAsync();
            return Redirect("~/Shipping/All");
        }
        public async Task<ActionResult> Details([FromRoute]int id)
        {
            var comp = _mapper.Map<ShippingViewModels>(await _unitOfWork.ShippingRepo.GetAsync(id));
            return View("~/Views/Shipping/Details.cshtml", comp);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteShipping([FromRoute] int id)
        {
            Shipping Shipping = await _unitOfWork.ShippingRepo.GetAsync(id);
            if (Shipping == null)
            {
                return Redirect("/Shipping/All");
            }
            _unitOfWork.ShippingRepo.Remove(Shipping);
            await _unitOfWork.CommitAsync();
            return Redirect("/Shipping/All");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateShipping([FromRoute] int id)
        {
            Shipping Shipping = await _unitOfWork.ShippingRepo.GetAsync(id);
            ViewData["Shipping"] = Shipping;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipping([FromForm] ShippingViewModels _Shipping)
        {
            Shipping Shipping = _mapper.Map<Shipping>(_Shipping);
            await _unitOfWork.ShippingRepo.Update(Shipping);
            await _unitOfWork.CommitAsync();
            return Redirect("/Shipping/All");
        }
    }
}
