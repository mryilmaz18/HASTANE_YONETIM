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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void linkKayıt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıt fr = new HastaKayıt();
            fr.Show();
            this.Hide();
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where Hasta_TC=@h1 and Hasta_Sifre=@h2", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", maskedTC.Text);
            komut.Parameters.AddWithValue("@h2", textSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                HastaDetay frm = new HastaDetay();
                frm.TC = maskedTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
            bgl.baglanti().Close();
        }
    }
}
