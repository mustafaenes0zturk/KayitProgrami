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
using DevExpress.XtraReports.UI;

namespace pcKayitProgram.Formlar
{
    public partial class FormUnvanListesi : DevExpress.XtraEditors.XtraForm
    {
        public FormUnvanListesi()
        {
            InitializeComponent();
            Listele();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void Listele()
        {
            var degerler = (from x in db.UnvanTablo
                            select new
                            {
                                x.UnvanID,
                                x.UnvanAdi
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns["UnvanID"].Caption  = "Ünvan ID";
            gridView1.Columns["UnvanAdi"].Caption = "Ünvan Adı";
        }

        private void btnYeniUnvanFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormUnvanEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormUnvanEkle frm = new FormUnvanEkle();
            frm.UnvanKaydedildi += Frm_UnvanKaydedildi;
            frm.ShowDialog();
        }
        private void Frm_UnvanKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormUnvanListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnUnvanSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("UnvanID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir ünvan seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int UnvanID     = (int)selectedRow;
            string UnvanAdi = gridView1.GetFocusedRowCellValue("UnvanAdi").ToString();

            FormUnvanSil frm  = new FormUnvanSil(UnvanID, UnvanAdi);
            frm.UnvanSilindi += Frm_UnvanSilindi;
            frm.ShowDialog();
        }
        private void Frm_UnvanSilindi(object sender, EventArgs e)
        {
            Listele();
        }
 
        private void btnUnvanGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("UnvanID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir ünvan seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int UnvanID     = (int)selectedRow;
            string UnvanAdi = gridView1.GetFocusedRowCellValue("UnvanAdi").ToString();

            FormUnvanGuncelle frm = new FormUnvanGuncelle(UnvanID, UnvanAdi);
            frm.UnvanGuncellendi += Frm_UnvanGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_UnvanGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnUnvanRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport5 rpr = new XtraReport5();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}