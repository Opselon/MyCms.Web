using MyCms.DomainClasses.PageGroup;
using MyCms.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MyCms.Services.Repositories
{
    public interface IPageGroupRepository
    {

        #region Get All Page Groups
        /// <summary>
        /// its giving the us List of Page Groups
        /// That Giving The GetAllPageGroups
        /// </summary>
        /// <returns></returns>
        List<PageGroup> GetAllPageGroups();
        #endregion

        #region Get Page Group By ID
        /// <summary>
        /// This Method Returns thats page needs to finding by ID!
        /// </summary>
        /// <param name="groupId">Finding the parameter ID When we Want Find Special Row</param>
        /// <returns></returns>
        PageGroup GetPageGroupByID(int groupId);
        #endregion

        #region Insert Page Group
        /// <summary>
        /// Insert Method when we want to insert something in database
        /// </summary>
        /// <param name="PageGroup"></param>
        void InsertPageGroup(PageGroup PageGroup);
        #endregion

        #region Update Page Group
        /// <summary>
        /// Update-Database Or Replacing Something Method
        /// </summary>
        /// <param name="pageGroup"></param>
        void UpdatePageGroup(PageGroup pageGroup);
        #endregion
        
        #region Delete Page Group
        /// <summary>
        /// Deleting the spieced row or rol in the database
        /// </summary>
        /// <param name="pageGroup"></param>
        void DeletePageGroup(PageGroup pageGroup);
        #endregion

        #region Delete Page Group
        /// <summary>
        /// Deleting Page Group, thats delete a spcied row or rol from database by ID.
        /// </summary>
        /// <param name="groupID">Its our parametr for finding the our ROW </param>
        void DeletePageGroup(int groupID);

        #endregion

        #region Page Group Exists
        /// <summary>
        /// it checks if page group is exits , if true so do anything and else.
        /// </summary>
        /// <param name="PageGroupId">it value about page group id from database column "ID" we should giving it.</param>
        /// <returns></returns>
        bool PageGroupExists(int PageGroupId);
        #endregion

        #region Show Groups ViewModel
        /// <summary>
        /// This method returned the value of count Group Bars
        /// </summary>
        /// <returns></returns>
        List<ShowGroupsViewModel> GetListGroups();
        #endregion

        #region Save parameter
        /// <summary>
        /// Save the all edits into a database or save every changes we do!
        /// </summary>
        void Save();
        #endregion

    }
}
