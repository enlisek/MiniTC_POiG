using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Microsoft.Expression.Interactivity.Media;

namespace MiniTC_POiG.Model
{
    class Model2C
    {
        //private List<string> drives;
        private file file1;
        private file file2;

        public Model2C()
        {
            file1 = new file();
            file2 = new file();
        }

       
        public List<string> Drives { get; set; }

        
        public List<string> GetDrives()
        {
            System.IO.DriveInfo[] dyski = System.IO.DriveInfo.GetDrives();
            List<string> dyskiReady = new List<string>();
            foreach (System.IO.DriveInfo dysk in dyski)
            {
                if (dysk.IsReady) dyskiReady.Add(dysk.ToString());
            }
            Drives = dyskiReady;
            return Drives;
        }

        public void Copy(string pathWhat, string path1, string pathWhere, string path2 )
        {
            
            if (!string.IsNullOrEmpty(pathWhere) && pathWhere!="..." && file2.IsDirectory(path2+pathWhere.Substring(3)) && !System.IO.File.Exists(path2 + pathWhere.Substring(3) + "\\" + pathWhat))
            {
                System.IO.File.Copy(path1+pathWhat, path2+pathWhere.Substring(3) + "\\"+pathWhat);
            }
            else if (((!string.IsNullOrEmpty(pathWhere) && pathWhere != "..." && !file2.IsDirectory(path2+pathWhere.Substring(3))) || (string.IsNullOrEmpty(pathWhere)) || pathWhere != "...") && !System.IO.File.Exists(path2 + pathWhat))
            {
                System.IO.File.Copy(path1 + pathWhat, path2 + pathWhat);
            }
            #region brudnopis
            //if(!string.IsNullOrEmpty(pathWhat) && !string.IsNullOrEmpty(pathWhere)) //jesli oba sa zaznaczone
            //{
            //    if (!file1.IsDirectory(pathWhat) && file2.IsDirectory(pathWhere)) //jesli zaznaczenie1 nie jest folderem, a drugie jest
            //    {
            //        try
            //        {
            //            if (pathWhere.EndsWith("\\"))
            //            {
            //                System.IO.File.Copy(pathWhat, pathWhere.Substring(0,pathWhere.Length-1));
            //            }

            //        }
            //        catch (UnauthorizedAccessException) { }
            //    }
            //    else if (!file1.IsDirectory(pathWhat)) //jesli zaznaczenie 1 nie jest folderem i drugie tez nie jest
            //    {
            //        try
            //        {
            //            System.IO.File.Copy(pathWhat, pathZapas); //wtedy kopiujemy do folderu, gdzie zaznaczenie2 jest
            //        }
            //        catch (UnauthorizedAccessException) { }
            //    }
            //}
            //else if(!string.IsNullOrEmpty(pathWhat) && string.IsNullOrEmpty(pathWhere))
            //{
            //    try
            //    {
            //        System.IO.File.Copy(pathWhat, pathZapas); //wtedy kopiujemy do folderu, gdzie zaznaczenie2 jest
            //    }
            //    catch (UnauthorizedAccessException) { }
            //}
            #endregion

        }

        public string IgnoreD(string str)
        {
            if (str.Substring(0,3)=="<D>")
            {
                return str.Substring(3);
            }
            return str;
        }

        public string ChangeDirectory(string path, string directory)
        {
            if (directory == "...")
            {
                return file1.DirectoryBefore(path);
            }
            else if (file1.IsDirectory(path + IgnoreD(directory)) )
            {
                return path + IgnoreD(directory) + "\\";
               
            }
            
            return path;
            
        }
    }
}
