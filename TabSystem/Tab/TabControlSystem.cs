using System.Collections.Generic;
using System.Windows.Forms;
using TabSystem.Tab.UI;

namespace TabSystem.Tab
{
    class TabControlSystem
    {
        private TabPane tabPane;
        private Panel containerForTabSystem;
        private List<Tab> tabList;

        public TabControlSystem(Panel containerForTabSystem)
        {
            this.containerForTabSystem = containerForTabSystem;
            this.tabList = new List<Tab>();
            this.createUI();
        }

        private void createUI()
        {
            this.tabPane = new TabPane(this);
            this.tabPane.Visible = false;
            this.containerForTabSystem.Controls.Add(this.tabPane);
        }

        public void displayUI()
        {
            this.tabPane.Visible = true;
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
            this.tabPane.newTab(tab);
            this.selectTabRequest(tab);
        }

        public void selectTabRequest(Tab tab)
        {
            foreach (Tab t in this.tabList)
            {
                t.getTabContent().Visible = false;
            }

            tab.getTabContent().Visible = true;
        }

        public void closeTabRequest(Tab tab)
        {
            tab.disposeTab();
        }
    }
}
