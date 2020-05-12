using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniTC_POiG.ViewModel
{
    using Model;
    using BaseClass;
    using System.IO;
    using System.Diagnostics.Contracts;

    internal class ViewModel: ViewModelBase
    {
        private string path1;
        private string path2;

        public string Path1 
        { 
            get { return path1; }
            set  
            { 
                path1 = value;
                onPropertyChanged(nameof(Path1)); 
            }
        }
        public string Path2
        {
            get { return path2; }
            set
            {
                path2 = value;
                onPropertyChanged(nameof(Path2));
            }
        }

        private List<string> content1;
        private List<string> content2;

        public List<string> Content1
        {
            get { return content1; }
            set
            {
                content1 = value;
                onPropertyChanged(nameof(Content1));
            }
        }
        public List<string> Content2
        {
            get { return content2; }
            set
            {
                content2 = value;
                onPropertyChanged(nameof(Content2));
            }
        }

        public List<string> ListOfDrives { get; set; }

        private string selectedDrive1;
        private string selectedDrive2;

        public string SelectedDrive1
        {
            get { return selectedDrive1; }
            set
            {
                selectedDrive1 = value;
                onPropertyChanged(nameof(SelectedDrive1));
            }
        }
        public string SelectedDrive2
        {
            get { return selectedDrive2; }
            set
            {
                selectedDrive2 = value;
                onPropertyChanged(nameof(SelectedDrive2));
            }
        }

        public string SelectedItem1 { get; set; }
        public string SelectedItem2 { get; set; }






        private Model2C model2C = new Model.Model2C();
        private file file1 = new file();
        private file file2 = new file();


        public ViewModel()
        {
            ListOfDrives = model2C.GetDrives();
            SelectedDrive1 = ListOfDrives[0];
            Path1 = SelectedDrive1;
            SelectedDrive2 = ListOfDrives[0];
            Path2 = SelectedDrive2;
            Content1 = file1.GetContent(Path1);
            Content2 = file2.GetContent(Path2);
        }

        #region ICommand do kopiowania
        private ICommand _coppy = null;


        public ICommand Coppy
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_coppy == null)
                {
                    _coppy = new RelayCommand(
                        arg => { model2C.Copy(SelectedItem1, Path1, SelectedItem2, Path2); Content2 = file2.GetContent(Path2); },
                        arg => (!string.IsNullOrEmpty(SelectedItem1) && !(SelectedItem1=="...") && !(SelectedItem1.Substring(0,3)=="<D>")) );
                }

                return _coppy;
            }
        }

        #endregion

        #region ICommand do changeDirectory1

        private ICommand _changeDirectory1 = null;

        public ICommand ChDirectory1
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_changeDirectory1 == null)
                {
                    _changeDirectory1 = new RelayCommand(
                        arg =>{ Path1 = model2C.ChangeDirectory(Path1, SelectedItem1);
                            if (Content1 == file1.GetContent(Path1))
                            {
                                Path1 = file1.DirectoryBefore(Path1);
                            }
                            else
                            {
                                Content1 = file1.GetContent(Path1);
                            }
                            },
                        arg => (!string.IsNullOrEmpty(SelectedItem1)));
                }

                return _changeDirectory1;
            }
        }

        #endregion

        #region ICommand do changeDirectory2

        private ICommand _changeDirectory2 = null;

        public ICommand ChDirectory2
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_changeDirectory2 == null)
                {
                    _changeDirectory2 = new RelayCommand(
                        arg => { Path2 = model2C.ChangeDirectory(Path2, SelectedItem2); Content2 = file2.GetContent(Path2); },
                        arg => (!string.IsNullOrEmpty(SelectedItem2)));
                }

                return _changeDirectory2;
            }
        }

        #endregion

        #region ICommand do zmiany dysku1

        private ICommand _changeDrive1 = null;

        public ICommand ChangeDrive1
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_changeDrive1 == null)
                {
                    _changeDrive1 = new RelayCommand(
                        arg => { Path1 = SelectedDrive1; Content1 = file1.GetContent(Path1); },
                        arg => (!string.IsNullOrEmpty(SelectedDrive1)));
                }

                return _changeDrive1;
            }
        }
        #endregion

        #region ICommand do zmiany dysku1

        private ICommand _changeDrive2 = null;

        public ICommand ChangeDrive2
        {
            //do stworzenia obiektu polecenie użyjemy pomocniczej klasy RelayCommand
            get
            {
                if (_changeDrive2 == null)
                {
                    _changeDrive2 = new RelayCommand(
                        arg => { Path2 = SelectedDrive2; Content2 = file2.GetContent(Path2); },
                        arg => (!string.IsNullOrEmpty(SelectedDrive2)));
                }

                return _changeDrive2;
            }
        }
        #endregion

    }
}
