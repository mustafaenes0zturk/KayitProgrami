namespace pcKayitProgram.Formlar
{
    partial class FormPersonelListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonelListesi));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnYeniPersonelFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonelSilFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonelGuncelleFormu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonelRapor = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnYeniPersonelFormu,
            this.btnPersonelSilFormu,
            this.btnPersonelGuncelleFormu,
            this.barButtonItem1,
            this.btnPersonelRapor,
            this.barButtonItem2,
            this.btnCikis});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1094, 150);
            // 
            // btnYeniPersonelFormu
            // 
            this.btnYeniPersonelFormu.Caption = "Yeni Personel";
            this.btnYeniPersonelFormu.Id = 1;
            this.btnYeniPersonelFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYeniPersonelFormu.ImageOptions.SvgImage")));
            this.btnYeniPersonelFormu.Name = "btnYeniPersonelFormu";
            this.btnYeniPersonelFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniPersonelFormu_ItemClick);
            // 
            // btnPersonelSilFormu
            // 
            this.btnPersonelSilFormu.Caption = "Personel Sil";
            this.btnPersonelSilFormu.Id = 2;
            this.btnPersonelSilFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPersonelSilFormu.ImageOptions.SvgImage")));
            this.btnPersonelSilFormu.Name = "btnPersonelSilFormu";
            this.btnPersonelSilFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonelSilFormu_ItemClick);
            // 
            // btnPersonelGuncelleFormu
            // 
            this.btnPersonelGuncelleFormu.Caption = "Personel Güncelle";
            this.btnPersonelGuncelleFormu.Id = 3;
            this.btnPersonelGuncelleFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPersonelGuncelleFormu.ImageOptions.SvgImage")));
            this.btnPersonelGuncelleFormu.Name = "btnPersonelGuncelleFormu";
            this.btnPersonelGuncelleFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonelGuncelleFormu_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnPersonelRapor
            // 
            this.btnPersonelRapor.Caption = "Rapor";
            this.btnPersonelRapor.Id = 5;
            this.btnPersonelRapor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPersonelRapor.ImageOptions.SvgImage")));
            this.btnPersonelRapor.Name = "btnPersonelRapor";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Rapor Oluştur";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Personel İşlemleri";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnYeniPersonelFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPersonelSilFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPersonelGuncelleFormu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1094, 418);
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
            this.btnCikis.Id = 7;
            this.btnCikis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            // 
            // FormPersonelListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 568);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormPersonelListesi.IconOptions.SvgImage")));
            this.Name = "FormPersonelListesi";
            this.Text = "Personel İşlemleri";
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
        private DevExpress.XtraBars.BarButtonItem btnYeniPersonelFormu;
        private DevExpress.XtraBars.BarButtonItem btnPersonelSilFormu;
        private DevExpress.XtraBars.BarButtonItem btnPersonelGuncelleFormu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnPersonelRapor;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}