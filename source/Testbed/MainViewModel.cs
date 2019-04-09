using Ratcow.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Testbed
{
    public class MainViewModel: ViewModelBase
    {
        string value;
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                RaisePropertyChanged();
            }
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            Value = "99";
        }

        public void OnClosed(object sender)
        {
      
        }
    }
}
