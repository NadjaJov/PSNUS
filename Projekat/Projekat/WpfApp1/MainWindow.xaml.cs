using DataConcentrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Data.Linq;
using System.Globalization;
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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Data_Concentrator concentrator = new Data_Concentrator();
       // public static Context Context { get; set; }
        public DI SelectedDI { get; set; }
        public DO SelectedDO { get; set; }
        public AI SelectedAI { get; set; }
        public AO SelectedAO { get; set; }
        public Alarm SelectedAlarm { get; set; }

        public List<string> addrListDI;
        public List<string> addrListDO;
        public List<string> addrListAI;
        public List<string> addrListAO;
        public List<Alarm> alarmList = new List<Alarm>();
        public List<AI> aiList = new List<AI>();
       
      //  public static dataC dataconc = new DataConcentrator();





        public MainWindow()
        {
            InitializeComponent();

            if (Data_Concentrator.Context==null)
            { 
                Data_Concentrator.Context = new Context();
            }

            this.DataContext = this;
           
            Data_Concentrator.Context.DIItems.Load();
         
            Data_Concentrator.Context.DOItems.Load();
            Data_Concentrator.Context.AIItems.Load();
            
            Data_Concentrator.Context.AOItems.Load();
            Data_Concentrator.Context.AlarmItems.Load();

         

            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {
                List<string> stringList = new List<string>();
                foreach (var s in ai.AlarmString.Split(';'))
                {
                    stringList.Add(s);
                }
                foreach (var aName in stringList)
                {
                    foreach (var al in Data_Concentrator.Context.AlarmItems.ToList())
                    {
                        if (aName==al.idnameAlarm)
                        {
                          
                            ai.Alarms.Add(al);
                            
                        }
                    }
                }
                Data_Concentrator.Context.AIItems.AddOrUpdate(ai);
                Data_Concentrator.Context.SaveChanges();
            }
         
            Data_Concentrator.PLC.PLCstart();
            concentrator.DILoadT();
            concentrator.AILoadT();
            datagridDI.ItemsSource = Data_Concentrator.Context.DIItems.Local;
            datagridDO.ItemsSource = Data_Concentrator.Context.DOItems.Local;
            datagridAI.ItemsSource = Data_Concentrator.Context.AIItems.Local;
            datagridAO.ItemsSource = Data_Concentrator.Context.AOItems.Local;
            datagridAlarms.ItemsSource = Data_Concentrator.Context.AlarmItems.Local;
            


        }

        private void Button_Click_AddDI(object sender, RoutedEventArgs e)
        {
            addrListDI = new List<string>();
            foreach (var di in Data_Concentrator.Context.DIItems.ToList())
            {
                addrListDI.Add(di.AddressDI);
            }
            AddDi addwindow = new AddDi(addrListDI);
            addwindow.ShowDialog();
            
        }

        private void Button_Click_AddDO(object sender, RoutedEventArgs e)
        {
            addrListDO = new List<string>();
            foreach (var doo in Data_Concentrator.Context.DOItems.ToList())
            {
                addrListDO.Add(doo.AddressDO);
            }
            AddDO addwindow = new AddDO(addrListDO);
            addwindow.ShowDialog();
            
        }

        private void Button_Click_AddAI(object sender, RoutedEventArgs e)
        {
            addrListAI = new List<string>();
            alarmList.Clear();
            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {
                addrListAI.Add(ai.AddressAI);
            }
            foreach (var al in Data_Concentrator.Context.AlarmItems.ToList())
            {
                alarmList.Add(al);
            }
            AddAI addwindow = new AddAI(alarmList, addrListAI );
            addwindow.ShowDialog();
            
        }

        private void Button_Click_AddAO(object sender, RoutedEventArgs e)
        {
            addrListAO = new List<string>();
            foreach (var ao in Data_Concentrator.Context.AOItems.ToList())
            {
                addrListAO.Add(ao.AddressAO);
            }
            AddAO addwindow = new AddAO(addrListAO);
            addwindow.ShowDialog();
            
        }

        private void Button_Click_AddAlarm(object sender, RoutedEventArgs e)
        {
            
            AddAlarm addwindow = new AddAlarm();
            addwindow.ShowDialog();
            
        }
        private void deleteDI(object sender, RoutedEventArgs e)
        {
            concentrator.cDeleteDI(SelectedDI);

        }

        private void deleteDO(object sender, RoutedEventArgs e)
        {
            concentrator.cDeleteDO(SelectedDO);
        }

        private void deleteAI(object sender, RoutedEventArgs e)
        {
            concentrator.cDeleteAI(SelectedAI);
        }

        private void deleteAO(object sender, RoutedEventArgs e)
        {
            concentrator.cDeleteAO(SelectedAO);
        }

        private void deleteAlarm(object sender, RoutedEventArgs e)
        {
            
            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {   if (ai.ActiveAlarms.ToList() != null || ai.ActiveAlarms.ToList().Count!=0)
                {
                    foreach (var al in ai.ActiveAlarms.ToList())
                    {
                        if (SelectedAlarm.IdNameAlarm == al.IdNameAlarm)
                        {
                            ai.ActiveAlarms.Remove(al);
                            concentrator.cDeleteAlarmFromAI(ai);
                        }
                    }
                }
                if (ai.Alarms.ToList() != null || ai.Alarms.ToList().Count!=0)
                {
                    foreach (var al in ai.Alarms.ToList())
                    {
                        if (SelectedAlarm.IdNameAlarm == al.IdNameAlarm)
                        {
                            ai.Alarms.Remove(SelectedAlarm);
                            string del = $"{al.IdNameAlarm};";
                            ai.AlarmString.Replace(del, "");
                            concentrator.cDeleteAlarmFromAI(ai);
                        }
                    }
                }
            
            }
            concentrator.cDeleteAlarm(SelectedAlarm);
        }

        private void Button_Click_AddAlarmAI(object sender, RoutedEventArgs e)
        {

            alarmList.Clear();
            foreach (var al in Data_Concentrator.Context.AlarmItems.ToList())
            {
                alarmList.Add(al);
            }
            AddAlarmAI addAlarmToAI = new AddAlarmAI(SelectedAI, alarmList);
            addAlarmToAI.ShowDialog();
            
        }

        private void deleteAIalarm(object sender, RoutedEventArgs e)
        {
            
         
            DeleteAlarmAI deletealarmai = new DeleteAlarmAI(SelectedAI);
            deletealarmai.ShowDialog();
          
        }

        private void addAItoAlarm(object sender, RoutedEventArgs e)
        {
            aiList.Clear();
            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {
                aiList.Add(ai);
            }
            AddAItoAlarm addAItoAlarm = new AddAItoAlarm(SelectedAlarm,aiList);
            addAItoAlarm.ShowDialog();
        }

        private void deleteAIfromAlarm(object sender, RoutedEventArgs e)
        {

            aiList.Clear();
            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {
                aiList.Add(ai);
            }
            DeleteAIfromAlarm deleteAlarmAI = new DeleteAIfromAlarm(SelectedAlarm,aiList);
            deleteAlarmAI.ShowDialog();

        }

        private void viewAIs(object sender, RoutedEventArgs e)
        {
            aiList.Clear();
            foreach (var ai in Data_Concentrator.Context.AIItems.ToList())
            {
                aiList.Add(ai);
            }
            ViewAIs viewais = new ViewAIs(SelectedAlarm, aiList);
            viewais.ShowDialog();
        }

        private void viewAlarms(object sender, RoutedEventArgs e)
        {

            ViewAlarms viewalarms = new ViewAlarms(SelectedAI);
            viewalarms.ShowDialog();
        }

        private void viewHistory(object sender, RoutedEventArgs e)
        {
            ViewHistory viewHistory = new ViewHistory();
            viewHistory.ShowDialog();
        }

      

        private void datagridDO_CurrentCellChanged(object sender, EventArgs e)
        {
           
            Data_Concentrator.Context.SaveChanges();
        }

        private void datagridAO_CurrentCellChanged(object sender, EventArgs e)
        {
            Data_Concentrator.Context.SaveChanges();
        }

        
        



        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Data_Concentrator.Context.SaveChanges();
            Data_Concentrator.Context.Dispose();
        }



    }
    internal class ValueValidationDO : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int proposedValue;
                if (!int.TryParse(value.ToString(), out proposedValue))
                {
                    return new ValidationResult(false, MessageBox.Show(" Value can only be 0 or 1."));
                }
                if (proposedValue == 0)
                {
                    return new ValidationResult(true, null);
                    
                }
                if (proposedValue ==1)
                {
                   return new ValidationResult(true, null); 
                }
                else {return new ValidationResult(false, MessageBox.Show(" Value can only be 0 or 1.")); }
               
            }
            return new ValidationResult(true, null);




          
        }
    }
    internal class ValueValidationAO : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                double proposedValue;
             
                if (value.ToString().StartsWith("-"))
                {
                    string s = value.ToString().Substring(1);
                    if (!double.TryParse(s.ToString(), out proposedValue))
                    {

                        return new ValidationResult(false, MessageBox.Show("Invalid value."));
                    }
                    else return new ValidationResult(true,null);
                }
                else if (!double.TryParse(value.ToString(), out proposedValue))
                {

                    return new ValidationResult(false, MessageBox.Show(" Invalid value."));
                }
                else
                {
                    

                    return new ValidationResult(true, null);

                }
            }
             return new ValidationResult(true, null);
        }
    }
}
