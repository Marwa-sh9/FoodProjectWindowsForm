using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace FoodProjectWindowsForm
{
    public partial class ToSearch : Form
    {
        public ToSearch()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-476EKAJ;Initial Catalog=Food;Integrated Security=True");
        //SqlCommand cmd;
        SqlDataAdapter adapt;
        private void ToSearch_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'foodDataSet.FoodInfo' table. You can move, or remove it, as needed.
            //this.foodInfoTableAdapter.Fill(this.foodDataSet.FoodInfo);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "" || TxtName.Text!="" )
            {
                con.Open();
                adapt = new SqlDataAdapter("select * from FoodInfo where (MealID like '" + TxtID.Text+ "%' " +
                    " and MealName like '" + TxtName.Text+"%' )", con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                GrdMealSearch.DataSource = dt;
                con.Close();
            }
            else
            {
                MessageBox.Show("Please Enter ID or Name to Search");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Food f = new Food();
            f.Show();
            Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ClearData()
        {
            TxtID.Text = "";
            TxtName.Text = "";
            TxtMethod.Text = "";
            TxtIgr.Text = "";
            TxtLoc.Text = "";
            MealPic.Image = null;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images(.jpg,.png,.gif,.bmp)|*.png;*.jpg;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                    MealPic.Image = Image.FromFile(ofd.FileName);
                TxtLoc.Text = ofd.FileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Choose photo!");
            }
        }

        private void SavePicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Save_To_Device_Click(object sender, EventArgs e)
        {
          
        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void GrdMealSearch_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtID.Text = GrdMealSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = GrdMealSearch.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtIgr.Text = GrdMealSearch.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtMethod.Text = GrdMealSearch.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtLoc.Text = GrdMealSearch.Rows[e.RowIndex].Cells[4].Value.ToString();
            MealPic.Image = ConvertByteArrayToImage((byte[])GrdMealSearch.Rows[e.RowIndex].Cells[5].Value);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
