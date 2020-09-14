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
    /// Interaction logic for DeleteAIfromAlarm.xaml
    /// </summary>
    public partial class DeleteAIfromAlarm : Window
    {
        public Alarm deleteitem = new Alarm();
        public List<AI> AIList = new List<AI>();
        public List<AI> deleteAIList = new List<AI>();
        public DeleteAIfromAlarm(Alarm selectedAlarm, List<AI> aiList)
        {
            InitializeComponent();
            deleteitem = selectedAlarm;
            AIList = aiList;
            if (AIList != null)
            {
                foreach (var ai in AIList)
                {
                    if (ai.Alarms != null)
                    {
                        foreach (var al in ai.Alarms)
                        {
                            if (deleteitem.IdNameAlarm == al.IdNameAlarm) deleteAIList.Add(ai);
                         
                        }
                    }
                  
                }
            }
            deletellist.ItemsSource = deleteAIList;

        }

        private void deleteAIalarm(object sender, RoutedEventArgs e)
        {
            if (deletellist.SelectedItems != null)
            {
                
                    foreach (var d in deletellist.SelectedItems)
                    {
                        (d as AI).Alarms.Remove(deleteitem);
                        string delete = $"{deleteitem.IdNameAlarm};";

                        (d as AI).AlarmString.Replace(delete,"");
                        if ((d as AI).ActiveAlarms.ToList() != null)
                        {
                           if ((d as AI).ActiveAlarms.ToList().Count != 0)
                            foreach (var n in (d as AI).ActiveAlarms.ToList())
                            {
                                if (deleteitem.IdNameAlarm == n.IdNameAlarm)
                                    (d as AI).ActiveAlarms.Remove(deleteitem);
                            }
                        }
                       /* if ((d as AI).ActiveAlarms != null)
                        {
                           if ((d as AI).AlarmActiveString.Contains(delete))
                           {
                             (d as AI).AlarmActiveString.Replace(delete, "");
                           }
                        }*/
                        MainWindow.concentrator.cDeleteAlarmFromAI(d as AI);
                    }
            }

            this.Close();
        }
    }
}
