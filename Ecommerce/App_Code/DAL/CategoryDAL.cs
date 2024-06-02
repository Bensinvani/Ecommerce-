using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.App_Code.DAL
{
    public class CategoryDAL
    {
        /*public static List<Category> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = "SELECT * FROM T_Category"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת רשימה של קטגוריות והכנסת הנתונים לתוכה
            List<Category> LstCategory = new List<Category>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Category Tmp = new Category()
                {
                    Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
                    Cname = Dt.Rows[i]["Cname"] + "",
                    Cdesc = Dt.Rows[i]["Cdesc"] + "",
                    Picname = Dt.Rows[i]["Picname"] + "",
                    ParentCid = int.Parse(Dt.Rows[i]["ParentCid"] + ""),
                    Status = Dt.Rows[i]["Status"] + "",
                    AddDate = Dt.Rows[i]["AddDate"] + ""
                };
                LstCategory.Add(Tmp);
            }
            Db.Close();
            return LstCategory;
        }

        public static Category GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = $"SELECT * FROM T_Category WHERE Cid={Id}"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת אובייקט של קטגוריה והכנסת הנתונים אליו
            Category Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Category()
                {
                    Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
                    Cname = Dt.Rows[0]["Cname"] + "",
                    Cdesc = Dt.Rows[0]["Cdesc"] + "",
                    Picname = Dt.Rows[0]["Picname"] + "",
                    ParentCid = int.Parse(Dt.Rows[0]["ParentCid"] + ""),
                    Status = Dt.Rows[0]["Status"] + "",
                    AddDate = Dt.Rows[0]["AddDate"] + ""
                };
            }
            Db.Close();
            return Tmp;
        }*/

        public static List<Category> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "SELECT * FROM T_Category"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            List<Category> LstCategories = new List<Category>(); // יצירת רשימה של הקטגוריות

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Category category = new Category()
                {
                    Cid = int.Parse(Dt.Rows[i]["Cid"].ToString()),
                    Cname = Dt.Rows[i]["Cname"].ToString(),
                    Cdesc = Dt.Rows[i]["Cdesc"].ToString(),
                    Picname = Dt.Rows[i]["Picname"].ToString(),
                    ParentCid = int.Parse(Dt.Rows[i]["ParentCid"].ToString()),
                    Status = Dt.Rows[i]["Status"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString())
                };
                LstCategories.Add(category);
            }
            Db.Close();
            return LstCategories;
        }

        public static Category GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"SELECT * FROM T_Category WHERE Cid={Id}"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            Category category = null;
            if (Dt.Rows.Count > 0)
            {
                category = new Category()
                {
                    Cid = int.Parse(Dt.Rows[0]["Cid"].ToString()),
                    Cname = Dt.Rows[0]["Cname"].ToString(),
                    Cdesc = Dt.Rows[0]["Cdesc"].ToString(),
                    Picname = Dt.Rows[0]["Picname"].ToString(),
                    ParentCid = int.Parse(Dt.Rows[0]["ParentCid"].ToString()),
                    Status = Dt.Rows[0]["Status"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString())
                };
            }
            Db.Close();
            return category;
        }

        public static void Save(Category category)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "";
            if (category.Cid == 0)
            {
                sql = $"INSERT INTO T_Category (Cname, Cdesc, Picname, ParentCid, Status, AddDate) VALUES ('{category.Cname}', '{category.Cdesc}', '{category.Picname}', {category.ParentCid}, 'Active', GETDATE())";
            }
            else
            {
                sql = $"UPDATE T_Category SET Cname='{category.Cname}', Cdesc='{category.Cdesc}', Picname='{category.Picname}', ParentCid={category.ParentCid}, Status='{category.Status}' WHERE Cid={category.Cid}";
            }
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה לביצוע פעולה על בסיס הנתונים
            Db.Close();
        }
        public static void Insert(Category category)
        {
            DbContext Db = new DbContext();
            string sql = $"INSERT INTO T_Category (Cname, Cdesc, Picname, ParentCid, Status, AddDate) VALUES (N'{category.Cname}', N'{category.Cdesc}', N'{category.Picname}', {category.ParentCid}, N'{category.Status}', '{category.AddDate}')";
            Db.ExecuteNonQuery(sql);
            Db.Close();
        }

        public static void Update(Category category)
        {
            DbContext Db = new DbContext();
            string sql = $"UPDATE T_Category SET Cname=N'{category.Cname}', Cdesc=N'{category.Cdesc}', Picname=N'{category.Picname}', ParentCid={category.ParentCid}, Status=N'{category.Status}', AddDate='{category.AddDate}' WHERE Cid={category.Cid}";
            Db.ExecuteNonQuery(sql);
            Db.Close();
        }
        public static void Delete(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"DELETE FROM T_Category WHERE Cid={Id}"; // הגדרת משפט השאילתה למחיקת קטגוריה
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה
            Db.Close();
        }
    }
}