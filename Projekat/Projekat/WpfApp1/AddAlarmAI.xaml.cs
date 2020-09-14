using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddAlarmAI.xaml
    /// </summary>
    ///
   
    public partial class AddAlarmAI : Window
    {

        public AI item = new AI();

        
        public List<Alarm> AlarmList = new List<Alarm>();
        public   List<Alarm> alarmbox = new List<Alarm>();
       
        public AddAlarmAI(AI selitem, List<Alarm> alarmList)
        {
            InitializeComponent();
            item = selitem;

            if (alarmList != null)
            {
                foreach (var a in alarmList)
                {
                    AlarmList.Add(a);
                    alarmbox.Add(a);
                }
            }
            

            if (item.Alarms != null)
            {
                foreach (var al in AlarmList)
                {   
                        foreach (var ala in item.Alarms)
                        {


                        if (al.IdNameAlarm == ala.IdNameAlarm) alarmbox.Remove(al);
                        }
                    
                }


            }
            
        
            listbox.ItemsSource = alarmbox;
            
            
            

        }
        private void addAlarmToAI(object sender, RoutedEventArgs e)
        {
        
            if (listbox.SelectedItems != null)
            {
                foreach (var sel in listbox.SelectedItems)
                {
                    string s = $"{(sel as Alarm).IdNameAlarm};";
                    item.AlarmString += s;
                    item.Alarms.Add(sel as Alarm);
                  
                }
                
            }
          
            

            MainWindow.concentrator.cAddAlarmToAI(item);
      

            this.Close();

        }

    }
}
