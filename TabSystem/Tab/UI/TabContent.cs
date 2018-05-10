using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabContent : TableLayoutPanel
    {
        private Tab tab = null;

        public TabContent(Tab tab, string url)
        {
            this.tab = tab;
            this.createUI();
        }

        private void createUI()
        {
            // Main style
            this.Dock = DockStyle.Fill;
            this.Padding = this.Margin = new Padding(0);
            this.RowCount = 1;
            this.ColumnCount = 1;

            // Add browser to it !
            this.tab.getBrowserView().Margin = this.tab.getBrowserView().Padding = new Padding(0);
            this.Controls.Add((Control)this.tab.getBrowserView().GetComponent(), 0, 0);
        }

        public void disposeTab()
        {
            this.Dispose();
        }
    }
}
