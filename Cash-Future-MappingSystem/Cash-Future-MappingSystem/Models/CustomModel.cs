using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.Models
{
    public class CustomModel
    {
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserID")]
        [EmailAddress]
        public string UserID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string CaptchaInputText { get; set; }

    }
    public class csvdatatable
    {
        public DataTable objdta { get; set; }
        public string msg { get; set; }
    }
}