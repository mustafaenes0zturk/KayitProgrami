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
    public partial class FormSirketGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int SirketID;

        public FormSirketGuncelle(int SirketID, string SirketAdi, string SirketTel, string SirketAdres)
        {
            InitializeComponent();
            this.SirketID         = SirketID;
            txtID.Text            = SirketID.ToString();
            txtSirketAdi.Text     = SirketAdi;
            txtSirketTel.Text     = SirketTel;
            memoSirketAdresi.Text = SirketAdres;
        }

        public event EventHandler SirketGuncellendi;

        private void btnSirketGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSirketAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSirketTel.Text) ||
                string.IsNullOrWhiteSpace(memoSirketAdresi.Text))
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutSirket = db.SirketTablo
                .FirstOrDefault(s => s.SirketAdi == txtSirketAdi.Text && s.SirketID != SirketID);

            if (mevcutSirket != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir şirket zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Şirket güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var sirket = db.SirketTablo.Find(SirketID);
                if (sirket != null)
                {
                    sirket.SirketAdi   = txtSirketAdi.Text;
                    sirket.SirketTel   = txtSirketTel.Text;
                    sirket.SirketAdres = memoSirketAdresi.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Şirket başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    SirketGuncellendi?.Invoke(this, EventArgs.Empty);
                    GlobalEvents.OnDataChanged();
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