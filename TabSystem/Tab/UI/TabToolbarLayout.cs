using System.Drawing;
using System.Windows.Forms;
using TabSystem.Properties;
using Bunifu.Framework.UI;

namespace TabSystem.Tab.UI
{
    class TabToolbarLayout : TableLayoutPanel
    {
        #region Template
        // -- ToolBarPanel
        // -- PreviousButton
        // -- NextButton
        // -- RefreshButton
        // -- HomeButton
        // -- TextBoxURL
        #endregion

        private ImageButton previousButton { get; set; }
        private ImageButton nextButton { get; set; }
        private ImageButton refreshButton { get; set; }
        private ImageButton homeButton { get; set; }
        private BunifuMetroTextbox textBoxURL { get; set; }

        public TabToolbarLayout()
        {
            this.createUI();
        }

        private void createUI()
        {
            // Main style
            this.BackColor = Color.FromArgb(0, 102, 153);
            this.ColumnCount = 5;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.Dock = DockStyle.Top;
            this.RowCount = 1;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Size = new Size(this.Size.Width, 32);

            this.previousButton = this.createNavigationButtonFromRessource(Resources.PagePrevious);
            this.Controls.Add(this.previousButton, 0, 0);

            this.nextButton = this.createNavigationButtonFromRessource(Resources.PageNext);
            this.Controls.Add(this.nextButton, 1, 0);

            this.refreshButton = this.createNavigationButtonFromRessource(Resources.PageRefresh);
            this.Controls.Add(this.refreshButton, 2, 0);

            this.homeButton = this.createNavigationButtonFromRessource(Resources.PageHome);
            this.Controls.Add(this.homeButton, 3, 0);

            this.textBoxURL = this.createTextBoxURL();
            this.Controls.Add(this.textBoxURL, 4, 0);
        }

        private ImageButton createNavigationButtonFromRessource(Bitmap res)
        {
            ImageButton imageButton = new ImageButton();
            imageButton.Icon = res;
            imageButton.Dock = DockStyle.Fill;
            imageButton.Cursor = Cursors.Hand;
            return imageButton;
        }

        private BunifuMetroTextbox createTextBoxURL()
        {
            BunifuMetroTextbox textBox = new BunifuMetroTextbox();
            textBox.BackColor = Color.FromArgb(20, 122, 173);
            textBox.BorderColorFocused = Color.FromArgb(20, 122, 173);
            textBox.BorderColorIdle = Color.FromArgb(20, 122, 173);
            textBox.BorderColorMouseHover = Color.FromArgb(20, 122, 173);
            textBox.BorderThickness = 1;
            textBox.Dock = DockStyle.Fill;
            textBox.Cursor = Cursors.IBeam;
            textBox.Font = new Font("Tahoma", 11F);
            textBox.ForeColor = Color.White;
            textBox.Margin = new Padding(0);
            textBox.Text = "http://facebook.com (delete)";

            return textBox;
        }
    }
}
