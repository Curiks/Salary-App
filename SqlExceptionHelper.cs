using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryLibrary
{
    public static class SqlExceptionHelper
    {
        public static string message;
        public static bool ExceptionHandler(int error, string table)
        {
            bool ret = true;

            switch (error)
            {
                case 547:
                    message = table + " cannot be deleted while dependent record exist. Delete dependent record and try again";
                    ret = false;
                    break;
                case 2627:
                    message = "Cannot create a record in " + table + ". The record already exists";
                    ret = false;
                    break;
                default:
                    message = "Operation could not be completed";
                    ret = false;
                    break;
            }

            return ret;
        }
    }
}
