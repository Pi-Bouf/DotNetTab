using DotNetBrowser.Events;
using DotNetBrowser.WinForms;
using System.Windows.Forms;
using TabSystem.Tab.UI;

namespace TabSystem.Tab
{
    class Tab
    {
        public string url {get; set;}
        public string title { get; set; }
        private TabCaption tabCaption = null;
        private TabContent tabContent = null;
        private WinFormsBrowserView browserView;
        private TabBrowserEvent tabBrowserEvent = null;

        public Tab(string url, string title)
        {
            this.url = url;
            this.title = title;
            this.createUI();
        }

        #region UI
        private void createUI()
        {
            this.createBrowserView();
            this.buildCaption();
            this.buildContent();
        }
        #endregion

        #region Change Title & URL
        public void changeCaptionTitle(string title)
        {
            this.title = title;
            this.getTabCaption().changeTitle(title);
        }

        public void changeURL(string url)
        {
            this.url = url;
            this.browserView.Browser.Stop();
            this.browserView.Browser.LoadURL(url);
        }
        #endregion

        #region Building main elements
        private void buildCaption()
        {
            this.tabCaption = new TabCaption(this, this.title);
        }

        private void buildContent()
        {
            this.tabContent = new TabContent(this, this.url);
        }

        private void createBrowserView()
        {
            this.browserView = new WinFormsBrowserView();
            this.browserView.Browser.CacheStorage.ClearCache();
            this.browserView.Browser.LoadURL(this.url);
            this.tabBrowserEvent = new TabBrowserEvent(this);

            this.browserView.Browser.TitleChangedEvent += delegate(object sender, TitleEventArgs e)
            {
                this.changeCaptionTitle(e.Title.ToString());
            };
        }
        #endregion

        #region Getter main elements
        public TabCaption getTabCaption()
        {
            return this.tabCaption;
        }

        public TabContent getTabContent()
        {
            return this.tabContent;
        }

        public WinFormsBrowserView getBrowserView()
        {
            return this.browserView;
        }
        #endregion

        public void disposeTab()
        {
            this.tabCaption.disposeTab();
            this.tabContent.disposeTab();
        }
    }
}