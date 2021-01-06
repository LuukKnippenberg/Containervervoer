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
        private List<string[]> tempContainers = new List<string[]>();
        public Form1()
        {
            InitializeComponent();

            cbType.DataSource = new ComboItem[]
            {
                new ComboItem{ ID = 0, Text = "Normal" },
                new ComboItem{ ID = 0, Text = "Valuable" },
                new ComboItem{ ID = 0, Text = "Cooled" },
                new ComboItem{ ID = 0, Text = "Cooled Valuable" }
            };

        }

        class ComboItem
        {
            public int ID { get; set; }
            public string Text { get; set; }
        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            string comboItem = $"Weigth: {nupWeight.Value.ToString()} Type: {cbType.SelectedIndex} ";
            for (int i = 0; i < nupAmount.Value; i++)
            {
                //ship.AddContainerToShip(Convert.ToInt32(nupWeight.Value), (cbType.SelectedIndex + 1));
                lvContainers.Items.Add(comboItem);
                string[] tempContainer = { nupWeight.Value.ToString(), (cbType.SelectedIndex + 1).ToString() };
                tempContainers.Add(tempContainer);
            }
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            if (ship == null)
            {
                ship = new Ship(Convert.ToInt32(nupLength.Value), Convert.ToInt32(nupWidth.Value));
            }

            foreach (var item in tempContainers)
            {
                ship.AddContainerToShip(Convert.ToInt32(item[0]), Convert.ToInt32(item[1]));
            }

            ship.OpenContainerVisualizer();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tempContainers.Clear();
        }
    }
}
