using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Data
{
    public class LogginOperations : Database
    {
        private static LogginOperations _instance;

        public static LogginOperations getInstance()
        {
            if (_instance == null)
            {
                _instance = new LogginOperations();

                _instance.initialize();

            }

            return _instance;

        }

        private new void initialize()
        {
            try
            {
                base.initialize();
            }
            catch (Exception ex)
            {
                //do logging.
                LogginOperations logger = new LogginOperations();
                logger.SaveException(ex.Message);
            }
        }


        public int SaveException(string sErrorMessage)
        {
            SqlCommand command = new SqlCommand();
            int result = 0;

            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Constants.SP_SaveException;

                command.Parameters.AddWithValue("@errormessage", sErrorMessage);
                result = base.ExecuteNonQuery(command);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                LogginOperations logger = new LogginOperations();
                logger.SaveException(ex.Message);
                throw new Exception("Oops! Something went wrong.");
            }
            catch (Exception ex)
            {
                //Do logging..
                LogginOperations logger = new LogginOperations();
                logger.SaveException(ex.Message);

            }
            finally
            {
                command.Dispose();
            }

            return result;

        }
    }
}