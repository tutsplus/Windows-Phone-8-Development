using System.ComponentModel;
using System.Windows.Input;
using App9.Commands;
using App9.Models;

namespace App9.ViewModels
{
    public class InvoiceViewModel : INotifyPropertyChanged {
        private Invoice _invoice;
        public InvoiceViewModel( Invoice invoice ) {
            _invoice = invoice;
            _amount = _invoice.Amount;
            _isPaid = _invoice.IsPaid;

            PayCommand = new PayCommand(() => IsPaid = true, () => !IsPaid);
        }

        public ICommand PayCommand { get; set; }

        private decimal _amount;
        public decimal Amount {
            get { return _amount; }
            set {
                if(_amount == value)
                    return;

                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private bool _isPaid;
        public bool IsPaid {
            get { return _isPaid; }
            set {
                if(_isPaid == value)
                    return;

                _isPaid = value;
                OnPropertyChanged("IsPaid");
            }
        }

        public void Pay( ) {
            _invoice.Pay();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
