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
    public partial class HastaBilgiGuncelleme : Form
    {
        public HastaBilgiGuncelleme()
        {
            InitializeComponent();
        }
        public string TC_no;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void HastaBilgiGuncelleme_Load(object sender, EventArgs e)
        {
            maskedTC.Text = TC_no;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where Hasta_TC=@h1", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", maskedTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textAd.Text = dr[1].ToString();
                textSoyad.Text = dr[2].ToString();
                maskedTel.Text = dr[4].ToString();
                textSifre.Text = dr[5].ToString();
                comboCinsiyet.Text = dr[6].ToString();
            }
        }

        private void buttonBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set Hasta_Ad=@h1,Hasta_Soyad=@h2,Hasta_Telefon=@h3,Hasta_Sifre=@h4,Hasta_Cinsiyet=@h5 where Hasta_TC=@h6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@h1", textAd.Text);
            komut2.Parameters.AddWithValue("@h2", textSoyad.Text);
            komut2.Parameters.AddWithValue("@h3", maskedTel.Text);
            komut2.Parameters.AddWithValue("@h4", textSifre.Text);
            komut2.Parameters.AddWithValue("@h5", comboCinsiyet.Text);
            komut2.Parameters.AddWithValue("@h6", maskedTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }
    }
}
