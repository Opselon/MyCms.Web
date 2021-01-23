using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyCms.DomainClasses.Page
{

    /// <summary>
    /// My page detail and information data custom it giving from the website boxes
    /// </summary>
    public class Page
    {

        #region Constructors
        public Page()
        {

        }

        #endregion

        #region Static Property

        #region Group ID

        /// <summary>
        /// this is show this news is configure to witch of Group
        /// </summary>
        [Display(Name = "گروه خبر")]
        public int GroupID { get; set; }

        #endregion

        #region Page ID
        /// <summary>
        /// Page ID Key In Database
        /// </summary>
        [Key]
        public int PageID { get; set; }
        #endregion

        #region Page Title
        /// <summary>
        /// This is the page title propety
        /// </summary>
        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [MaxLength(400)]
        public string PageTitle { get; set; }
        #endregion

        #region Short Description
        /// <summary>
        /// Short Description in Page. it cost 500 character as max !
        /// just for givin the short detail about the page
        /// </summary>
        /// 
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)] // Make The Field of inputing text to multi line from single line as well
        public string ShortDescription { get; set; }

        #endregion

        #region Page Text
        /// <summary>
        /// This is the text inside of page that user can see
        /// </summary>
        /// 
        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [DataType(DataType.MultilineText)] // Make The Field of inputing text to multi line from single line as well
        public string PageText { get; set; }
        #endregion

        #region Page Visit
        /// <summary>
        /// this propety showing the number visiting the page
        /// </summary>
        [Display(Name = "تعداد بازدید")]
        public int PageVisit { get; set; }
        #endregion

        #region Image Name
        /// <summary>
        /// This is Saving the path of image in our database
        /// </summary>
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        #endregion

        #region Page Tags
        /// <summary>
        /// This is the Page-Tags in our page as well
        /// </summary>
        [Display(Name = "کلمات کیلیدی")]
        public string PageTags { get; set; }
        #endregion

        #region Slider
        /// <summary>
        /// This is the checkbox that if it is true then
        /// we can see in our slider page
        /// else we can not see it 
        /// </summary>
        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }
        #endregion

        #region Date Time
        /// <summary>
        /// This is Saving The DateTime  in Our Database
        /// </summary>
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }
        #endregion

        #endregion

        #region Navigation Property

        /// <summary>
        /// This article gives an overview of how Entity Framework manages relationships between entities.
        /// It also gives some guidance on how to map and manipulate relationships.
        /// </summary>
        public virtual PageGroup.PageGroup PageGroup { get; set; }

        #endregion

    }
}
