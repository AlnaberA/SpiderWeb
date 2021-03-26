using Gecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyManaged;


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

        public void showGetSource()
        {
            form.Show();
        }

        private void setupHTMLView()
        {
            var geckoDomElement = geckoWebBrowser.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                var element = (GeckoHtmlElement)geckoDomElement;
                var outerHtml = element.OuterHtml;

                //Format html
                using (Document htmlDoc = Document.FromString(outerHtml))
                {
                    htmlDoc.ShowWarnings = false;
                    htmlDoc.Quiet = true;
                    htmlDoc.OutputXhtml = true;
                    htmlDoc.CleanAndRepair();
                    string parsed = htmlDoc.Save();
                    form.htmlView.Text = parsed;
                }
            }
        }
    }
}
