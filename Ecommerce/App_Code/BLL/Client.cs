using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.App_Code
{
    public class Client
    {
        public int ClientId { get; set; } // קוד לקוח
        public string ClientFirstName { get; set; } // שם פרטי של הלקוח
        public string ClientLastName { get; set; } // שם משפחה של הלקוח
        public string ClientAddress { get; set; } // כתובת הלקוח
        public string ClientCity { get; set; } // קוד העיר
        public string ClientPhone { get; set; } // טלפון של הלקוח
        public string ClientEmail { get; set; } // אימייל של הלקוח
        public string ClientPassword { get; set; } // סיסמה של הלקוח
        public string ClientStatus { get; set; } // סטאטוס הלקוח
        public string ClientPic { get; set; } // תמונה של הלקוח
        public DateTime ClientAddedDate { get; set; } // תאריך הוספה
    }
}