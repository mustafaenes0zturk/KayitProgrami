using DevExpress.XtraEditors;
using pcKayitProgram.Entity;
using pcKayitProgram.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pcKayitProgram.Formlar
{
    public partial class FormQRCodeEtiket : DevExpress.XtraEditors.XtraForm
    {
        private dbPcKayitEntities3 db = new dbPcKayitEntities3();
        private int bilgisayarID;
        private string bilgisayarAdi;
        private string bilgisayarModeli;
        private string personelAdi;
        private DateTime kurulumTarihi;
        private Bitmap currentLabel;

        public FormQRCodeEtiket(int bilgisayarID, string bilgisayarAdi, string bilgisayarModeli, string personelAdi, DateTime kurulumTarihi)
        {
            InitializeComponent();
            
            this.bilgisayarID = bilgisayarID;
            this.bilgisayarAdi = bilgisayarAdi;
            this.bilgisayarModeli = bilgisayarModeli;
            this.personelAdi = personelAdi;
            this.kurulumTarihi = kurulumTarihi;
            
            this.Load += FormQRCodeEtiket_Load;
        }

        private void FormQRCodeEtiket_Load(object sender, EventArgs e)
        {
            try
            {
                // QR kod etiketini oluştur
                currentLabel = QRCodeHelper.CreateComputerLabel(
                    bilgisayarID, 
                    bilgisayarAdi, 
                    bilgisayarModeli, 
                    personelAdi, 
                    kurulumTarihi);

                // PictureBox'a etiket görselini yükle
                pictureBoxEtiket.Image = currentLabel;
                pictureBoxEtiket.SizeMode = PictureBoxSizeMode.Zoom;

                // Form başlığını güncelle
                this.Text = $"QR Kod Etiket - PC ID: {bilgisayarID}";

                // Bilgi labellarını güncelle
                lblBilgisayarID.Text = $"PC ID: {bilgisayarID}";
                lblBilgisayarAdi.Text = $"PC Adı: {bilgisayarAdi ?? "N/A"}";
                lblBilgisayarModeli.Text = $"Model: {bilgisayarModeli ?? "N/A"}";
                lblPersonelAdi.Text = $"Personel: {personelAdi ?? "N/A"}";
                lblKurulumTarihi.Text = $"Kurulum: {kurulumTarihi:dd.MM.yyyy}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"QR kod oluşturulurken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLabel != null)
                {
                    QRCodeHelper.PrintLabel(currentLabel);
                }
                else
                {
                    XtraMessageBox.Show("Yazdırılacak etiket bulunamadı.", 
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Yazdırma hatası: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLabel != null)
                {
                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "PNG Dosyası|*.png|JPEG Dosyası|*.jpg|Bitmap Dosyası|*.bmp";
                        saveDialog.Title = "QR Kod Etiketini Kaydet";
                        saveDialog.FileName = $"PC_Etiket_{bilgisayarID}_{DateTime.Now:yyyyMMdd_HHmmss}";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            QRCodeHelper.SaveLabelToFile(currentLabel, saveDialog.FileName);
                            XtraMessageBox.Show("Etiket başarıyla kaydedildi.", 
                                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Kaydedilecek etiket bulunamadı.", 
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kaydetme hatası: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut etiketi temizle
                if (currentLabel != null)
                {
                    currentLabel.Dispose();
                }

                // Yeni etiket oluştur
                currentLabel = QRCodeHelper.CreateComputerLabel(
                    bilgisayarID, 
                    bilgisayarAdi, 
                    bilgisayarModeli, 
                    personelAdi, 
                    kurulumTarihi);

                // PictureBox'ı güncelle
                pictureBoxEtiket.Image = currentLabel;

                XtraMessageBox.Show("Etiket yenilendi.", 
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Yenileme hatası: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Kaynakları temizle
            if (currentLabel != null)
            {
                currentLabel.Dispose();
            }
            
            base.OnFormClosed(e);
        }
    }
} 