using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Business
{
    public class Borrower
    {
        public string MobileNo { get; set; }
        public string NationalID { get; set; }

        public string Name { get; set; }

        public DateTime ReturnDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Book Book { get; set; }

    }
}