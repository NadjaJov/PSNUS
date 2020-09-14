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
    /// Interaction logic for AddAItoAlarm.xaml
    /// </summary>
    public partial class AddAItoAlarm : Window
    {
        public Alarm item = new Alarm();

        public List<AI> collAI = new List<AI>();
        public List<AI> AIList = new List<AI>();
        public List<AI> aibox = new List<AI>();

        public AddAItoAlarm(Alarm selitem, List<AI> aiList)
        {
            InitializeComponent();
            item = selitem;


            foreach (var a in aiList)
            {
                AIList.Add(a);
                aibox.Add(a);
                
            }



            if (AIList != null)
            {
                foreach (var ai in AIList)
                {   if (ai.Alarms != null)
                    {
                        foreach (var al in ai.Alarms)
                        {


                            if (al.IdNameAlarm == item.IdNameAlarm) aibox.Remove(ai);
                            
                        }
                    }

                }


            }
            
            
            llistbox.ItemsSource = aibox;




        }
        private void addAItoAlarm(object sender, RoutedEventArgs e)
        {
            

            if (llistbox.SelectedItems != null)
                {
                foreach (var sel in llistbox.SelectedItems)
                {
                    (sel as AI).Alarms.Add(item);
                    string s = $"{item.IdNameAlarm};";
                    (sel as AI).AlarmString+=s;
                    MainWindow.concentrator.cAddAlarmToAI(sel as AI);
                }
                 
            }
            this.Close();

        }

    }
}
