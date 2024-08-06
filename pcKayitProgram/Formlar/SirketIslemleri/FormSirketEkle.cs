using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pcKayitProgram.Entity;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace pcKayitProgram.Formlar
{
    public partial class FormSirketEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormSirketEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler SirketKaydedildi;

        private void btnSirketKaydet_Click(object sender, EventArgs e)
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
                .FirstOrDefault(s => s.SirketAdi == txtSirketAdi.Text);
            if (mevcutSirket != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir şirket zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SirketTablo t = new SirketTablo();
            t.SirketAdi   = txtSirketAdi.Text;
            t.SirketTel   = txtSirketTel.Text;
            t.SirketAdres = memoSirketAdresi.Text;
            db.SirketTablo.Add(t);
            db.SaveChanges();

            XtraMessageBox.Show("Şirket başarılı bir şekilde kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtSirketAdi.Text     = string.Empty;
            txtSirketTel.Text     = string.Empty;
            memoSirketAdresi.Text = string.Empty;

            SirketKaydedildi?.Invoke(this, EventArgs.Empty);
            Close();
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