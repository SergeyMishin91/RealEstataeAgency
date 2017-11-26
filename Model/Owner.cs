using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Owner : INotifyPropertyChanged
    {
        #region Owner fields
        private int _ownerID;
        private string _ownerName;
        private int _ownerUNP;
        private string _ownerAdress;
        private string _ownerPhone;
        #endregion

        #region Owner properties
        public int OwnerID
        {
            get { return _ownerID; }
            set
            {
                if (value == _ownerID) return;
                _ownerID = value;
                OnPropertyChanged();
            }
        }

        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                if (value == _ownerName) return;
                _ownerName = value;
                OnPropertyChanged();
            }
        }

        public int OwnerUNP
        {
            get { return _ownerUNP; }
            set
            {
                if (value == _ownerUNP) return;
                _ownerUNP = value;
                OnPropertyChanged();
            }
        }

        public string OwnerAdress
        {
            get { return _ownerAdress; }
            set
            {
                if (value == _ownerAdress) return;
                _ownerAdress = value;
                OnPropertyChanged();
            }
        }

        public string OwnerPhone
        {
            get { return _ownerPhone; }
            set
            {
                if (value == _ownerPhone) return;
                _ownerPhone = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
