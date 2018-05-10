using DotNetBrowser;
using DotNetBrowser.Events;

namespace TabSystem.Tab.UI
{
    class TabBrowserEvent
    {
        private Tab tab;

        public TabBrowserEvent(Tab tab)
        {
            this.tab = tab;
        }

        private Browser getBrowser()
        {
            return this.tab.getBrowserView().Browser;
        }

        private void registerAllEvents()
        {
            this.getBrowser().TitleChangedEvent += this.TitleChangedEvent;
            //this.getBrowser().ProvisionalLoadingFrameEvent += this.ProvisionalLoadingFrameEvent;
        }

        private void TitleChangedEvent(object sender, TitleEventArgs e)
        {
            this.tab.changeCaptionTitle(e.Title.ToString());
        }

        private void ProvisionalLoadingFrameEvent(object sender, ProvisionalLoadingArgs e)
        {
            //this.tab.changeTextboxURL(e.Url);
        }
    }
}
