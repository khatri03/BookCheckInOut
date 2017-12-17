using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Business
{
    public class BaseBusinessLogic
    {
        private BusinessLogicExceptionOperations _logger = null;
        protected BusinessLogicExceptionOperations logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new BusinessLogicExceptionOperations();
                }
                return _logger;
            }
        }
    }
}