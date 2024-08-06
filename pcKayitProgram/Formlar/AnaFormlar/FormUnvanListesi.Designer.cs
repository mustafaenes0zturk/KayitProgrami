namespace pcKayitProgram.Formlar
{
    partial class FormUnvanListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnvanListesi));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnYeniUnvanFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnvanSilFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnvanGuncelleFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnvanRapor = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnYeniUnvanFormu,
            this.btnUnvanSilFormu,
            this.btnUnvanGuncelleFormu,
            this.btnUnvanRapor,
            this.btnCikis});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1154, 150);
            // 
            // btnYeniUnvanFormu
            // 
            this.btnYeniUnvanFormu.Caption = "Yeni Ünvan";
            this.btnYeniUnvanFormu.Id = 1;
            this.btnYeniUnvanFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYeniUnvanFormu.ImageOptions.SvgImage")));
            this.btnYeniUnvanFormu.Name = "btnYeniUnvanFormu";
            this.btnYeniUnvanFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniUnvanFormu_ItemClick);
            // 
            // btnUnvanSilFormu
            // 
            this.btnUnvanSilFormu.Caption = "Ünvan Sil";
            this.btnUnvanSilFormu.Id = 2;
            this.btnUnvanSilFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnvanSilFormu.ImageOptions.SvgImage")));
            this.btnUnvanSilFormu.Name = "btnUnvanSilFormu";
            this.btnUnvanSilFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnvanSilFormu_ItemClick);
            // 
            // btnUnvanGuncelleFormu
            // 
            this.btnUnvanGuncelleFormu.Caption = "Ünvan Güncelle";
            this.btnUnvanGuncelleFormu.Id = 3;
            this.btnUnvanGuncelleFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnvanGuncelleFormu.ImageOptions.SvgImage")));
            this.btnUnvanGuncelleFormu.Name = "btnUnvanGuncelleFormu";
            this.btnUnvanGuncelleFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnvanGuncelleFormu_ItemClick);
            // 
            // btnUnvanRapor
            // 
            this.btnUnvanRapor.Caption = "Rapor Oluştur";
            this.btnUnvanRapor.Id = 4;
            this.btnUnvanRapor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnvanRapor.ImageOptions.SvgImage")));
            this.btnUnvanRapor.Name = "btnUnvanRapor";
            this.btnUnvanRapor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnvanRapor_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ünvan İşlemleri";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnYeniUnvanFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUnvanSilFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUnvanGuncelleFormu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUnvanRapor);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1154, 346);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
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
            // FormUnvanListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 496);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormUnvanListesi.IconOptions.SvgImage")));
            this.Name = "FormUnvanListesi";
            this.Text = "Ünvan İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnYeniUnvanFormu;
        private DevExpress.XtraBars.BarButtonItem btnUnvanSilFormu;
        private DevExpress.XtraBars.BarButtonItem btnUnvanGuncelleFormu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnUnvanRapor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}