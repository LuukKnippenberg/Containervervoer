using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace Containervervoer
{
    public partial class Form1 : Form
    {
        Ship ship;
        //private List<string[]> tempContainers = new List<string[]>();

        private List<Logic.Container> tempContainers = new List<Logic.Container>();
        public Form1()
        {
            InitializeComponent();
        }

        class ComboItem
        {
            public int ID { get; set; }
            public string Text { get; set; }
        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            bool coolable = false;
            bool valuable = false;
            int weight = Convert.ToInt32(nupWeight.Value);



            if (cbCoolable.Checked)
            {
                coolable = true;
            }
            if (cbValuable.Checked)
            {
                valuable = true;
            }

            for (int i = 0; i < nupAmount.Value; i++)
            {
                Logic.Container tempContainer = new Logic.Container(weight, valuable, coolable);
                lbContainers.Items.Add(tempContainer.ReturnContainerInfoString());
                tempContainers.Add(tempContainer);
            }
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            ship = new Ship(Convert.ToInt32(nupLength.Value), Convert.ToInt32(nupWidth.Value), Convert.ToInt32(nupHeight.Value));

            foreach (var item in tempContainers)
            {
                ship.AddContainerToShip(item);
            }

            lblFeedback.Text = ship.AlgorithmHandler();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbContainers.Items.Clear();
            tempContainers.Clear();
        }
    }
}
