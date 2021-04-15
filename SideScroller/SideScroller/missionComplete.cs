using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideScroller
{
    public partial class missionComplete : Form
    {
        public missionComplete()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadGame(object sender, EventArgs e)
        {
           lvl2_H storyWindow = new lvl2_H(); //this loads the version of level 2 that has NOT collected the intel and the H stands for HARD, because the level adds an enemy

           storyWindow.Show();

           this.Close();
            
        }

        private void exitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadStories(object sender, EventArgs e)
        {
            warstories storyWindow = new warstories();

            storyWindow.Show();
        }

        private void missionComplete_Load(object sender, EventArgs e)
        {

        }
    }
}
