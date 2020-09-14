using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ViewHistory.xaml
    /// </summary>
    public partial class ViewHistory : Window
    {
        public List<string> historyList = new List<string>();


        public ViewHistory()
        {
            InitializeComponent();

            foreach (var ai in Data_Concentrator.Context.AIItems)
            {
                if (ai.History !=null)
                {
                    foreach (var h in ai.History.Split(';'))
                    {
                       if( h!="")
                       historyList.Add(h);
                    }
                }
                hList.ItemsSource = historyList;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hList.ItemsSource = null;
            foreach (var a in Data_Concentrator.Context.AIItems.ToList())
            {
                a.History = null;
                Data_Concentrator.Context.AIItems.AddOrUpdate(a);
                Data_Concentrator.Context.SaveChanges();
            }
        }
    }
}
