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
    public partial class Food : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-476EKAJ;Initial Catalog=Food;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public Food()
        {
            InitializeComponent();
            DisplayData();

        }

        private void Food_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet1.FoodInfo' table. You can move, or remove it, as needed.
            //this.foodInfoTableAdapter.Fill(this.foodDataSet1.FoodInfo);

        }

        private void DisplayData()
        {

            con.Open();
            adapt = new SqlDataAdapter("select * from FoodInfo", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            //dataGridView1.DataSource = dt;
            GrdFood.DataSource = dt;
            con.Close();
        }
        private void ClearData()
        {
            TxtID.Text = "";
            TxtName.Text = "";
            TxtIgr.Text = "";
            TxtMethod.Text = "";
            TxtLoc.Text = "";
            MealPic.Image = null;
        }

        public void insert(byte[] image)
        {
            cmd = new SqlCommand("insert into FoodInfo(MealName,MealIngredients,Method,location,photo)values(@MealName,@MealIngredients,@Method,@location,@photo )", con);
            con.Open();
            // cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@MealName", TxtName.Text);
            cmd.Parameters.AddWithValue("@MealIngredients", TxtIgr.Text);
            cmd.Parameters.AddWithValue("@Method", TxtMethod.Text);
            cmd.Parameters.AddWithValue("@location", TxtLoc.Text);
            cmd.Parameters.AddWithValue("@photo", image);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Meal information entered Successfully");
            DisplayData();
            ClearData();
        }
        public void UpdateRec(byte[] image)
        {
            cmd = new SqlCommand("update FoodInfo set MealName=@MealName,MealIngredients=@MealIngredients,Method=@Method,location=@location,photo=@photo  where MealID=@MealID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@MealID", TxtID.Text);
            cmd.Parameters.AddWithValue("@MealName", TxtName.Text);
            cmd.Parameters.AddWithValue("@MealIngredients", TxtIgr.Text);
            cmd.Parameters.AddWithValue("@Method", TxtMethod.Text);
            cmd.Parameters.AddWithValue("@location", TxtLoc.Text);
            cmd.Parameters.AddWithValue("@photo", image);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Meal information Updated Successfully");
            con.Close();
            ClearData();
        }
        byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void toolStripUpdate_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "" && TxtName.Text != "" && TxtIgr.Text != "" && TxtLoc.Text != ""  )
            {
                UpdateRec(ConvertImageToByte(MealPic.Image));
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                cmd = new SqlCommand("delete FoodInfo where MealID=@MealID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@MealID", TxtID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Meal Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Images(.jpg,.png,.gif,.bmp)|*.png;*.jpg;*.gif;*.bmp";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    MealPic.Image = Image.FromFile(openFileDialog1.FileName);
                TxtLoc.Text = openFileDialog1.FileName;
                DisplayData();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose photo!");
            }
        }

        private void toDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TxtName.Text != "" && TxtLoc.Text != "")
            {
                insert(ConvertImageToByte(MealPic.Image));
            }
            else
            {
                MessageBox.Show("Please fill data correctly!");
            }
        }

        private void toFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "all files(*.*)|*.*|Text Files(*.txt)|*.txt|Word File(*.doc)|*.doc |Images(*.bmp)|*.bmp|jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|tiff (*.tiff)|*.tiff";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine(TxtID.Text);
                    sw.WriteLine(TxtName.Text);
                    sw.WriteLine(TxtIgr.Text);
                    sw.WriteLine(TxtMethod.Text);
                    sw.WriteLine(TxtLoc.Text);
                }
            }
            MessageBox.Show("Text saved in File successfully");
        }

        private void openFileOnTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TextFile(*.txt)|*.txt";
            openFileDialog1.DefaultExt = ".txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtName.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }
        private void OpenPhoto_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string h = "";
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            h = TxtIgr.Text;
            TxtIgr.Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                TxtIgr.Text = h;
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtIgr.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            TxtIgr.Copy();            
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtIgr.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtIgr.SelectAll();
        }
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply = true;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtIgr.SelectionFont = fontDialog1.Font;
            }
        }
        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtIgr.SelectionColor = colorDialog1.Color;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 h = new Form2();
            //h.Show();
            //Visible = false;
        }

        private void GrdFood_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtID.Text = GrdFood.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = GrdFood.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtIgr.Text = GrdFood.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtMethod.Text = GrdFood.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtLoc.Text = GrdFood.Rows[e.RowIndex].Cells[4].Value.ToString();
            MealPic.Image = ConvertByteArrayToImage((byte[])GrdFood.Rows[e.RowIndex].Cells[5].Value);

        }

        private void searchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToSearch S = new ToSearch();
            S.Show();
            Visible = false;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Welcom w = new Welcom();
            w.Show();
            Visible = false;

        }
    }
}
