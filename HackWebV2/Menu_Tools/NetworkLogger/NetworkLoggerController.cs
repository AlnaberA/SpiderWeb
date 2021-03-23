using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackWebV2.Menu_NetworkLogger
{
    class NetworkLoggerController
    {
        public void showNetworkLoggerSection()
        {
            NetworkLoggerForm networkLoggerForm = new NetworkLoggerForm();
            networkLoggerForm.ShowDialog();
        }
    }
}
