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
    public partial class FormKullaniciEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormKullaniciEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler KullaniciKaydedildi;

        private void btnKullaniciKaydet_Click(object sender, EventArgs e)
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
                .FirstOrDefault(s => s.KullaniciGirisAdi == txtKullaniciGirisAdi.Text);
            if (mevcutKullanici != null)
            {
                XtraMessageBox.Show("Bu giriş kimliğine sahip bir kullanıcı zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            KullaniciTablo k = new KullaniciTablo
            {
                KullaniciAdiGercek = txtKullaniciAdiGercek.Text,
                KullaniciMail      = txtKullaniciMail.Text,
                KullaniciGirisAdi  = txtKullaniciGirisAdi.Text,
                KullaniciSifre     = txtKullaniciSifre.Text
            };
            db.KullaniciTablo.Add(k);
            db.SaveChanges();

            XtraMessageBox.Show("Kullanıcı başarılı bir şekilde kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtKullaniciAdiGercek.Text = string.Empty;
            txtKullaniciMail.Text      = string.Empty;
            txtKullaniciGirisAdi.Text  = string.Empty;
            txtKullaniciSifre.Text     = string.Empty;

            KullaniciKaydedildi?.Invoke(this, EventArgs.Empty);
            Close();
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