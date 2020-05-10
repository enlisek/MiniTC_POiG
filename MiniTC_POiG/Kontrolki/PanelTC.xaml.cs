using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC_POiG.Kontrolki
{
    /// <summary>
    /// Logika interakcji dla klasy kontrolkaDysku.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }


        public string BiezacaSciezka
        {
            get
            {
                return Sciezka.Text;
            }
            set
            {
                Sciezka.Text = value;
            }
        }
        public List<string> DostepneNapedy
        {
            get
            {
                return (List<string>)comboBoxDyski.ItemsSource;
            }
        }
        //public List<string> DostepneSciezki
        //{
        //    get
        //    {
        //        return 
        //    }
        //}
        private void comboBoxDyski_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
