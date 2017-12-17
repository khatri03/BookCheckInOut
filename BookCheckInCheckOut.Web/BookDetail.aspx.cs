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
    public partial class BookDetail : BasePage, IHeaderTitle
    {
        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                return "Book Detail";
            }
        }
        #endregion

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

        private Borrower _CurrentBorrower = null;
        protected Borrower CurrentBorrower
        {
            get
            {
                if (_CurrentBorrower == null && prmBookId > 0)
                {
                    _CurrentBorrower = base.db.RetrieveBookBorrowerDetails(prmBookId);
                }
                return _CurrentBorrower;
            }
        }

        private List<Borrower> _BorrowerHistory = null;
        private List<Borrower> BorrowerHistory
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

        private void DopageLoadSettings()
        {
            DisplayBookDetail();
        }
        private void DisplayBookDetail()
        {
            if(this.SelectedBook != null)
            {
                txtBookTitle.Text = this.SelectedBook.Title;
                txtISBN.Text = this.SelectedBook.ISBN;
                txtPublishYear.Text = this.SelectedBook.PublishYear;
                txtCoverPrice.Text = string.Format(Constants.CURRENCY_FORMAT, this.SelectedBook.CoverPrice);
                txtStatus.Text = this.SelectedBook.CheckOutStatusDescription;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DopageLoadSettings();
                }
                catch (Exception ex)
                {                    
                    base.logger.SaveException(ex.Message);
                    base.SetPageMessage(ex.Message, Utilities.Utilities.Severity.error);
                    return;
                }
            }
        }
    }
}