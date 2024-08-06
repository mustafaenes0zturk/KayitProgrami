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
    public partial class FormDepartmanEkle : DevExpress.XtraEditors.XtraForm
    {
        public FormDepartmanEkle()
        {
            InitializeComponent();
        }

        dbPcKayitEntities3 db = new dbPcKayitEntities3();

        public event EventHandler DepartmanKaydedildi;

        private void btnDepartmanKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartmanAdi.Text))
            {
                XtraMessageBox.Show("Lütfen bir departman adı giriniz." ,      
                    "Uyarı" ,
                    MessageBoxButtons.OK , 
                    MessageBoxIcon.Error);
                return;
            }

            var mevcutDepartman = db.DepartmanTablo
                .FirstOrDefault(s=> s.DepartmanAdi == txtDepartmanAdi.Text);
            if (mevcutDepartman != null)
            {
                XtraMessageBox.Show("Bu ada sahip bir departman zaten mevcut.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DepartmanTablo t = new DepartmanTablo();
            t.DepartmanAdi   = txtDepartmanAdi.Text;
            db.DepartmanTablo.Add(t);
            db.SaveChanges();

            XtraMessageBox.Show("Departman başarılı bir şekilde kaydedildi." ,
                "Bilgi" ,
                MessageBoxButtons.OK ,
                MessageBoxIcon.Information);

            txtDepartmanAdi.Text = string.Empty;

            DepartmanKaydedildi?.Invoke(this, EventArgs.Empty);
            Close();
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