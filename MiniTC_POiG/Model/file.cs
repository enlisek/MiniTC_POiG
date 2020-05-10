using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MiniTC_POiG.Model
{
    class file
    {
        //private string path;
        //private List<string> content;

        #region konstruktor
        public file()
        {
           
        }
        #endregion

        #region properties
        //public string Path
        //{
        //    get { return path; }
        //    set { path = value; }
        //}
        public List<string> Content { get; set; }
        
        #endregion

        #region metody

        public string Directory(string path) //w jakim folderze dany plik/folder sie znajduje
        {
            try
            {
                if (path.Length==3) //jesli dysk
                {
                    return path;
                }
                string path1 = ((System.IO.Directory.GetParent(path)).ToString() + @"\");
                if (path1.EndsWith(@"\\"))
                {
                    path1 = path1.Remove(path.Length - 1);
                }
                return path1;
            }
            catch (Exception)
            {
                return path;
            }
        }

        public string DirectoryBefore(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                string path1 = path.Substring(0, path.Length - 1);
                while (!path1.EndsWith("\\"))
                {
                    path1 = path1.Substring(0, path1.Length - 1);
                }
                return path1;
            }
            else
            {
                return Directory(path);
            }
            
        }
        public List<string> GetContent(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                List<string> zaw = new List<string>();
                if (!(path.Length==3)) //jesli nie dysk
                {
                    zaw.Add("...");
                }
                try
                {
                    string[] files = System.IO.Directory.GetFileSystemEntries(path);
                    foreach (string file in files)
                    {
                        string file_name = System.IO.Path.GetFileName(file);
                        if (File.GetAttributes(file).HasFlag(FileAttributes.Directory))
                        {
                            file_name = @"<D>" + file_name;
                            zaw.Add(file_name);
                        }
                    }
                    foreach (string file in files)
                    {
                        string file_name = System.IO.Path.GetFileName(file);
                        if (!File.GetAttributes(file).HasFlag(FileAttributes.Directory))
                        {
                            zaw.Add(file_name);
                        }
                    }
                    Content = zaw;
                }
                catch (Exception)
                {
                    Content = GetContent(Directory(path));
                }
            }
            else if (System.IO.File.Exists(path)) //jak to bedzie sciezka do pliku, to zeby zabezpieczyc sie przed bledem, to zwroci content folderu, w ktoym plik sie znajduje
            {
                Content = GetContent(Directory(path));
            }

            return Content;
        }

        public bool IsDirectory(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }

        #endregion
    }
}
