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
    public partial class FormPersonelGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int PersonelID;

        public FormPersonelGuncelle(int PersonelID, string PersonelAdi, string SirketAdi, string DepartmanAdi, string UnvanAdi, string PersonelTel, string PersonelMail)
        {
            InitializeComponent();
            this.PersonelID      = PersonelID;
            txtID.Text           = PersonelID.ToString();
            txtPersonelAdi.Text  = PersonelAdi;
            txtPersonelTel.Text  = PersonelTel;
            txtPersonelMail.Text = PersonelMail;
            LoadComboBoxes(SirketAdi, DepartmanAdi, UnvanAdi);
        }

        public event EventHandler PersonelGuncellendi;

        private void LoadComboBoxes(string SirketAdi, string DepartmanAdi, string UnvanAdi)
        {
            var sirketler = db.SirketTablo
                .Select(s => new { s.SirketID, s.SirketAdi })
                .ToList();
            lookUpEditSirket.Properties.DataSource    = sirketler;
            lookUpEditSirket.Properties.DisplayMember = "SirketAdi";
            lookUpEditSirket.Properties.ValueMember   = "SirketID";
            lookUpEditSirket.EditValue = sirketler
                .FirstOrDefault(s => s.SirketAdi == SirketAdi)?.SirketID;

            var departmanlar = db.DepartmanTablo
                .Select(d => new { d.DepartmanID, d.DepartmanAdi })
                .ToList();
            lookUpEditDepartman.Properties.DataSource    = departmanlar;
            lookUpEditDepartman.Properties.DisplayMember = "DepartmanAdi";
            lookUpEditDepartman.Properties.ValueMember   = "DepartmanID";
            lookUpEditDepartman.EditValue = departmanlar
                .FirstOrDefault(d => d.DepartmanAdi == DepartmanAdi)?.DepartmanID;

            var unvanlar = db.UnvanTablo
                .Select(u => new { u.UnvanID, u.UnvanAdi })
                .ToList();
            lookUpEditUnvan.Properties.DataSource    = unvanlar;
            lookUpEditUnvan.Properties.DisplayMember = "UnvanAdi";
            lookUpEditUnvan.Properties.ValueMember   = "UnvanID";
            lookUpEditUnvan.EditValue = unvanlar
                .FirstOrDefault(u => u.UnvanAdi == UnvanAdi)?.UnvanID;
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonelAdi.Text) ||
                lookUpEditSirket.EditValue == null             ||
                lookUpEditDepartman.EditValue == null          ||
                lookUpEditUnvan.EditValue == null              ||
                string.IsNullOrWhiteSpace(txtPersonelTel.Text) ||
                string.IsNullOrWhiteSpace(txtPersonelMail.Text))
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutPersonel = db.PersonelTablosu
                .FirstOrDefault(p => p.PersonelAdi == txtPersonelAdi.Text && p.PersonelID != PersonelID);

            if (mevcutPersonel != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir personel zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Personel güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var personel = db.PersonelTablosu.Find(PersonelID);
                if (personel != null)
                {
                    personel.PersonelAdi  = txtPersonelAdi.Text;
                    personel.SirketID     = (int)lookUpEditSirket.EditValue;
                    personel.DepartmanID  = (int)lookUpEditDepartman.EditValue;
                    personel.UnvanID      = (int)lookUpEditUnvan.EditValue;
                    personel.PersonelTel  = txtPersonelTel.Text;
                    personel.PersonelMail = txtPersonelMail.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Personel başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    PersonelGuncellendi?.Invoke(this, EventArgs.Empty);
                    GlobalEvents.OnDataChanged();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnPersonelİptal_Click(object sender, EventArgs e)
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