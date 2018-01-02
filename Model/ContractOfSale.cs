using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class ContractOfSale: INotifyPropertyChanged, IDataErrorInfo
    {
        #region ContractOfSale fields
        private int _contractOfSaleID;
        private int _contractOfSaleBuyerID;
        private int _contractOfSaleEstateID;
        private string _contractOfSaleNumber;
        private DateTime _contractOfSaleDate;
        private string _contractOfSaleOwner;
        private string _contractOfSaleBuyer;
        private double _contractOfSaleCost;
        private string _contractOfSaleEstateInventoryNumber;

        private string _error = null;
        #endregion

        #region ContractOfSale properties
        public int ContractOfSaleID
        {
            get { return _contractOfSaleID; }
            set
            {
                if (value == _contractOfSaleID) return;
                _contractOfSaleID = value;
                OnPropertyChanged();
            }
        }

        public int ContractOfSaleBuyerID
        {
            get { return _contractOfSaleBuyerID; }
            set
            {
                if (value == _contractOfSaleBuyerID) return;
                _contractOfSaleBuyerID = value;
                OnPropertyChanged();
            }
        }

        public int ContractOfSaleEstateID
        {
            get { return _contractOfSaleEstateID; }
            set
            {
                if (value == _contractOfSaleEstateID) return;
                _contractOfSaleEstateID = value;
                OnPropertyChanged();
            }
        }

        public string ContractOfSaleNumber
        {
            get { return _contractOfSaleNumber; }
            set
            {
                if (value == _contractOfSaleNumber) return;
                _contractOfSaleNumber = value;
                OnPropertyChanged();
            }
        }

        public DateTime ContractOfSaleDate
        {
            get { return _contractOfSaleDate; }
            set
            {
                if (value == _contractOfSaleDate) return;
                _contractOfSaleDate = value;
                OnPropertyChanged();
            }
        }

        public string ContractOfSaleOwner
        {
            get { return _contractOfSaleOwner; }
            set
            {
                if (value == _contractOfSaleOwner) return;
                _contractOfSaleOwner = value;
                OnPropertyChanged();
            }
        }

        public string ContractOfSaleBuyer
        {
            get { return _contractOfSaleBuyer; }
            set
            {
                if (value == _contractOfSaleBuyer) return;
                _contractOfSaleBuyer = value;
                OnPropertyChanged();
            }
        }

        public double ContractOfSaleCost
        {
            get { return _contractOfSaleCost; }
            set
            {
                if (value == _contractOfSaleCost) return;
                _contractOfSaleCost = value;
                OnPropertyChanged();
            }
        }

        public string ContractOfSaleEstateInventoryNumber
        {
            get { return _contractOfSaleEstateInventoryNumber; }
            set
            {
                if (value == _contractOfSaleEstateInventoryNumber) return;
                _contractOfSaleEstateInventoryNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Contract of Sale Validation
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ContractOfSaleNumber):
                        _error = ValidateStringValue(ContractOfSaleNumber);
                        break;
                    case nameof(ContractOfSaleDate):
                        _error = ValidateStringValue(ContractOfSaleDate.ToString());
                        break;
                    case nameof(ContractOfSaleOwner):
                        _error = ValidateStringValue(ContractOfSaleOwner);
                        break;
                    case nameof(ContractOfSaleBuyer):
                        _error = ValidateStringValue(ContractOfSaleBuyer);
                        break;
                    case nameof(ContractOfSaleCost):
                        _error = ValidationCost(ContractOfSaleCost);
                        break;
                    case nameof(ContractOfSaleEstateInventoryNumber):
                        _error = ValidateStringValue(ContractOfSaleEstateInventoryNumber);
                        break;
                }
                return _error;
            }
        }

        private string ValidationCost(double cost)
        {
            if (cost < 1)
                return "Недопустимое значение";
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

        public Estate Estate
        {
            get => default(Estate);
            set
            {
            }
        }

        public Buyer Buyer
        {
            get => default(Buyer);
            set
            {
            }
        }
    }
}
