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
    public partial class FormProgramSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int ProgramID;

        public FormProgramSil(int ProgramID, string ProgramAdi)
        {
            InitializeComponent();
            this.ProgramID     = ProgramID;
            txtProgramID.Text  = ProgramID.ToString();
            txtProgramAdi.Text = ProgramAdi;
        }

        public event EventHandler ProgramSilindi;

        private void btnProgramSil_Click(object sender, EventArgs e)
        {
            bool program = db.ProgramBilgisayar
                .Any(pb => pb.ProgramID == ProgramID);

            if (program)
            {
                XtraMessageBox.Show("Bu program bilgisayarlarda kullanılıyor. Lütfen ilgili bilgisayarları silin veya değiştirin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var programSil = db.ProgramTABLO
                .FirstOrDefault(p => p.ProgramID == ProgramID);

            if (programSil != null)
            {
                DialogResult sonuc = XtraMessageBox.Show("Program silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    db.ProgramTABLO.Remove(programSil);
                    db.SaveChanges();

                    XtraMessageBox.Show("Program başarılı bir şekilde silindi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ProgramSilindi?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("Silinecek program bulunamadı.",
                    "Silme Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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