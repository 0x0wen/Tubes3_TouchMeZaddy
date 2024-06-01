using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TouchMeZaddy;
    public partial class Form1 : Form
    {
        private Button selectedAlgorithm;
        private String selectedAlgorithmText;   
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
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            pictureBox2.Image = null;
            fingerprintFileName.Text = "";
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
                    fingerprintFileName.Text = openFileDialog1.FileName.Split('\\').Last();
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
            selectedAlgorithmText = button.Text;
            selectedAlgorithm.BackColor = Color.LightBlue; // Or any color you prefer

        
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
    public class BorderedPanel : Panel
    {
        public BorderedPanel()
        {
            // Set background color to Transparent
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw border using ControlPaint
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
    private void PopulateResultData(Result result)
    {
        // Clear existing controls
        tableLayoutPanel1.Controls.Clear();

        // Ensure the TableLayoutPanel will auto-size columns and rows
        tableLayoutPanel1.ColumnStyles.Clear();
        tableLayoutPanel1.RowStyles.Clear();

        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.RowCount = 10;

        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
        {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        // Add Labels with borders
        AddLabelToTable("NIK", result.biodata.NIK, 0);
        AddLabelToTable("Name", result.biodata.nama, 1);
        AddLabelToTable("Place, Birth Date", result.biodata.tempat_lahir + ", " + result.biodata.tanggal_lahir.Split(' ')[0], 2);
        AddLabelToTable("Gender", result.biodata.jenis_kelamin, 3);
        AddLabelToTable("Blood Type", result.biodata.golongan_darah, 4);
        AddLabelToTable("Address", result.biodata.alamat, 5);
        AddLabelToTable("Religion", result.biodata.agama, 6);
        AddLabelToTable("Marital Status", result.biodata.status_perkawinan, 7);
        AddLabelToTable("Occupancy", result.biodata.pekerjaan, 8);
        AddLabelToTable("Nationality", result.biodata.kewarganegaraan, 9);
    }

    private void AddLabelToTable(string labelText, string valueText, int rowIndex)
    {
        // Create custom bordered panels
        var labelPanel = new BorderedPanel { AutoSize = true, Dock = DockStyle.Fill };
        var valuePanel = new BorderedPanel { AutoSize = true, Dock = DockStyle.Fill };

        // Create labels
        var label = new Label
        {
            Text = labelText,
            TextAlign = ContentAlignment.MiddleRight,
            AutoSize = true
        };

        var value = new Label
        {
            Text = valueText,
            AutoSize = true
        };

        // Set the label to be vertically centered
        //var labelContainer = new Panel { Dock = DockStyle.Fill };
        //labelContainer.Controls.Add(label);
        //labelContainer.Padding = new Padding(0, 10, 0, 10);

        // Add labels to panels
        labelPanel.Controls.Add(label);
        valuePanel.Controls.Add(value);

        // Add panels to TableLayoutPanel
        tableLayoutPanel1.Controls.Add(labelPanel, 0, rowIndex);
        tableLayoutPanel1.Controls.Add(valuePanel, 1, rowIndex);

        // Ensure that the labelPanel and valuePanel take up enough space
        tableLayoutPanel1.SetColumn(labelPanel, 0);
        tableLayoutPanel1.SetRow(labelPanel, rowIndex);
        tableLayoutPanel1.SetColumn(valuePanel, 1);
        tableLayoutPanel1.SetRow(valuePanel, rowIndex);
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

        private async void button3_Click(object sender, EventArgs e)
        {
        pictureBox2.Image = global::TouchMeZaddy.Properties.Resources.giphy__1_;
        pictureBox5.Image = global::TouchMeZaddy.Properties.Resources.giphy__1_;

        Result hasil;
            if (this.selectedAlgorithmText == "KMP")
            {
                hasil = await Task.Run(() => MainCalculation.KMPCalculation(new Bitmap(imageFile)));

        }
            else
            {
                hasil = await Task.Run(() => MainCalculation.BMCalculation(new Bitmap(imageFile)));
        }
            pictureBox2.Image = hasil.picture;
            pictureBox5.Image = null;
            pictureBox5.Visible = false;
            hasil.biodata.printData();
            System.Console.WriteLine(hasil.picture);
            System.Console.WriteLine(hasil.similarity);
            System.Console.WriteLine(hasil.executionTime);
            executionTime.Text = hasil.executionTime.ToString() + "s";
            similarityPct.Text = hasil.similarity.ToString() + "%";
            PopulateResultData(hasil);
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

    private void pictureBox5_Click(object sender, EventArgs e)
    {

    }
}
