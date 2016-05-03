using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _tbEquation;
        public string tbEquation
        {
            get
            {
                return _tbEquation;
            }
            set
            {
                _tbEquation = value;
                PropChanged();
            }
        }
        private ICommand _btnCommand;
        public ICommand BtnCommand
        {
            get
            {
                return _btnCommand;
            }
            set
            {
                _btnCommand = value;
            }
        }
        public void appendEquation(object obj)
        {
            tbEquation += obj.ToString();
        }
        public CalculatorViewModel()
        {
            BtnCommand = new DelegateCommand(appendEquation);
        }
    }   
}
