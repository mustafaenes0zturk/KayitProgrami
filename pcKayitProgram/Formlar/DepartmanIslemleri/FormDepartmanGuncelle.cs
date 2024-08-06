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

namespace pcKayitProgram.Formlar.DepartmanIslemleri
{
    public partial class FormDepartmanGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int DepartmanID;

        public FormDepartmanGuncelle(int DepartmanID, string DepartmanAdi)
        {
            InitializeComponent();
            this.DepartmanID     = DepartmanID;
            txtDepID.Text = DepartmanID.ToString();
            txtDepartmanAdi.Text = DepartmanAdi;
        }

        public event EventHandler DepartmanGuncellendi;

        private void btnDepartmanGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartmanAdi.Text))
            {
                XtraMessageBox.Show("Lütfen bir departman adı girin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutDepartman = db.DepartmanTablo
                .FirstOrDefault(d => d.DepartmanAdi == txtDepartmanAdi.Text && d.DepartmanID != DepartmanID);
            if (mevcutDepartman != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir departman zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Departman güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var departman = db.DepartmanTablo.Find(DepartmanID);
                if (departman != null)
                {
                    departman.DepartmanAdi = txtDepartmanAdi.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Departman başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DepartmanGuncellendi?.Invoke(this, EventArgs.Empty);
                    GlobalEvents.OnDataChanged();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnDepartmanİptal_Click(object sender, EventArgs e)
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