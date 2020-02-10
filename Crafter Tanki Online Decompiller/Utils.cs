using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CrafterTankiOnlineDecompiller
{
    class Utils
    {
        public static string cmtc(string crypt, bool base64)
        {
            string dec = "";
            if (base64)
                dec = Encoding.UTF8.GetString(Convert.FromBase64String(crypt));
            else
                dec = crypt;

            string text = "";
            var gf = dec.Split(',');
            foreach (string array in gf)
            {
                text += (char)Convert.ToInt32(array);
            }

            return text;
        }
        public static string MD5File(string path)
        {
            string result;
            using (MD5 md = MD5.Create())
            {
                using (FileStream fileStream = File.OpenRead(path))
                {
                    byte[] array = md.ComputeHash(fileStream);
                    string text = string.Empty;
                    for (int i = 0; i < array.Length; i++)
                    {
                        text += Convert.ToString(array[i], 16).PadLeft(2, '0');
                    }
                    result = text.PadLeft(32, '0');
                }
            }
            return result;
        }

    }
}
    namespace System.Mathf
    {
        static class Mathf
        {
            public static float Clamp(float value, float min, float max)
            {
                return (value < min) ? min : (value > max) ? max : value;
            }
        }
}