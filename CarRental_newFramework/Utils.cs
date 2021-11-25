using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CarRental_newFramework
{
    public static class Utils
    {
        public static bool FormIsOpen(string name)
        {
            //Check if Window is already openned
            var openForms = Application.OpenForms.Cast<Form>();
            var isOpen = openForms.Any(q => q.Name == name);
            return isOpen;
        }

        public static string HashedPassword(string password)
        {
            SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();

            for(int i = 0;i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            var hashedPassword = sb.ToString();

            return hashedPassword;


        }

        public static string DefaultHashPassword()
        {
            SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("password@123"));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            var hashedPassword = sb.ToString();

            return hashedPassword;
        }
        

    }
}
