using Gecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackWebV2.Menu_Tools
{
    class GetSourceController
    {
        private GeckoWebBrowser geckoWebBrowser;
        GetSourceForm form;

        public GetSourceController(GeckoWebBrowser geckoWebBrowser)
        {
            this.geckoWebBrowser = geckoWebBrowser;
            form = new GetSourceForm();
            setupHTMLView();
        }

        public void showGetSourceDialog()
        {
            form.ShowDialog();
        }


        private void setupHTMLView()
        {
            var geckoDomElement = geckoWebBrowser.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                GeckoHtmlElement element = (GeckoHtmlElement)geckoDomElement;
                var outerHtml = element.OuterHtml;
                form.htmlView.Text = outerHtml;
            }
        }
    }
}
