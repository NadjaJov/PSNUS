using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class DO : INotifyPropertyChanged
    {
        #region Fields
        [Key]
        public int idDO { get; set; }
        public string idnameDO;
        public string descriptionDO;
        public string addressDO;
        public int initialvalueDO;
        
        #endregion

        #region Properties


        
        public string IdNameDO
        {
            get { return idnameDO; }
            set
            {
                idnameDO = value;
                OnPropertyChanged("IdNameDD");
            }
        }

        public string DescriptionDO
        {
            get { return descriptionDO; }
            set
            {
                descriptionDO = value;
                OnPropertyChanged("DescriptionDO");
            }
        }

        public string AddressDO
        {
            get { return addressDO; }
            set
            {
                addressDO = value;
                OnPropertyChanged("AddressDO");
            }
        }

        public int InitialValueDO
        {
            get { return initialvalueDO; }
            set
            {
                initialvalueDO = value;
                OnPropertyChanged("InitialValueDO");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods
        public DO() { }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

    

      
        #endregion
    }
}
