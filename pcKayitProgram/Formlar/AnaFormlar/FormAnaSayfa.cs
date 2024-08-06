using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraVerticalGrid;
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
    public partial class FormAnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public FormAnaSayfa()
        {
            InitializeComponent();
            InitializeTabPane();
        }

        private void InitializeTabPane()
        {
            TabPane tabPane = new TabPane();
            tabPane.Dock = DockStyle.Fill;

            TabNavigationPage tabNavigationPage1 = new TabNavigationPage();
            tabNavigationPage1.Caption = "Şirket Listesi";
            GridControl gridControl1 = new GridControl();
            gridControl1.Dock = DockStyle.Fill;
            tabNavigationPage1.Controls.Add(gridControl1);
            tabPane.Pages.Add(tabNavigationPage1);

            TabNavigationPage tabNavigationPage2 = new TabNavigationPage();
            tabNavigationPage2.Caption = "Personel Listesi";
            GridControl gridControl2 = new GridControl();
            gridControl2.Dock = DockStyle.Fill;
            tabNavigationPage2.Controls.Add(gridControl2);
            tabPane.Pages.Add(tabNavigationPage2);

            TabNavigationPage tabNavigationPage3 = new TabNavigationPage();
            tabNavigationPage3.Caption = "Bilgisayar Listesi";
            GridControl gridControl3 = new GridControl();
            gridControl3.Dock = DockStyle.Fill;
            tabNavigationPage3.Controls.Add(gridControl3);
            tabPane.Pages.Add(tabNavigationPage3);

            TabNavigationPage tabNavigationPage4 = new TabNavigationPage();
            tabNavigationPage4.Caption = "İstatistikler";
            GridControl gridControl4 = new GridControl();
            gridControl4.Dock = DockStyle.Fill;
            tabNavigationPage4.Controls.Add(gridControl4);
            tabPane.Pages.Add(tabNavigationPage4);

            this.Controls.Add(tabPane);
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public void SirketListele()
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
            gridView1.Columns["SirketAdi"].Caption   = "Şirket Adı";
            gridView1.Columns["SirketTel"].Caption   = "Şirket Telefon";
            gridView1.Columns["SirketAdres"].Caption = "Şirket Adres";
        }

        private void btnSirketBul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage1;
            SirketListele();
        }

        public void PersonelListele()
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
            gridControl2.DataSource = degerler;
            gridView2.OptionsBehavior.Editable = false;

            SetGridColumnCaption("PersonelID", "Personel ID");
            SetGridColumnCaption("PersonelAdi", "Personel Adı");
            SetGridColumnCaption("SirketAdi", "Şirket");
            SetGridColumnCaption("DepartmanAdi", "Departman");
            SetGridColumnCaption("UnvanAdi", "Ünvan");
            SetGridColumnCaption("PersonelTel", "Telefon");
            SetGridColumnCaption("PersonelMail", "Mail");

            gridView2.BestFitColumns();
        }

        private void SetGridColumnCaption(string fieldName, string caption)
        {
            var column = gridView2.Columns[fieldName];
            if (column != null)
            {
                column.Caption = caption;
            }
            else
            {
                Console.WriteLine($"Kolon '{fieldName}' bulunamadı.");
            }
        }

        private void btnPersonelBul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage2;
            PersonelListele();
        }

        BindingSource bilgisayarBindingSource = new BindingSource();
        BindingSource BindingSource1 = new BindingSource();

        public void BilgisayarListele()
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
            gridControl3.DataSource = bilgisayarBindingSource;
            gridView3.OptionsBehavior.Editable = false;

            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView3.Columns)
            {
                Console.WriteLine("Column Name: " + column.FieldName);
            }

            var columns = gridView3.Columns;
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

            gridView3.BestFitColumns();
            gridView3.MasterRowGetChildList     += GridView3_MasterRowGetChildList;
            gridView3.MasterRowGetRelationName  += GridView3_MasterRowGetRelationName;
            gridView3.MasterRowGetRelationCount += GridView3_MasterRowGetRelationCount;
        }

        private void GridView3_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void GridView3_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Programlar";
        }

        private void GridView3_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var bilgisayar = gridView3.GetRow(e.RowHandle) as dynamic;
            BindingSource1.DataSource = bilgisayar.Programlar;
            e.ChildList = BindingSource1;
        }
        private void btnBilgisayarBul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage3;
            BilgisayarListele();
        }
        public class TabloVeri
        {
            public string TabloAdi { get; set; }
            public int VeriSayisi { get; set; }
        }

        public void Toplamlar()
        {
            using (var db = new dbPcKayitEntities3())
            {
                var tabloVerileri = new List<TabloVeri>
                {                  
                    new TabloVeri { TabloAdi = "Şirket",     VeriSayisi = db.SirketTablo.Count() },
                    new TabloVeri { TabloAdi = "Departman",  VeriSayisi = db.DepartmanTablo.Count() },
                    new TabloVeri { TabloAdi = "Ünvan",      VeriSayisi = db.UnvanTablo.Count() },
                    new TabloVeri { TabloAdi = "Personel",   VeriSayisi = db.PersonelTablosu.Count() },
                    new TabloVeri { TabloAdi = "Bilgisayar", VeriSayisi = db.BilgisayarTABLO.Count() },
                    new TabloVeri { TabloAdi = "Kullanıcı",  VeriSayisi = db.KullaniciTablo.Count() }
                };
                
                gridControl4.DataSource = tabloVerileri;
                gridView4.PopulateColumns();
                gridView4.Columns["TabloAdi"].Caption   = "Veri";
                gridView4.Columns["TabloAdi"].BestFit();
                gridView4.Columns["TabloAdi"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gridView4.Columns["VeriSayisi"].Caption = "Toplam Veri";
                gridView4.Columns["VeriSayisi"].BestFit();
                gridView4.Columns["VeriSayisi"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gridView4.BestFitColumns();
                gridView4.OptionsBehavior.Editable = false;
            }
        }

        private void btnStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage4;
            Toplamlar();
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {
            SirketListele();
            PersonelListele();
            BilgisayarListele();
            Toplamlar();
        }

        private void btnSIRKET_RAPOR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport2 rpr = new XtraReport2();
            rpr.ShowPreviewDialog();
        }

        private void btnPERSONEL_RAPOR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport1 rpr = new XtraReport1();
            rpr.ShowPreviewDialog();
        }

        private void btnPC_RAPOR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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