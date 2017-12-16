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
    public partial class CheckIn : BasePage, IHeaderTitle
    {
        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                return "Checkin Book";
            }
        }
        #endregion

        protected bool CheckedInSuccessfully
        {
            get
            {
                return base.GetViewState<bool>("CheckedInSuccessfully", false);
            }
            set
            {
                base.SetViewState<bool>("CheckedInSuccessfully", value);
            }
        }

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

        private void DisplayBorrowerDeails()
        {
            if(SelectedBook != null)
            {
                txtBookTitle.Text = SelectedBook.Title;
            }
            Borrower borrower = base.db.RetrieveBookBorrowerDetails(prmBookId);

            if (borrower != null)
            {
                txtBorrowerName.Text = borrower.Name;
                txtMobileNumber.Text = borrower.MobileNo;
                txtRequiredReturnDate.Text = borrower.ReturnDate.ToString(Constants.DATE_FORMAT);
                txtReturnDate.Text = DateTime.Now.ToString(Constants.DATE_FORMAT);

                //double penaltyAmount = calcultePenaltyAmount(DateTime.Now, borrower.ReturnDate);
                //lblPenaltyAmount.Text = String.Format("{0:#,##0.00}", penaltyAmount);
                
                
                double penaltyAmount = 0;
                int iExceedDaysCount = borrower.ReturnDate.CountBusinessDaysFrom(DateTime.Now);
                if (iExceedDaysCount > 0)
                {
                    penaltyAmount = iExceedDaysCount * base.PenalityAmount;
                    txtPenalityAmount.Text = string.Format(Constants.CURRENCY_FORMAT, penaltyAmount);
                }
            }
            else
            {
                //Utilities.Utilities.setPageMessage("Book is either already checked in or was not found.", Utilities.Utilities.severity.error, Page.Master);
                //return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DisplayBorrowerDeails();
            }
        }

        protected void btnCheckin_Click(object sender, EventArgs e)
        {
            int result = base.db.CheckIn(prmBookId);

            if (result == 0)
            {
                base.SetPageMessage("Encountered an error while checking in.", Utilities.Utilities.Severity.error);
                return;
            }

            base.SetPageMessage("Book has been checked in successfully.", Utilities.Utilities.Severity.success);
            CheckedInSuccessfully = true;
        }
    }
}