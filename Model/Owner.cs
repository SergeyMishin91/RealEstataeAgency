using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Owner : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Owner fields
        private int _ownerID;
        private string _ownerName;
        private int _ownerUNP;
        private string _ownerAdress;
        private string _ownerPhone;

        private string _error = null;
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

        #region OwnerValidation
        public string this[string columnName]
        {
            get
            {

                switch (columnName)
                {
                    case nameof(OwnerName):
                        _error = ValidateStringValue(OwnerName);
                        break;
                    case nameof(OwnerAdress):
                        _error = ValidateStringValue(OwnerAdress);
                        break;
                    case nameof(OwnerPhone):
                        _error = ValidateStringValue(OwnerPhone);
                        break;
                    case nameof(OwnerUNP):
                        _error = ValidationOwnerUNP(OwnerUNP);
                        break;
                }

                return _error;
            }
        }

        private string ValidationOwnerUNP(int ownerUNP)
        {
            if (ownerUNP > 999999999 || ownerUNP < 100000000)
                return "УНП состоит из 9 цифр";
            return null;
        }

        private string ValidateStringValue(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "Строка не может быть пустой";
            return null;
        }

        public string Error { get { return _error; } }
        #endregion
    }
}
