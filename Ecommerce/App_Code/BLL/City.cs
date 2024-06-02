using BLL;
using DAL;
using Ecommerce.App_Code.DAL;
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
        public DateTime CityAddedDate { get; set; } // תאריך הוספה

        public static List<City> GetAll()
        {
            return CityDAL.GetAll();
        }

        public static City GetById(int Id)
        {
            return CityDAL.GetById(Id);
        }

        public void Save()
        {
            CityDAL.Save(this);
        }

        public static void Delete(int Id)
        {
            CityDAL.Delete(Id);
        }
    }
}