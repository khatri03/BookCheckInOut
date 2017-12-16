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

        private void FillData()
        {
            if(SelectedBook != null)
            {
                txtCheckoutDate.Text = DateTime.Now.ToString(Constants.DATE_TIME_FORMAT);
                DateTime returnDate = DateTime.Now.BusinessDays(base.BookReturnDays);
                txtCheckinDate.Text = returnDate.ToString(Constants.DATE_TIME_FORMAT);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(prmBookId <= 0)
                {
                    base.SetPageMessage("Book detail not found", Utilities.Utilities.Severity.error);
                }
                else
                {
                    FillData();
                }
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (BookHasBeenCheckedOut)
            {
                base.SetPageMessage("Book has already been checked out.", Utilities.Utilities.Severity.error);
                return;
            }
            else
            {
                if(SelectedBook == null)
                {
                    base.SetPageMessage("Book detail not found.", Utilities.Utilities.Severity.error);
                }
                else
                {
                    int iResult = base.db.CheckOut(prmBookId, txtBorrowerName.Text, txtMobileNumber.Text, txtNationalId.Text, Convert.ToDateTime(txtCheckoutDate.Text), Convert.ToDateTime(txtCheckinDate.Text));
                    if(iResult <= 0)
                    {
                        base.SetPageMessage("Encountered an error while checking out.", Utilities.Utilities.Severity.error);
                    }
                    else
                    {
                        base.SetPageMessage("Book has been checked out in the name of " + txtBorrowerName.Text, Utilities.Utilities.Severity.success);
                        _CheckOutHistory.Refresh();
                    }
                }
            }
        }
    }
}