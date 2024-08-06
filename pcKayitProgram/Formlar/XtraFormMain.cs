using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pcKayitProgram.Entity;
using System.Windows.Forms;
using pcKayitProgram.Formlar;
using DevExpress.XtraSplashScreen;

namespace pcKayitProgram.Formlar
{
    public partial class XtraFormMain : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormMain()
        {
            InitializeComponent();
        }

        public void btnSirketListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormSirketListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormSirketListesi frm = new Formlar.FormSirketListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnDepartmanListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormDepartmanListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormDepartmanListesi frm = new Formlar.FormDepartmanListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnUnvanListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormUnvanListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormUnvanListesi frm = new FormUnvanListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnPersonelListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormPersonelListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormPersonelListesi frm = new FormPersonelListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnBilgisayarListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormBilgisayarListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormBilgisayarListesi frm = new FormBilgisayarListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnProgramListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormProgramListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormProgramListesi frm = new FormProgramListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnKullanıcıListesi_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormKullaniciListesi)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormKullaniciListesi frm = new FormKullaniciListesi();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void XtraFormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            // UYGULAMA AÇILDIĞINDA ANA SAYFA YÜKLENSİN İSTENİRSE 
            /*try                      
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormAnaSayfa)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormAnaSayfa frm = new Formlar.FormAnaSayfa();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl1.Text = DateTime.Now.ToString();
        }

        private void btnSistemAyarları_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormSistemAyar)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormSistemAyar frm = new FormSistemAyar();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                foreach (Form form in this.MdiChildren)
                {
                    if (form is FormAnaSayfa)
                    {
                        form.BringToFront();
                        return;
                    }
                }

                Formlar.FormAnaSayfa frm = new Formlar.FormAnaSayfa();
                frm.MdiParent = this;
                frm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }
    }
}