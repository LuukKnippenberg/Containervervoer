using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Containervervoer
{
    public partial class Form1 : Form
    {
        Ship ship;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ship = new Ship(Convert.ToInt32(nupLength.Value), Convert.ToInt32(nupWidth.Value));
            
        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }

        private void nupAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            if(ship != null)
            {
                ship.AddContainerToShip();
            }
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            if (ship != null)
            {
                ship.OpenContainerVisualizer();
            }
        }
    }
}
