using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class DI : INotifyPropertyChanged
    {
        #region Fields
        [Key]
        public int idDI { get; set; }
        public string idnameDI;
        public string descriptionDI;
        public string addressDI;
        public double scantimeDI;
        public int valueDI;
        #endregion

        #region Properties


        public int ValueDI
        {
            get { return valueDI; }
            set
            {
                valueDI = value;
                OnPropertyChanged("ValueDI");
            }
        }
        public string IdNameDI
        {
            get { return idnameDI; }
            set
            {
                idnameDI = value;
                OnPropertyChanged("IdNameDI");
            }
        }

        public string DescriptionDI
        {
            get { return descriptionDI; }
            set
            {
                descriptionDI = value;
                OnPropertyChanged("DescriptionDI");
            }
        }

        public string AddressDI
        {
            get { return addressDI; }
            set
            {
                addressDI = value;
                OnPropertyChanged("AddressDI");
            }
        }

        public double ScanTimeDI
        {
            get { return scantimeDI; }
            set
            {
                scantimeDI = value;
                OnPropertyChanged("ScanTimeDI");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        public DI() { }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

      

        
        #endregion
    }
}
