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
    public partial class Doktor_giris : Form
    {
        public Doktor_giris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void buttonGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktor Where Doktor_TC=@d1 and Doktor_Sifre=@d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", maskedTC.Text);
            komut.Parameters.AddWithValue("@d2", textSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay frm = new DoktorDetay();
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
