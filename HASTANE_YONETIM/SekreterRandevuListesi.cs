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
    public partial class SekreterRandevuListesi : Form
    {
        public SekreterRandevuListesi()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void SekreterRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-1E1UBAU\\SQLEXPRESS;Initial Catalog=Hastane_Yonetim_Sistemi;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Randevulistele()
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select *From Table_Randevular", bgl.baglanti());
            sda.Fill(daset, "Table_Randevular");
            dataGridView1.DataSource = daset.Tables["Table_Randevular"];
            bgl.baglanti().Close();

        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.SelectedRows.Count > 0))
            {
                MessageBox.Show("Silmek İstediğiniz Randevuyu Seçiniz");
                return;
            }
            SqlCommand komut = new SqlCommand("Delete From Table_Randevular where Randevu_Id='" + dataGridView1.CurrentRow.Cells["Randevu_Id"].Value.ToString() + "'", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Silindi");
            Randevulistele();
            bgl.baglanti().Close();
        }
    }
}
