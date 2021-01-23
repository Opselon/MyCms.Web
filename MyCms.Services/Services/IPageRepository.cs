using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DomainClasses.PageGroup;
using MyCms.Services.Repositories;
using MyCms.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.Services.Services
{
    public class PageGroupRepository : IPageGroupRepository
    {

        #region Private Variables
        /// <summary>
        /// This method making a DB Context From Layer scr "DataLayer/Context/MyCmsDbContext"
        /// so far we using that Database Layer For Making Our Commands While We Coding First-Database Layer Mode
        /// We Call It _db. to use
        /// </summary>
        /// 
        private MyCmsDbContext _db;
        #endregion

        #region PageGroup Repository
        /// <summary>
        /// Feel-Free
        /// </summary>
        /// <param name="db"></param>
        public PageGroupRepository(MyCmsDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Get Page Group By ID
        /// <summary>
        /// This Method Returns A Spciel Selected Row By ID
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public PageGroup GetPageGroupByID(int groupId)
        {
            return _db.PageGroups.Find(groupId);
        }
        #endregion

        #region List Page Groups
        /// <summary>
        /// This method returns the all of our rows into a LIST to show 
        /// </summary>
        /// <returns></returns>
        public List<PageGroup> GetAllPageGroups()
        {
            return _db.PageGroups.ToList();
        }
        #endregion

        #region Delete - Update - Insert

        #region Delete Page Group
        /// <summary>
        /// Modified a pageGroup From "DomainClass/PageGroups/PageGroup
        /// </summary>
        /// <param name="pageGroup"></param>
        public void DeletePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Deleted;
        }

        /// <summary>
        /// Deleting a Spciel Row From Database 
        /// </summary>
        /// <param name="groupID">To Find A Focused Row We Need To Giving This Parameter To method</param>
        public void DeletePageGroup(int groupID)
        {
            // This group variable returns the our selected row with ID 
            var group = GetPageGroupByID(groupID);

            //it starting DelePageGroup-Method For deleting selected row
            DeletePageGroup(group);
        }
        #endregion

        #region Insert Page Group
        /// <summary>
        /// this method insert the some detail or information or anything into a database
        /// as well this method Adding Page Group
        /// </summary>
        /// <param name="PageGroup">Null</param>
        public void InsertPageGroup(PageGroup PageGroup)
        {
            _db.PageGroups.Add(PageGroup);
        }
        #endregion

        #region Update Page Group

        /// <summary>
        /// Update PageGroup
        /// </summary>
        /// <param name="pageGroup"></param>
        public void UpdatePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Modified;
        }
        #endregion

        #endregion

        #region Show Groups View Model
        /// <summary>
        /// This method returned the Page Counts and Titles as well with ID
        /// </summary>
        /// <returns></returns>
        /// 

        public List<ShowGroupsViewModel> GetListGroups()
        {
            return _db.PageGroups.Select(g => new ShowGroupsViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count

            }).ToList();
        }
        #endregion

        #region Save And Exists
        /// <summary>
        /// Save Anything in database 
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        /// <summary>
        /// چک کن ببین پیج گروپی داری که گروه ایدی اش برابر با پیچ گروپ ایدی ورودی متود باشد؟
        /// </summary>
        /// <param name="PageGroupId">ورودی متود</param>
        /// <returns></returns>
        public bool PageGroupExists(int PageGroupId)
        {
   
            //check, did u have a PageGroup who has my method returned PageGroupID
            return _db.PageGroups.Any(p=>p.GroupID==PageGroupId);
        }

        #endregion

       

    }
}
