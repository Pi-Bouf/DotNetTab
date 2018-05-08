using System;
using System.Windows.Forms;
using TabSystem.Tab.UI;

namespace TabSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonActivationTabSystem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabToolbarLayout toolbar = new TabToolbarLayout();

            this.panelForTest.Controls.Add(toolbar);

            /*
            TabControlSystem tabControlSystem = new TabControlSystem(this.panelTest);
            tabControlSystem.displayUI();
            */
        }
    }
}
