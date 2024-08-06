namespace pcKayitProgram.Formlar
{
    partial class FormUnvanGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnvanGuncelle));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUnvanİptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnvanGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.txtUnvanAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnvanID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvanAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvanID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnUnvanİptal);
            this.groupControl1.Controls.Add(this.btnUnvanGuncelle);
            this.groupControl1.Controls.Add(this.txtUnvanAdi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtUnvanID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(373, 202);
            this.groupControl1.TabIndex = 3;
            // 
            // btnUnvanİptal
            // 
            this.btnUnvanİptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUnvanİptal.Appearance.Options.UseFont = true;
            this.btnUnvanİptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnvanİptal.ImageOptions.SvgImage")));
            this.btnUnvanİptal.Location = new System.Drawing.Point(232, 105);
            this.btnUnvanİptal.Name = "btnUnvanİptal";
            this.btnUnvanİptal.Size = new System.Drawing.Size(90, 62);
            this.btnUnvanİptal.TabIndex = 9;
            this.btnUnvanİptal.Text = "İptal Et";
            this.btnUnvanİptal.Click += new System.EventHandler(this.btnUnvanİptal_Click);
            // 
            // btnUnvanGuncelle
            // 
            this.btnUnvanGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUnvanGuncelle.Appearance.Options.UseFont = true;
            this.btnUnvanGuncelle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnvanGuncelle.ImageOptions.SvgImage")));
            this.btnUnvanGuncelle.Location = new System.Drawing.Point(128, 105);
            this.btnUnvanGuncelle.Name = "btnUnvanGuncelle";
            this.btnUnvanGuncelle.Size = new System.Drawing.Size(98, 62);
            this.btnUnvanGuncelle.TabIndex = 8;
            this.btnUnvanGuncelle.Text = "Güncelle";
            this.btnUnvanGuncelle.Click += new System.EventHandler(this.btnUnvanGuncelle_Click);
            // 
            // txtUnvanAdi
            // 
            this.txtUnvanAdi.Location = new System.Drawing.Point(128, 73);
            this.txtUnvanAdi.Name = "txtUnvanAdi";
            this.txtUnvanAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnvanAdi.Properties.Appearance.Options.UseFont = true;
            this.txtUnvanAdi.Properties.MaxLength = 45;
            this.txtUnvanAdi.Size = new System.Drawing.Size(194, 22);
            this.txtUnvanAdi.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(52, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ünvan Adı:";
            // 
            // txtUnvanID
            // 
            this.txtUnvanID.Enabled = false;
            this.txtUnvanID.Location = new System.Drawing.Point(128, 41);
            this.txtUnvanID.Name = "txtUnvanID";
            this.txtUnvanID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnvanID.Properties.Appearance.Options.UseFont = true;
            this.txtUnvanID.Properties.ReadOnly = true;
            this.txtUnvanID.Size = new System.Drawing.Size(194, 22);
            this.txtUnvanID.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(59, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ünvan ID:";
            // 
            // FormUnvanGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 226);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormUnvanGuncelle.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUnvanGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ünvan Güncelle";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvanAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvanID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnUnvanİptal;
        private DevExpress.XtraEditors.SimpleButton btnUnvanGuncelle;
        private DevExpress.XtraEditors.TextEdit txtUnvanAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUnvanID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}