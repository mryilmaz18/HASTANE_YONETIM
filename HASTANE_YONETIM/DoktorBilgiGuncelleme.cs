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
    public partial class DoktorBilgiGuncelleme : Form
    {
        public DoktorBilgiGuncelleme()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TC;
        private void DoktorBilgiGuncelleme_Load(object sender, EventArgs e)
        {
            maskedTC.Text = TC;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktor where Doktor_TC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", maskedTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textAd.Text = dr[1].ToString();
                textSoyad.Text = dr[2].ToString();
                comboBrans.Text = dr[3].ToString();
                textSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void buttonBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Doktor set Doktor_Ad=@d1,Doktor_Soyad=@d2,Doktor_Brans=@d3,Doktor_Sifre=@d4 where Doktor_TC=@d5", bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", textAd.Text);
            komut2.Parameters.AddWithValue("@d2", textSoyad.Text);
            komut2.Parameters.AddWithValue("@d3", comboBrans.Text);
            komut2.Parameters.AddWithValue("@d4", textSifre.Text);
            komut2.Parameters.AddWithValue("@d5", maskedTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }
    }
}
