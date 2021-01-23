using Microsoft.AspNetCore.Mvc;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.Controllers
{
    public class News : Controller
    {
        private IPageRepository pageRepository;
        public News(IPageRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        [Route("News/{newsId}")]
        public IActionResult ShowNews(int newsId)
        {
            var page = pageRepository.GetPageByID(newsId);
            if(page!=null)
            {
                page.PageVisit += 1;
                pageRepository.UpdatePage(page);
                pageRepository.Save();
            }
            return View(page);
        }

        [Route("Group/{groupID}/{title}")]
        public IActionResult ShowNewsByGroupID(int groupID , string title)
        {
            ViewData["GroupTitle"] = title;
            return View(pageRepository.GetPagesByGroupID(groupID));
        }

        [Route("Search")]
        public IActionResult Search(string q)
        {
            return View(pageRepository.Search(q));
        }

    }
}
