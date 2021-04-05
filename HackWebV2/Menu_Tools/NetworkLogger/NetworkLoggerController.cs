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
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            FiddlerApplication.BeforeResponse += FiddlerApplication_BeforeResponse;
        }

        public void showNetworkLogger()
        {
            form.Show();
        }
        private void FiddlerApplication_BeforeRequest(Session oSession)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("REQ: {0}", oSession.url));
        }
        private void FiddlerApplication_BeforeResponse(Session oSession)
        {
            System.Diagnostics.Trace.WriteLine(Encoding.UTF8.GetString(oSession.ResponseBody));
        }
    }
}
