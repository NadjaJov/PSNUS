using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class AO : INotifyPropertyChanged
    {
        #region Fields
        [Key]
        public int idAO { get; set; }
        public string idnameAO;
        public string descriptionAO;
        public string addressAO;
        public double initialvalueAO;
        public string unitsAO;
        #endregion

        #region Properties


        
        public string IdNameAO
        {
            get { return idnameAO; }
            set
            {
                idnameAO = value;
                OnPropertyChanged("IdNameAO");
            }
        }

        public string DescriptionAO
        {
            get { return descriptionAO; }
            set
            {
                descriptionAO = value;
                OnPropertyChanged("DescriptionAO");
            }
        }

        public string AddressAO
        {
            get { return addressAO; }
            set
            {
                addressAO = value;
                OnPropertyChanged("AddressAO");
            }
        }

        public double InitialValueAO
        {
            get { return initialvalueAO; }
            set
            {
                initialvalueAO = value;
                OnPropertyChanged("InitialValueAO");
            }
        }


        public string UnitsAO
        {
            get { return unitsAO; }
            set
            {
                unitsAO = value;
                OnPropertyChanged("UnitsAO");
            }


        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        public AO() { }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

       

        
        #endregion
    }
}

