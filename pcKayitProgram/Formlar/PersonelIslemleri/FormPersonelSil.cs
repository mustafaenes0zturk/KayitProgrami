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
    public partial class FormPersonelSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int PersonelID;

        public FormPersonelSil(int PersonelID, string PersonelAdi, string SirketAdi, string DepartmanAdi, string UnvanAdi, string PersonelTel, string PersonelMail)
        {
            InitializeComponent();
            this.PersonelID      = PersonelID;
            txtID.Text           = PersonelID.ToString();
            txtPersonelAdi.Text  = PersonelAdi;
            txtSirketAdi.Text    = SirketAdi;
            txtDepartmanAdi.Text = DepartmanAdi;
            txtUnvanAdi.Text     = UnvanAdi;
            txtPersonelTel.Text  = PersonelTel;
            txtPersonelMail.Text = PersonelMail;
        }

        public event EventHandler PersonelSilindi;

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            var personel = db.PersonelTablosu.Find(PersonelID);
            if (personel != null)
            {
                bool hasComputers = db.BilgisayarTABLO.Any(b => b.PersonelID == PersonelID);

                if (hasComputers)
                {
                    XtraMessageBox.Show("Bu personele bağlı bilgisayarlar var. " +
                        "Silme işlemini gerçekleştirebilmek için ilgili bilgisayarları silin veya güncelleyin.",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult sonuc = XtraMessageBox.Show("Personel silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    try
                    {
                        db.PersonelTablosu.Remove(personel);
                        db.SaveChanges();

                        XtraMessageBox.Show("Personel başarılı bir şekilde silindi.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        PersonelSilindi?.Invoke(this, EventArgs.Empty);
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
                XtraMessageBox.Show("Silinecek personel bulunamadı.",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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