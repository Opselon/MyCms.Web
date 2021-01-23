using Microsoft.AspNetCore.Mvc;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.ViewComponents
{
    public class ShowTopNewsComponent : ViewComponent
    {
        IPageRepository _pageRepository;
        public ShowTopNewsComponent(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)
                View("ShowTopNewsComponent", _pageRepository.GetTopNews()));
        }

    }
}
