using BookCheckInCheckOut.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Web.Core
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
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

        private BusinessLogicExceptionOperations _exceptionLogger = null;
        protected BusinessLogicExceptionOperations exceptionLogger
        {
            get
            {
                if (_exceptionLogger == null)
                {
                    _exceptionLogger = new BusinessLogicExceptionOperations();
                }
                return _exceptionLogger;
            }
        }

        public T GetViewState<T>(string sKey, T defaultValue)
        {
            string sVsKey = string.Concat(this.ClientID, "_", sKey);
            if(ViewState[sVsKey] == null)
            {
                return defaultValue;
            }
            return (T)Convert.ChangeType(ViewState[sVsKey], typeof(T));
        }
        public void SetViewState<T>(string sKey, T value)
        {
            string sVsKey = string.Concat(this.ClientID, "_", sKey);
            ViewState[sVsKey] = value;
        }
    }
}