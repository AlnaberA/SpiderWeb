using Gecko;
using HackWebV2.HelpMenu;
using HackWebV2.Menu_Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackWebV2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
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
    }
}
