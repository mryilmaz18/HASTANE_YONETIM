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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        public string TC_numara;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            labelTC.Text = TC_numara;
            //adsoyad
            SqlCommand komut1 = new SqlCommand("Select Sekreter_AdSoyad From Tbl_Sekreter where Sekreter_TC=@h1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@h1", labelTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                labelAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branslar datagrıdvıewe aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //doktorları datagrıdvıewe aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (Doktor_Ad +' '+ Doktor_Soyad) as 'Doktorlar', Doktor_Brans From Tbl_Doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Bransı Comboboxa aktarma
            SqlCommand komut2 = new SqlCommand("Select Brans_Ad From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Table_Randevular(Randevu_Tarih,Randevu_Saat,Randevu_Brans,Randevu_Doktor)values(@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", maskedTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", maskedSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", comboBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", comboDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Kaydedildi");
        }

        private void buttonDuyuruYayınla_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular(duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", richDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyurunuz Yayınlandı");
        }

        private void buttonDoktorPaneli_Click(object sender, EventArgs e)
        {
            SekreterDoktorPaneli fsdp = new SekreterDoktorPaneli();
            fsdp.Show();
        }

        private void sekreter_islem_Click(object sender, EventArgs e)
        {
            SekreterIslemPaneli fsip = new SekreterIslemPaneli();
            fsip.Show();
        }

        private void buttonBransPaneli_Click(object sender, EventArgs e)
        {
            SekreterBransPaneli fsbp = new SekreterBransPaneli();
            fsbp.Show();
        }

        private void buttonRandevuListesi_Click(object sender, EventArgs e)
        {
            SekreterRandevuListesi fsrs = new SekreterRandevuListesi();
            fsrs.Show();
        }

        private void Duyuru_Listesi_Click(object sender, EventArgs e)
        {
            Duyurular fsrs = new Duyurular();
            fsrs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Girisler frm = new Girisler();
            frm.Show();
            this.Hide();
        }

        private void buttonCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
