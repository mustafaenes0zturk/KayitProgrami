namespace pcKayitProgram.Formlar
{
    partial class FormDepartmanEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDepartmanEkle));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDepartmanİptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnDepartmanKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtDepartmanAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmanAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDepartmanİptal);
            this.groupControl1.Controls.Add(this.btnDepartmanKaydet);
            this.groupControl1.Controls.Add(this.txtDepartmanAdi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtDepID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(373, 202);
            this.groupControl1.TabIndex = 1;
            // 
            // btnDepartmanİptal
            // 
            this.btnDepartmanİptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDepartmanİptal.Appearance.Options.UseFont = true;
            this.btnDepartmanİptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDepartmanİptal.ImageOptions.SvgImage")));
            this.btnDepartmanİptal.Location = new System.Drawing.Point(245, 106);
            this.btnDepartmanİptal.Name = "btnDepartmanİptal";
            this.btnDepartmanİptal.Size = new System.Drawing.Size(90, 62);
            this.btnDepartmanİptal.TabIndex = 9;
            this.btnDepartmanİptal.Text = "İptal Et";
            this.btnDepartmanİptal.Click += new System.EventHandler(this.btnDepartmanİptal_Click);
            // 
            // btnDepartmanKaydet
            // 
            this.btnDepartmanKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDepartmanKaydet.Appearance.Options.UseFont = true;
            this.btnDepartmanKaydet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDepartmanKaydet.ImageOptions.SvgImage")));
            this.btnDepartmanKaydet.Location = new System.Drawing.Point(141, 106);
            this.btnDepartmanKaydet.Name = "btnDepartmanKaydet";
            this.btnDepartmanKaydet.Size = new System.Drawing.Size(90, 62);
            this.btnDepartmanKaydet.TabIndex = 8;
            this.btnDepartmanKaydet.Text = "Kaydet";
            this.btnDepartmanKaydet.Click += new System.EventHandler(this.btnDepartmanKaydet_Click);
            // 
            // txtDepartmanAdi
            // 
            this.txtDepartmanAdi.Location = new System.Drawing.Point(141, 74);
            this.txtDepartmanAdi.Name = "txtDepartmanAdi";
            this.txtDepartmanAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepartmanAdi.Properties.Appearance.Options.UseFont = true;
            this.txtDepartmanAdi.Properties.MaxLength = 35;
            this.txtDepartmanAdi.Size = new System.Drawing.Size(194, 22);
            this.txtDepartmanAdi.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(33, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(102, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Departman Adı:";
            // 
            // txtDepID
            // 
            this.txtDepID.Enabled = false;
            this.txtDepID.Location = new System.Drawing.Point(141, 42);
            this.txtDepID.Name = "txtDepID";
            this.txtDepID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepID.Properties.Appearance.Options.UseFont = true;
            this.txtDepID.Properties.ReadOnly = true;
            this.txtDepID.Size = new System.Drawing.Size(194, 22);
            this.txtDepID.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(40, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Departman ID:";
            // 
            // FormDepartmanEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 226);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormDepartmanEkle.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDepartmanEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Departman";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmanAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDepartmanİptal;
        private DevExpress.XtraEditors.SimpleButton btnDepartmanKaydet;
        private DevExpress.XtraEditors.TextEdit txtDepartmanAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDepID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}