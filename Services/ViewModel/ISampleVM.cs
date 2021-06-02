using System;
using System.Collections.Generic;
using System.Text;

namespace WpfDi.ViewModel
{
    public interface ISampleVM
    {
        string ConectToBd();

        IList<object> GetData();
    }
}
