using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce
{
    public class GlobFunc
    {
        // פונקציה המקבלת מספר ומחזירה מחרוזת המוכרבת מתווים אקראיים באורך שקיבלנו
        public static string GetRandStr(int length)
        {
            string str = "abcdefghijklmnopqurstuvwxyz0123456789"; // 36 תווים
            // מחרוזת באורך 3 כמה אפשרויות יש לי
            // 36 * 36 * 36 = 32 2^5 = 2^15
            // 2^40 = 2^10 = K 2^20 M 2^30 G 2^40 T
            string RetStr = "";
            int index;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                index = rnd.Next(str.Length); // מגריל מספר בין 0-35
                RetStr += str[index]; // מוסיך במיקום שהוגרל קח את התו ותוסיף אותו למשתנה עזר
            }
            return RetStr; // החזרה של המחרוזת המוגרלת
        }
    }
}