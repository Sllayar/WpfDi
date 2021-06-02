using System;
using System.Collections.Generic;
using System.Text;

namespace WpfDi.ViewModel
{
    public class MainWindowVM : ISampleVM
    {
        public string ConectToBd() => "Sucsess";

        public IList<object> GetData() => new List<object>();
    }
}
