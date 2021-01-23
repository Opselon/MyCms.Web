using Microsoft.AspNetCore.Mvc;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.Controllers
{
    public class HomeController : Controller
    {



        private IPageRepository _pageRepository;
        public HomeController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            ViewData["Slider"] = _pageRepository.GetPagesInSlider();

            return View(_pageRepository.GetLatesPage());
        }
    }
}
