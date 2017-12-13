using BookCheckInCheckOut.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookCheckInCheckOut.Web.Controls
{
    public partial class _PageTitles : BaseUserControl
    {
        public string PageTitle
        {
            get
            {
                string sTitle = base.GetViewState<string>("PageTitle", null);
                if(string.IsNullOrEmpty(sTitle))
                {
                    return "Dashboard";
                }
                return base.GetViewState<string>("PageTitle", null);
            }
            set
            {
                base.SetViewState<string>("PageTitle", value);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}