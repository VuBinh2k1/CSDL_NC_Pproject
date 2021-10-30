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


namespace CSDLNC
{
    public partial class Form1 : Form
    {
        SqlConnection connect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'qLHoaDonDataSet.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.qLHoaDonDataSet.HoaDon);

            connect = new SqlConnection("Data Source=PHUOCTRAN\\SQLEXPRESS;Initial Catalog=QLHoaDon;Integrated Security=True");
            connect.Open();

            string sqlselect1 = "SELECT TOP 5 MaHD as 'Mã HĐ', MaKH as 'Mã KH', FORMAT(NgayLap, 'dd/MM/yyyy') as 'Ngày Lập', cast(TongTien as decimal(20,0)) as 'Tổng Tiền' FROM HOADON";
            SqlCommand cmd = new SqlCommand(sqlselect1, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.hoaDonTableAdapter.FillBy(this.qLHoaDonDataSet.HoaDon);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.hoaDonTableAdapter.FillBy(this.qLHoaDonDataSet.HoaDon);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.hoaDonTableAdapter.FillBy1(this.qLHoaDonDataSet.HoaDon);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy11ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.hoaDonTableAdapter.FillBy11(this.qLHoaDonDataSet.HoaDon);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
