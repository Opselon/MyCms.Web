﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCms.DomainClasses.Page;
using MyCms.Services.Repositories;

namespace MyCms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private IPageRepository _pageRepository;
        private IPageGroupRepository _pageGroupRepository;
  
        public PagesController(IPageRepository pageRepository , IPageGroupRepository pageGroupRepository)
        {
            _pageRepository = pageRepository;
            _pageGroupRepository = pageGroupRepository;
        }

        // GET: Admin/Pages
        /// <summary>
        /// this method giv
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {              
            //Show any rows in database as a datagrid
            var myCmsDbContext = _pageRepository.GetAllPage();
            return View(myCmsDbContext);
        
        }

        // GET: Admin/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page =  _pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroups(), "GroupID", "GroupTitle");
            return View();
        }
      
        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupID,PageID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {
                page.PageVisit = 0;
                page.CreateDate = DateTime.Now;
                if(imgup != null)
                {
                    //Genarate a Random Name + Filename To Saving 
                    //We Use this method for looply File.
                    page.ImageName = Guid.NewGuid().ToString()+ Path.GetExtension(imgup.FileName);
                    string savePath = Path.Combine(
                        //Find the path file located in and bind it with "wwwroot/PageImages"
                        Directory.GetCurrentDirectory(), "wwwroot/PageImages", page.ImageName
                        ) ;

                    using (FileStream outputFileStream = new FileStream(savePath, FileMode.Create))
                    {
                       imgup.CopyTo(outputFileStream);
                    }
                
                }

                _pageRepository.InsertPage(page);
                _pageRepository.Save();

                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page =  _pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupID,PageID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page,IFormFile imgup)
        {
            if (id != page.PageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (imgup != null)
                    {
                        //Genarate a Random Name + Filename To Saving 
                        //We Use this method for looply File.
                        if (page.ImageName == null)
                        {
                            page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                        }

                        string savePath = Path.Combine(
                          //Find the path file located in and bind it with "wwwroot/PageImages"
                          Directory.GetCurrentDirectory(), "wwwroot/PageImages", page.ImageName
                          );
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            //save file
                            imgup.CopyToAsync(stream);
                        }


                        _pageRepository.UpdatePage(page);
                        _pageRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = _pageRepository.GetPageByID(id);
            if (page.ImageName != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PageImages",page.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
                ;
             _pageRepository.DeletePage(id);
            _pageRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _pageRepository.PageExists(id);
        }
    }
}
