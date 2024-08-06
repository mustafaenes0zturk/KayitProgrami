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

namespace pcKayitProgram.Formlar
{
    public partial class FormBilgisayarEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormBilgisayarEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler BilgisayarKaydedildi;

        private void FormBilgisayarEkle_Load(object sender, EventArgs e)
        {
            var personeller = db.PersonelTablosu
                .Select(p => new { p.PersonelID, p.PersonelAdi })
                .ToList();
            lookUpEditPersonel.Properties.DataSource    = personeller;
            lookUpEditPersonel.Properties.DisplayMember = "PersonelAdi";
            lookUpEditPersonel.Properties.ValueMember   = "PersonelID";
            lookUpEditPersonel.EditValue                = null;
            lookUpEditPersonel.Properties.NullText      = "Personel seçiniz...";
            lookUpEditPersonel.Properties.Columns.Clear();
            lookUpEditPersonel.Properties.Columns.Add(new LookUpColumnInfo("PersonelID", "Personel ID"));
            lookUpEditPersonel.Properties.Columns.Add(new LookUpColumnInfo("PersonelAdi", "Personel Adı"));

            var programlar = db.ProgramTABLO
                .Select(p => new { p.ProgramID, p.ProgramAdi })
                .ToList();
            ComboBoxEditProgramlar.Properties.Items.Clear();
            foreach (var program in programlar)
            {
                ComboBoxEditProgramlar.Properties.Items.Add(
                    new CheckedListBoxItem(program.ProgramID, program.ProgramAdi)
                );
            }
            ComboBoxEditProgramlar.EditValue = null;
            ComboBoxEditProgramlar.Properties.NullText = "Program seçiniz...";

            dateTarih.Properties.NullText = "Tarih seçiniz...";
        }

        private void btnBilgisayarKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBilgisayarAdi.Text)    ||
                string.IsNullOrWhiteSpace(txtBilgisayarModeli.Text) ||        
                lookUpEditPersonel.EditValue == null                ||
                dateTarih.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var seciliProgramlar = ComboBoxEditProgramlar.Properties.Items
                .Where(item => item.CheckState == System.Windows.Forms.CheckState.Checked)
                .Select(item => (int)item.Value)
                .ToList();
        
            if (seciliProgramlar.Count == 0)
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            var bilgisayar = new BilgisayarTABLO
            {
                BilgisayarAdi    = txtBilgisayarAdi.Text,
                BilgisayarModeli = txtBilgisayarModeli.Text,
                KurulumTarihi    = dateTarih.DateTime,
                PersonelID       = (int)lookUpEditPersonel.EditValue
            };

            db.BilgisayarTABLO.Add(bilgisayar);
            db.SaveChanges();

            foreach (var programID in seciliProgramlar)
            {
                var programBilgisayar = new ProgramBilgisayar
                {
                    BilgisayarID = bilgisayar.BilgisayarID,
                    ProgramID = programID
                };
                db.ProgramBilgisayar.Add(programBilgisayar);
            }
            db.SaveChanges();

            XtraMessageBox.Show("Bilgisayar başarılı bir şekilde kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            BilgisayarKaydedildi?.Invoke(this, EventArgs.Empty);
            this.Close();

            txtBilgisayarAdi.Text        = string.Empty;
            txtBilgisayarModeli.Text     = string.Empty;
            dateTarih.EditValue          = null;
            lookUpEditPersonel.EditValue = null;
            ComboBoxEditProgramlar.SetEditValue(null);
            foreach (CheckedListBoxItem item in ComboBoxEditProgramlar.Properties.Items)
            {
                item.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
        }

        private void btnBilgisayarİptal_Click(object sender, EventArgs e)
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