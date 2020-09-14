using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
   // public enum AlarmState
   /* {
        ACTIVE,
        INACTIVE
    }*/
    public class Alarm : INotifyPropertyChanged
    {  
         [Key]
        public int idAlarm { get; set; }
        public string idnameAlarm;
        public string message;
        public string overunder;
        public double limit;
        
      
        public DateTime time { get; set; }

        


        #region Properties
       

        public string IdNameAlarm
        {
            get { return idnameAlarm; }
            set
            {
                idnameAlarm = value;
                OnPropertyChanged("IdNameAlarm");
            }
        }

      

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public string OverUnder
        {
            get { return overunder; }
            set
            {
                overunder = value;
                OnPropertyChanged("OverUnder");
            }
        }

        public double Limit
        {
            get { return limit; }
            set
            {
                limit = value;
                OnPropertyChanged("Limit");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        public Alarm()
        {
            
         
        }

      
        

        private void OnPropertyChanged(string name)
        {   
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


      

       
        #endregion




    }
}
