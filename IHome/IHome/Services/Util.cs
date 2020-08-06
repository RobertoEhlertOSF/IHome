using Java.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IHome.Services
{
    public static class Util
    {
        public static void CreateFileConfig(string text)
        {

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "config.txt");

            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            System.IO.File.WriteAllText(fileName, "http://" + text + "/");
        }

        public static string GetServerConfig()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "config.txt");

            if (System.IO.File.Exists(fileName))
            {
                return System.IO.File.ReadAllText(fileName);
            }
            else
            {
                return "";
            }
        }
    }
}
