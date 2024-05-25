using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchMeZaddy
{
    public partial class Form1 : Form
    {
        private Button selectedAlgorithm;
        public Form1()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    // Load the image from the selected file
                    string filePath = openFileDialog1.FileName;
                    Image fingerprintImage = Image.FromFile(filePath);

                    // Display the image in the PictureBox
                    pictureBox1.Image = fingerprintImage;
                    label1.Text = openFileDialog1.FileName.Split('\\').Last();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the image: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            SetSelectedButton(clickedButton);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void SetSelectedButton(Button button)
        {
            if (selectedAlgorithm != null)
            {
                // Reset the previously selected button's color
                selectedAlgorithm.BackColor = SystemColors.Control;
            }

            // Set the new selected button and change its color
            selectedAlgorithm = button;
            selectedAlgorithm.BackColor = Color.LightBlue; // Or any color you prefer

            // Optionally, perform additional actions based on the selected button
            // e.g., Update a variable, enable/disable other UI elements, etc.
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            // Initialize button states
            button1.Click += new EventHandler(this.button1_Click);
            button2.Click += new EventHandler(this.button2_Click);

            // Optionally set an initial selection
            SetSelectedButton(button1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            SetSelectedButton(clickedButton);
        }
    }
}
