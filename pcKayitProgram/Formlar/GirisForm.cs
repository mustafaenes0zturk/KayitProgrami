﻿using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class GirisForm : DevExpress.XtraEditors.XtraForm
    {
        public GirisForm()
        {
            InitializeComponent();
            this.txtgirisSifre.Properties.PasswordChar = '*';
            ceGoster.CheckedChanged += ceGoster_CheckedChanged;
        }

        private void ceGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (ceGoster.Checked)
            {
                txtgirisSifre.Properties.PasswordChar = '\0';
            }
            else
            {
                txtgirisSifre.Properties.PasswordChar = '*';
            }
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string KullaniciGirisAdi = txtID.Text;
            string KullaniciSifre    = txtgirisSifre.Text;

            if (Kullanici(KullaniciGirisAdi, KullaniciSifre))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Geçersiz ID veya şifre.",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool Kullanici(string KullaniciGirisAdi, string KullaniciSifre)
        {
            using (var db = new dbPcKayitEntities3())
            {
                return db.KullaniciTablo
                    .Any(u => u.KullaniciGirisAdi == KullaniciGirisAdi && u.KullaniciSifre == KullaniciSifre);
            }
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}