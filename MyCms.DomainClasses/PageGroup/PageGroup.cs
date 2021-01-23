using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCms.DomainClasses.PageGroup
{
    #region Page Group

    /// <summary>
    /// Page Group Propety for First-Code Database
    /// </summary>
    public class PageGroup
    {
        #region Constructors
        public PageGroup()
        {

        }
        #endregion

        #region Group ID Function
        /// <summary>
        /// in the code first projects we should using the 'KEY' Anyway.
        /// so what we have here so far is our Database Key-Based As Group ID
        /// </summary>
        [Key] //its the key in our first-code table
        public int GroupID { get; set; }
        #endregion

        #region Group Title Function
        /// <summary>
        /// Group Title is for reach the Title of Project as well
        /// </summary>
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]  // it mean Group title can not be null
        [MaxLength(200)]  // it mean how many characters can inport this
        [Display(Name = "عنوان گروه")] // DisplayName sets the DisplayName in the model metadata.
        public string GroupTitle { get; set; }
        #endregion

        #region Navigation Property

        /// <summary>
        /// This article gives an overview of how Entity Framework manages relationships between entities.
        /// It also gives some guidance on how to map and manipulate relationships.
        /// </summary>
        public virtual List<Page.Page> Pages { get; set; }

        #endregion

    }

    #endregion
}
