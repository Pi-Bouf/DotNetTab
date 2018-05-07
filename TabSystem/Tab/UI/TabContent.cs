using DotNetBrowser.Events;
using DotNetBrowser.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TabSystem.Tab.UI
{
    class TabContent : TableLayoutPanel
    {
        private string url;
        private Tab tab = null;
        private TextBox textBoxURL = null;
        private Panel containerForBrowserView = null;
        private WinFormsBrowserView browserView;


        public TabContent(Tab tab, string url)
        {
            this.tab = tab;
            this.url = url;
            this.createUI();
            this.createBrowserUI();
        }

        private void createUI()
        {
            // Main style
            this.Dock = DockStyle.Fill;
            this.Padding = this.Margin = new Padding(0);
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));

            FlowLayoutPanel containerForTextBox = new FlowLayoutPanel();
            containerForTextBox.Padding = new Padding(5, 6, 5, 0);
            containerForTextBox.Margin = new Padding(0);
            containerForTextBox.BackColor = Color.FromArgb(0, 102, 153);
            containerForTextBox.Dock = DockStyle.Top;

            // URL textbox
            this.textBoxURL = new TextBox();
            this.textBoxURL.Dock = DockStyle.Fill;
            this.textBoxURL.Padding = new Padding(3);
            this.textBoxURL.Margin = new Padding(0);
            this.textBoxURL.BorderStyle = BorderStyle.None;
            this.textBoxURL.ForeColor = Color.White;
            this.textBoxURL.BackColor = Color.FromArgb(0, 102, 153);
            this.textBoxURL.Text = this.url;
            this.textBoxURL.Size = new System.Drawing.Size(215, 20);
            this.textBoxURL.KeyDown += new KeyEventHandler(this.keyDownTextBoxURL);
            containerForTextBox.Controls.Add(this.textBoxURL);

            this.containerForBrowserView = new Panel();
            this.containerForBrowserView.Padding = this.containerForBrowserView.Margin = new Padding(0);
            this.containerForBrowserView.Dock = DockStyle.Fill;

            this.Controls.Add(containerForTextBox, 0, 0);
            this.Controls.Add(containerForBrowserView, 0, 1);
        }

        private void createBrowserUI()
        {
            this.browserView = new WinFormsBrowserView();
            this.browserView.Browser.CacheStorage.ClearCache();
            this.browserView.Browser.LoadURL(this.url);
            this.containerForBrowserView.Controls.Add((Control)this.browserView.GetComponent());
            this.browserView.Browser.TitleChangedEvent += delegate (object sender, TitleEventArgs e)
            {
                this.tab.changeCaptionTitle(e.Title.ToString());
            };
            this.browserView.Browser.ProvisionalLoadingFrameEvent += delegate (object sender, ProvisionalLoadingArgs e)
            {
                this.textBoxURL.Invoke((MethodInvoker)(() => this.textBoxURL.Text = e.Url));
            };
        }

        private void keyDownTextBoxURL(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.changeBrowserURL(this.textBoxURL.Text);
            }
        }

        private void changeBrowserURL(string url)
        {
            this.browserView.Browser.LoadURL(url);
            this.tab.changeCaptionTitle(url);
        }

        public void disposeTab()
        {
            this.browserView.Browser.Dispose();
            this.Dispose();
        }

        private string uniqText(int nbChar)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[nbChar];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
