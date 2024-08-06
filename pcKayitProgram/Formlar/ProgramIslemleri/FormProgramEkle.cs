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
    public partial class FormProgramEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormProgramEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler ProgramKaydedildi;

        private void btnProgramKaydet_Click(object sender, EventArgs e)
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
                .FirstOrDefault(s => s.ProgramAdi == txtProgramAdi.Text);
            if (mevcutProgram != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir program zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ProgramTABLO t = new ProgramTABLO();
            t.ProgramAdi   = txtProgramAdi.Text;
            db.ProgramTABLO.Add(t);
            db.SaveChanges();

            XtraMessageBox.Show("Program başarılı bir şekilde kaydedildi.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtProgramAdi.Text = string.Empty;

            ProgramKaydedildi?.Invoke(this, EventArgs.Empty);
            Close();
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