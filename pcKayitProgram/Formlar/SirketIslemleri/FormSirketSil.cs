using DevExpress.XtraEditors;
using pcKayitProgram.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcKayitProgram.Formlar
{
    public partial class FormSirketSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int SirketID;

        public FormSirketSil(int SirketID, string SirketAdi, string SirketTel, string SirketAdres)
        {
            InitializeComponent();
            this.SirketID         = SirketID;
            txtID.Text            = SirketID.ToString();
            txtSirketAdi.Text     = SirketAdi;  
            txtSirketTel.Text     = SirketTel;
            memoSirketAdresi.Text = SirketAdres;
        }

        public event EventHandler SirketSilindi;

        private void btnSirketSil_Click(object sender, EventArgs e)
        {
            var sirket = db.SirketTablo.Find(SirketID);
            if (sirket != null)
            {
                var ilgiliPersoneller = db.PersonelTablosu
                    .Where(p => p.SirketID == SirketID)
                    .ToList();
                if (ilgiliPersoneller.Any())
                {
                    XtraMessageBox.Show("Bu şirkete bağlı personeller var. Lütfen önce bu personellerin şirketlerini değiştirin veya silin.",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult sonuc = XtraMessageBox.Show("Şirket silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    db.SirketTablo.Remove(sirket);
                    db.SaveChanges();

                    XtraMessageBox.Show("Şirket başarılı bir şekilde silindi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    SirketSilindi?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }


        private void btnSirketİptal_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = XtraMessageBox.Show("İşlem iptal edilsin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.No)
            {
                return;
            }
            Close();
        }
    }
}