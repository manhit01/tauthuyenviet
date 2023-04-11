using System;
using System.Text.RegularExpressions;
namespace TauThuyenViet.Utilities
{
    public static class Commons
    {
        public static string GetFirstImage(this string value)
        {
            string result = value.Split('\n')[0]; //0 là lấy cấp thứ 0
            return result;
        }
        
        public static string[] GetListImage(this string value)
        {
            string[] result = value.Split('\n');
            return result;
        }

        public static string RemoveSign(this string value)
        {
            string result = value;

            string[] charList = new string[] { "aáàảãạăắằẳẵặâấầẩẫậ", "oóòỏõọôốồổỗộơớờởỡợ", "eéèẻẽẹêếềểễệ", "iíìỉĩị", "uúùủũụưứừửữự", "yýỳỷỹỵ", "dđ" };

            //Chạy N lần, mỗi lần qua 1 đoạn trong charList
            for (int i = 0; i < charList.Length; i++)
            {
                //Chạy qua từng ký tự của 1 đoạn trong vòng for bên ngoài
                for (int j = 1; j < charList[i].Length; j++)
                {
                    result = result.Replace(charList[i][j], charList[i][0]);
                    result = result.Replace(charList[i][j].ToString().ToUpper(), charList[i][0].ToString().ToUpper());
                }
            }

            return result;
        }

        public static string ToUrlFormat(this string value)
        {
            value = value.ToLower();

            value = value.RemoveSign();

            // chưa tối ưu
            //value = value.Replace(" ","-");
            //value = value.Replace("%", "-");
            //value = value.Replace("@", "-");
            //value = value.Replace("$", "-");
            //value = value.Replace("#", "-");

            //Tối  ưu
            string charList = " ~!@#$%^&*()_+/\\:'|{},.?[]<>";

            for (int i = 0; i < charList.Length; i++)
            {
                value = value.Replace(charList[i], '-');
            }

            //Thay thế những đáu -kép thành dấu - đơn
            Regex regex = new Regex("-+");
            value = regex.Replace(value, "-" );

            return value;
        }

    }
        
   }

