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
    public partial class FormKullaniciSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int KullaniciID;
        public FormKullaniciSil(int KullaniciID, string KullaniciAdiGercek, string KullaniciMail, string KullaniciGirisAdi, string KullaniciSifre)
        {
            InitializeComponent();
            this.KullaniciID           = KullaniciID;
            txtUnvanID.Text            = KullaniciID.ToString();
            txtKullaniciAdiGercek.Text = KullaniciAdiGercek;
            txtKullaniciMail.Text      = KullaniciMail;
            txtKullaniciGirisAdi.Text  = KullaniciGirisAdi;
            txtKullaniciSifre.Text     = KullaniciSifre;
        }

        public event EventHandler KullaniciSilindi;

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            var kullanici = db.KullaniciTablo.Find(KullaniciID);
            if (kullanici != null)
            {
                DialogResult sonuc = XtraMessageBox.Show("Kullanıcı silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    db.KullaniciTablo.Remove(kullanici);
                    try
                    {
                        db.SaveChanges();
                        XtraMessageBox.Show("Kullanıcı başarılı bir şekilde silindi.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        KullaniciSilindi?.Invoke(this, EventArgs.Empty);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                XtraMessageBox.Show("Silinecek kullanıcı bulunamadı.",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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