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
    public partial class SekreterBransPaneli : Form
    {
        public SekreterBransPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void SekreterBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void branskontrol()
        {
            durum = true;

            SqlCommand komut = new SqlCommand("select* from Tbl_Branslar", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {


                if (textBransAd.Text == read["Brans_Ad"].ToString() || string.IsNullOrEmpty(textBransAd.Text.Trim()))
                {
                    durum = false;
                }

            }

        }
        bool durum;

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            branskontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (Brans_Ad) values (@b1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@b1", textBransAd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Brans Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Branş Kayıtlı veya Boş Alan Bırakmayınız!");
            }
            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Branslar where Brans_Id=@b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", textBransId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Branslar set Brans_Ad=@b1 where Brans_Id=@b2", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", textBransAd.Text);
            komut.Parameters.AddWithValue("@b2", textBransId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBransId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
