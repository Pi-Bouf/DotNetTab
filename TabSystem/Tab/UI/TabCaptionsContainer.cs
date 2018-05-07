using System;
using System.Drawing;
using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabCaptionsContainer : FlowLayoutPanel
    {
        private TabControlSystem tabControlSystem = null;

        public TabCaptionsContainer(TabControlSystem tabControlSystem)
        {
            this.tabControlSystem = tabControlSystem;
            this.createUI();
        }

        private void createUI()
        {
            // Main style
            this.Dock = DockStyle.Top;
            this.Padding = this.Margin = new Padding(0);
            this.BackColor = Color.FromArgb(0, 23, 38);
            this.createAddTabButtonUI();
        }

        private void createAddTabButtonUI()
        {
            // Add new tab button
            ImageButton imageButton = new ImageButton();
            imageButton.Icon = Properties.Resources.TabAdd;
            imageButton.Location = new System.Drawing.Point(0, 0);
            imageButton.Margin = new Padding(2);
            imageButton.Cursor = Cursors.Hand;
            this.Controls.Add(imageButton);

            // Event on it
            imageButton.Click += new System.EventHandler(this.newTabRequest);
        }

        private void newTabRequest(object sender, EventArgs e)
        {
            this.tabControlSystem.newTabRequest();
        }

        public void newTab(Tab tab)
        {
            this.Controls.Add(tab.getTabCaption());
        }
    }
}
