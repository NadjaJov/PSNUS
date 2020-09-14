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
    /// Interaction logic for AddAO.xaml
    /// </summary>
    public partial class AddAO : Window
    {
        public List<string> comboAO = new List<string>() { "ADDR012", "ADDR013", "ADDR014", "ADDR015" };
        public AO newAO = new AO();
        public AddAO(List<string>addrAO)
        {
            InitializeComponent();
            this.DataContext = newAO;
            NameBoxAO.Text = "";
            DescriptionBoxAO.Text = "";
            UnitsBoxAO.Text = "";
            ValueBoxAO.Text = "";

            if (addrAO != null) 
            {
                foreach (var add in addrAO)
                {
                    if (add == "ADDR012") comboAO.Remove("ADDR012");
                    if (add == "ADDR013") comboAO.Remove("ADDR013");
                    if (add == "ADDR014") comboAO.Remove("ADDR014");
                    if (add == "ADDR015") comboAO.Remove("ADDR015");
                }
            }
            this.AddressComboAO.ItemsSource = comboAO;
        }

       

        private void SaveAO(object sender, RoutedEventArgs e)
        {
            bool checkName = false;
            bool checkEqual = false;
            bool checkAddress = false;
            bool checkDescription = false;
            bool checkUnits = false;
            bool checkValue = false;
            bool checkL = false;
            bool checkDouble = false;
            int i = 0;
            foreach (var a in Data_Concentrator.Context.AOItems)
            {
                string str = NameBoxAO.Text;
                if (str==a.IdNameAO) { NameBoxAO.BorderBrush = Brushes.Red; checkEqual = true; } else NameBoxAO.BorderBrush = Brushes.LightGray;
            }
            foreach (var c in ValueBoxAO.Text.ToString())
            {
                if (c.Equals(".")) i++;
            }
            if (i == 0) { checkDouble = false; ValueBoxAO.BorderBrush = Brushes.LightGray; }
            else if (i == 1) { checkDouble = false; ValueBoxAO.BorderBrush = Brushes.LightGray; }
            double proposedValue;
            if (ValueBoxAO.Text.Length == 0 || ValueBoxAO.Text.ToString().Trim().Length == 0) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue = true; }
           
            else if (ValueBoxAO.Text.ToString().Any(char.IsLetter)) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue = true; }
            else if (ValueBoxAO.Text.ToString().Any(char.IsWhiteSpace)) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue = true; }
            else if (!double.TryParse(ValueBoxAO.Text.ToString(), out proposedValue)) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue = true; }
          
            else { checkValue = false; ValueBoxAO.BorderBrush = Brushes.LightGray; }
            if (ValueBoxAO.Text.ToString().Equals("0")) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue = true; }

            else { checkDouble = true; ValueBoxAO.BorderBrush = Brushes.Red; }
            if (NameBoxAO.Text.Length == 0 || NameBoxAO.Text.ToString().Trim().Length == 0) { NameBoxAO.BorderBrush = Brushes.Red; checkName=true; } else NameBoxAO.BorderBrush = Brushes.LightGray;
            if (DescriptionBoxAO.Text.Length == 0  || DescriptionBoxAO.Text.ToString().Trim().Length == 0) { DescriptionBoxAO.BorderBrush = Brushes.Red; checkDescription=true; } else DescriptionBoxAO.BorderBrush = Brushes.LightGray;
            if (UnitsBoxAO.Text.Length == 0 || UnitsBoxAO.Text.ToString().Trim().Length==0) { UnitsBoxAO.BorderBrush = Brushes.Red; checkUnits=true; } else UnitsBoxAO.BorderBrush = Brushes.LightGray;
            if (AddressComboAO.Text.Length==0) { BorderAO.BorderBrush = Brushes.Red; checkAddress= true; } else BorderAO.BorderBrush = Brushes.LightGray;
            char m = '-';
            char mm = ValueBoxAO.Text.ToString().First();
            if (ValueBoxAO.Text.ToString().Any(char.IsSymbol))
            {
                if (mm != m)
                { checkL = true; ValueBoxAO.BorderBrush = Brushes.Red; }
                else { checkL = false; ValueBoxAO.BorderBrush = Brushes.LightGray; }
            }
            if (ValueBoxAO.Text.Length == 0 || ValueBoxAO.Text.ToString().Any(char.IsSymbol) || ValueBoxAO.Text.ToString().Any(char.IsLetter) || ValueBoxAO.Text.ToString().Trim().Length==0) { ValueBoxAO.BorderBrush = Brushes.Red; checkValue= true; } else ValueBoxAO.BorderBrush = Brushes.LightGray;
            if (checkName == false && checkEqual == false && checkL==false &&checkAddress==false && checkDescription==false && checkUnits==false && checkValue==false && checkDouble==false)
            {
                MainWindow.concentrator.cAddAO(newAO);
                this.Close();
            }
            else if (checkName==true) MessageBox.Show("Name field is empty!");
            else if (checkDescription == true) MessageBox.Show("Description field is empty!");
            else if (checkAddress == true) MessageBox.Show("Address field is empty!");
            else if (checkEqual == true) MessageBox.Show("Name alredy exists!");
            else if (checkUnits == true) MessageBox.Show("Units field is empty!");
            else if (checkDouble == true || checkValue==true) MessageBox.Show("Value input is invalid!");

        }
    }
}
