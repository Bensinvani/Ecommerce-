using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.App_Code.DAL
{
    public class ClientDAL
    {
        /*public static List<Client> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string sql = "SELECT * FROM T_Client"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת רשימה של היוזרים והכנסת הנתונים לתוכה
            List<Client> LstClients = new List<Client>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Client client = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[i]["ClientId"].ToString()),
                    ClientFirstName = Dt.Rows[i]["ClientFirstName"].ToString(),
                    ClientLastName = Dt.Rows[i]["ClientLastName"].ToString(),
                    ClientAddress = Dt.Rows[i]["ClientAddress"].ToString(),
                    ClientCity = Dt.Rows[i]["ClientCity"].ToString(),
                    ClientPhone = Dt.Rows[i]["ClientPhone"].ToString(),
                    ClientEmail = Dt.Rows[i]["ClientEmail"].ToString(),
                    ClientPassword = Dt.Rows[i]["ClientPassword"].ToString(),
                    ClientPic = Dt.Rows[i]["ClientPic"].ToString(),
                };
                LstClients.Add(client);
            }
            Db.Close();
            return LstClients;
        }

        public static Client GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים

            string sql = $"SELECT * FROM T_Client WHERE ClientId={Id}"; // הגדרת משפט השאילתה

            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים

            // יצירת אובייקט של הלקוח אם נמצא
            Client client = null;
            if (Dt.Rows.Count > 0)
            {
                client = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[0]["ClientId"].ToString()),
                    ClientFirstName = Dt.Rows[0]["ClientFirstName"].ToString(),
                    ClientLastName = Dt.Rows[0]["ClientLastName"].ToString(),
                    ClientAddress = Dt.Rows[0]["ClientAddress"].ToString(),
                    ClientCity = Dt.Rows[0]["ClientCity"].ToString(),
                    ClientPhone = Dt.Rows[0]["ClientPhone"].ToString(),
                    ClientEmail = Dt.Rows[0]["ClientEmail"].ToString(),
                    ClientPassword = Dt.Rows[0]["ClientPassword"].ToString(),
                    ClientPic = Dt.Rows[0]["ClientPic"].ToString(),
                };
            }
            Db.Close();
            return client;
        }*/

        public static List<Client> GetAll()
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "SELECT * FROM T_Client"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            List<Client> LstClients = new List<Client>(); // יצירת רשימה של היוזרים

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Client client = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[i]["ClientId"].ToString()),
                    ClientFirstName = Dt.Rows[i]["ClientFirstName"].ToString(),
                    ClientLastName = Dt.Rows[i]["ClientLastName"].ToString(),
                    ClientAddress = Dt.Rows[i]["ClientAddress"].ToString(),
                    ClientCity = Dt.Rows[i]["ClientCity"].ToString(),
                    ClientPhone = Dt.Rows[i]["ClientPhone"].ToString(),
                    ClientEmail = Dt.Rows[i]["ClientEmail"].ToString(),
                    ClientPassword = Dt.Rows[i]["ClientPassword"].ToString(),
                    ClientStatus = Dt.Rows[i]["ClientStatus"].ToString(),
                    ClientPic = Dt.Rows[i]["ClientPic"].ToString(),
                    ClientAddedDate = DateTime.Parse(Dt.Rows[i]["ClientAddedDate"].ToString())
                };
                LstClients.Add(client);
            }
            Db.Close();
            return LstClients;
        }

        public static Client GetById(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"SELECT * FROM T_Client WHERE ClientId={Id}"; // הגדרת משפט השאילתה
            DataTable Dt = Db.Execute(sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת נתונים
            Client client = null;
            if (Dt.Rows.Count > 0)
            {
                client = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[0]["ClientId"].ToString()),
                    ClientFirstName = Dt.Rows[0]["ClientFirstName"].ToString(),
                    ClientLastName = Dt.Rows[0]["ClientLastName"].ToString(),
                    ClientAddress = Dt.Rows[0]["ClientAddress"].ToString(),
                    ClientCity = Dt.Rows[0]["ClientCity"].ToString(),
                    ClientPhone = Dt.Rows[0]["ClientPhone"].ToString(),
                    ClientEmail = Dt.Rows[0]["ClientEmail"].ToString(),
                    ClientPassword = Dt.Rows[0]["ClientPassword"].ToString(),
                    ClientStatus = Dt.Rows[0]["ClientStatus"].ToString(),
                    ClientPic = Dt.Rows[0]["ClientPic"].ToString(),
                    ClientAddedDate = DateTime.Parse(Dt.Rows[0]["ClientAddedDate"].ToString())
                };
            }
            Db.Close();
            return client;
        }

        public static void Save(Client client)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = "";
            if (client.ClientId == 0)
            {
                sql = $"INSERT INTO T_Client (ClientFirstName, ClientLastName, ClientAddress, ClientCity, ClientPhone, ClientEmail, ClientPassword, ClientStatus, ClientPic, ClientAddedDate) VALUES ('{client.ClientFirstName}', '{client.ClientLastName}', '{client.ClientAddress}', '{client.ClientCity}', {client.ClientPhone}, '{client.ClientEmail}', '{client.ClientPassword}', 'Active', '{client.ClientPic}', GETDATE())";
            }
            else
            {
                sql = $"UPDATE T_Client SET ClientFirstName='{client.ClientFirstName}', ClientLastName='{client.ClientLastName}', ClientAddress='{client.ClientAddress}', ClientCity='{client.ClientCity}', ClientPhone={client.ClientPhone}, ClientEmail='{client.ClientEmail}', ClientPassword='{client.ClientPassword}', ClientStatus='{client.ClientStatus}', ClientPic='{client.ClientPic}' WHERE ClientId={client.ClientId}";
            }
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה לביצוע פעולה על בסיס הנתונים
            Db.Close();
        }

        public static void Delete(int Id)
        {
            DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
            string sql = $"DELETE FROM T_Client WHERE ClientId={Id}"; // הגדרת משפט השאילתה למחיקת יוזר
            Db.ExecuteNonQuery(sql); // הפעלת השאילתה
            Db.Close();
        }

    }
}