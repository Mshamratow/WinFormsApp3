using System.Text;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<string[]> strings;
        public Form1()
        {
            InitializeComponent();
            strings = new List<string[]>();
            StreamReader f = new StreamReader("../../../info.txt", Encoding.Default);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                string[] parts = s.Split(' ');
                dataGridView1.Rows.Add(parts[0], parts[1], parts[2]);
                strings.Add(new string[2] { parts[0] + ".jpg", parts[3] });
            }
            f.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex;
            int x = e.ColumnIndex;
            if (y < strings.Count && x < 3)
            {
                pictureBox1.Image = new Bitmap("../../../" + strings[y][0]);
                label1.Text = "Тип  "+ strings[y][1];
                label2.Text = "Кличка  " + dataGridView1.Rows[y].Cells[1].Value.ToString();
            }
        }
    }
}
