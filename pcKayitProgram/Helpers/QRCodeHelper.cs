using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace pcKayitProgram.Helpers
{
    public static class QRCodeHelper
    {
        /// <summary>
        /// Bilgisayar bilgileri için QR kod üretir
        /// </summary>
        /// <param name="bilgisayarID">Bilgisayar ID</param>
        /// <param name="bilgisayarAdi">Bilgisayar Adı</param>
        /// <param name="bilgisayarModeli">Bilgisayar Modeli</param>
        /// <param name="personelAdi">Personel Adı</param>
        /// <param name="kurulumTarihi">Kurulum Tarihi</param>
        /// <returns>QR kod bitmap</returns>
        public static Bitmap GenerateQRCode(int bilgisayarID, string bilgisayarAdi, string bilgisayarModeli, string personelAdi, DateTime kurulumTarihi)
        {
            // QR kod için veri string'i oluştur
            string qrData = CreateQRDataString(bilgisayarID, bilgisayarAdi, bilgisayarModeli, personelAdi, kurulumTarihi);
            
            // Google Charts API kullanarak gerçek QR kod oluştur
            return CreateRealQRCode(qrData, 200, 200);
        }

        /// <summary>
        /// QR kod için veri string'i oluşturur (Web URL formatında)
        /// </summary>
        private static string CreateQRDataString(int bilgisayarID, string bilgisayarAdi, string bilgisayarModeli, string personelAdi, DateTime kurulumTarihi)
        {
            // URL encode için gerekli karakterleri temizle ve kısa tut
            string cleanPcAdi = Uri.EscapeDataString(bilgisayarAdi ?? "N/A");
            string cleanModel = Uri.EscapeDataString(bilgisayarModeli ?? "N/A");
            string cleanPersonel = Uri.EscapeDataString(personelAdi ?? "N/A");
            string cleanKurulum = Uri.EscapeDataString(kurulumTarihi.ToString("dd.MM.yyyy"));

            // Web sayfası URL'si oluştur (dinamik port ile)
            int port = WebServerHelper.IsRunning ? WebServerHelper.Port : 8080;
            var url = $"http://localhost:{port}/bilgisayar-detay.html?" +
                     $"id={bilgisayarID}&" +
                     $"ad={cleanPcAdi}&" +
                     $"model={cleanModel}&" +
                     $"personel={cleanPersonel}&" +
                     $"kurulum={cleanKurulum}";
            
            // URL uzunluğunu kontrol et (QR kod için maksimum ~2000 karakter önerilir)
            if (url.Length > 1500)
            {
                // Çok uzunsa sadece ID ve temel bilgileri içer
                url = $"http://localhost:8080/bilgisayar-detay.html?id={bilgisayarID}&ad={Uri.EscapeDataString((bilgisayarAdi ?? "PC").Substring(0, Math.Min(20, (bilgisayarAdi ?? "PC").Length)))}";
            }
            
            return url;
        }

        /// <summary>
        /// Google Charts API kullanarak gerçek QR kod oluşturur
        /// </summary>
        private static Bitmap CreateRealQRCode(string data, int width, int height)
        {
            try
            {
                // Google Charts QR Code API URL'si - daha kararlı API endpoint
                string encodedData = Uri.EscapeDataString(data);
                string apiUrl = $"https://api.qrserver.com/v1/create-qr-code/?size={width}x{height}&data={encodedData}";

                using (WebClient webClient = new WebClient())
                {
                    // User-Agent header ekleyelim
                    webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
                    
                    byte[] imageBytes = webClient.DownloadData(apiUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata detayını loglayalım
                System.Diagnostics.Debug.WriteLine($"QR Kod oluşturma hatası: {ex.Message}");
                
                // Hata durumunda basit QR kod benzeri görsel oluştur
                return CreateSimpleQRCode(data, width, height);
            }
        }

        /// <summary>
        /// Basit QR kod benzeri görsel oluşturur (fallback)
        /// </summary>
        private static Bitmap CreateSimpleQRCode(string data, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                // Beyaz arka plan
                graphics.Clear(Color.White);
                
                // Siyah çerçeve
                using (var pen = new Pen(Color.Black, 2))
                {
                    graphics.DrawRectangle(pen, 5, 5, width - 10, height - 10);
                }

                // QR kod benzeri pattern oluştur
                var random = new Random(data.GetHashCode()); // Aynı veri için aynı pattern
                var blockSize = 6;
                
                for (int x = 20; x < width - 20; x += blockSize)
                {
                    for (int y = 20; y < height - 20; y += blockSize)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            using (var brush = new SolidBrush(Color.Black))
                            {
                                graphics.FillRectangle(brush, x, y, blockSize - 1, blockSize - 1);
                            }
                        }
                    }
                }

                // URL'yi QR kod altına yazdır (küçük font ile)
                using (var urlFont = new Font("Arial", 6, FontStyle.Regular))
                using (var urlBrush = new SolidBrush(Color.DarkBlue))
                {
                    var shortUrl = data.Length > 30 ? data.Substring(0, 30) + "..." : data;
                    var urlSize = graphics.MeasureString(shortUrl, urlFont);
                    graphics.DrawString(shortUrl, urlFont, urlBrush, 
                        (width - urlSize.Width) / 2, height - 15);
                }

                // Köşe işaretleri (QR kod benzeri)
                DrawCornerMarker(graphics, 15, 15, 25);
                DrawCornerMarker(graphics, width - 40, 15, 25);
                DrawCornerMarker(graphics, 15, height - 40, 25);
            }
            
            return bitmap;
        }

        /// <summary>
        /// QR kod köşe işaretlerini çizer
        /// </summary>
        private static void DrawCornerMarker(Graphics graphics, int x, int y, int size)
        {
            using (var brush = new SolidBrush(Color.Black))
            {
                // Dış kare
                graphics.FillRectangle(brush, x, y, size, size);
                
                // İç beyaz kare
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    graphics.FillRectangle(whiteBrush, x + 3, y + 3, size - 6, size - 6);
                }
                
                // Merkez siyah kare
                graphics.FillRectangle(brush, x + 8, y + 8, size - 16, size - 16);
            }
        }

        /// <summary>
        /// QR kod ile birlikte etiket oluşturur
        /// </summary>
        public static Bitmap CreateComputerLabel(int bilgisayarID, string bilgisayarAdi, string bilgisayarModeli, string personelAdi, DateTime kurulumTarihi)
        {
            var labelWidth = 400;
            var labelHeight = 300;
            var qrSize = 150;
            
            var bitmap = new Bitmap(labelWidth, labelHeight);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                // Başlık
                using (var titleFont = new Font("Arial", 14, FontStyle.Bold))
                using (var titleBrush = new SolidBrush(Color.DarkBlue))
                {
                    var title = "PC KAYIT SİSTEMİ";
                    var titleSize = graphics.MeasureString(title, titleFont);
                    graphics.DrawString(title, titleFont, titleBrush, 
                        (labelWidth - titleSize.Width) / 2, 10);
                }

                // QR kod
                var qrCode = GenerateQRCode(bilgisayarID, bilgisayarAdi, bilgisayarModeli, personelAdi, kurulumTarihi);
                graphics.DrawImage(qrCode, 10, 40, qrSize, qrSize);

                // Bilgi metinleri
                using (var infoFont = new Font("Arial", 10, FontStyle.Regular))
                using (var infoBrush = new SolidBrush(Color.Black))
                {
                    var startY = 50;
                    var lineHeight = 20;
                    var leftMargin = qrSize + 20;

                    graphics.DrawString($"PC ID: {bilgisayarID}", infoFont, infoBrush, leftMargin, startY);
                    graphics.DrawString($"PC Adı: {bilgisayarAdi ?? "N/A"}", infoFont, infoBrush, leftMargin, startY + lineHeight);
                    graphics.DrawString($"Model: {bilgisayarModeli ?? "N/A"}", infoFont, infoBrush, leftMargin, startY + lineHeight * 2);
                    graphics.DrawString($"Personel: {personelAdi ?? "N/A"}", infoFont, infoBrush, leftMargin, startY + lineHeight * 3);
                    graphics.DrawString($"Kurulum: {kurulumTarihi:dd.MM.yyyy}", infoFont, infoBrush, leftMargin, startY + lineHeight * 4);
                }

                // Alt bilgi
                using (var footerFont = new Font("Arial", 8, FontStyle.Italic))
                using (var footerBrush = new SolidBrush(Color.Gray))
                {
                    var footer = $"Oluşturulma: {DateTime.Now:dd.MM.yyyy HH:mm}";
                    var footerSize = graphics.MeasureString(footer, footerFont);
                    graphics.DrawString(footer, footerFont, footerBrush, 
                        labelWidth - footerSize.Width - 10, labelHeight - 25);
                }

                // QR kod açıklama metni
                using (var qrFont = new Font("Arial", 8, FontStyle.Bold))
                using (var qrBrush = new SolidBrush(Color.DarkBlue))
                {
                    var qrText = "📱 QR kodu tarayarak web sayfasını açın";
                    graphics.DrawString(qrText, qrFont, qrBrush, 10, labelHeight - 45);
                }

                // Çerçeve
                using (var pen = new Pen(Color.DarkBlue, 2))
                {
                    graphics.DrawRectangle(pen, 2, 2, labelWidth - 4, labelHeight - 4);
                }
            }
            
            return bitmap;
        }

        /// <summary>
        /// Bitmap'i dosyaya kaydeder
        /// </summary>
        public static void SaveLabelToFile(Bitmap label, string filePath)
        {
            label.Save(filePath, ImageFormat.Png);
        }

        /// <summary>
        /// Etiket yazdırma için hazırlar
        /// </summary>
        public static void PrintLabel(Bitmap label)
        {
            try
            {
                var printDocument = new System.Drawing.Printing.PrintDocument();
                printDocument.PrintPage += (sender, e) =>
                {
                    // Sayfanın ortasına yerleştir
                    var x = (e.PageBounds.Width - label.Width) / 2;
                    var y = (e.PageBounds.Height - label.Height) / 2;
                    e.Graphics.DrawImage(label, x, y);
                };

                // Yazdırma dialog'u göster
                var printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.Document = printDocument;
                
                if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Yazdırma hatası: {ex.Message}", "Hata", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
} 