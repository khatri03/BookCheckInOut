using BookCheckInCheckOut.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Business
{
    public class BusinessLogicDBOperations : BaseBusinessLogic
    {

        public List<Book> RetrieveBooksList()
        {
            try
            {
                List<Book> books = null;

                BookCheckInCheckOutDBOperations db = BookCheckInCheckOutDBOperations.getInstance();

                IDataReader reader = db.RetrieveBooksList();

                DataTable dt = SchemaInfo.CreateBookDetailsSchemaTable();


                if (reader != null)
                {
                    books = new List<Book>();

                    while (reader.Read())
                    {


                        books.Add(new Book
                        {
                            BookID = (int)reader["BookID"],
                            Title = (string)reader["Title"],
                            ISBN = (string)reader["ISBN"],
                            PublishYear = (string)reader["PublishYear"],
                            CoverPrice = (decimal)reader["CoverPrice"],
                            CheckOutStatusDescription = (string)reader["CheckOutStatusDescription"]
                            ,
                            CurrentBorrowerID = Convert.ToString(reader["CurrentBorrowerID"])
                        });
                    }
                }



                return books;
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
            }
            return null;
        }

        public List<Borrower> RetrieveBookCheckOutHistory(int BookID)
        {
            try
            {
                List<Borrower> borrowers = null;
                BookCheckInCheckOutDBOperations db = BookCheckInCheckOutDBOperations.getInstance();

                IDataReader reader = db.RetrieveBookCheckOutHistory(BookID);

                if (reader != null)
                {
                    borrowers = new List<Borrower>();

                    while (reader.Read())
                    {
                        borrowers.Add(new Borrower
                        {
                            Name = (string)reader["Name"],
                            CheckOutDate = (DateTime)reader["CheckOutDate"],
                            ReturnDate = (DateTime)reader["ReturnDate"]
                        });
                    }
                }

                return borrowers;
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
            }
            return null;
        }

        public Borrower RetrieveBookBorrowerDetails(int BookID)
        {
            try
            {
                Borrower borrower = null;

                BookCheckInCheckOutDBOperations db = BookCheckInCheckOutDBOperations.getInstance();

                IDataReader reader = db.RetrieveBookBorrowerDetails(BookID);

                if (reader != null)
                    if (reader.Read())
                    {
                        borrower = new Borrower();
                        borrower.Name = (string)reader["Name"];
                        borrower.MobileNo = (string)reader["Mobile"];
                        borrower.ReturnDate = (DateTime)reader["ReturnDate"];
                    }

                return borrower;
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
            }
            return null;
        }

        public int CheckIn(int bookID)
        {
            try
            {
                BookCheckInCheckOutDBOperations db = BookCheckInCheckOutDBOperations.getInstance();

                return db.CheckIn(bookID);
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
            }
            return -1;
        }

        public int CheckOut(int bookID, string Name, string MobileNo, string NationalID, DateTime checkOutDate, DateTime ReturnDate)
        {
            try
            {
                BookCheckInCheckOutDBOperations db = BookCheckInCheckOutDBOperations.getInstance();

                return db.CheckOut(bookID, Name, MobileNo, NationalID, checkOutDate, ReturnDate);
            }
            catch (Exception ex)
            {
                base.logger.SaveException(ex.Message);
            }
            return -1;
        }
    }
}