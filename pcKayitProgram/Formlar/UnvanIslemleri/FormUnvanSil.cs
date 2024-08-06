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
    public partial class FormUnvanSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int UnvanID;

        public FormUnvanSil(int UnvanID, string UnvanAdi)
        {
            InitializeComponent();
            this.UnvanID     = UnvanID;
            txtUnvanID.Text  = UnvanID.ToString();
            txtUnvanAdi.Text = UnvanAdi;
        }

        public event EventHandler UnvanSilindi;

        private void btnUnvanSil_Click(object sender, EventArgs e)
        {
            var unvan = db.UnvanTablo.Find(UnvanID);
            if (unvan != null)
            {
                var ilgiliPersoneller = db.PersonelTablosu
                    .Where(p => p.UnvanID == UnvanID)
                    .ToList();
                if (ilgiliPersoneller.Any())
                {
                    XtraMessageBox.Show("Bu ünvana bağlı personeller var. Lütfen önce bu personellerin ünvanlarını değiştirin veya silin.",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult sonuc = XtraMessageBox.Show("Ünvan silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    db.UnvanTablo.Remove(unvan);
                    db.SaveChanges();

                    XtraMessageBox.Show("Ünvan başarılı bir şekilde silindi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    UnvanSilindi?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnUnvanİptal_Click(object sender, EventArgs e)
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