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
    public partial class FormDepartmanSil : DevExpress.XtraEditors.XtraForm
    {
        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public int DepartmanID;

        public FormDepartmanSil(int DepartmanID, string DepartmanAdi)
        {
            InitializeComponent();
            this.DepartmanID     = DepartmanID;
            txtDepID.Text = DepartmanID.ToString();
            txtDepartmanAdi.Text = DepartmanAdi;
        }

        public event EventHandler DepartmanSilindi;

        private void btnDepartmanSil_Click(object sender, EventArgs e)
        {
            var departman = db.DepartmanTablo.Find(DepartmanID);
            if (departman != null)
            {
                var ilgiliPersoneller = db.PersonelTablosu
                    .Where(p => p.DepartmanID == DepartmanID)
                    .ToList();
                if (ilgiliPersoneller.Any())
                {
                    XtraMessageBox.Show("Bu departmana bağlı personeller var. Lütfen önce bu personellerin departmanlarını değiştirin veya silin.",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult sonuc = XtraMessageBox.Show("Departman silinsin mi?",
                    "Bilgi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    db.DepartmanTablo.Remove(departman);
                    db.SaveChanges();

                    XtraMessageBox.Show("Departman başarılı bir şekilde silindi.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DepartmanSilindi?.Invoke(this, EventArgs.Empty);
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