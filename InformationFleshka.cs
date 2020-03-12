using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Threading.Tasks;

namespace Флешка
{
    class InformationFromFleshka
    {
        /*static void Main()
        {
            Console.WriteLine(InformationAboutFile());
            Console.ReadKey();
        }*/
        static string InformationAboutFile()
        {
            string NameOfDriver = " ", textFromFile = " "; ;
            bool changingname = false;
            DriveInfo[] D = DriveInfo.GetDrives();
            foreach (DriveInfo DI in D)
            {
                if (DI.DriveType == DriveType.Removable)
                {
                    NameOfDriver = Convert.ToString(DI.Name);
                    changingname = true;
                }
            }
            if (changingname == false) return "ObmanSuperPuper";
            else
            {
                string path = NameOfDriver + "\\employeeid";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                using (FileStream fstream = File.OpenRead($"{path}\\id.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    textFromFile = System.Text.Encoding.Default.GetString(array);
                    return textFromFile;
                }
            }
        }
    }
}
