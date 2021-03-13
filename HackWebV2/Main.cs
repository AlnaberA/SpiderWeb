using Fiddler;
using Gecko;
using HackWebV2.HelpMenu;
using HackWebV2.Menu_Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackWebV2
{
    public partial class Main : Form
    {
        private static String cert = "";
        private static String key = "";
        public Main()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            geckoWebBrowser.Navigate("https://www.duckduckgo.com");
            setupProxy();

            testMethod();
        }


        private void urlEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                geckoWebBrowser.Navigate(url.Text);
            }
        }

        private void geckoWebBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            url.Text = geckoWebBrowser.Url.AbsoluteUri;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            geckoWebBrowser.GoBack();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            geckoWebBrowser.GoForward();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutController controller = new AboutController();
            controller.showAboutSection();
        }

        private void getSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSourceController controller = new GetSourceController(geckoWebBrowser);
            controller.showGetSourceDialog();
        }

        private void setupProxy()
        {
            GeckoPreferences.Default["network.proxy.type"] = 1;
            GeckoPreferences.Default["network.proxy.http"] = "127.0.0.1";
            GeckoPreferences.Default["network.proxy.http_port"] = 8764;
            GeckoPreferences.Default["network.proxy.https"] = "127.0.0.1";
            GeckoPreferences.Default["network.proxy.https_port"] = 8764;
            GeckoPreferences.Default["network.proxy.ssl"] = "127.0.0.1";
            GeckoPreferences.Default["network.proxy.ssl_port"] = 8764;

            GeckoPreferences.User["security.enterprise_roots.enabled"] = true;
            GeckoPreferences.User["security.enterprise_roots.auto-enabled"] = true;
        }

        private void testMethod()
        {
            System.Diagnostics.Trace.WriteLine("testing.");
            /*           
             *           
             *          https://stackoverflow.com/questions/17904789/using-fiddler-with-a-c-sharp-application-ipport-proxy
                        https://stackoverflow.com/questions/21029531/listen-to-browsers-requests
                        https://stackoverflow.com/questions/22150216/how-to-check-single-url-webtraffic-in-c-sharp
                        https://stackoverflow.com/questions/19238425/geckofx-22-by-pass-self-sign-cert
                        https://stackoverflow.com/questions/37511187/how-to-fix-gecko-29-0-error-sec-error-unknown-issuer-on-a-website
            */
            /*            geckoWebBrowser.NSSError += (s, e) =>
                        {
                            if (e.Message.Contains("Certificate"))//Peer's Certificate issuer is not recognized.
                                        {
                                CertOverrideService.GetService().RememberValidityOverride(e.Uri, e.Certificate, CertOverride.Mismatch | CertOverride.Time | CertOverride.Untrusted, false);
                                *//*if (!e.Uri.AbsoluteUri.Contains(".js") && !e.Uri.AbsoluteUri.Contains(".css")) geckoWebBrowser.Navigate(e.Uri.AbsoluteUri);*//*
                                e.Handled = true;//otherwise shows error
                                        }
                        };*/

            /*            InstallCertificate();
                        FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.key", key);
                        FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.cert", cert);*/
            Gecko.CertOverrideService.GetService().ValidityOverride += geckoWebBrowser1_ValidityOverride;

            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            FiddlerApplication.Startup(8764, false, true);
        }
        private void geckoWebBrowser1_ValidityOverride(object sender, Gecko.Events.CertOverrideEventArgs e)
        {
            e.OverrideResult = Gecko.CertOverride.Mismatch | Gecko.CertOverride.Time | Gecko.CertOverride.Untrusted;
            e.Temporary = true;
            e.Handled = true;
        }

        private void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("REQ: {0}", oSession.url));
        }

        public void Dispose()
        {
            Fiddler.FiddlerApplication.Shutdown();
        }

        public static bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;

                if (!CertMaker.trustRootCert())
                    return false;

                // persist Fiddlers certificate into app specific config
                cert =
                   FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
                key =
                   FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
            }

            return true;
        }

    }
}
