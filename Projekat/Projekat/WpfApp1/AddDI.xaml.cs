using DataConcentrator;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddDi.xaml
    /// </summary>
    public partial class AddDi : Window
    {
        public DI newDI = new DI();
        public List<string> comboDI= new List<string>() { "ADDR000", "ADDR001"  ,"ADDR002", "ADDR003" };
        public AddDi(List<string> addrDI)
        {
            InitializeComponent();
            this.DataContext = newDI;
            NameBoxDI.Text = "";
            DescriptionBoxDI.Text = "";
            TimeBoxDI.Text = "";

            if (addrDI != null) 
            {
                foreach (var add in addrDI)
                {
                    if (add == "ADDR000") comboDI.Remove("ADDR000");
                    if (add == "ADDR001") comboDI.Remove("ADDR001");
                    if (add == "ADDR002") comboDI.Remove("ADDR002");
                    if (add == "ADDR003") comboDI.Remove("ADDR003");
                }
            }
            this.AddressComboDI.ItemsSource = comboDI;
              
        }

       

        private void SaveDI(object sender, RoutedEventArgs e)
        {
            bool checkName = false;
            bool checkEqual = false;
            bool checkAddress = false;
            bool checkDescription = false;
            bool checkTime = false;
            
            
            foreach (var a in Data_Concentrator.Context.DIItems)
            {
                string st = NameBoxDI.Text;
                if (st==a.IdNameDI) { NameBoxDI.BorderBrush = Brushes.Red; checkEqual = true; } else NameBoxDI.BorderBrush = Brushes.LightGray;
            }
            double proposedValue;
            if (NameBoxDI.Text.Length == 0 || NameBoxDI.Text.ToString().Trim().Length == 0) { NameBoxDI.BorderBrush = Brushes.Red; checkName=true; } else NameBoxDI.BorderBrush = Brushes.LightGray;
            if (DescriptionBoxDI.Text.Length == 0 || DescriptionBoxDI.Text.ToString().Trim().Length==0) { DescriptionBoxDI.BorderBrush = Brushes.Red; checkDescription= true; } else DescriptionBoxDI.BorderBrush = Brushes.LightGray;
            if (TimeBoxDI.Text.Length == 0 || TimeBoxDI.Text.ToString().StartsWith("0") || TimeBoxDI.Text.ToString().Trim().Length == 0) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (TimeBoxDI.Text.ToString().Any(char.IsSymbol)) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (TimeBoxDI.Text.ToString().Any(char.IsLetter)) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (TimeBoxDI.Text.ToString().Any(char.IsWhiteSpace)) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            else if (!double.TryParse(TimeBoxDI.Text.ToString(), out proposedValue)) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            else if ((double.TryParse(TimeBoxDI.Text.ToString(), out proposedValue)))
            {
                double d = Convert.ToDouble(TimeBoxDI.Text);
                if (d < 0) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            }
            else { checkTime = false; TimeBoxDI.BorderBrush = Brushes.LightGray; }
            if (TimeBoxDI.Text.ToString().Equals("0")) { TimeBoxDI.BorderBrush = Brushes.Red; checkTime = true; }
            if (AddressComboDI.Text.Length==0) { BorderDI.BorderBrush = Brushes.Red; checkAddress= true; } BorderDI.BorderBrush = Brushes.LightGray;
            
            if (checkName == false && checkTime==false && checkEqual==false && checkAddress==false && checkDescription==false )
            {
                MainWindow.concentrator.cAddDI(newDI);
                this.Close();
            }
            else if (checkName == true) MessageBox.Show("Name field is empty!");
            else if (checkDescription == true) MessageBox.Show("Description field is empty!");
            else if (checkAddress == true) MessageBox.Show("Address field is empty!");
            else if (checkEqual == true) MessageBox.Show("Name alredy exists!");
            else if (checkTime == true) MessageBox.Show("Time input is invalid!");

        }
    }
}
