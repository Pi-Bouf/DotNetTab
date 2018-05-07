using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TabSystem.Tab;

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
            TabControlSystem tabControlSystem = new TabControlSystem(this.panelTest);
            tabControlSystem.displayUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabControlSystem tabControlSystem = new TabControlSystem(this.panelTest);
            tabControlSystem.displayUI();
        }
    }
}
