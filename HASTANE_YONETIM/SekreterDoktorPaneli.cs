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
    public partial class SekreterDoktorPaneli : Form
    {
        public SekreterDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void SekreterDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //brans comboboxa ekleme
            SqlCommand komut2 = new SqlCommand("Select Brans_Ad From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
        bool durum;
        private void doktorkontrol()
        {
            durum = true;

            SqlCommand komut = new SqlCommand("select* from Tbl_Doktor", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (string.IsNullOrEmpty(textAd.Text.Trim()))
                {
                    durum = false;
                }
                if (string.IsNullOrEmpty(textSoyad.Text.Trim()))
                {
                    durum = false;
                }
                if (string.IsNullOrEmpty(comboBrans.Text.Trim()))
                {
                    durum = false;
                }
                if (maskedDoktorTC.Text == read["Doktor_TC"].ToString() || string.IsNullOrEmpty(maskedDoktorTC.Text.Trim()))
                {
                    durum = false;
                }
                if (string.IsNullOrEmpty(textSifre.Text.Trim()))
                {
                    durum = false;
                }

            }

        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            doktorkontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Doktor (Doktor_Ad,Doktor_Soyad,Doktor_Brans,Doktor_TC,Doktor_Sifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", textAd.Text);
                komut.Parameters.AddWithValue("@d2", textSoyad.Text);
                komut.Parameters.AddWithValue("@d3", comboBrans.Text);
                komut.Parameters.AddWithValue("@d4", maskedDoktorTC.Text);
                komut.Parameters.AddWithValue("@d5", textSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Doktor Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Doktor Kayıtlı veya Boş Alan Bırakmayınız!");
            }

            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Doktor where Doktor_TC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", maskedDoktorTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktor set Doktor_Ad=@d1,Doktor_Soyad=@d2,Doktor_Brans=@d3,Doktor_Sifre=@d5 where Doktor_TC=@d4", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", textAd.Text);
            komut.Parameters.AddWithValue("@d2", textSoyad.Text);
            komut.Parameters.AddWithValue("@d3", comboBrans.Text);
            komut.Parameters.AddWithValue("@d4", maskedDoktorTC.Text);
            komut.Parameters.AddWithValue("@d5", textSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedDoktorTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textSifre.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
