using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pcKayitProgram.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using DevExpress.Data.Mask.Internal;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;


namespace pcKayitProgram.Formlar
{
    public partial class FormSirketListesi : DevExpress.XtraEditors.XtraForm
    {
        public FormSirketListesi()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void Listele()
        {
            var degerler = (from x in db.SirketTablo
                            select new
                            {
                                x.SirketID,
                                x.SirketAdi,
                                x.SirketTel,
                                x.SirketAdres
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
            gridView1.Columns["SirketID"].Caption    = "Şirket ID";
            gridView1.Columns["SirketID"].BestFit();
            gridView1.Columns["SirketAdi"].Caption   = "Şirket Adı";
            gridView1.Columns["SirketTel"].Caption   = "Şirket Telefon";
            gridView1.Columns["SirketAdres"].Caption = "Şirket Adres";

        }

        private void btnYeniSirketFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSirketEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormSirketEkle frm = new FormSirketEkle();
            frm.SirketKaydedildi += Frm_SirketKaydedildi;
            frm.ShowDialog();
        }

        private void Frm_SirketKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormSirketListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSirketSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("SirketID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir şirket seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int SirketID       = (int)selectedRow;
            string SirketAdi   = gridView1.GetFocusedRowCellValue("SirketAdi").ToString();
            string SirketTel   = gridView1.GetFocusedRowCellValue("SirketTel").ToString();
            string SirketAdres = gridView1.GetFocusedRowCellValue("SirketAdres").ToString();

            FormSirketSil frm  = new FormSirketSil(SirketID, SirketAdi, SirketTel, SirketAdres);
            frm.SirketSilindi += Frm_SirketSilindi;
            frm.ShowDialog();
        }

        private void Frm_SirketSilindi(object sender, EventArgs e)
        {
            Listele();
        }
         
        private void btnSirketGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("SirketID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir şirket seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int SirketID       = (int)selectedRow;
            string SirketAdi   = gridView1.GetFocusedRowCellValue("SirketAdi").ToString();
            string SirketTel   = gridView1.GetFocusedRowCellValue("SirketTel").ToString();
            string SirketAdres = gridView1.GetFocusedRowCellValue("SirketAdres").ToString();

            FormSirketGuncelle frm = new FormSirketGuncelle(SirketID, SirketAdi, SirketTel, SirketAdres);
            frm.SirketGuncellendi += Frm_SirketGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_SirketGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSirketRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport2 rpr = new XtraReport2();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}