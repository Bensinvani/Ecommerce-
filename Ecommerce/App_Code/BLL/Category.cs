using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Category
    {
        public int Cid { get; set; } // קוד קטגוריה
        public string Cname { get; set; } // שם קטגוריה
        public string Cdesc { get; set; } // תיאור
        public string Picname { get; set; } // שם תמונה
        public int ParentCid { get; set; } // קוד קטגורית אב 
        public string Status { get; set; } // סטאטוס
        public string AddDate { get; set; } // תאריך הוספה
    }
}