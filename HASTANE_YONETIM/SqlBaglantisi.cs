using System.Data.SqlClient;

namespace HASTANE_YONETIM
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-1E1UBAU\\SQLEXPRESS;Initial Catalog=Hastane_Yonetim_Sistemi;Integrated Security=True");
            baglan.Open();

            return baglan;
        }
    }
}