using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed
{
    public class ViewModelLocator
    {
        MainViewModel mainViewModel;

        public MainViewModel Main => mainViewModel ?? (mainViewModel = new MainViewModel());
    }
}
