using DataConcentrator;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddAlarm.xaml
    /// </summary>
    public partial class AddAlarm : Window
    {
        public Alarm newAlarm = new Alarm();
        
        public AddAlarm()
        {
            InitializeComponent();
            this.DataContext = newAlarm;

            NameBoxAlarm.Text = "";
            messageBoxAlarm.Text = "";
            this.overunderBoxAlarm.ItemsSource = new List<string>() { "above", "under" };
            limitvalueBoxAlarm.Text = "";
            newAlarm.time = DateTime.Now;
            
        }

        private void saveAlarm(object sender, RoutedEventArgs e)
        {
            bool checkName = false;
            bool checkMessage = false;
            bool checkOU = false;
            bool checkValue = false;
            bool checkEqual = false;
            double proposedValue;
            foreach (var a in Data_Concentrator.Context.AlarmItems)
            {
                string str = NameBoxAlarm.Text;
                if (str == a.IdNameAlarm) { NameBoxAlarm.BorderBrush = Brushes.Red; checkEqual = true; } else NameBoxAlarm.BorderBrush = Brushes.LightGray;
            }
            
            if (limitvalueBoxAlarm.Text.Length == 0 || limitvalueBoxAlarm.Text.ToString().Any(char.IsLetter) || limitvalueBoxAlarm.Text.ToString().Trim().Length == 0 || limitvalueBoxAlarm.Text.ToString().Any(char.IsWhiteSpace)) { limitvalueBoxAlarm.BorderBrush = Brushes.Red; checkValue = true; } 
            else if (!double.TryParse(limitvalueBoxAlarm.Text.ToString(), out proposedValue)) { limitvalueBoxAlarm.BorderBrush = Brushes.Red; checkValue = true; }
            else {limitvalueBoxAlarm.BorderBrush = Brushes.LightGray; checkValue = false; }
        
            if (NameBoxAlarm.Text.Length == 0 || NameBoxAlarm.Text.ToString().Trim().Length == 0) { NameBoxAlarm.BorderBrush = Brushes.Red; checkName = true; } else NameBoxAlarm.BorderBrush = Brushes.LightGray;
            if (messageBoxAlarm.Text.Length == 0 || messageBoxAlarm.Text.ToString().Trim().Length == 0) { messageBoxAlarm.BorderBrush = Brushes.Red; checkMessage = true; } else messageBoxAlarm.BorderBrush = Brushes.LightGray;
            if (overunderBoxAlarm.Text.Length == 0) { BorderAlarm.BorderBrush = Brushes.Red; checkOU = true; } else BorderAlarm.BorderBrush = Brushes.LightGray;
           
            if (checkName == false && checkEqual==false && checkMessage == false && checkOU == false && checkValue == false)
            {
                MainWindow.concentrator.cAddAlarm(newAlarm);
                this.Close();
            }
            else if (checkName == true) MessageBox.Show("Name field is empty!");
            else if (checkMessage == true) MessageBox.Show("Message field is empty!");
            else if (checkOU == true) MessageBox.Show("Over/under field is empty!");
            else if (checkValue == true) MessageBox.Show("Limit value input is invalid!");
            else if (checkEqual == true) MessageBox.Show("Name already exists!");
        }
    }
}
