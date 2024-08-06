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
    public partial class FormProgramListesi : DevExpress.XtraEditors.XtraForm
    {
        public FormProgramListesi()
        {
            InitializeComponent();
            Listele();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void Listele()
        {
            var degerler = (from x in db.ProgramTABLO
                            select new
                            {
                                x.ProgramID,
                                x.ProgramAdi
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns["ProgramID"].Caption = "Program ID";
            gridView1.Columns["ProgramAdi"].Caption = "Program Adı";
        }

        private void btnYeniProgramFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormProgramEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormProgramEkle frm = new FormProgramEkle();
            frm.ProgramKaydedildi += Frm_ProgramKaydedildi;
            frm.ShowDialog();
        }

        private void Frm_ProgramKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormProgramListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        
        private void btnProgramSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("ProgramID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir program seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int ProgramID     = (int)selectedRow;
            string ProgramAdi = gridView1.GetFocusedRowCellValue("ProgramAdi").ToString();

            FormProgramSil frm  = new FormProgramSil(ProgramID, ProgramAdi);
            frm.ProgramSilindi += Frm_ProgramSilindi;
            frm.ShowDialog();
        }
        private void Frm_ProgramSilindi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnProgramGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("ProgramID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir program seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int ProgramID     = (int)selectedRow;
            string ProgramAdi = gridView1.GetFocusedRowCellValue("ProgramAdi").ToString();

            FormProgramGuncelle frm = new FormProgramGuncelle(ProgramID, ProgramAdi);
            frm.ProgramGuncellendi += Frm_ProgramGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_ProgramGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnProgramRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport6 rpr = new XtraReport6();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}