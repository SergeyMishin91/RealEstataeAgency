using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Estate : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Estate fields
        private int _estateID;
        private int _estateOwnerID;
        private string _estateFunction;
        private string _estateName;
        private string _estateInventoryNumber;
        private double _estateSpace;
        private string _estateAdress;
        private int _estateYear;
        private string _estateWall;
        private string _estateState;
        private string _estateOwner;
        private double _estateCostOfSale;
        private string _estateDescription;


        private string _error = null;

        #endregion

        #region Estate properties
        public int EstateID 
        {
            get { return _estateID; }
            set
            {
                if (value == _estateID) return;
                _estateID = value;
                OnPropertyChanged();
            }
        }

        public int EstateOwnerID  
        {
            get { return _estateOwnerID; }
            set
            {
                if (value == _estateOwnerID) return;
                _estateOwnerID = value;
                OnPropertyChanged();
            }
        }

        public string EstateFunction
        {
            get { return _estateFunction; }
            set
            {
                if (value == _estateFunction) return;
                _estateFunction = value;
                OnPropertyChanged();
            }
        }

        public string EstateName
        {
            get { return _estateName; }
            set
            {
                if (value == _estateName) return;
                _estateName = value;
                OnPropertyChanged();
            }
        }

        public string EstateInventoryNumber
        {
            get { return _estateInventoryNumber; }
            set
            {
                if (value == _estateInventoryNumber) return;
                _estateInventoryNumber = value;
                OnPropertyChanged();
            }
        }

        public double EstateSpace
        {
            get { return _estateSpace; }
            set
            {
                if (value == _estateSpace) return;
                _estateSpace = value;
                OnPropertyChanged();
            }
        }

        public string EstateAdress
        {
            get { return _estateAdress; }
            set
            {
                if (value == _estateAdress) return;
                _estateAdress = value;
                OnPropertyChanged();
            }
        }

        public int EstateYear
        {
            get { return _estateYear; }
            set
            {
                if (value == _estateYear) return;
                _estateYear = value;
                OnPropertyChanged();
            }
        }

        public string EstateWall
        {
            get { return _estateWall; }
            set
            {
                if (value == _estateWall) return;
                _estateWall = value;
                OnPropertyChanged();
            }
        }

        public string EstateState
        {
            get { return _estateState; }
            set
            {
                if (value == _estateState) return;
                _estateState = value;
                OnPropertyChanged();
            }
        }

        public string EstateOwner
        {
            get { return _estateOwner; }
            set
            {
                if (value == _estateOwner) return;
                _estateOwner = value;
                OnPropertyChanged();
            }
        }

        public double EstateCostOfSale
        {
            get { return _estateCostOfSale; }
            set
            {
                if (value == _estateCostOfSale) return;
                _estateCostOfSale = value;
                OnPropertyChanged();
            }
        }

        public string EstateDescription
        {
            get { return _estateDescription; }
            set
            {
                if (value == _estateDescription) return;
                _estateDescription = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region EstateValidation
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(EstateFunction):
                        _error = ValidateStringValue(EstateFunction);
                        break;
                    case nameof(EstateName):
                        _error = ValidateStringValue(EstateName);
                        break;
                    case nameof(EstateInventoryNumber):
                        _error = ValidateStringValue(EstateInventoryNumber);
                        break;
                    case nameof(EstateSpace):
                        _error = ValidationEstateSpace(EstateSpace);
                        break;
                    case nameof(EstateAdress):
                        _error = ValidateStringValue(EstateAdress);
                        break;
                    case nameof(EstateYear):
                        _error = ValidationEstateYear(EstateYear);
                        break;
                    case nameof(EstateWall):
                        _error = ValidateStringValue(EstateWall);
                        break;
                    case nameof(EstateOwner):
                        _error = ValidateStringValue(EstateOwner);
                        break;
                    case nameof(EstateCostOfSale):
                        break;
                    case nameof(EstateDescription):
                        break;
                }

                return _error;
            }
        }

        private string ValidationEstateSpace(double estateSpace)
        {
            if (estateSpace <= 0)
                return "Недопустимое значение";
            return null;
        }

        private string ValidationEstateYear(int year)
        {
            if (year < 1800 || year > 2017)
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
    }
}
