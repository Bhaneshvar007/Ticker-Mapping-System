using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cylsys.Common
{
    public class MessageHelper
    {
        public static string Exists_Sub_Record
        {
            get
            {
                return "Category have its Sub Category please delete sub Category First!";
            }
        }
        public static string DeleteRecord
        {
            get
            {
                return "Record Deleted Successfully !";
            }
        }
        public static string IdNotValid
        {
            get
            {
                return "Id Not Valid";
            }
        }

        public static string Internal_DB_Error
        {
            get
            {
                return "Internal_DB_Error";
            }
        }
        public static string InvalidCredentials
        {
            get
            {
                return "Invalid User & Password.";
            }
        }
        public static string Success
        {
            get
            {
                return "Data Save Successfully !";
            }
        }
        public static string Fail
        {
            get
            {
                return "Fail";
            }
        }
        public static string DuplicateRecord
        {
            get
            {
                return "Record Already Present !";
            }
        }
        public static string Already_Updated_Record
        {
            get
            {
                return "Record is already updated !";
            }
        }
    }
}