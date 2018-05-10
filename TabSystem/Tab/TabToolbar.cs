using DotNetBrowser;
using DotNetBrowser.Events;
using System;
using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabToolbar
    {
        private Tab currentTab = null;
        private TabToolbarLayout tabToolbarLayout = null;
        private TabControlSystem tabControlSystem = null;

        public TabToolbar(TabControlSystem tabControlSystem)
        {
            this.tabControlSystem = tabControlSystem;
            this.tabToolbarLayout = new TabToolbarLayout();
            this.registerEventOnToolbar();
        }

        public TabToolbarLayout GetTabToolbarLayout()
        {
            return this.tabToolbarLayout;
        }

        public void setCurrentTab(Tab tab)
        {
            this.unregisterCurrentEvent();
            this.currentTab = tab;
            this.registerCurrentEvent();
        }

        public void disposeTab()
        {
            this.currentTab = null;
            this.unregisterCurrentEvent();
        }

        #region Toolbar event on browser
        public void registerEventOnToolbar()
        {
            this.tabToolbarLayout.textBoxURL.KeyPress += this.textBoxUrlKeyPress;
            this.tabToolbarLayout.homeButton.Click += this.homeButtonClick;
            this.tabToolbarLayout.refreshButton.Click += this.refreshButtonClick;
            this.tabToolbarLayout.previousButton.Click += this.previousButtonClick;
            this.tabToolbarLayout.nextButton.Click += this.nextButtonClick;
        }

        private void nextButtonClick(object sender, EventArgs e)
        {
            if (this.currentTab != null)
            {
                if (this.currentTab.getBrowserView().Browser.CanGoForward())
                {
                    this.currentTab.getBrowserView().Browser.GoForward();
                }
            }
        }

        private void previousButtonClick(object sender, EventArgs e)
        {
            if (this.currentTab != null)
            {
                if(this.currentTab.getBrowserView().Browser.CanGoBack())
                {
                    this.currentTab.getBrowserView().Browser.GoBack();
                }
            }
        }

        private void refreshButtonClick(object sender, EventArgs e)
        {
            if (this.currentTab != null)
            {
                this.currentTab.getBrowserView().Browser.Reload();
            }
        }

        private void homeButtonClick(object sender, EventArgs e)
        {
            if (this.currentTab != null)
            {
                this.currentTab.changeURL(this.tabToolbarLayout.textBoxURL.Text);
            }
            else
            {
                this.tabControlSystem.newTabRequest("http://google.fr", "Google");
            }
        }

        private void textBoxUrlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {
                if (this.currentTab != null)
                {
                    this.currentTab.changeURL(this.tabToolbarLayout.textBoxURL.Text);
                }
                else
                {
                    this.tabControlSystem.newTabRequest(this.tabToolbarLayout.textBoxURL.Text, this.tabToolbarLayout.textBoxURL.Text);
                }
            }
        }
        #endregion

        #region Browser event on toolbar
        private void registerCurrentEvent()
        {
            Browser browser = this.currentTab.getBrowserView().Browser;
            browser.ProvisionalLoadingFrameEvent += this.UrlChangeEvent;
            this.tabToolbarLayout.textBoxURL.Text = this.currentTab.url;
        }

        private void unregisterCurrentEvent()
        {
            if (this.currentTab != null)
            {
                Browser lastBrowser = this.currentTab.getBrowserView().Browser;
                lastBrowser.ProvisionalLoadingFrameEvent -= this.UrlChangeEvent;
            }
        }

        private void UrlChangeEvent(object sender, ProvisionalLoadingArgs e)
        {
            if (this.currentTab != null)
            {
                this.currentTab.url = e.Url;
                this.tabToolbarLayout.textBoxURL.Invoke((MethodInvoker)(() => this.tabToolbarLayout.textBoxURL.Text = e.Url));
            }
        }
        #endregion
    }
}
