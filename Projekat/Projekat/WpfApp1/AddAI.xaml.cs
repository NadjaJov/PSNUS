using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for AddAI.xaml
    /// </summary>
    public partial class AddAI : Window
    {
        public AI newAI = new AI();

        public List<Alarm> alarmlist = new List<Alarm>();
        public List<Alarm> colAlarm = new List<Alarm>();
        public List<string> comboAI = new List<string>() { "ADDR008", "ADDR009", "ADDR010", "ADDR011" };
        public List<Alarm> a = new List<Alarm>();
       

        public AddAI( List<Alarm> alarmList, List<string>addrAI)
        {
            InitializeComponent();
            this.DataContext = newAI;
            alarmlist = alarmList;
            NameBoxAI.Text = "";
            DescriptionBoxAI.Text = "";
            TimeBoxAI.Text = "";
            UnitsBoxAI.Text = "";



            listboxAI.ItemsSource = alarmlist;
          


            if (addrAI != null)

            {
                foreach (var add in addrAI)
                {
                    if (add == "ADDR008") comboAI.Remove("ADDR008");
                    if (add == "ADDR009") comboAI.Remove("ADDR009");
                    if (add == "ADDR010") comboAI.Remove("ADDR010");
                    if (add == "ADDR011") comboAI.Remove("ADDR011");
                }
            }
            
            this.AddressComboAI.ItemsSource = comboAI;
        }



        private void SaveAI(object sender, RoutedEventArgs e)
        {
            
                bool checkName = false;
            bool checkEqual = false;
            bool checkDescription = false;
            bool checkTime = false;
            bool checkUnits = false;
            bool checkAddress = false;
           
            
            if (NameBoxAI.Text.Length == 0 || NameBoxAI.Text.ToString().Trim().Length==0) { NameBoxAI.BorderBrush = Brushes.Red; checkName = true; } else NameBoxAI.BorderBrush = Brushes.LightGray;
            foreach (var a in Data_Concentrator.Context.AIItems)
            {
                string str = NameBoxAI.Text;
                if (str==a.IdNameAI) { NameBoxAI.BorderBrush = Brushes.Red; checkEqual = true; } else NameBoxAI.BorderBrush = Brushes.LightGray;
            }
           
            if (DescriptionBoxAI.Text.Length == 0 || DescriptionBoxAI.Text.ToString().Trim().Length==0) { DescriptionBoxAI.BorderBrush = Brushes.Red; checkDescription = true; } else DescriptionBoxAI.BorderBrush = Brushes.LightGray;
            double proposedValue;
            if (TimeBoxAI.Text.Length == 0 || TimeBoxAI.Text.ToString().Trim().Length == 0) { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (TimeBoxAI.Text.ToString().Any(char.IsLetter)) { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (TimeBoxAI.Text.ToString().Any(char.IsWhiteSpace)) { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (!double.TryParse(TimeBoxAI.Text.ToString(), out proposedValue)) { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }
            else if ((double.TryParse(TimeBoxAI.Text.ToString(),out proposedValue))) 
              {
                double d = Convert.ToDouble(TimeBoxAI.Text);
                if (d<0)  { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }}
            else { checkTime = false; TimeBoxAI.BorderBrush = Brushes.LightGray; }
            if (TimeBoxAI.Text.ToString().Equals("0")) { TimeBoxAI.BorderBrush = Brushes.Red; checkTime = true; }

            if (UnitsBoxAI.Text.Length == 0 || UnitsBoxAI.Text.ToString().Trim().Length==0 || UnitsBoxAI.Text.ToString().Any(char.IsWhiteSpace)) { UnitsBoxAI.BorderBrush = Brushes.Red; checkUnits= true; } UnitsBoxAI.BorderBrush = Brushes.LightGray;
            if (AddressComboAI.Text.Length==0) { BorderAI.BorderBrush = Brushes.Red; checkAddress= true; } BorderAI.BorderBrush = Brushes.LightGray;

            if (checkName == false && checkAddress == false && checkDescription == false && checkEqual == false && checkTime == false && checkUnits == false)
            {
                if (listboxAI.SelectedItems != null)
                {
                 
                    foreach (var sel in listboxAI.SelectedItems)
                    {
                        
                        string s = $"{(sel as Alarm).IdNameAlarm};";
                        newAI.Alarms.Add(sel as Alarm);
                        newAI.AlarmString += s;
                        
                       
                    }
                }
                
               MainWindow.concentrator.cAddAI(newAI);
              
                this.Close();
            }
            else if (checkName == true) MessageBox.Show("Name field is empty!");
            else if (checkAddress == true) MessageBox.Show("Address field is empty!");
            else if (checkDescription == true) MessageBox.Show("Description field is empty!");
            else if (checkEqual == true) MessageBox.Show("Name already exists!");
            else if (checkTime == true) MessageBox.Show("Time input is invalid!");
            else if (checkName == true) MessageBox.Show("Units input is invalid!");
             
        }
    }
}
