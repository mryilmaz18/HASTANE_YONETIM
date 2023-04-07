using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASTANE_YONETIM
{
    public partial class Girisler : Form
    {
        public Girisler()
        {
            InitializeComponent();
        }

        private void buttonDoktorGirisi_Click(object sender, EventArgs e)
        {
            Doktor_giris fr = new Doktor_giris();
            fr.Show();
            this.Hide();
        }

        private void buttonHastaGirisi_Click(object sender, EventArgs e)
        {
            HastaGiris fr = new HastaGiris();
            fr.Show();
            this.Hide();
        }

        private void buttonSekreterGirisi_Click(object sender, EventArgs e)
        {
            SekreterGiris fr = new SekreterGiris();
            fr.Show();
            this.Hide();
        }
    }
}
