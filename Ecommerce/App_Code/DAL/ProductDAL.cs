using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class ProductDAL
    {
        //======== כיתה ======//
        /*public static List<Product> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = "SELECT * FROM T_Product"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // נעבור על כל הנתונים שחזרו ונכניס לתוך רשימה של מוצרים
            List<Product> LstProd = new List<Product>(); // יצירת רשימה של המוצרים

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Product Tmp = new Product()
                {
                    Pid = int.Parse(Dt.Rows[i]["Pid"] + ""),
                    Pname = Dt.Rows[i]["Pname"] + "",
                    Price = float.Parse(Dt.Rows[i]["Price"] + ""),
                    Pdesc = Dt.Rows[i]["Pdesc"] + "",
                    Picname = Dt.Rows[i]["Picname"] + "",
                    Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
                };
                LstProd.Add(Tmp);
            }
            Db.Close();
            return LstProd;
        }

        public static Product GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = $"SELECT * FROM T_Product where Pid={Id}"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // נעבור על כל הנתונים שחזרו ונכניס לתוך רשימה של מוצרים
            Product Tmp = null;
            if(Dt.Rows.Count > 0)
            {
                Tmp = new Product()
                {
                    Pid = int.Parse(Dt.Rows[0]["Pid"] + ""),
                    Pname = Dt.Rows[0]["Pname"] + "",
                    Price = float.Parse(Dt.Rows[0]["Price"] + ""),
                    Pdesc = Dt.Rows[0]["Pdesc"] + "",
                    Picname = Dt.Rows[0]["Picname"] + "",
                    Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
                };
            }
            Db.Close();
            return Tmp;
        }*/

        public static List<Product> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string Sql = "SELECT * FROM T_Product"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            List<Product> LstProd = new List<Product>(); // יצירת רשימה של המוצרים

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Product Tmp = new Product()
                {
                    Pid = int.Parse(Dt.Rows[i]["Pid"] + ""),
                    Pname = Dt.Rows[i]["Pname"] + "",
                    Price = float.Parse(Dt.Rows[i]["Price"] + ""),
                    Pdesc = Dt.Rows[i]["Pdesc"] + "",
                    Picname = Dt.Rows[i]["Picname"] + "",
                    Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
                    Status = Dt.Rows[i]["Status"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")
                };
                LstProd.Add(Tmp);
            }
            Db.Close();
            return LstProd;
        }

        public static Product GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string Sql = $"SELECT * FROM T_Product where Pid={Id}"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            Product Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Product()
                {
                    Pid = int.Parse(Dt.Rows[0]["Pid"] + ""),
                    Pname = Dt.Rows[0]["Pname"] + "",
                    Price = float.Parse(Dt.Rows[0]["Price"] + ""),
                    Pdesc = Dt.Rows[0]["Pdesc"] + "",
                    Picname = Dt.Rows[0]["Picname"] + "",
                    Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
                    Status = Dt.Rows[0]["Status"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + "")
                };
            }
            Db.Close();
            return Tmp;
        }
        public static void Insert(Product product)
        {
            DbContext Db = new DbContext();
            string Sql = "INSERT INTO T_Product (Pname, Price, Pdesc, Picname, Cid, Status, AddDate) VALUES ";
            Sql += $"(N'{product.Pname}', {product.Price}, N'{product.Pdesc}', N'{product.Picname}', {product.Cid}, N'{product.Status}', '{product.AddDate}')";
            Db.ExecuteNonQuery(Sql);
            Db.Close();
        }

        public static List<Product> GetByCategoryId(int categoryId)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string Sql = $"SELECT * FROM T_Product WHERE Cid={categoryId}"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            List<Product> LstProd = new List<Product>(); // יצירת רשימה של המוצרים

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Product Tmp = new Product()
                {
                    Pid = int.Parse(Dt.Rows[i]["Pid"] + ""),
                    Pname = Dt.Rows[i]["Pname"] + "",
                    Price = float.Parse(Dt.Rows[i]["Price"] + ""),
                    Pdesc = Dt.Rows[i]["Pdesc"] + "",
                    Picname = Dt.Rows[i]["Picname"] + "",
                    Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
                    Status = Dt.Rows[i]["Status"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")
                };
                LstProd.Add(Tmp);
            }
            Db.Close();
            return LstProd;
        }


        public static void Update(Product product)
        {
            DbContext Db = new DbContext();
            string Sql = "UPDATE T_Product SET ";
            Sql += $"Pname = N'{product.Pname}', ";
            Sql += $"Price = {product.Price}, ";
            Sql += $"Pdesc = N'{product.Pdesc}', ";
            Sql += $"Picname = N'{product.Picname}', ";
            Sql += $"Cid = {product.Cid}, ";
            Sql += $"Status = N'{product.Status}', ";
            Sql += $"AddDate = '{product.AddDate}' ";
            Sql += $"WHERE Pid = {product.Pid}";
            Db.ExecuteNonQuery(Sql);
            Db.Close();
        }
        public static void Save(Product product)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string Sql = "";
            if (product.Pid == -1)
            {
                Sql = $"INSERT INTO T_Product (Pname, Price, Pdesc, Picname, Cid, Status, AddDate) VALUES ('{product.Pname}', {product.Price}, '{product.Pdesc}', '{product.Picname}', {product.Cid}, 'Active', GETDATE())";
            }
            else
            {
                Sql = $"UPDATE T_Product SET Pname='{product.Pname}', Price={product.Price}, Pdesc='{product.Pdesc}', Picname='{product.Picname}', Cid={product.Cid}, Status='{product.Status}' WHERE Pid={product.Pid}";
            }
            Db.ExecuteNonQuery(Sql); // הפעלת השאילתה לביצוע פעולה על בסיס הנתונים
            Db.Close();
        }

        public static void Delete(int id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string Sql = $"DELETE FROM T_Product WHERE Pid={id}"; // הגדרת משפט השאילתה למחיקת מוצר
            Db.ExecuteNonQuery(Sql); // הפעלת השאילתה
            Db.Close();
        }
    }
}