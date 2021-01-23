using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DomainClasses.Page;
using MyCms.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.Services.Services
{
    public class PageRepository : IPageRepository
    {

        #region Private Variables

        //expected to add MyCmsDbContext for use in the Class for 
        private MyCmsDbContext _db;
        public PageRepository(MyCmsDbContext db)
        {
            _db = db;
        }

        #endregion

        #region My Methods [ Delete ]

        /// <summary>
        /// expecting deleting a Page from my database
        /// </summary>
        /// <param name="page">it is all of my page elements</param>
        public void DeletePage(Page page)
        {
            //delete the page from the database using LINQ
            //State: Gets or sets that state that this entity is being tracked in.
            _db.Entry(page).State = EntityState.Deleted;
        }



        #endregion

        #region Delete , Add , Update 

        #region Deleting a page

        /// <summary>
        /// Deleting a focused page with a ID number
        /// </summary>
        /// <param name="pageId">this parameter needed to choice a corrent row from the database</param>
        public void DeletePage(int pageId)
        {
            //this variable gets page ID by GETpageByID Method[it cost a integer]
            var page = GetPageByID(pageId);

            //call the Deleting a page Method for delete page [ with all rows ] 
            DeletePage(page);
        }


        #endregion

        #region Insert a new page

        /// <summary>
        /// add page into a database with information
        /// </summary>
        /// <param name="page"></param>
        public void InsertPage(Page page)
        {
            //add all details into a database
            _db.Pages.Add(page);
        }


        #endregion

        #region Update Page
        /// <summary>
        /// expecting to save any changes in my database as well
        /// </summary>
        /// <param name="page"></param>
        public void UpdatePage(Page page)
        {
            _db.Entry(page).State = EntityState.Modified;
        }

        #endregion

        #endregion

        #region Get All Page

        /// <summary>
        /// this command gets all page lists into a IEnumberable to show the user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Page> GetAllPage()
        {
            //expecting to get list of my rows into a datagrid
            return _db.Pages.ToList();
        }

        #endregion

        #region Get Lates Page

        /// <summary>
        /// Get the Lates Page from my database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Page> GetLatesPage()
        {
            //its order pages by descending and show to user, if its less then 4 it make it 4
            return _db.Pages.OrderByDescending(p => p.CreateDate).Take(4).ToList();
        }

        #endregion

        #region Get Page By ID

        /// <summary>
        /// expecting find my page by ID to does any changes 
        /// </summary>
        /// <param name="PageId">Giving this parameter to define our page [ID] </param>
        /// <returns></returns>
        public Page GetPageByID(int PageId)
        {
            //find a special row from my database with ID
            return _db.Pages.Find(PageId);
        }


        #endregion

        #region Get Pages By Group ID

        /// <summary>
        /// expecting to return Pages by group id from the database
        /// </summary>
        /// <param name="groupID">our integer for finding a spaciel row from database</param>
        /// <returns></returns>
        public IEnumerable<Page> GetPagesByGroupID(int groupID)
        {
            return _db.Pages.Where(p => p.GroupID == groupID).ToList();
        }


        #endregion

        #region Get Pages In Slider

        /// <summary>
        /// find pages thats are enabled show in slider with linq query
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Page> GetPagesInSlider()
        {
            //expecting search the database and find which wanted rows to show the user
            return _db.Pages.Where(p => p.ShowInSlider).ToList();

        }

        #endregion

        #region Get Top News

        /// <summary>
        /// Get Top News from the my database </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<Page> GetTopNews(int take = 4)
        {
            //get the best topic from my database where page visit is larger in first by Descending
            return _db.Pages.OrderByDescending(p => p.PageVisit).Take(take).ToList();
        }


        #endregion

        #region Page Exists

        /// <summary>
        /// returns if any pages exists command
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public bool PageExists(int pageId)
        {
            return _db.Pages.Any(p => p.PageID == pageId);
        }


        #endregion

        #region Save Command
        /// <summary>
        /// expecting save all of changes into a database
        /// </summary>
        public void Save()
        {
            //save command
            _db.SaveChanges();
        }

        #endregion

        #region Search

        /// <summary>
        /// search the custom string into my database , its for searching part of website and search method as well
        /// </summary>
        /// <param name="q">My Speciel String For Search</param>
        /// <returns></returns>
        public IEnumerable<Page> Search(string q)
        {
            var list = _db.Pages.Where(p => p.PageTitle.Contains(q) || p.ShortDescription.Contains(q) || p.PageText.Contains(q) || p.PageTags.Contains(q)).ToList();
            return list.Distinct().ToList();
        }


        #endregion


    }
}
