using BookCheckInCheckOut.Business;
using BookCheckInCheckOut.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookCheckInCheckOut.Web.Controls
{
    public partial class _CheckOutHistory : BaseUserControl
    {
        private List<Borrower> _BorrowerHistory = null;
        protected List<Borrower> BorrowerHistory
        {
            get
            {
                if (_BorrowerHistory == null && prmBookId > 0)
                {
                    _BorrowerHistory = base.db.RetrieveBookCheckOutHistory(prmBookId);
                }
                return _BorrowerHistory;
            }
        }

        public int prmBookId
        {
            get
            {
                int iBookId = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["bookid"]))
                {
                    int.TryParse(Request.QueryString["bookid"], out iBookId);
                }
                return iBookId;
            }
        }

        private void BindBookBorrowHistory()
        {
            HistoryList.DataSource = BorrowerHistory;
            HistoryList.DataBind();
        }

        public void Refresh()
        {
            BindBookBorrowHistory();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBookBorrowHistory();
            }
        }
    }
}