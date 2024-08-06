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
    public partial class FormProgramGuncelle : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int ProgramID;

        public FormProgramGuncelle(int ProgramID, string ProgramAdi)
        {
            InitializeComponent();
            this.ProgramID     = ProgramID;
            txtProgramID.Text  = ProgramID.ToString();
            txtProgramAdi.Text = ProgramAdi;
        }

        public event EventHandler ProgramGuncellendi;

        private void btnProgramGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProgramAdi.Text))
            {
                XtraMessageBox.Show("Lütfen bir program adı girin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutProgram = db.ProgramTABLO
                .FirstOrDefault(p => p.ProgramAdi == txtProgramAdi.Text && p.ProgramID != ProgramID);

            if (mevcutProgram != null)
            {
                XtraMessageBox.Show("Bu ada sahip program zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = XtraMessageBox.Show("Program güncellensin mi?",
                "Bilgi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var program = db.ProgramTABLO.Find(ProgramID);
                if (program != null)
                {
                    program.ProgramAdi = txtProgramAdi.Text;
                    db.SaveChanges();

                    XtraMessageBox.Show("Program başarılı bir şekilde güncellendi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ProgramGuncellendi?.Invoke(this, EventArgs.Empty);
                    GlobalEvents.OnDataChanged();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnProgramİptal_Click(object sender, EventArgs e)
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