using BookCheckInCheckOut.Business;
using BookCheckInCheckOut.Web.Core;
using BookCheckInCheckOut.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookCheckInCheckOut.Web
{
    public partial class HomePage : BasePage, IHeaderTitle
    {
        private const string BOOK_SELECT_MESSAGE = "Please select the book first.";

        #region IHeaderTitle Members
        public string PageHeader
        {
            get
            {
                return "Book Check In/Out List";
            }
        }
        #endregion


        private List<Book> _Books = null;
        private List<Book> Books
        {
            get
            {
                if(_Books == null)
                {
                    _Books = base.db.RetrieveBooksList();
                }
                return _Books;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DisplayBooks();
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
                base.SetPageMessage(ex.Message, Utilities.Utilities.Severity.error);
                return;
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(hdnField.Value))
                {
                    base.SetPageMessage(BOOK_SELECT_MESSAGE, Utilities.Utilities.Severity.error);
                    return;
                }

                Response.Redirect("CheckOut.aspx?bookID=" + int.Parse(hdnField.Value));
            }
            catch (ThreadAbortException ex)
            {
                BusinessLogicExceptionOperations logger = new BusinessLogicExceptionOperations();
                logger.SaveException(ex.Message);
            }
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(hdnField.Value))
                {
                    base.SetPageMessage(BOOK_SELECT_MESSAGE, Utilities.Utilities.Severity.error);
                    return;
                }

                Response.Redirect("CheckIn.aspx?bookID=" + int.Parse(hdnField.Value));
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
                base.SetPageMessage(ex.Message, Utilities.Utilities.Severity.error);
                return;
            }
        }


        private void DisplayBooks()
        {
            BusinessLogicDBOperations dbOp = new BusinessLogicDBOperations();

            try
            {
                BooksList.DataSource = Books;
                BooksList.DataBind();
            }
            catch (Exception ex)
            {
                BusinessLogicExceptionOperations logger = new BusinessLogicExceptionOperations();
                logger.SaveException(ex.Message);
                base.SetPageMessage(ex.Message, Utilities.Utilities.Severity.error);
                return;
            }


        }

        protected void btnBookDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(hdnField.Value))
                {
                    base.SetPageMessage(BOOK_SELECT_MESSAGE, Utilities.Utilities.Severity.error);
                    return;
                }

                Response.Redirect(string.Concat("BookDetail.aspx?bookID=", int.Parse(hdnField.Value)));
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