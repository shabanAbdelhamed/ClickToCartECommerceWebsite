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
    public class ColorController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper _mapper;
        
        public ColorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> All()
        {
            var list = _mapper.Map<IEnumerable<ColorViewModel>>(await UnitOfWork.ColorRepo.GetAllAsync());
            return View(list);
        }
        [HttpGet]
        public ActionResult AddColor()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddColor([FromForm] ColorViewModel _Color)
        {
            var Color = _mapper.Map<Color>(_Color);
            await UnitOfWork.ColorRepo.AddAsync(Color);
            await UnitOfWork.CommitAsync();
            return Redirect("/Color/All");
        }

    }
}
