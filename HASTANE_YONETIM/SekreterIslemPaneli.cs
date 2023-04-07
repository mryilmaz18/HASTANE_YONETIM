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
    public partial class SekreterIslemPaneli : Form
    {
        public SekreterIslemPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        bool durum;
        private void sekreterkontrol()
        {
            durum = true;

            SqlCommand komut = new SqlCommand("select* from Tbl_Sekreter", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (string.IsNullOrEmpty(textAdSoyad.Text.Trim()))
                {
                    durum = false;
                }
                if (maskedSekreterTC.Text == read["Sekreter_TC"].ToString() || string.IsNullOrEmpty(maskedSekreterTC.Text.Trim()))
                {
                    durum = false;
                }
                if (string.IsNullOrEmpty(textSifre.Text.Trim()))
                {
                    durum = false;
                }


            }

        }
        private void SekreterIslemPaneli_Load(object sender, EventArgs e)
        {

        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            sekreterkontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Sekreter (Sekreter_AdSoyad,Sekreter_TC,Sekreter_Sifre) values (@d1,@d2,@d3)", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", textAdSoyad.Text);
                komut.Parameters.AddWithValue("@d2", maskedSekreterTC.Text);
                komut.Parameters.AddWithValue("@d3", textSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Sekreter Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sekreter Kayıtlı veya Boş Alan Bırakmayınız!");
            }
        }
    }
}
