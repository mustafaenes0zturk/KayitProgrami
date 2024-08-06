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
    public partial class BilgisayarSilForm : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int BilgisayarID { get; private set; }

        public BilgisayarSilForm(int BilgisayarID, string BilgisayarAdi, string BilgisayarModeli, List<string> programlar, string PersonelAdi, DateTime kurulumTarihi)
        {
            InitializeComponent();
            this.BilgisayarID        = BilgisayarID;
            txtBilgisayarID.Text = BilgisayarID.ToString();
            txtBilgisayarAdi.Text    = BilgisayarAdi;
            txtBilgisayarModeli.Text = BilgisayarModeli;
            txtPersonelAdi.Text      = PersonelAdi;
            dateTarih.DateTime       = kurulumTarihi;
            txtProgramlar.Text       = string.Join(", ", programlar);
        }

        public event EventHandler BilgisayarSilindi;

        private void btnBilgisayarSil_Click(object sender, EventArgs e)
        {
            var bilgisayar  = db.BilgisayarTABLO.Find(BilgisayarID);
            if (bilgisayar != null)
            {
                DialogResult sonuc = XtraMessageBox.Show("Bilgisayar silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    var programBilgisayarRecords = db.ProgramBilgisayar
                        .Where(bp => bp.BilgisayarID == BilgisayarID)
                        .ToList();
                    db.ProgramBilgisayar.RemoveRange(programBilgisayarRecords);
                    db.BilgisayarTABLO.Remove(bilgisayar);

                    try
                    {
                        db.SaveChanges();
                        XtraMessageBox.Show("Bilgisayar başarılı bir şekilde silindi.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        BilgisayarSilindi?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("Silinecek bilgisayar bulunamadı.",
                    "Silme Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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