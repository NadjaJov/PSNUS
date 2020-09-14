using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{

    public enum State
    {
        NO_LINKED_ALARM,
        REGULAR,
        ALARM
    }

    public class AI : INotifyPropertyChanged
    {
        #region Fields
        [Key]
        public int idAI { get; set; }
        public string idnameAI;
        public string descriptionAI;
        public string addressAI;
        public double scantimeAI;
        public string alarmstring = "";
      

        [NotMapped]
        public  List<Alarm> Alarms { get; set; }
        [NotMapped]
        public List<Alarm> ActiveAlarms { get; set; }
        public string history="";
       
        public string unitsAI;
        public State state;
        public double valueAI;
        public string active;
        
        
        #endregion

        #region Properties
        public string AlarmString
        {
            get { return alarmstring; }
            set {
                alarmstring = value;
                OnPropertyChanged("AlarmString");
            }
        }

        public string Active
        {
            get { return active; }
            set
            {
                active= value;
                OnPropertyChanged("Active");
            }
        }


        public string History
        {
            get { return history; }
            set
            {
                history = value;
                OnPropertyChanged("History");
            }
        }

        public double ValueAI
        {
            get { return valueAI; }
            set
            {
                valueAI = value;
                OnPropertyChanged("ValueAI");
            }
        }

       

        public string IdNameAI
        {
            get { return idnameAI; }
            set
            {
                idnameAI = value;
                OnPropertyChanged("IdNameAI");
            }
        }

        public string DescriptionAI
        {
            get { return descriptionAI; }
            set
            {
                descriptionAI = value;
                OnPropertyChanged("DescriptionAI");
            }
        }

        public string AddressAI
        {
            get { return addressAI; }
            set
            {
                addressAI = value;
                OnPropertyChanged("AddressAI");
            }
        }

        public double ScanTimeAI
        {
            get { return scantimeAI; }
            set
            {
                scantimeAI = value;
                OnPropertyChanged("ScanTimeAI");
            }
        }

        

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }


        public string UnitsAI
        {
            get { return unitsAI; }
            set
            {
                unitsAI = value;
                OnPropertyChanged("UnitsAI");
            }


        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        public AI() {
            Alarms = new List<Alarm>();
            ActiveAlarms = new List<Alarm>();
            
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

      
        
        #endregion
    }
}
