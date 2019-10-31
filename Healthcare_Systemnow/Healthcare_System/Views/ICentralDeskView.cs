using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface ICentralDeskView
    {
        event EventHandler ViewPatient;//FisrtName, SecondName as a parameters
        event EventHandler SignOut;
        void Show();
    }
}
