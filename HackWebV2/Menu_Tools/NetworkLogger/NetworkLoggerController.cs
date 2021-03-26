using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackWebV2.Menu_NetworkLogger
{
    class NetworkLoggerController
    {
        NetworkLoggerForm form;
        public NetworkLoggerController()
        {
            form = new NetworkLoggerForm();
        }

        public void showNetworkLogger()
        {
            form.Show();
        }
    }
}
