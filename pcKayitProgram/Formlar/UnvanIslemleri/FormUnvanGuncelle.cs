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
    public partial class FormUnvanGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int UnvanID;

        public FormUnvanGuncelle(int UnvanID, string UnvanAdi)
        {
            InitializeComponent();
            this.UnvanID     = UnvanID;
            txtUnvanID.Text  = UnvanID.ToString();
            txtUnvanAdi.Text = UnvanAdi;
        }

        public event EventHandler UnvanGuncellendi;

        private void btnUnvanGuncelle_Click(object sender, EventArgs e)
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
                .FirstOrDefault(u => u.UnvanAdi == txtUnvanAdi.Text && u.UnvanID != UnvanID);

            if (mevcutUnvan != null)
            {
                XtraMessageBox.Show("Bu ada sahip ünvan zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Ünvan güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var unvan = db.UnvanTablo.Find(UnvanID);
                if (unvan != null)
                {
                    unvan.UnvanAdi = txtUnvanAdi.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Ünvan başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    UnvanGuncellendi?.Invoke(this, EventArgs.Empty);
                    GlobalEvents.OnDataChanged();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
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