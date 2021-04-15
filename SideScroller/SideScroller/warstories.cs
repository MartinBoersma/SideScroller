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
    public partial class warstories : Form
    {

        public warstories()
        {
            InitializeComponent();
        }        

        private void loadMenu(object sender, EventArgs e)
        {
            mainMenu mainWindow = new mainMenu();

            mainWindow.Show();
        }                   

        private void loadStory1(object sender, EventArgs e)
        {
            sfStory sfWindow = new sfStory();

            sfWindow.Show();
        }

        private void loadStory2(object sender, EventArgs e)
        {

        }

        private void loadStory3(object sender, EventArgs e)
        {

        }
    }
}
