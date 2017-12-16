using BookCheckInCheckOut.Web.Core;
using BookCheckInCheckOut.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookCheckInCheckOut.Web
{
    public partial class BookDetail : BasePage, IHeaderTitle
    {
        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                return "Bool Detail";
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}