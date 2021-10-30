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
    public partial class Form2 : Form
    {
        SqlConnection connect;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection("Data Source=PHUOCTRAN\\SQLEXPRESS;Initial Catalog=QLHoaDon;Integrated Security=True");
            connect.Open();
            int check = 0;
            string sqlselect = "INSERT INTO HOADON(MaHD, MaKH, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @NgLap, @TT)";
            SqlCommand cmd = new SqlCommand(sqlselect, connect);

            string[] date = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd").Split('/');
            int year = Int32.Parse(date[0]);
            int month = Int32.Parse(date[1]);
            if ((year == 2020 && month >= 5 && month <= 12) || (year == 2021 && month >= 1 && month <= 6))
            {
                check++;
            } else
            {
                MessageBox.Show("Hóa đơn phải được lập từ 5/2020 đến 6/2021");
            }

            if (textBox2.Text == "") {
                MessageBox.Show("HÃY NHẬP MÃ KHÁCH HÀNG");
            } else
            {
                check++;
            }

            if(check == 2)
            {
                cmd.Parameters.Add(new SqlParameter("@MaHD", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@MaKH", textBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@TT", textBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@NgLap", dateTimePicker1.Value.Date));
                cmd.ExecuteNonQuery();
            }
            string sqlselect2 = "SELECT * FROM HoaDon WHERE MaHD not in (SELECT TOP ((SELECT COUNT(*) from HoaDon) - 5) MaHD FROM HoaDon)";
            SqlCommand cmd2 = new SqlCommand(sqlselect2, connect);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView1.DataSource = dt2;
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
