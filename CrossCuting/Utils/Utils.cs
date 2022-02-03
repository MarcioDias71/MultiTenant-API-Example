using System;

using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CrossCuting
{
    public class Utils
    {
        
        public static object PegaValorPropriedade(object obj, string propName)
        {
            return obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        public static void VarDump(object objeto)
        {

            Type t = objeto.GetType();

            PropertyInfo[] pi = t.GetProperties();

            foreach(PropertyInfo p in pi)
            {
                Console.WriteLine(p.GetValue(objeto) != null ? p.Name + ": " + p.GetValue(objeto): p.Name + ": " + "null");
            }


        }

        public static string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }




        private static string RetonarHash(MD5 md5Hash, string input)
        {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();
        }

        public static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }


        public static DateTime? ConvertUTSToDatetime(System.Int64 UTS){

          return  DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(UTS)).LocalDateTime;

        }

    }
}