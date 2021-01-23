using MyCms.DomainClasses.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCms.Services.Repositories
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllPage();
        IEnumerable<Page> GetTopNews(int take = 4);
        IEnumerable<Page> GetPagesInSlider();
        IEnumerable<Page> GetLatesPage();
        IEnumerable<Page> GetPagesByGroupID(int groupID);
        IEnumerable<Page> Search(string q);
        Page GetPageByID(int PageId);
        void InsertPage(Page page);
        void DeletePage(Page page);
        void UpdatePage(Page page);
        void DeletePage(int pageId);
        bool PageExists(int pageId);
        void Save();
    }
}
