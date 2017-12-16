using BookCheckInCheckOut.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookCheckInCheckOut.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage, IHeaderTitle
    {
        private IHeaderTitle _ContentPage
        {
            get
            {
                return this.Page as IHeaderTitle;
            }
        }

        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                if(this._ContentPage != null)
                {
                    return _ContentPage.PageHeader;
                }
                return "Book Check In/Out";
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}