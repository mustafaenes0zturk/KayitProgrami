using DevExpress.XtraEditors;
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
    public partial class FormUnvanEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormUnvanEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler UnvanKaydedildi;

        private void btnUnvanKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnvanAdi.Text))
            {
                XtraMessageBox.Show("Lütfen bir ünvan adı girin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutUnvan = db.UnvanTablo
                .FirstOrDefault(s => s.UnvanAdi == txtUnvanAdi.Text);
            if (mevcutUnvan != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir ünvan zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            UnvanTablo t = new UnvanTablo();
            t.UnvanAdi = txtUnvanAdi.Text;
            db.UnvanTablo.Add(t);
            db.SaveChanges();

            XtraMessageBox.Show("Ünvan başarılı bir şekilde kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtUnvanAdi.Text = string.Empty;

            UnvanKaydedildi?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void btnUnvanİptal_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = XtraMessageBox.Show("İşlem iptal edilsin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.No)
            {
                return;
            }
            Close();
        }
    }
}