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
    public partial class FormKullaniciGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int KullaniciID;

        public FormKullaniciGuncelle(int KullaniciID, string KullaniciAdiGercek, string KullaniciMail, string KullaniciGirisAdi, string KullaniciSifre)
        {
            InitializeComponent();
            this.KullaniciID           = KullaniciID;
            txtUnvanID.Text            = KullaniciID.ToString();
            txtKullaniciAdiGercek.Text = KullaniciAdiGercek;
            txtKullaniciMail.Text      = KullaniciMail;
            txtKullaniciGirisAdi.Text  = KullaniciGirisAdi;
            txtKullaniciSifre.Text     = KullaniciSifre;
        }

        public event EventHandler KullaniciGuncellendi;

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdiGercek.Text) ||
                string.IsNullOrWhiteSpace(txtKullaniciMail.Text)      ||
                string.IsNullOrWhiteSpace(txtKullaniciGirisAdi.Text)  ||
                string.IsNullOrWhiteSpace(txtKullaniciSifre.Text))
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutKullanici = db.KullaniciTablo
                .FirstOrDefault(s => s.KullaniciGirisAdi == txtKullaniciGirisAdi.Text && s.KullaniciID != KullaniciID);

            if (mevcutKullanici != null)
            {
                XtraMessageBox.Show("Bu giriş kimliğine sahip bir kullanıcı zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Kullanıcı güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var kullanici = db.KullaniciTablo.Find(KullaniciID);
                if (kullanici != null)
                {
                    kullanici.KullaniciAdiGercek = txtKullaniciAdiGercek.Text;
                    kullanici.KullaniciMail      = txtKullaniciMail.Text;
                    kullanici.KullaniciGirisAdi  = txtKullaniciGirisAdi.Text;
                    kullanici.KullaniciSifre     = txtKullaniciSifre.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Kullanıcı başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    KullaniciGuncellendi?.Invoke(this, EventArgs.Empty);
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void btnKullaniciİptal_Click(object sender, EventArgs e)
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