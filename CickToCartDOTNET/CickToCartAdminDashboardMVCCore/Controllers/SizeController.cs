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
    public class SizeController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper _mapper;

        public SizeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> All()
        {
            var list = _mapper.Map<IEnumerable<SizeViewModel>>(await UnitOfWork.SizeRepo.GetAllAsync());
            return View(list);
        }
        [HttpGet]
        public ActionResult AddSize()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSize([FromForm] SizeViewModel _Size)
        {
            var Size = _mapper.Map<Size>(_Size);
            await UnitOfWork.SizeRepo.AddAsync(Size);
            await UnitOfWork.CommitAsync();
            return Redirect("/Size/All");
        }
    }
}
