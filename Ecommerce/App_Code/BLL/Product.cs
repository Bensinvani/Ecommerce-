using DAL;
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

        public static List<Product> GetAll()
        {
            return ProductDAL.GetAll();
        }

        public static Product GetById(int Id)
        {
            return ProductDAL.GetById(Id);
        }

        public void Save()
        {
            ProductDAL.Save(this);
        }

        public static void Delete(int Id)
        {
            ProductDAL.Delete(Id);
        }
    }
}