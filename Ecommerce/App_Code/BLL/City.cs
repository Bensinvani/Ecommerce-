using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.App_Code.BLL
{
    public class City
    {
        public int CityId { get; set; } // קוד העיר
        public string CityName { get; set; } // שם העיר
        public string CityStatus { get; set; } // סטאטוס העיר
        public string CityAddedDate { get; set; } // תאריך הוספה
    }
}