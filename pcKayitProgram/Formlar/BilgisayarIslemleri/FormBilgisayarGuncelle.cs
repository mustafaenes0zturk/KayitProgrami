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
    public partial class FormBilgisayarGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private dbPcKayitEntities3 db = new dbPcKayitEntities3();

        private int _bilgisayarID;
        public FormBilgisayarGuncelle(int BilgisayarID, string BilgisayarAdi, string BilgisayarModeli, string PersonelAdi, DateTime kurulumTarihi)
        {
            InitializeComponent();
            this._bilgisayarID       = BilgisayarID;
            txtID.Text = BilgisayarID.ToString();
            txtBilgisayarAdi.Text    = BilgisayarAdi;
            txtBilgisayarModeli.Text = BilgisayarModeli;
            dateTarih.DateTime       = kurulumTarihi;
            lookUpEditPersonel.EditValue = db.PersonelTablosu
                .FirstOrDefault(p => p.PersonelAdi == PersonelAdi)?.PersonelID;
            this.Load += FormBilgisayarGuncelle_Load;
        }

        private void FormBilgisayarGuncelle_Load(object sender, EventArgs e)
        {
            var personeller = db.PersonelTablosu
                .Select(p   => new { p.PersonelID, p.PersonelAdi })
                .ToList();
            lookUpEditPersonel.Properties.DataSource    = personeller;
            lookUpEditPersonel.Properties.DisplayMember = "PersonelAdi";
            lookUpEditPersonel.Properties.ValueMember   = "PersonelID";
            lookUpEditPersonel.Properties.NullText      = "Personel seçiniz...";

            var programlarListesi = db.ProgramTABLO
                .Select(p => new { p.ProgramID, p.ProgramAdi })
                .ToList();
            ComboBoxEditProgramlar.Properties.Items.Clear();
            foreach (var program in programlarListesi)
            {
                var item = new CheckedListBoxItem(program.ProgramID, program.ProgramAdi);
                ComboBoxEditProgramlar.Properties.Items.Add(item);
            }
            var seciliProgramlar = db.ProgramBilgisayar
                .Where(pb  => pb.BilgisayarID == _bilgisayarID)
                .Select(pb => pb.ProgramID).ToList();
            foreach (CheckedListBoxItem item in ComboBoxEditProgramlar.Properties.Items)
            {
                item.CheckState = seciliProgramlar.Contains((int)item.Value) ? CheckState.Checked : CheckState.Unchecked;
            }

            var personelID = db.BilgisayarTABLO
                .Where(b   => b.BilgisayarID == _bilgisayarID)
                .Select(b  => b.PersonelID)
                .FirstOrDefault();
            lookUpEditPersonel.EditValue = personelID;
        }
        private void btnBilgisayarGuncelle_Click(object sender, EventArgs e)
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
                .Where(item => item.CheckState == CheckState.Checked)
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

            var bilgisayar = db.BilgisayarTABLO.FirstOrDefault(b => b.BilgisayarID == _bilgisayarID);
            if (bilgisayar == null)
            {
                XtraMessageBox.Show("Güncellenecek bilgisayar bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = XtraMessageBox.Show("Bilgisayar güncellensin mi?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            bilgisayar.BilgisayarAdi    = txtBilgisayarAdi.Text;
            bilgisayar.BilgisayarModeli = txtBilgisayarModeli.Text;
            bilgisayar.KurulumTarihi    = dateTarih.DateTime;
            bilgisayar.PersonelID       = (int)lookUpEditPersonel.EditValue;

            var mevcutProgramlar = db.ProgramBilgisayar
                .Where(pb => pb.BilgisayarID == _bilgisayarID)
                .ToList();
            db.ProgramBilgisayar.RemoveRange(mevcutProgramlar);

            foreach (var programID in seciliProgramlar)
            {
                db.ProgramBilgisayar.Add(new ProgramBilgisayar
                {
                    BilgisayarID = _bilgisayarID,
                    ProgramID = programID
                });
            }

            try
            {
                db.SaveChanges();
                XtraMessageBox.Show("Bilgisayar başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnBilgisayarGuncellendi();
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event EventHandler BilgisayarGuncellendi;

        protected virtual void OnBilgisayarGuncellendi()
        {
            BilgisayarGuncellendi?.Invoke(this, EventArgs.Empty);
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