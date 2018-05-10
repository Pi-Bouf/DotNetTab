using DotNetBrowser;
using System.Collections.Generic;
using System.Windows.Forms;
using TabSystem.Tab.UI;
using System.Linq;

namespace TabSystem.Tab
{
    class TabControlSystem
    {
        private TabPane tabPane;
        private TabToolbar tabToolbar;
        private Panel containerForTabSystem;
        private List<Tab> tabList;

        public TabControlSystem(Panel containerForTabSystem)
        {
            this.containerForTabSystem = containerForTabSystem;
            this.tabList = new List<Tab>();
            this.createUI();

            BrowserPreferences.SetChromiumSwitches("--enable-npapi");
        }

        private void createUI()
        {
            this.tabToolbar = new TabToolbar(this);
            this.tabPane = new TabPane(this);
            this.containerForTabSystem.Controls.Add(this.tabPane);
        }

        public TabToolbar getToolbar()
        {
            return this.tabToolbar;
        }

        public void newTabRequest()
        {
            Tab newTab = TabFactory.createNewTab();
            this.addNewTab(newTab);
        }

        public void newTabRequest(string url, string title)
        {
            Tab newTab = TabFactory.createNewTab(url, title);
            this.addNewTab(newTab);
        }

        private void addNewTab(Tab tab)
        {
            tab.getTabCaption().setTabControlSystem(this);
            tabList.Add(tab);
            this.tabPane.addNewTab(tab);
            this.selectTabRequest(tab);
        }

        public void selectTabRequest(Tab tab)
        {
            foreach (Tab t in this.tabList)
            {
                t.getTabContent().Visible = false;
            }

            this.tabToolbar.setCurrentTab(tab);
            tab.getTabContent().Visible = true;
        }

        public void closeTabRequest(Tab tab)
        {
            int index = tabList.IndexOf(tab);
            if(tabList.Count > 1)
            {
                if(tabList.ElementAtOrDefault(index - 1) != null)
                {
                    this.selectTabRequest(tabList.ElementAt(index - 1));
                } else if(tabList.ElementAtOrDefault(index + 1) != null)
                {
                    this.selectTabRequest(tabList.ElementAt(index + 1));
                }
            }

            tabToolbar.disposeTab();
            tab.disposeTab();
            tabList.Remove(tab);
        }

        public void disposeTabControlSystem()
        {
            foreach (Tab t in this.tabList)
            {
                t.disposeTab();
            }
        }
    }
}
