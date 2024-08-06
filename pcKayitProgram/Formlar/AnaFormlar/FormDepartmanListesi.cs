using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using pcKayitProgram.Entity;
using pcKayitProgram.Formlar.DepartmanIslemleri;
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
    public partial class FormDepartmanListesi : DevExpress.XtraEditors.XtraForm
    {
        public FormDepartmanListesi()
        {
            InitializeComponent();
            Listele();
        }
        
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void Listele()
        {
            var degerler = (from x in db.DepartmanTablo
                            select new
                            {
                                x.DepartmanID,
                                x.DepartmanAdi
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
            gridView1.Columns["DepartmanID"].Caption  = "Departman ID";
            gridView1.Columns["DepartmanAdi"].Caption = "Departman Adı";

        }

        private void btnYeniDepartmanFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormDepartmanEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormDepartmanEkle frm = new FormDepartmanEkle();
            frm.DepartmanKaydedildi += Frm_DepartmanKaydedildi;
            frm.ShowDialog();
        }

        private void Frm_DepartmanKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormDepartmanListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
                                   
        private void btnDepartmanSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("DepartmanID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir departman seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int DepartmanID = (int)selectedRow;
            string DepartmanAdi = gridView1.GetFocusedRowCellValue("DepartmanAdi").ToString();

            FormDepartmanSil frm  = new FormDepartmanSil(DepartmanID, DepartmanAdi);
            frm.DepartmanSilindi += Frm_DepartmanSilindi;
            frm.ShowDialog();
        }

        private void Frm_DepartmanSilindi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDepartmanGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("DepartmanID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir departman seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int DepartmanID = (int)selectedRow;
            string DepartmanAdi = gridView1.GetFocusedRowCellValue("DepartmanAdi").ToString();

            FormDepartmanGuncelle frm = new FormDepartmanGuncelle(DepartmanID, DepartmanAdi);
            frm.DepartmanGuncellendi += Frm_DepartmanGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_DepartmanGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDepartmanRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport4 rpr = new XtraReport4();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}