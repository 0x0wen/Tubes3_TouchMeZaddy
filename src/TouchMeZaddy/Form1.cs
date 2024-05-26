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
        private Image imageFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            // clear time and similarity
            executionTime.Text = "???";
            similarityPct.Text = "???";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    // Load the image from the selected file
                    string filePath = openFileDialog1.FileName;
                    Image fingerprintImage = Image.FromFile(filePath);
                    this.imageFile = fingerprintImage;

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
        private void PopulateResultData()
        {
            // Add Labels and TextBoxes
            tableLayoutPanel1.Controls.Add(new Label { Text = "NIK", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label { Text = "John Doe" }, 1, 0);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Name", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 1);
            tableLayoutPanel1.Controls.Add(new Label { Text = new DateTime(1990, 1, 1).ToString("d") }, 1, 1);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Place, Birth Date", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 2);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Jane Doe" }, 1, 2);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Gender", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 3);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 3);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Blood Type", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 4);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 4);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Address", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 5);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 5);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Religion", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 6);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 6);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Marital Status", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 7);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 7);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Occupancy", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 8);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 8);

            tableLayoutPanel1.Controls.Add(new Label { Text = "Nationality", TextAlign = System.Drawing.ContentAlignment.MiddleRight }, 0, 9);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Software Developer" }, 1, 9);



        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            SetSelectedButton(clickedButton);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopulateResultData();
        }

        private void executionTime_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void similarityPct_Click(object sender, EventArgs e)
        {

        }
    }
}
