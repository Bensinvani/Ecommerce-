using DATA;
using Ecommerce.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.App_Code.DAL
{
    public class CityDAL
    {
        /*public static List<City> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = "SELECT * FROM T_City"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת רשימה של הערים והכנסת הנתונים לתוכה
            List<City> LstCity = new List<City>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                City Tmp = new City()
                {
                    CityId = int.Parse(Dt.Rows[i]["CityId"] + ""),
                    CityName = Dt.Rows[i]["CityName"] + "",
                    CityStatus = Dt.Rows[i]["CityStatus"] + "",
                    CityAddedDate = Dt.Rows[i]["CityAddedDate"] + ""
                };
                LstCity.Add(Tmp);
            }
            Db.Close();
            return LstCity;
        }

        public static City GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string Sql = $"SELECT * FROM T_City WHERE CityId={Id}"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת אובייקט של עיר והכנסת הנתונים אליו
            City Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new City()
                {
                    CityId = int.Parse(Dt.Rows[0]["CityId"] + ""),
                    CityName = Dt.Rows[0]["CityName"] + "",
                    CityStatus = Dt.Rows[0]["CityStatus"] + "",
                    CityAddedDate = Dt.Rows[0]["CityAddedDate"] + ""
                };
            }
            Db.Close();
            return Tmp;
        }*/

        public static List<City> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "SELECT * FROM T_City"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            List<City> LstCities = new List<City>(); // יצירת רשימה של הערים

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                City city = new City()
                {
                    CityId = int.Parse(Dt.Rows[i]["CityId"].ToString()),
                    CityName = Dt.Rows[i]["CityName"].ToString(),
                    CityStatus = Dt.Rows[i]["CityStatus"].ToString(),
                    CityAddedDate = DateTime.Parse(Dt.Rows[i]["CityAddedDate"].ToString())
                };
                LstCities.Add(city);
            }
            Db.Close();
            return LstCities;
        }

        public static City GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"SELECT * FROM T_City WHERE CityId={Id}"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            City city = null;
            if (Dt.Rows.Count > 0)
            {
                city = new City()
                {
                    CityId = int.Parse(Dt.Rows[0]["CityId"].ToString()),
                    CityName = Dt.Rows[0]["CityName"].ToString(),
                    CityStatus = Dt.Rows[0]["CityStatus"].ToString(),
                    CityAddedDate = DateTime.Parse(Dt.Rows[0]["CityAddedDate"].ToString())
                };
            }
            Db.Close();
            return city;
        }

        public static void Save(City city)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "";
            if (city.CityId == -1)
            {
                sql = $"INSERT INTO T_City (CityName, CityStatus, CityAddedDate) VALUES ('{city.CityName}', 'Active', GETDATE())";
            }
            else
            {
                sql = $"UPDATE T_City SET CityName='{city.CityName}', CityStatus='{city.CityStatus}' WHERE CityId={city.CityId}";
            }
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה לביצוע פעולה על בסיס הנתונים
            Db.Close();
        }

        public static void Delete(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"DELETE FROM T_City WHERE CityId={Id}"; // הגדרת משפט השאילתה למחיקת עיר
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה
            Db.Close();
        }
    }
}