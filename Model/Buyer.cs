using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Buyer : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Buyer fields
        private int _buyerID;
        private string _buyerName;
        private string _buyerAdress;
        private int _buyerUNP;
        private string _buyerPhone;
        private string _buyerRequest;

        private string _error = null;
        #endregion

        #region Buyer properties
        public int BuyerID
        {
            get { return _buyerID; }
            set
            {
                if (value == _buyerID) return;
                _buyerID = value;
                OnPropertyChanged();
            }
        }

        public string BuyerName
        {
            get { return _buyerName; }
            set
            {
                if (value == _buyerName) return;
                _buyerName = value;
                OnPropertyChanged();
            }
        }

        public string BuyerAdress
        {
            get { return _buyerAdress; }
            set
            {
                if (value == _buyerAdress) return;
                _buyerAdress = value;
                OnPropertyChanged();
            }
        }

        public int BuyerUNP
        {
            get { return _buyerUNP; }
            set
            {
                if (value == _buyerUNP) return;
                _buyerUNP = value;
                OnPropertyChanged();
            }
        }

        public string BuyerPhone
        {
            get { return _buyerPhone; }
            set
            {
                if (value == _buyerPhone) return;
                _buyerPhone = value;
                OnPropertyChanged();
            }
        }

        public string BuyerRequest
        {
            get { return _buyerRequest; }
            set
            {
                if (value == _buyerRequest) return;
                _buyerRequest = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged ([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region BuyerValidation
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(BuyerName):
                        _error = ValidateStringValue(BuyerName);
                        break;
                    case nameof(BuyerAdress):
                        _error = ValidateStringValue(BuyerAdress);
                        break;
                    case nameof(BuyerPhone):
                        _error = ValidateStringValue(BuyerPhone);
                        break;
                    case nameof(BuyerRequest):
                        _error = ValidateStringValue(BuyerRequest);
                        break;
                    case nameof(BuyerUNP):
                        _error = ValidationBuyerUNP(BuyerUNP);
                        break;
                }
                return _error;
            }
        }

        private string ValidationBuyerUNP(int buyerUNP)
        {
            if (buyerUNP > 999999999 || buyerUNP < 100000000)
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
