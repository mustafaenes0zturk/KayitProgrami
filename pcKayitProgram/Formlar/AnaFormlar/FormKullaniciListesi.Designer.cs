namespace pcKayitProgram.Formlar
{
    partial class FormKullaniciListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKullaniciListesi));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnYeniKullanıcıFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullanıcıSilFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullanıcıGuncelleFormu = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullaniciSilForm = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullaniciRapor = new DevExpress.XtraBars.BarButtonItem();
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.btnYeniKullanıcıFormu,
            this.btnKullanıcıSilFormu,
            this.btnKullanıcıGuncelleFormu,
            this.btnKullaniciSilForm,
            this.btnKullaniciRapor,
            this.btnCikis});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1094, 150);
            // 
            // btnYeniKullanıcıFormu
            // 
            this.btnYeniKullanıcıFormu.Caption = "Yeni Kullanıcı";
            this.btnYeniKullanıcıFormu.Id = 1;
            this.btnYeniKullanıcıFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYeniKullanıcıFormu.ImageOptions.SvgImage")));
            this.btnYeniKullanıcıFormu.Name = "btnYeniKullanıcıFormu";
            this.btnYeniKullanıcıFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniKullanıcıFormu_ItemClick);
            // 
            // btnKullanıcıSilFormu
            // 
            this.btnKullanıcıSilFormu.Caption = "Kullanıcı Sil";
            this.btnKullanıcıSilFormu.Id = 2;
            this.btnKullanıcıSilFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKullanıcıSilFormu.ImageOptions.SvgImage")));
            this.btnKullanıcıSilFormu.Name = "btnKullanıcıSilFormu";
            // 
            // btnKullanıcıGuncelleFormu
            // 
            this.btnKullanıcıGuncelleFormu.Caption = "Kullanıcı Güncelle";
            this.btnKullanıcıGuncelleFormu.Id = 3;
            this.btnKullanıcıGuncelleFormu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKullanıcıGuncelleFormu.ImageOptions.SvgImage")));
            this.btnKullanıcıGuncelleFormu.Name = "btnKullanıcıGuncelleFormu";
            this.btnKullanıcıGuncelleFormu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullanıcıGuncelleFormu_ItemClick);
            // 
            // btnKullaniciSilForm
            // 
            this.btnKullaniciSilForm.Caption = "Kullanıcı Sil";
            this.btnKullaniciSilForm.Id = 4;
            this.btnKullaniciSilForm.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKullaniciSilForm.ImageOptions.SvgImage")));
            this.btnKullaniciSilForm.Name = "btnKullaniciSilForm";
            this.btnKullaniciSilForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullaniciSilForm_ItemClick);
            // 
            // btnKullaniciRapor
            // 
            this.btnKullaniciRapor.Caption = "Rapor Oluştur";
            this.btnKullaniciRapor.Id = 5;
            this.btnKullaniciRapor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKullaniciRapor.ImageOptions.SvgImage")));
            this.btnKullaniciRapor.Name = "btnKullaniciRapor";
            this.btnKullaniciRapor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullaniciRapor_ItemClick);
            // 
            // btnCikis
            // 
            this.btnCikis.Caption = "Çıkış";
            this.btnCikis.Id = 6;
            this.btnCikis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Kullanıcı İşlemleri";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnYeniKullanıcıFormu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKullaniciSilForm);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKullanıcıGuncelleFormu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKullaniciRapor);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCikis);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1094, 418);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // FormKullaniciListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 568);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormKullaniciListesi.IconOptions.SvgImage")));
            this.Name = "FormKullaniciListesi";
            this.Text = "Kullanıcı İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnYeniKullanıcıFormu;
        private DevExpress.XtraBars.BarButtonItem btnKullanıcıSilFormu;
        private DevExpress.XtraBars.BarButtonItem btnKullanıcıGuncelleFormu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciSilForm;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciRapor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}