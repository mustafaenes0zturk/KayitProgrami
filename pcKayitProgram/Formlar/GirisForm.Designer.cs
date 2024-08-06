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
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.btniptal = new DevExpress.XtraEditors.SimpleButton();
            this.txtgirisSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.ceGoster = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgirisSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGoster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(28, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 16);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "Şifre:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(44, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 16);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "ID:";
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGiris.ImageOptions.SvgImage")));
            this.btnGiris.Location = new System.Drawing.Point(72, 78);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(123, 41);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btniptal
            // 
            this.btniptal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btniptal.Appearance.Options.UseFont = true;
            this.btniptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btniptal.ImageOptions.SvgImage")));
            this.btniptal.Location = new System.Drawing.Point(209, 78);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(123, 41);
            this.btniptal.TabIndex = 5;
            this.btniptal.Text = "İptal Et";
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // txtgirisSifre
            // 
            this.txtgirisSifre.Location = new System.Drawing.Point(72, 46);
            this.txtgirisSifre.Name = "txtgirisSifre";
            this.txtgirisSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtgirisSifre.Properties.Appearance.Options.UseFont = true;
            this.txtgirisSifre.Properties.MaxLength = 50;
            this.txtgirisSifre.Size = new System.Drawing.Size(260, 22);
            this.txtgirisSifre.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(72, 14);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Properties.MaxLength = 50;
            this.txtID.Size = new System.Drawing.Size(260, 22);
            this.txtID.TabIndex = 1;
            // 
            // ceGoster
            // 
            this.ceGoster.Location = new System.Drawing.Point(338, 47);
            this.ceGoster.Name = "ceGoster";
            this.ceGoster.Properties.Caption = "Göster";
            this.ceGoster.Size = new System.Drawing.Size(75, 20);
            this.ceGoster.TabIndex = 3;
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 132);
            this.Controls.Add(this.ceGoster);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtgirisSifre);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.btniptal);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GirisForm.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Program Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.txtgirisSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGoster.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.SimpleButton btniptal;
        private DevExpress.XtraEditors.TextEdit txtgirisSifre;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.CheckEdit ceGoster;
    }
}