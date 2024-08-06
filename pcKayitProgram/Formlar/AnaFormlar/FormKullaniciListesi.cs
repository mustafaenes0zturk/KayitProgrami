using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class FormKullaniciListesi : DevExpress.XtraEditors.XtraForm
    {
        public FormKullaniciListesi()
        {
            InitializeComponent();
            Listele();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void Listele()
        {
            var degerler = (from x in db.KullaniciTablo
                            select new
                            {
                                x.KullaniciID,
                                x.KullaniciAdiGercek,
                                x.KullaniciMail,
                                x.KullaniciGirisAdi,
                            }).ToList();
            gridControl1.DataSource                         = degerler;
            gridView1.OptionsBehavior.Editable              = false;
            gridView1.BestFitColumns();
            gridView1.Columns["KullaniciID"].Caption        = "Kullanıcı ID";
            gridView1.Columns["KullaniciAdiGercek"].Caption = "Kullanıcı Adı";
            gridView1.Columns["KullaniciMail"].Caption      = "Mail";
            gridView1.Columns["KullaniciGirisAdi"].Caption  = "Kullanıcı Giriş ID";
        }

        private void btnYeniKullanıcıFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormKullaniciEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormKullaniciEkle frm = new FormKullaniciEkle();
            frm.KullaniciKaydedildi += Frm_KullaniciKaydedildi;
            frm.ShowDialog();
        }
        private void Frm_KullaniciKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormKullanıcıListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKullaniciSilForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow();
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir kullanıcı seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int KullaniciID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("KullaniciID"));

            using (var db = new dbPcKayitEntities3())
            {
                var kullanici = db.KullaniciTablo.Find(KullaniciID);
                if (kullanici != null)
                {
                    string KullaniciAdiGercek = kullanici.KullaniciAdiGercek;
                    string KullaniciMail      = kullanici.KullaniciMail;
                    string KullaniciGirisAdi  = kullanici.KullaniciGirisAdi;
                    string KullaniciSifre     = kullanici.KullaniciSifre;

                    FormKullaniciSil frm = new FormKullaniciSil(KullaniciID, KullaniciAdiGercek, KullaniciMail, KullaniciGirisAdi, KullaniciSifre);
                    frm.KullaniciSilindi += Frm_KullaniciSilindi;
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı bulunamadı.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Frm_KullaniciSilindi(object sender, EventArgs e)
        {
            Listele();
        }
         
        private void btnKullanıcıGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow();
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int KullaniciID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("KullaniciID"));

            using (var db = new dbPcKayitEntities3())
            {
                var kullanici = db.KullaniciTablo.Find(KullaniciID);
                if (kullanici != null)
                {
                    string KullaniciAdiGercek = kullanici.KullaniciAdiGercek;
                    string KullaniciMail      = kullanici.KullaniciMail;
                    string KullaniciGirisAdi  = kullanici.KullaniciGirisAdi;
                    string KullaniciSifre     = kullanici.KullaniciSifre;

                    FormKullaniciGuncelle frm = new FormKullaniciGuncelle(KullaniciID, KullaniciAdiGercek, KullaniciMail, KullaniciGirisAdi, KullaniciSifre);
                    frm.KullaniciGuncellendi += Frm_KullaniciGuncellendi;
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı bulunamadı.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Frm_KullaniciGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKullaniciRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport7 rpr = new XtraReport7();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}