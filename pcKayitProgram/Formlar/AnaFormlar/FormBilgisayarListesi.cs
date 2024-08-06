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
using static DevExpress.CodeParser.CodeStyle.Formatting.Rules.Spacing;

namespace pcKayitProgram.Formlar
{
    public partial class FormBilgisayarListesi : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();
        BindingSource bilgisayarBindingSource = new BindingSource();
        BindingSource BindingSource1 = new BindingSource();
        public FormBilgisayarListesi()
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
            var degerler = (from b in db.BilgisayarTABLO
                            join p in db.PersonelTablosu on b.PersonelID equals p.PersonelID
                            select new
                            {
                                b.BilgisayarID,
                                b.BilgisayarAdi,
                                b.BilgisayarModeli,
                                Programlar = (from bp in db.ProgramBilgisayar
                                              join pr in db.ProgramTABLO on bp.ProgramID equals pr.ProgramID
                                              where bp.BilgisayarID == b.BilgisayarID
                                              select new { pr.ProgramAdi }).ToList(),
                                b.KurulumTarihi,
                                PersonelAdi = p.PersonelAdi
                            }).ToList();

            var bilgisayarListesi = degerler.Select(x => new
            {
                x.BilgisayarID,
                x.BilgisayarAdi,
                x.BilgisayarModeli,
                Programlar = x.Programlar,
                x.PersonelAdi,
                x.KurulumTarihi
            }).ToList();
            bilgisayarBindingSource.DataSource = bilgisayarListesi;
            gridControl1.DataSource            = bilgisayarBindingSource;
            gridView1.OptionsBehavior.Editable = false;

            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
            {
                Console.WriteLine("Column Name: " + column.FieldName);
            }

            var columns = gridView1.Columns;
            if (columns["BilgisayarID"] != null)
                columns["BilgisayarID"].Caption = "Bilgisayar ID";
            else
                Console.WriteLine("'Bilgisayar ID' sütunu bulunamadı.");

            if (columns["BilgisayarAdi"] != null)
                columns["BilgisayarAdi"].Caption = "Bilgisayar Marka";
            else
                Console.WriteLine("'Bilgisayar Marka' sütunu bulunamadı.");

            if (columns["BilgisayarModeli"] != null)
                columns["BilgisayarModeli"].Caption = "Bilgisayar Model";
            else
                Console.WriteLine("'Bilgisayar Model' sütunu bulunamadı.");

            if (columns["Programlar"] != null)
                columns["Programlar"].Caption = "Programlar";
            else
                Console.WriteLine("'Programlar' sütunu bulunamadı");

            if (columns["PersonelAdi"] != null)
                columns["PersonelAdi"].Caption = "Personel";
            else
                Console.WriteLine("'Personel Adı' sütunu bulunamadı.");

            if (columns["KurulumTarihi"] != null)
                columns["KurulumTarihi"].Caption = "Kurulum Tarihi";
            else
                Console.WriteLine("'Kurulum Tarihi' sütunu bulunamadı.");

            gridView1.BestFitColumns();
            gridView1.MasterRowGetChildList     += GridView1_MasterRowGetChildList;
            gridView1.MasterRowGetRelationName  += GridView1_MasterRowGetRelationName;
            gridView1.MasterRowGetRelationCount += GridView1_MasterRowGetRelationCount;
        }

        private void GridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Programlar";
        }

        private void GridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var bilgisayar = gridView1.GetRow(e.RowHandle) as dynamic;
            BindingSource1.DataSource = bilgisayar.Programlar;
            e.ChildList = BindingSource1;
        }

        private void btnYeniBilgisayarFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormBilgisayarEkle)
                {
                    form.BringToFront();
                    return;
                }
            }

            Formlar.FormBilgisayarEkle frm = new FormBilgisayarEkle();
            frm.BilgisayarKaydedildi += Frm_BilgisayarKaydedildi;
            frm.ShowDialog();
        }
        private void Frm_BilgisayarKaydedildi(object sender, EventArgs e)
        {
            Listele();
        }

        private void FormBilgisayarListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnBilgisayarSilFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow();
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen silmek için bir bilgisayar seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int BilgisayarID        = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BilgisayarID"));
            string BilgisayarAdi    = gridView1.GetFocusedRowCellValue("BilgisayarAdi")?.ToString() ?? "";
            string BilgisayarModeli = gridView1.GetFocusedRowCellValue("BilgisayarModeli")?.ToString() ?? "";

            var programlar = (from bp in db.ProgramBilgisayar
                              join pr in db.ProgramTABLO on bp.ProgramID equals pr.ProgramID
                              where bp.BilgisayarID == BilgisayarID
                              select pr.ProgramAdi).ToList();

            string PersonelAdi     = gridView1.GetFocusedRowCellValue("PersonelAdi")?.ToString() ?? "";
            DateTime kurulumTarihi = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("KurulumTarihi"));

            BilgisayarSilForm frm  = new BilgisayarSilForm(BilgisayarID, BilgisayarAdi, BilgisayarModeli, programlar, PersonelAdi, kurulumTarihi);
            frm.BilgisayarSilindi += Frm_BilgisayarSilindi;
            frm.ShowDialog();
        }
        private void Frm_BilgisayarSilindi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnBilgisayarGuncelleFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRowCellValue("BilgisayarID");
            if (selectedRow == null)
            {
                XtraMessageBox.Show("Lütfen güncellemek için bir bilgisayar seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int BilgisayarID        = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BilgisayarID"));
            string BilgisayarAdi    = gridView1.GetFocusedRowCellValue("BilgisayarAdi")?.ToString() ?? "";
            string BilgisayarModeli = gridView1.GetFocusedRowCellValue("BilgisayarModeli")?.ToString() ?? "";
            string programlar       = gridView1.GetFocusedRowCellValue("Programlar")?.ToString() ?? "";
            string PersonelAdi      = gridView1.GetFocusedRowCellValue("PersonelAdi")?.ToString() ?? "";
            DateTime kurulumTarihi  = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("KurulumTarihi"));

            FormBilgisayarGuncelle frm = new FormBilgisayarGuncelle(BilgisayarID, BilgisayarAdi, BilgisayarModeli, PersonelAdi, kurulumTarihi);
            frm.BilgisayarGuncellendi += Frm_BilgisayarGuncellendi;
            frm.ShowDialog();
        }

        private void Frm_BilgisayarGuncellendi(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnBilgisayarRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport3 rpr = new XtraReport3();
            rpr.ShowPreviewDialog();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}