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
    public class TagController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper _mapper;
        public IActionResult Index()
        {
            return View();
        }
        public TagController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<ActionResult> All()
        {
            var list = _mapper.Map<IEnumerable<TagViewModel>>(await UnitOfWork.TagRepo.GetAllAsync());
            return View(list);
        }
        [HttpGet]
        public ActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTag([FromForm] TagViewModel tagViewModel)
        {
            Tag Tag = _mapper.Map<Tag>(tagViewModel);
            await UnitOfWork.TagRepo.AddAsync(Tag);
            await UnitOfWork.CommitAsync();
            return Redirect("/Tag/All");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTag( [FromRoute]int id)
        {
            Tag Tag = await UnitOfWork.TagRepo.GetAsync(id);
            if (Tag == null)
            {
                return Redirect("/Admin/Dashboard");
            }
            UnitOfWork.TagRepo.Remove(Tag);
            await UnitOfWork.CommitAsync();
            return Redirect("/Tag/All");
        }
        public async Task<ActionResult>UpdateTag([FromRoute]int id)
        {
            Tag tag = await UnitOfWork.TagRepo.GetAsync(id);
            if (tag == null)
            {
                return Redirect("/Admin/Dashboard");
            }
            ViewData["Tag"] = tag;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateTag([FromForm] Tag _Tag)
        {
            Tag Tag = _mapper.Map<Tag>(_Tag);
            await UnitOfWork.TagRepo.Update(Tag);
            await UnitOfWork.CommitAsync();
            return Redirect("/Tag/All");
        }
    }
}
