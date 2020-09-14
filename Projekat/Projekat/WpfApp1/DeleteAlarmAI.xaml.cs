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
    /// Interaction logic for DeleteAlarmAI.xaml
    /// </summary>
    public partial class DeleteAlarmAI : Window
    {
        public AI deleteitem = new AI();

        public List<Alarm> deleteAlarmList = new List<Alarm>();
        

        public DeleteAlarmAI(AI selectedAI)
        {
            InitializeComponent();
            deleteitem = selectedAI;
            foreach (var a in deleteitem.Alarms)
            {
                deleteAlarmList.Add(a);
                
            }
            deletelist.ItemsSource = deleteAlarmList;
            
        }

        private void deleteAIalarm(object sender, RoutedEventArgs e)
        {
            if (deletelist.SelectedItems != null)
            {
                {
                    foreach (var d in deletelist.SelectedItems)
                    {
                        deleteitem.Alarms.Remove(d as Alarm);
                        string delete = $"{(d as Alarm).IdNameAlarm};";

                        deleteitem.AlarmString.Replace(delete, "");
                        if (deleteitem.ActiveAlarms.ToList() != null)
                        {
                            if (deleteitem.ActiveAlarms.ToList().Count != 0)
                                foreach (var n in deleteitem.ActiveAlarms)
                                {
                                    if ((d as Alarm).IdNameAlarm == n.IdNameAlarm)
                                        deleteitem.ActiveAlarms.Remove(d as Alarm);
                                }
                        }
                        
                    }
                }
             
              
                MainWindow.concentrator.cDeleteAlarmFromAI(deleteitem);
            }

            this.Close();
        }
    }
}
