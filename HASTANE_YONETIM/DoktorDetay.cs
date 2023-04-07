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

namespace HASTANE_YONETIM
{
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        public string TC;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            labelTC.Text = TC;
            SqlCommand komut = new SqlCommand("Select Doktor_Ad,Doktor_Soyad From Tbl_Doktor where Doktor_TC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", labelTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular where Randevu_Doktor='" + labelAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            DoktorBilgiGuncelleme frm = new DoktorBilgiGuncelleme();
            frm.TC = labelTC.Text;
            frm.Show();
        }

        private void buttonDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular frm = new Duyurular();
            frm.Show();
        }

        private void buttonCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Girisler frm = new Girisler();
            frm.Show();
            this.Hide();
        }

    }
}
