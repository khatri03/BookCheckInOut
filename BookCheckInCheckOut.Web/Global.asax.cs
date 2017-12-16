using BookCheckInCheckOut.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BookCheckInCheckOut.Web
{
    public class Global : System.Web.HttpApplication
    {
        private BusinessLogicExceptionOperations _logger = null;
        private BusinessLogicExceptionOperations logger
        {
            get
            {
                if(_logger == null)
                {
                    _logger = new BusinessLogicExceptionOperations();
                }
                return _logger;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            if(HttpContext.Current != null)
            {
                if(HttpContext.Current.Request != null)
                {
                    string sUrl = HttpContext.Current.Request.Url.ToString();
                    if(HttpContext.Current.Server != null)
                    {
                        Exception ex = Context.Server.GetLastError();
                        if (ex != null)
                        {
                            logger.SaveException(ex.Message);
                            Context.Response.Redirect("~/Oops.aspx");
                        }
                    }                    
                }
            }
        }
    }
}