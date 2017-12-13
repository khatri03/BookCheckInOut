using BookCheckInCheckOut.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static BookCheckInCheckOut.Web.Utilities.Utilities;

namespace BookCheckInCheckOut.Web.Core
{
    public class BasePage : System.Web.UI.Page
    {
        private MasterPage _master = null;
        private MasterPage master
        {
            get
            {
                if(_master == null)
                {
                    _master = Master as MasterPage;
                }
                return _master;
            }
        }

        protected T GetViewState<T>(string sKey, T defaultValue)
        {
            string sVsKey = string.Concat(this.ClientID, "_", sKey);
            if (ViewState[sVsKey] == null)
            {
                return defaultValue;
            }
            return (T)Convert.ChangeType(ViewState[sVsKey], typeof(T));
        }
        protected void SetViewState<T>(string sKey, T value)
        {
            string sVsKey = string.Concat(this.ClientID, "_", sKey);
            ViewState[sVsKey] = value;
        }

        private BusinessLogicDBOperations _db = null;
        protected BusinessLogicDBOperations db
        {
            get
            {
                if (_db == null)
                {
                    _db = new BusinessLogicDBOperations();
                }
                return _db;
            }
        }

        protected Label lblMessage
        {
            get
            {
                if(this.master != null)
                {
                    return master.FindControl("lblMessage") as Label;
                }
                return null;
            }
        }

        protected void SetPageMessage(string sMessage)
        {
            SetPageMessage(sMessage, Severity.info);
        }
        protected void SetPageMessage(string sMessage, Severity serverity)
        {
            if(lblMessage != null)
            {
                lblMessage.Text = sMessage;
                switch(serverity)
                {
                    case Severity.error:
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        break;

                    case Severity.info:
                        lblMessage.ForeColor = System.Drawing.Color.Blue;
                        break;

                    case Severity.success:
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        break;
                }
            }
        }
    }
}