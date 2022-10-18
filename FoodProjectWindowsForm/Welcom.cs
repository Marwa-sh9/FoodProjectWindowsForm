using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodProjectWindowsForm
{
    public partial class Welcom : Form
    {
        public Welcom()
        {
            InitializeComponent();
        }

        private void Enter_MouseHover(object sender, EventArgs e)
        {

        }
        private void Enter_Click(object sender, EventArgs e)
        {
            Food f = new Food();
            f.Show();
            Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
