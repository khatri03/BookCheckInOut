using BookCheckInCheckOut.Business;
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
    public partial class CheckOut : BasePage, IHeaderTitle
    {
        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                return "Checkout Book";
            }
        }
        #endregion

        private int prmBookId
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

        private Book _SelecedBook = null;
        protected Book SelectedBook
        {
            get
            {
                if (_SelecedBook == null)
                {
                    if (prmBookId > 0)
                    {
                        List<Book> lstBooks = base.db.RetrieveBooksList();
                        _SelecedBook = (from b in lstBooks
                                        where b.BookID == this.prmBookId
                                        select b)
                                             .FirstOrDefault();
                    }
                    else
                    {
                        base.SetPageMessage("Book details not found.", Utilities.Utilities.Severity.error);
                    }
                }
                return _SelecedBook;
            }
        }

        private bool BookHasBeenCheckedOut
        {
            get
            {
                bool isCheckedOut = false;
                if (this.SelectedBook != null)
                {
                    isCheckedOut = !string.IsNullOrEmpty(this.SelectedBook.CurrentBorrowerID);
                }
                return isCheckedOut;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}