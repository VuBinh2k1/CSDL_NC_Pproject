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
    public partial class Form3 : Form
    {
        SqlConnection connect;
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection("Data Source=HGGQUAN\\SQLEXPRESS05;Initial Catalog=QLHoaDon;Integrated Security=True");
            connect.Open();

            string sqlselect = "SELECT CAST(SUM(TongTien) AS DECIMAL(20,0)) FROM HoaDon where MONTH(NgayLap) = MONTH(@NgLap) AND YEAR(NgayLap) = YEAR(@NgLap)";
            SqlCommand cmd = new SqlCommand(sqlselect, connect);
            cmd.Parameters.Add(new SqlParameter("@NgLap", dateTimePicker1.Value.Date));
            cmd.ExecuteNonQuery();

            try
            {
                textBox2.Text = Convert.ToString(cmd.ExecuteScalar()) + " đồng";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            string sqlselect2 = "SELECT TOP 10 * FROM HoaDon WHERE MONTH(NgayLap) = MONTH(@NgLap) AND YEAR(NgayLap) = YEAR(@NgLap)";
            SqlCommand cmd2 = new SqlCommand(sqlselect2, connect);
            cmd2.Parameters.Add(new SqlParameter("@NgLap", dateTimePicker1.Value.Date));
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView1.DataSource = dt2;
            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
