using System;
using System.Drawing;
using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabCaption : FlowLayoutPanel
    {
        private TabControlSystem tabControlSystem = null;
        private string title = null;
        private FlowLayoutPanel componentLayout = null;
        private Label label = null;
        private ImageButton imageButton = null;
        private Tab tab = null;
        private int textTabLimit = 22;

        public TabCaption(Tab tab, string title)
        {
            this.tab = tab;
            this.title = title;
            this.createUI();
        }

        public void createUI()
        {
            // Main style
            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.Padding = new Padding(0);
            this.Margin = new Padding(2); // new Padding(2, 5, 0, 0);
            this.BackColor = Color.FromArgb(0, 102, 153);
            this.createComponentUI();
        }

        public void setTabControlSystem(TabControlSystem tabControlSystem)
        {
            this.tabControlSystem = tabControlSystem;
        }

        public void createComponentUI()
        {
            // Main style
            this.componentLayout = new FlowLayoutPanel();
            this.componentLayout.Dock = DockStyle.Top;
            this.componentLayout.AutoSize = true;
            this.componentLayout.Padding = new Padding(0);
            this.componentLayout.Margin = new Padding(0);

            // Label
            this.label = new Label();
            this.label.Text = this.title;
            this.label.ForeColor = Color.FromArgb(230, 240, 245);
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Size = new System.Drawing.Size(140, 20);
            this.label.Font = new Font(new System.Drawing.FontFamily("Tahoma"), 8);
            this.label.Cursor = Cursors.Hand;
            this.label.Click += new System.EventHandler(this.selectTabRequest);

            // Close button
            this.imageButton = new ImageButton();
            this.imageButton.Icon = Properties.Resources.TabClose;
            this.imageButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.imageButton.Location = new System.Drawing.Point(0, 0);
            this.imageButton.Cursor = Cursors.Hand;
            // Add event on it
            this.imageButton.Click += new System.EventHandler(this.closeTabRequest);

            // Adding element to template
            this.componentLayout.Controls.Add(label);
            this.componentLayout.Controls.Add(imageButton);
            this.Controls.Add(this.componentLayout);
        }

        public void changeTitle(string title)
        {
            if(title.Length > this.textTabLimit)
            {
                title = title.Substring(0, this.textTabLimit) + "...";
            }

            this.label.Invoke((MethodInvoker)(() => this.label.Text = title));
        }

        private void selectTabRequest(object sender, EventArgs e)
        {
            this.tabControlSystem.selectTabRequest(this.tab);
        }

        private void closeTabRequest(object sender, EventArgs e)
        {
            this.tabControlSystem.closeTabRequest(this.tab);
        }

        public void disposeTab()
        {
            this.Dispose();
        }
    }
}
