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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string TC;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad çekme
            labelTC.Text = TC;
            SqlCommand komut = new SqlCommand("Select Hasta_Ad,Hasta_Soyad From Tbl_Hastalar where Hasta_TC=@h1", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", labelTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular where Hasta_TC=" + TC, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select Brans_Ad From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void comboBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select Doktor_Ad,Doktor_Soyad From Tbl_Doktor where Doktor_Brans=@h1", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", comboBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void comboDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular Where Randevu_Brans='" + comboBrans.Text + "'" + " and Randevu_Doktor='" + comboDoktor.Text + "' and Randevu_Durum=0", bgl.baglanti());
            da.Fill(dt);
            DataAktifRandevular.DataSource = dt;
        }

        private void buttonRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Table_Randevular Set Randevu_Durum=1,Hasta_TC=@h1, Hasta_Sikayet=@h2 Where Randevu_Id=@h3", bgl.baglanti());
            komut1.Parameters.AddWithValue("@h1", labelTC.Text);
            komut1.Parameters.AddWithValue("@h2", richSikayet.Text);
            komut1.Parameters.AddWithValue("@h3", textRandevuId.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Randevuları listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular where Hasta_TC=" + TC, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DataAktifRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = DataAktifRandevular.SelectedCells[0].RowIndex;
            textRandevuId.Text = DataAktifRandevular.Rows[secilen].Cells[0].Value.ToString();
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

        private void linkBilgiGüncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiGuncelleme fr = new HastaBilgiGuncelleme();
            fr.TC_no = labelTC.Text;
            fr.Show();
        }

    }
}
