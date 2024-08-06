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
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;

namespace pcKayitProgram.Formlar
{
    public partial class FormPersonelListesi : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public FormPersonelListesi()
        {
            InitializeComponent();
            GlobalEvents.DataChanged += GlobalEvents_DataChanged;
            Listele();
        }

        private void GlobalEvents_DataChanged(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            var degerler = (from p in db.PersonelTablosu
                            join s in db.SirketTablo on p.SirketID equals s.SirketID
                            join d in db.DepartmanTablo on p.DepartmanID equals d.DepartmanID
                            join u in db.UnvanTablo on p.UnvanID equals u.UnvanID
                            select new
                            {
                                p.PersonelID,
                                p.PersonelAdi,
                                SirketAdi = s.SirketAdi,
                                DepartmanAdi = d.DepartmanAdi,
                                UnvanAdi = u.UnvanAdi,
                                p.PersonelTel,
                                p.PersonelMail
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;

            SetGridColumnCaption("PersonelID", "Personel ID");
            SetGridColumnCaption("PersonelAdi", "Personel Adı");
            SetGridColumnCaption("SirketAdi", "Şirket");
            SetGridColumnCaption("DepartmanAdi", "Departman");
            SetGridColumnCaption("UnvanAdi", "Ünvan");
            SetGridColumnCaption("PersonelTel", "Telefon");
            SetGridColumnCaption("PersonelMail", "Mail");

            gridView1.BestFitColumns();
        }

        private void SetGridColumnCaption(string fieldName, string caption)
        {
            var column = gridView1.Columns[fieldName];
            if (column != null)
            {
                column.Caption = caption;
            }
            else
            {
                Console.WriteLine($"Column '{fieldName}' not found.");
            }
        }

        private void btnYeniPersonelFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPersonelEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormPersonelEkle frm = new FormPersonelEkle();
            frm.PersonelEklendi += Frm_PersonelEklendi;
            frm.ShowDialog();
        }

        private void Frm_PersonelEklendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormPersonelListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnPersonelSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("PersonelID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir personel seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int PersonelID      = (int)selectedRow;
            string PersonelAdi  = gridView1.GetFocusedRowCellValue("PersonelAdi").ToString();
            string SirketAdi    = gridView1.GetFocusedRowCellValue("SirketAdi").ToString();
            string DepartmanAdi = gridView1.GetFocusedRowCellValue("DepartmanAdi").ToString();
            string UnvanAdi     = gridView1.GetFocusedRowCellValue("UnvanAdi").ToString();
            string PersonelTel  = gridView1.GetFocusedRowCellValue("PersonelTel").ToString();
            string PersonelMail = gridView1.GetFocusedRowCellValue("PersonelMail").ToString();

            FormPersonelSil frm = new FormPersonelSil(PersonelID, PersonelAdi, SirketAdi, DepartmanAdi, UnvanAdi, PersonelTel, PersonelMail);
            frm.PersonelSilindi += Frm_PersonelSilindi;
            frm.ShowDialog();
        }
        private void Frm_PersonelSilindi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnPersonelGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("PersonelID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir personel seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int PersonelID      = (int)selectedRow;
            string PersonelAdi  = gridView1.GetFocusedRowCellValue("PersonelAdi").ToString();
            string SirketAdi    = gridView1.GetFocusedRowCellValue("SirketAdi").ToString();
            string DepartmanAdi = gridView1.GetFocusedRowCellValue("DepartmanAdi").ToString();
            string UnvanAdi     = gridView1.GetFocusedRowCellValue("UnvanAdi").ToString();
            string PersonelTel  = gridView1.GetFocusedRowCellValue("PersonelTel").ToString();
            string PersonelMail = gridView1.GetFocusedRowCellValue("PersonelMail").ToString();

            FormPersonelGuncelle frm = new FormPersonelGuncelle(PersonelID, PersonelAdi, SirketAdi, DepartmanAdi, UnvanAdi, PersonelTel, PersonelMail);
            frm.PersonelGuncellendi += Frm_PersonelGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_PersonelGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport1 rpr = new XtraReport1();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}
