namespace pcKayitProgram.Formlar
{
    partial class GirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtGirisID = new DevExpress.XtraEditors.TextEdit();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.btniptal = new DevExpress.XtraEditors.SimpleButton();
            this.sifregoster = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifregoster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(42, 44);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(90, 16);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "Kullanıcı Şifre:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(27, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(105, 16);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Kullanıcı Giriş ID:";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(138, 41);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.MaxLength = 50;
            this.txtSifre.Size = new System.Drawing.Size(260, 22);
            this.txtSifre.TabIndex = 2;
            // 
            // txtGirisID
            // 
            this.txtGirisID.Location = new System.Drawing.Point(138, 9);
            this.txtGirisID.Name = "txtGirisID";
            this.txtGirisID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGirisID.Properties.Appearance.Options.UseFont = true;
            this.txtGirisID.Properties.MaxLength = 50;
            this.txtGirisID.Size = new System.Drawing.Size(260, 22);
            this.txtGirisID.TabIndex = 1;
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGiris.ImageOptions.SvgImage")));
            this.btnGiris.Location = new System.Drawing.Point(138, 73);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(123, 41);
            this.btnGiris.TabIndex = 3;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btniptal
            // 
            this.btniptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btniptal.Appearance.Options.UseFont = true;
            this.btniptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btniptal.ImageOptions.SvgImage")));
            this.btniptal.Location = new System.Drawing.Point(275, 73);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(123, 41);
            this.btniptal.TabIndex = 4;
            this.btniptal.Text = "İptal Et";
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // sifregoster
            // 
            this.sifregoster.Location = new System.Drawing.Point(403, 42);
            this.sifregoster.Name = "sifregoster";
            this.sifregoster.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifregoster.Properties.Appearance.Options.UseFont = true;
            this.sifregoster.Properties.Caption = "Göster";
            this.sifregoster.Size = new System.Drawing.Size(75, 20);
            this.sifregoster.TabIndex = 23;
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 132);
            this.Controls.Add(this.sifregoster);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.btniptal);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtGirisID);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GirisForm.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Program Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifregoster.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtGirisID;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.SimpleButton btniptal;
        private DevExpress.XtraEditors.CheckEdit sifregoster;
    }
}