using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using RSACriptografic.Classes;

namespace RSACriptografic.ViewModels
{
    class ViewWorker : INotifyPropertyChanged
    {
        static Random random = new Random();
        CriptoWorker first;
        public ViewWorker()
        {
            EncriptMessage = "";
            first = new CriptoWorker(17, random);
            StatusFirst = first.ToString().Replace(" ", Environment.NewLine);
        }

        public string StatusFirst
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string encriptMessage;
        public string EncriptMessage
        {
            get { return encriptMessage; }
            set
            {
                if (value == encriptMessage)
                    return;
                encriptMessage = value;
                OnPropertyChanged("EncriptMessage");
            }
        }
        private string unEncriptMessage;
        public string UnEncriptMessage
        {
            get { return unEncriptMessage; }
            set
            {
                if (value == unEncriptMessage)
                    return;
                unEncriptMessage = value;
                OnPropertyChanged("UnEncriptMessage");
            }
        }
        private string forEncript;
        public string ForEncript
        {
            get { return forEncript; }
            set { forEncript = value; }
        }
        public ICommand EncriptBtnClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (first!=null)
                    {
                        EncriptMessage = $@"{first.Encript(forEncript, first.E, first.N)}";
                    }
                });
            }
        }
        public ICommand UnEncriptBtnClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (first != null)
                    {
                        UnEncriptMessage = $@"{first.ToUnEncript(EncriptMessage)}";
                    }
                });
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
