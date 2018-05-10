using System;
using System.Windows.Forms;
using TabSystem.Tab;
using TabSystem.Tab.UI;

namespace TabSystem
{
    public partial class FormMain : Form
    {
        private TabControlSystem tabControlSystem = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonActivationTabSystem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControlSystem = new TabControlSystem(this.panelTest);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tabControlSystem.disposeTabControlSystem();
        }
    }
}
