using BookCheckInCheckOut.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Business
{
    public class BusinessLogicExceptionOperations
    {
        public int SaveException(string sMessage)
        {
            LogginOperations db = LogginOperations.getInstance();
            return db.SaveException(sMessage);
        }
    }
}