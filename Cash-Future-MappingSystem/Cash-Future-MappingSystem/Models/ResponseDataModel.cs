using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.Models
{
    public class ResponseDataModel
    {
        public bool Status { get; set; }
        public DateTime BatchClose { get; set; }
        public string TRT { get; set; }
        public string msg { get; set; }
        public int DTCount { get; set; }
        public DataTable excel_dt { get; set; }
    }
    
    
}