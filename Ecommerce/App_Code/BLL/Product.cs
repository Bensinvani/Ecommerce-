using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Product
    {
        public int Pid { get; set; } // קוד מוצר
        public string Pname { get; set; } // שם מוצר
        public float Price { get; set; } // מחיר
        public string Pdesc { get; set; } // תיאור מוצר
        public string Picname { get; set; } // שם תמונה
        public int Cid { get; set; } // קוד קטגוריה
        public string Status { get; set; } // סטאטוס 
        public DateTime AddDate { get; set; } // תאריך הוספה

    }
}