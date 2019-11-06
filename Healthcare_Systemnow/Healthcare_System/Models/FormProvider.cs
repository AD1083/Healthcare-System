using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class FormProvider
    {
        public static CentralDeskView MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new CentralDeskView();
                }
                return _mainMenu;
            }
        }
        private static CentralDeskView _mainMenu;
    }
}
