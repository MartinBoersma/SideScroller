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
    public partial class missionwsComplete : Form
    {
        public missionwsComplete()
        {
            InitializeComponent();
        }

        private void loadStories(object sender, EventArgs e) //intel button
        {
            warstories storyWindow = new warstories();

            storyWindow.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //close app
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) //loads the next level
        {
            lvl2 storyWindow = new lvl2();

            storyWindow.Show();

            this.Close();
        }   


        private void missionwsComplete_Load(object sender, EventArgs e)
        {

        }
    }
}
