using System;
using System.Globalization;
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
using MiniTC_POiG.Model;

namespace MiniTC_POiG
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


        #region Zdarznie własne
        public static readonly RoutedEvent SelectionChangedEvent = 
        EventManager.RegisterRoutedEvent("TabItemSelected",
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(PanelTC));

        public static readonly RoutedEvent MouseDoubleClickEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected1",
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(PanelTC));

        //definicja zdarzenia NumberChanged
        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public event RoutedEventHandler MouseDoubleClick
        {
            add { AddHandler(MouseDoubleClickEvent, value); }
            remove { RemoveHandler(MouseDoubleClickEvent, value); }
        }


        //Metoda pomocnicza wywołująca zdarzenie
        //przy okazji metoda ta tworzy obiekt argument przekazywany przez to zdarzenie
        void RaiseSelectionChanged()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.SelectionChangedEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        void RaiseMouseDoubleClick()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.MouseDoubleClickEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }
        #endregion

        #region Własność zależna

        public static readonly DependencyProperty DyskiProperty =
            DependencyProperty.Register(
                "DostepneDyski",
                typeof(List<string>),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty ContentDProperty =
            DependencyProperty.Register(
                "ContentD",
                typeof(List<string>),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty BiezacaSciezkaProperty =
            DependencyProperty.Register(
                "BiezacaSciezka",
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty WybranyDyskProperty =
            DependencyProperty.Register(
                "WybranyDysk",
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty WybranaPozycjaProperty =
            DependencyProperty.Register(
                "WybranaPozycja",
                typeof(string),
                typeof(PanelTC),
                new FrameworkPropertyMetadata(null)
            );

        public List<string> DostepneDyski
        {
            get { return (List<string>)GetValue(DyskiProperty); }
            set { SetValue(DyskiProperty, value); }
        }

        public List<string> ContentD
        {
            get { return (List<string>)GetValue(ContentDProperty); }
            set { SetValue(ContentDProperty, value); }
        }

        public string BiezacaSciezka
        {
            get { return (string)GetValue(BiezacaSciezkaProperty); }
            set { SetValue(BiezacaSciezkaProperty, value); }
        }

        public string WybranyDysk
        {
            get { return (string)GetValue(WybranyDyskProperty); }
            set { SetValue(WybranyDyskProperty, value); }
        }
        public string WybranaPozycja
        {
            get { return (string)GetValue(WybranaPozycjaProperty); }
            set { SetValue(WybranaPozycjaProperty, value); }
        }
        #endregion

        #region Metody obsługujące wewnętrzne zdarzenia kontrolki



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseSelectionChanged();
        }

        private void ListaPlikow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RaiseMouseDoubleClick();
        }

        #endregion



    }
}
