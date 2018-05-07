using System.Windows.Forms;
using TabSystem.Tab.UI;

namespace TabSystem.Tab
{
    class Tab
    {
        private string url = null;
        private string title = null;
        private TabCaption tabCaption = null;
        private TabContent tabContent = null;

        public Tab(string url, string title)
        {
            this.url = url;
            this.title = title;
            this.createUI();
        }

        private void createUI()
        {
            this.buildCaption();
            this.buildContent();
        }

        public void changeCaptionTitle(string title)
        {
            this.getTabCaption().changeTitle(title);
        }

        public void disposeTab()
        {
            this.tabCaption.disposeTab();
            this.tabContent.disposeTab();
        }

        private void buildCaption()
        {
            this.tabCaption = new TabCaption(this, this.title);
        }

        private void buildContent()
        {
            this.tabContent = new TabContent(this, this.url);
        }

        public TabCaption getTabCaption()
        {
            return this.tabCaption;
        }

        public TabContent getTabContent()
        {
            return this.tabContent;
        }
    }
}
