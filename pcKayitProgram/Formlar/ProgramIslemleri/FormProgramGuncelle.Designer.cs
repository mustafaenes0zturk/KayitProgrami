namespace pcKayitProgram.Formlar
{
    partial class FormProgramGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgramGuncelle));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnProgramİptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnProgramGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.txtProgramAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProgramID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnProgramİptal);
            this.groupControl1.Controls.Add(this.btnProgramGuncelle);
            this.groupControl1.Controls.Add(this.txtProgramAdi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtProgramID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(373, 202);
            this.groupControl1.TabIndex = 4;
            // 
            // btnProgramİptal
            // 
            this.btnProgramİptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProgramİptal.Appearance.Options.UseFont = true;
            this.btnProgramİptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProgramİptal.ImageOptions.SvgImage")));
            this.btnProgramİptal.Location = new System.Drawing.Point(232, 105);
            this.btnProgramİptal.Name = "btnProgramİptal";
            this.btnProgramİptal.Size = new System.Drawing.Size(90, 62);
            this.btnProgramİptal.TabIndex = 6;
            this.btnProgramİptal.Text = "İptal Et";
            this.btnProgramİptal.Click += new System.EventHandler(this.btnProgramİptal_Click);
            // 
            // btnProgramGuncelle
            // 
            this.btnProgramGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProgramGuncelle.Appearance.Options.UseFont = true;
            this.btnProgramGuncelle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProgramGuncelle.ImageOptions.SvgImage")));
            this.btnProgramGuncelle.Location = new System.Drawing.Point(128, 105);
            this.btnProgramGuncelle.Name = "btnProgramGuncelle";
            this.btnProgramGuncelle.Size = new System.Drawing.Size(98, 62);
            this.btnProgramGuncelle.TabIndex = 5;
            this.btnProgramGuncelle.Text = "Güncelle";
            this.btnProgramGuncelle.Click += new System.EventHandler(this.btnProgramGuncelle_Click);
            // 
            // txtProgramAdi
            // 
            this.txtProgramAdi.Location = new System.Drawing.Point(128, 73);
            this.txtProgramAdi.Name = "txtProgramAdi";
            this.txtProgramAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProgramAdi.Properties.Appearance.Options.UseFont = true;
            this.txtProgramAdi.Properties.MaxLength = 95;
            this.txtProgramAdi.Size = new System.Drawing.Size(194, 22);
            this.txtProgramAdi.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(37, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Program Adı:";
            // 
            // txtProgramID
            // 
            this.txtProgramID.Enabled = false;
            this.txtProgramID.Location = new System.Drawing.Point(128, 41);
            this.txtProgramID.Name = "txtProgramID";
            this.txtProgramID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProgramID.Properties.Appearance.Options.UseFont = true;
            this.txtProgramID.Properties.ReadOnly = true;
            this.txtProgramID.Size = new System.Drawing.Size(194, 22);
            this.txtProgramID.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(44, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Program ID:";
            // 
            // FormProgramGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 226);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormProgramGuncelle.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgramGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Güncelle";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnProgramİptal;
        private DevExpress.XtraEditors.SimpleButton btnProgramGuncelle;
        private DevExpress.XtraEditors.TextEdit txtProgramAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtProgramID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}