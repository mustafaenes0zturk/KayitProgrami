using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pcKayitProgram.Formlar
{
    public partial class FormPersonelEkle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler PersonelEklendi;

        public FormPersonelEkle()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            var sirketler = db.SirketTablo
                .Select(s => new { s.SirketID, s.SirketAdi })
                .ToList();
            lookUpEditSirket.Properties.DataSource    = sirketler;
            lookUpEditSirket.Properties.DisplayMember = "SirketAdi";
            lookUpEditSirket.Properties.ValueMember   = "SirketID";
            lookUpEditSirket.EditValue                = null;
            lookUpEditSirket.Properties.NullText      = "Şirket seçiniz...";
            lookUpEditSirket.Properties.Columns.Clear();
            lookUpEditSirket.Properties.Columns.Add(new LookUpColumnInfo("SirketID", "Şirket ID"));
            lookUpEditSirket.Properties.Columns.Add(new LookUpColumnInfo("SirketAdi", "Şirket Adı"));

            var departmanlar = db.DepartmanTablo
                .Select(d => new { d.DepartmanID, d.DepartmanAdi })
                .ToList();
            lookUpEditDepartman.Properties.DataSource    = departmanlar;
            lookUpEditDepartman.Properties.DisplayMember = "DepartmanAdi";
            lookUpEditDepartman.Properties.ValueMember   = "DepartmanID";
            lookUpEditDepartman.EditValue                = null;
            lookUpEditDepartman.Properties.NullText      = "Departman seçiniz...";
            lookUpEditDepartman.Properties.Columns.Clear();
            lookUpEditDepartman.Properties.Columns.Add(new LookUpColumnInfo("DepartmanID", "Departman ID"));
            lookUpEditDepartman.Properties.Columns.Add(new LookUpColumnInfo("DepartmanAdi", "Departman Adı"));

            var unvanlar = db.UnvanTablo
                .Select(u => new { u.UnvanID, u.UnvanAdi })
                .ToList();
            lookUpEditUnvan.Properties.DataSource    = unvanlar;
            lookUpEditUnvan.Properties.DisplayMember = "UnvanAdi";
            lookUpEditUnvan.Properties.ValueMember   = "UnvanID";
            lookUpEditUnvan.EditValue                = null;
            lookUpEditUnvan.Properties.NullText      = "Ünvan seçiniz...";
            lookUpEditUnvan.Properties.Columns.Clear();
            lookUpEditUnvan.Properties.Columns.Add(new LookUpColumnInfo("UnvanID", "Ünvan ID"));
            lookUpEditUnvan.Properties.Columns.Add(new LookUpColumnInfo("UnvanAdi", "Ünvan Adı"));
        }

        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonelAdi.Text)  ||
                string.IsNullOrWhiteSpace(txtPersonelTel.Text)  ||
                string.IsNullOrWhiteSpace(txtPersonelMail.Text) ||
                lookUpEditSirket.EditValue    == null           ||
                lookUpEditDepartman.EditValue == null           ||
                lookUpEditUnvan.EditValue     == null)
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutPersonel = db.PersonelTablosu
                .FirstOrDefault(s => s.PersonelAdi == txtPersonelAdi.Text);
            if (mevcutPersonel != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir personel zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            PersonelTablosu p = new PersonelTablosu
            {
                PersonelAdi  = txtPersonelAdi.Text,
                SirketID     = (int)lookUpEditSirket.EditValue,
                DepartmanID  = (int)lookUpEditDepartman.EditValue,
                UnvanID      = (int)lookUpEditUnvan.EditValue,
                PersonelTel  = txtPersonelTel.Text,
                PersonelMail = txtPersonelMail.Text
            };
            db.PersonelTablosu.Add(p);
            db.SaveChanges();

            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            PersonelEklendi?.Invoke(this, EventArgs.Empty);
            this.Close();
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