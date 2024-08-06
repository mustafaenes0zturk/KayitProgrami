namespace pcKayitProgram.Formlar
{
    partial class FormBilgisayarListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBilgisayarListesi));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnYeniBilgisayarFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBilgisayarSilFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBilgisayarGuncelleFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBilgisayarRapor = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBilgisayarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBilgisayarAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBilgisayarModeli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKurulumTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bilgisayarTABLOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgisayarTABLOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnYeniBilgisayarFormu,
            this.btnBilgisayarSilFormu,
            this.btnBilgisayarGuncelleFormu,
            this.btnBilgisayarRapor,
            this.btnCikis});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1094, 150);
            // 
            // btnYeniBilgisayarFormu
            // 
            this.btnYeniBilgisayarFormu.Caption = "Yeni Bilgisayar";
            this.btnYeniBilgisayarFormu.Id = 1;
            this.btnYeniBilgisayarFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYeniBilgisayarFormu.ImageOptions.SvgImage")));
            this.btnYeniBilgisayarFormu.Name = "btnYeniBilgisayarFormu";
            this.btnYeniBilgisayarFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniBilgisayarFormu_ItemClick);
            // 
            // btnBilgisayarSilFormu
            // 
            this.btnBilgisayarSilFormu.Caption = "Bilgisayar Sil";
            this.btnBilgisayarSilFormu.Id = 2;
            this.btnBilgisayarSilFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBilgisayarSilFormu.ImageOptions.SvgImage")));
            this.btnBilgisayarSilFormu.Name = "btnBilgisayarSilFormu";
            this.btnBilgisayarSilFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBilgisayarSilFormu_ItemClick);
            // 
            // btnBilgisayarGuncelleFormu
            // 
            this.btnBilgisayarGuncelleFormu.Caption = "Bilgisayar Güncelle";
            this.btnBilgisayarGuncelleFormu.Id = 3;
            this.btnBilgisayarGuncelleFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBilgisayarGuncelleFormu.ImageOptions.SvgImage")));
            this.btnBilgisayarGuncelleFormu.Name = "btnBilgisayarGuncelleFormu";
            this.btnBilgisayarGuncelleFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBilgisayarGuncelleFormu_ItemClick);
            // 
            // btnBilgisayarRapor
            // 
            this.btnBilgisayarRapor.Caption = "Rapor Oluştur";
            this.btnBilgisayarRapor.Id = 4;
            this.btnBilgisayarRapor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBilgisayarRapor.ImageOptions.SvgImage")));
            this.btnBilgisayarRapor.Name = "btnBilgisayarRapor";
            this.btnBilgisayarRapor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBilgisayarRapor_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Bilgisayar İşlemleri";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnYeniBilgisayarFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBilgisayarSilFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBilgisayarGuncelleFormu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBilgisayarRapor);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(0, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1094, 418);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(pcKayitProgram.Entity.ProgramBilgisayar);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBilgisayarID,
            this.colBilgisayarAdi,
            this.colBilgisayarModeli,
            this.PersonelAdi,
            this.colKurulumTarihi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colBilgisayarID
            // 
            this.colBilgisayarID.FieldName = "BilgisayarID";
            this.colBilgisayarID.Name = "colBilgisayarID";
            this.colBilgisayarID.Visible = true;
            this.colBilgisayarID.VisibleIndex = 0;
            this.colBilgisayarID.Width = 82;
            // 
            // colBilgisayarAdi
            // 
            this.colBilgisayarAdi.FieldName = "BilgisayarAdi";
            this.colBilgisayarAdi.Name = "colBilgisayarAdi";
            this.colBilgisayarAdi.Visible = true;
            this.colBilgisayarAdi.VisibleIndex = 1;
            this.colBilgisayarAdi.Width = 245;
            // 
            // colBilgisayarModeli
            // 
            this.colBilgisayarModeli.FieldName = "BilgisayarModeli";
            this.colBilgisayarModeli.Name = "colBilgisayarModeli";
            this.colBilgisayarModeli.Visible = true;
            this.colBilgisayarModeli.VisibleIndex = 2;
            this.colBilgisayarModeli.Width = 245;
            // 
            // PersonelAdi
            // 
            this.PersonelAdi.Caption = "Personel Adı";
            this.PersonelAdi.FieldName = "PersonelAdi";
            this.PersonelAdi.Name = "PersonelAdi";
            this.PersonelAdi.Visible = true;
            this.PersonelAdi.VisibleIndex = 3;
            this.PersonelAdi.Width = 245;
            // 
            // colKurulumTarihi
            // 
            this.colKurulumTarihi.FieldName = "KurulumTarihi";
            this.colKurulumTarihi.Name = "colKurulumTarihi";
            this.colKurulumTarihi.Visible = true;
            this.colKurulumTarihi.VisibleIndex = 4;
            this.colKurulumTarihi.Width = 252;
            // 
            // bilgisayarTABLOBindingSource
            // 
            this.bilgisayarTABLOBindingSource.DataSource = typeof(pcKayitProgram.Entity.BilgisayarTABLO);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCikis);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // btnCikis
            // 
            this.btnCikis.Caption = "Çıkış";
            this.btnCikis.Id = 5;
            this.btnCikis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            // 
            // FormBilgisayarListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 568);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormBilgisayarListesi.IconOptions.SvgImage")));
            this.Name = "FormBilgisayarListesi";
            this.Text = "Bilgisayar İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgisayarTABLOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnYeniBilgisayarFormu;
        private DevExpress.XtraBars.BarButtonItem btnBilgisayarSilFormu;
        private DevExpress.XtraBars.BarButtonItem btnBilgisayarGuncelleFormu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colBilgisayarID;
        private DevExpress.XtraGrid.Columns.GridColumn colBilgisayarAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colBilgisayarModeli;
        private DevExpress.XtraGrid.Columns.GridColumn PersonelAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colKurulumTarihi;
        private System.Windows.Forms.BindingSource bilgisayarTABLOBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.BarButtonItem btnBilgisayarRapor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}