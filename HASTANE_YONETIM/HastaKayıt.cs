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
    public partial class HastaKayıt : Form
    {
        public HastaKayıt()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        bool durum;
        private void hastakontrol()
        {
            durum = true;

            SqlCommand komut = new SqlCommand("select* from Tbl_Hastalar", bgl.baglanti());
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
                if (maskedTC.Text == read["Hasta_TC"].ToString() || string.IsNullOrEmpty(maskedTC.Text.Trim()))
                {
                    durum = false;
                }
                if (maskedTel.Text == read["Hasta_Telefon"].ToString() || string.IsNullOrEmpty(maskedTel.Text.Trim()))
                {
                    durum = false;
                }
                if (string.IsNullOrEmpty(textSifre.Text.Trim()))
                {
                    durum = false;
                }

                if (string.IsNullOrEmpty(comboCinsiyet.Text.Trim()))
                {
                    durum = false;
                }

            }

        }

        private void buttonKayıt_Click(object sender, EventArgs e)
        {
            hastakontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (Hasta_Ad,Hasta_Soyad,Hasta_TC,Hasta_Telefon,Hasta_Sifre,Hasta_Cinsiyet) values (@h1,@h2,@h3,@h4,@h5,@h6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@h1", textAd.Text);
                komut.Parameters.AddWithValue("@h2", textSoyad.Text);
                komut.Parameters.AddWithValue("@h3", maskedTC.Text);
                komut.Parameters.AddWithValue("@h4", maskedTel.Text);
                komut.Parameters.AddWithValue("@h5", textSifre.Text);
                komut.Parameters.AddWithValue("@h6", comboCinsiyet.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kaydınız gerçekleşti şifreniz:" + textSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HastaGiris kg = new HastaGiris();
                kg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hasta Kayıtlı veya Boş Alan Bırakmayınız!");
            }
        }

    }
}
