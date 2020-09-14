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
    /// Interaction logic for ViewAlarms.xaml
    /// </summary>
    public partial class ViewAlarms : Window
    {
        public AI viewitem = new AI();

        public List<Alarm> viewAlarmList = new List<Alarm>();
        public ViewAlarms(AI selectedAI)
        {
            InitializeComponent();
            viewitem = selectedAI;
            if (viewitem.Alarms != null)
            {
                foreach (var a in viewitem.Alarms)
                {
                    viewAlarmList.Add(a);

                }
            }
            viewllist.ItemsSource = viewAlarmList;
        }
    }
}
