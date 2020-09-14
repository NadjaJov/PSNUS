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
    /// Interaction logic for AddDO.xaml
    /// </summary>
    public partial class AddDO : Window
    {

        public List<string> comboDO = new List<string>() { "ADDR004", "ADDR005", "ADDR006", "ADDR007" };
        public DO newDO = new DO();
        public AddDO(List<string>addrDO)
        {
            InitializeComponent();
            this.DataContext = newDO;
            NameBoxDO.Text = "";
            DescriptionBoxDO.Text = "";
            ValueBoxDO.Text = "";

            if (addrDO != null) 
            {
                foreach (var add in addrDO)
                {
                    if (add == "ADDR004") comboDO.Remove("ADDR004");
                    if (add == "ADDR005") comboDO.Remove("ADDR005");
                    if (add == "ADDR006") comboDO.Remove("ADDR006");
                    if (add == "ADDR007") comboDO.Remove("ADDR007");
                }
            }
            this.AddressComboDO.ItemsSource = comboDO;

        }

      

        private void SaveDO(object sender, RoutedEventArgs e)
        {
            bool checkName = false;
            bool checkEqual = false;
            bool checkAddress = false;
            bool checkDescription = false;
            bool checkValue = false;
            bool checkV = false;
            
            foreach (var a in Data_Concentrator.Context.DOItems)
            {
                string st = NameBoxDO.Text;
                if (st==a.IdNameDO) { NameBoxDO.BorderBrush = Brushes.Red; checkEqual = true; } else NameBoxDO.BorderBrush = Brushes.LightGray;
            }

            string str = ValueBoxDO.Text;
            string s1 = "1";
            string s0 = "0";
            if (str == s1) { ValueBoxDO.BorderBrush = Brushes.LightGray; checkV = false; }
            else if (str==s0) { ValueBoxDO.BorderBrush = Brushes.LightGray; checkV = false; }
            else { ValueBoxDO.BorderBrush = Brushes.Red; checkV = true; }
            if (NameBoxDO.Text.Length == 0 || NameBoxDO.Text.ToString().Trim().Length==0) { NameBoxDO.BorderBrush = Brushes.Red; checkName= true; } else NameBoxDO.BorderBrush = Brushes.LightGray;
            if (DescriptionBoxDO.Text.Length == 0 || DescriptionBoxDO.Text.ToString().Trim().Length==0) { DescriptionBoxDO.BorderBrush = Brushes.Red; checkDescription= true; } else DescriptionBoxDO.BorderBrush = Brushes.LightGray;
            if (AddressComboDO.SelectedValue == null) { BorderDO.BorderBrush = Brushes.Red; checkAddress= true; } else BorderDO.BorderBrush = Brushes.LightGray;
            if (ValueBoxDO.Text.Length == 0 || ValueBoxDO.Text.ToString().Trim().Length==0) { ValueBoxDO.BorderBrush = Brushes.Red; checkValue= true; } else ValueBoxDO.BorderBrush = Brushes.LightGray;

            if (checkName == false && checkDescription==false && checkEqual==false && checkV==false && checkValue==false && checkAddress==false)
            {
                MainWindow.concentrator.cAddDO(newDO);
                this.Close();
            }
            else if (checkName == true) MessageBox.Show("Name field is empty!");
            else if (checkDescription == true) MessageBox.Show("Description field is empty!");
            else if (checkAddress == true) MessageBox.Show("Address field is empty!");
            else if (checkEqual == true) MessageBox.Show("Name alredy exists!");
            else if ( checkValue == true || checkV==true) MessageBox.Show("Value input is invalid!");

        }
    }
}
