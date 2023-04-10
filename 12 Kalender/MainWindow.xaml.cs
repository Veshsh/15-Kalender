using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _12_Kalender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int DataPic;
        public MainWindow()
        {
            InitializeComponent();
            DataPicin.SelectedDate=DateTime.Now;
            Serializer.saves = (Serializer.Deserialize<List<Save>>() == null) ? new List<Save>() : Serializer.Deserialize<List<Save>>();
            UP();
        }
        private void Button_Clicke(object sender, RoutedEventArgs e)
        {
            DataPic = Convert.ToInt32(((Button)sender).Name.Split('B')[1]);
            DateTime dt = (DateTime)DataPicin.SelectedDate;
            DataPicin.SelectedDate= new DateTime(dt.Year, dt.Month, DataPic, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            MC.Content = new Chuse();
        }
        private void DataPicin_SelectedDateChanged(object sender=null, SelectionChangedEventArgs e=null)
        {
            Serializer.save.Date = (DateTime)DataPicin.SelectedDate;
            UP();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataPicin.SelectedDate = ((DateTime)DataPicin.SelectedDate).AddMonths(-1);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataPicin.SelectedDate = ((DateTime)DataPicin.SelectedDate).AddMonths(1);
        }
        private void UP()
        {
            MainContent.Children.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(((DateTime)DataPicin.SelectedDate).Year, ((DateTime)DataPicin.SelectedDate).Month); i++)
            {
                CONT userControl = new CONT();
                userControl.BT.Click+= Button_Clicke;
                userControl.Margin=new Thickness(5);
                userControl.Width=50;
                userControl.Height=50;
                userControl.MN.Text=i.ToString();
                userControl.BT.Name='B'+i.ToString();
                foreach (Save item in Serializer.saves)
                    if(item.Date.Year== ((DateTime)DataPicin.SelectedDate).Year && item.Date.Month== ((DateTime)DataPicin.SelectedDate).Month && item.Date.Day == i)
                        userControl.IMG.Source = new BitmapImage(item.Uri);
                MainContent.Children.Add(userControl);
            }
        }
        private void Ch(object sender, EventArgs e)
        {
            if (MC.Content == null)
            {
                DataPicin_SelectedDateChanged();
                Grid.SetColumnSpan(DataPicin, 1);
            }
            else
            {
                Grid.SetColumnSpan(DataPicin, 2);
            }
        }
    }
}
