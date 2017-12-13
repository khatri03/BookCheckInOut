﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Web.Core
{
    public class BaseUserControl : System.Web.UI.UserControl
    {

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