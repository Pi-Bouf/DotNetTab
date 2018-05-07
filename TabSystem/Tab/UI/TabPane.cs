using System.Drawing;
using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabPane : TableLayoutPanel
    {
        private TabControlSystem tabControlSystem = null;
        private TabCaptionsContainer tabCaptionsContainer = null;
        private TableLayoutPanel tabContentContainer = null;

        public TabPane(TabControlSystem tabSystem)
        {
            this.tabControlSystem = tabSystem;
            this.createUI();
        }

        private void createUI()
        {
            // Main style
            this.ColumnCount = 1;
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Padding = this.Margin = new Padding(0);

            // Border bottom
            FlowLayoutPanel borderBottom = new FlowLayoutPanel();
            borderBottom.Padding = borderBottom.Margin = new Padding(0);
            borderBottom.BackColor = Color.FromArgb(58, 153, 238);
            borderBottom.Dock = DockStyle.Fill;
            borderBottom.Size = new Size(0, 2);

            // Tab content container
            this.tabContentContainer = new TableLayoutPanel();
            this.tabContentContainer.Dock = DockStyle.Fill;
            this.tabContentContainer.Padding = this.tabContentContainer.Margin = new Padding(0);

            // Add captions & content panel
            this.tabCaptionsContainer = new TabCaptionsContainer(this.tabControlSystem);
            this.Controls.Add(this.tabCaptionsContainer, 0, 0);
            this.Controls.Add(borderBottom, 0, 1);
            this.Controls.Add(this.tabContentContainer, 0, 2);
        }

        public void newTab(Tab tab)
        {
            this.tabCaptionsContainer.newTab(tab);
            this.tabContentContainer.Controls.Add(tab.getTabContent(), 0, 2);
        }
    }
}
