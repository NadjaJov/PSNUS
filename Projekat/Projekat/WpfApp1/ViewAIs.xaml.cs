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
    /// Interaction logic for ViewAIs.xaml
    /// </summary>
    public partial class ViewAIs : Window
    {
        public List<AI> AIList = new List<AI>();
        public Alarm viewitem = new Alarm();
        public List<AI> viewAIList = new List<AI>();
        public ViewAIs(Alarm selectedAlarm, List<AI>aiList)
        {
            InitializeComponent();
            viewitem = selectedAlarm;
            AIList = aiList;
            if (AIList != null)
            {
                foreach (var ai in AIList)
                {
                    foreach (var al in ai.Alarms)
                    {
                        if (viewitem.IdNameAlarm == al.IdNameAlarm) viewAIList.Add(ai);
                       
                    }

                }
            }
          
            viewlist.ItemsSource = viewAIList;
        }
    }
}
