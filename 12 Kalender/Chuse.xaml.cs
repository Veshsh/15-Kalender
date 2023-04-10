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

namespace _12_Kalender
{
    /// <summary>
    /// Логика взаимодействия для Chuse.xaml
    /// </summary>
    public partial class Chuse : Page
    {
        int? checitem=null;
        public Chuse()
        {
            InitializeComponent();
            for (int i = 0; i < Serializer.saves.Count; i++)
                if (Serializer.saves[i].Date == Serializer.save.Date)
                {
                    checitem = i;
                    for (int l = 0; l < LI.Items.Count; l++)
                    {
                        CheckBox checkBox = new CheckBox();
                        if (LI.Items[l] is CheckBox)
                        {
                            checkBox = (CheckBox)LI.Items[l];
                            checkBox.IsChecked = Serializer.saves[i].Chus[l];
                        }
                    }
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void Button_Clicks(object sender, RoutedEventArgs e)
        {
            bool chec=false;
            List<bool> list = new List<bool>();
            foreach (object item in LI.Items)
            {
                CheckBox checkBox = new CheckBox();
                if (item is CheckBox)
                {
                    checkBox = (CheckBox)item;
                    if (checkBox.IsChecked==true && Serializer.save.Uri == null)
                        Serializer.save.Uri = new Uri('\\' + ((Image)checkBox.Content).Source.ToString().Split('/')[3], UriKind.Relative);
                    list.Add(((checkBox.IsChecked == true) ? true : false));
                    chec = (checkBox.IsChecked==true)?true:chec;
                }
            }
            Serializer.save.Chus = list;
            if(chec)
                if (checitem!=null)
                    Serializer.saves[(int)checitem] = Serializer.save;
                else
                    Serializer.saves.Add(Serializer.save);   
            else if (checitem != null)
                Serializer.saves.RemoveAt((int)checitem);
            Serializer.Serialize(Serializer.saves);
            Serializer.save = new Save();
            NavigationService.Navigate(null);
        }
    }
}
