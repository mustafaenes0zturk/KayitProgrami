using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace pcKayitProgram.Helpers
{
    /// <summary>
    /// QR kodlar için gömülü web sunucusu
    /// Uygulama başladığında otomatik olarak çalışır
    /// </summary>
    public static class WebServerHelper
    {
        private static HttpListener _listener;
        private static Thread _serverThread;
        private static bool _isRunning = false;
        private static int _port = 8080;

        /// <summary>
        /// Web sunucusunu başlatır (uygulama başladığında çağrılır)
        /// </summary>
        public static bool StartServer(int port = 8080)
        {
            if (_isRunning)
                return true;

            try
            {
                _port = port;
                _listener = new HttpListener();
                _listener.Prefixes.Add($"http://localhost:{port}/");
                
                _listener.Start();
                _isRunning = true;

                // Arka planda sunucu thread'i başlat
                _serverThread = new Thread(ServerLoop)
                {
                    IsBackground = true,
                    Name = "QR Kod Web Sunucusu"
                };
                _serverThread.Start();

                System.Diagnostics.Debug.WriteLine($"🚀 QR Kod Web Sunucusu başlatıldı: http://localhost:{port}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Web sunucusu başlatma hatası: {ex.Message}");
                
                // Port 8080 meşgulse 8081'i dene
                if (port == 8080)
                {
                    return StartServer(8081);
                }
                return false;
            }
        }

        /// <summary>
        /// Web sunucusunu durdurur
        /// </summary>
        public static void StopServer()
        {
            if (!_isRunning)
                return;

            try
            {
                _isRunning = false;
                _listener?.Stop();
                _listener?.Close();
                _listener = null;

                // Thread'in bitmesini bekle
                _serverThread?.Join(1000);
                
                System.Diagnostics.Debug.WriteLine("🛑 QR Kod Web Sunucusu durduruldu");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Web sunucusu durdurma hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Sunucunun çalışıp çalışmadığını kontrol eder
        /// </summary>
        public static bool IsRunning => _isRunning;

        /// <summary>
        /// Aktif port numarasını döndürür
        /// </summary>
        public static int Port => _port;

        /// <summary>
        /// Ana sunucu döngüsü
        /// </summary>
        private static void ServerLoop()
        {
            while (_isRunning && _listener != null)
            {
                try
                {
                    // Request bekle
                    var context = _listener.GetContext();
                    
                    // Async olarak işle
                    Task.Run(() => ProcessRequest(context));
                }
                catch (HttpListenerException)
                {
                    // Sunucu durdurulduğunda normal
                    break;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Sunucu döngüsü hatası: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// HTTP request'lerini işler
        /// </summary>
        private static void ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            try
            {
                // QR kod sayfası
                if (request.Url.AbsolutePath == "/bilgisayar-detay.html")
                {
                    ServeHtmlPage(response, request.Url.Query);
                }
                // Ana sayfa
                else if (request.Url.AbsolutePath == "/")
                {
                    ServeWelcomePage(response);
                }
                // Diğer dosyalar
                else
                {
                    response.StatusCode = 404;
                    var notFoundBytes = Encoding.UTF8.GetBytes("404 - Sayfa bulunamadı");
                    response.OutputStream.Write(notFoundBytes, 0, notFoundBytes.Length);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Request işleme hatası: {ex.Message}");
                response.StatusCode = 500;
            }
            finally
            {
                response.Close();
            }
        }

        /// <summary>
        /// PC detay HTML sayfasını sunar
        /// </summary>
        private static void ServeHtmlPage(HttpListenerResponse response, string queryString)
        {
            var html = GenerateHtmlPage(queryString);
            var buffer = Encoding.UTF8.GetBytes(html);
            
            response.ContentType = "text/html; charset=utf-8";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Karşılama sayfasını sunar
        /// </summary>
        private static void ServeWelcomePage(HttpListenerResponse response)
        {
            var html = @"
<!DOCTYPE html>
<html lang='tr'>
<head>
    <meta charset='UTF-8'>
    <title>PC Kayıt Sistemi - QR Sunucu</title>
    <style>
        body { font-family: Arial, sans-serif; text-align: center; padding: 50px; background: #f5f5f5; }
        .container { max-width: 600px; margin: 0 auto; background: white; padding: 30px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }
        h1 { color: #333; }
        .status { color: #28a745; font-size: 18px; font-weight: bold; }
    </style>
</head>
<body>
    <div class='container'>
        <h1>🚀 PC Kayıt Sistemi</h1>
        <p class='status'>✅ QR Kod Sunucusu Çalışıyor!</p>
        <p>QR kodlarınız artık düzgün çalışacak.</p>
        <p><strong>Port:</strong> " + _port + @"</p>
        <p><small>Bu sayfa QR kodlar için otomatik olarak oluşturulmuştur.</small></p>
    </div>
</body>
</html>";

            var buffer = Encoding.UTF8.GetBytes(html);
            response.ContentType = "text/html; charset=utf-8";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// PC detay HTML sayfasını dinamik olarak oluşturur
        /// </summary>
        private static string GenerateHtmlPage(string queryString)
        {
            // URL parametrelerini çöz
            var query = HttpUtility.ParseQueryString(queryString);
            var pcId = query["id"] ?? "N/A";
            var pcAd = query["ad"] ?? "N/A";
            var pcModel = query["model"] ?? "N/A";
            var personel = query["personel"] ?? "N/A";
            var kurulum = query["kurulum"] ?? "N/A";

            return $@"
<!DOCTYPE html>
<html lang='tr'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>PC Kayıt Sistemi - Bilgisayar Detayları</title>
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        body {{ 
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh; display: flex; align-items: center; justify-content: center; padding: 20px;
        }}
        .container {{ 
            background: white; border-radius: 20px; box-shadow: 0 20px 40px rgba(0,0,0,0.1);
            padding: 40px; max-width: 500px; width: 100%; text-align: center;
        }}
        .header {{ margin-bottom: 30px; }}
        .logo {{ 
            width: 80px; height: 80px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            border-radius: 50%; margin: 0 auto 20px; display: flex; align-items: center; justify-content: center;
            color: white; font-size: 30px; font-weight: bold;
        }}
        h1 {{ color: #333; font-size: 24px; margin-bottom: 10px; }}
        .subtitle {{ color: #666; font-size: 14px; }}
        .info-card {{ background: #f8f9fa; border-radius: 15px; padding: 25px; margin: 20px 0; text-align: left; }}
        .info-row {{ display: flex; justify-content: space-between; align-items: center; padding: 12px 0; border-bottom: 1px solid #e9ecef; }}
        .info-row:last-child {{ border-bottom: none; }}
        .info-label {{ font-weight: 600; color: #495057; font-size: 14px; }}
        .info-value {{ color: #212529; font-size: 14px; font-weight: 500; }}
        .pc-id {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 8px 16px; border-radius: 20px; font-size: 12px; font-weight: bold; }}
        .status {{ background: #28a745; color: white; padding: 6px 12px; border-radius: 15px; font-size: 12px; font-weight: bold; }}
        .footer {{ margin-top: 30px; padding-top: 20px; border-top: 1px solid #e9ecef; color: #6c757d; font-size: 12px; }}
        .qr-info {{ background: #e3f2fd; border: 1px solid #bbdefb; border-radius: 10px; padding: 15px; margin: 20px 0; color: #1565c0; font-size: 13px; }}
        @media (max-width: 480px) {{ .container {{ padding: 20px; margin: 10px; }} .info-row {{ flex-direction: column; align-items: flex-start; gap: 5px; }} }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <div class='logo'>PC</div>
            <h1>PC Kayît Sistemi</h1>
            <p class='subtitle'>Bilgisayar Detay Bilgileri</p>
        </div>

        <div class='info-card'>
            <div class='info-row'>
                <span class='info-label'>PC ID:</span>
                <span class='pc-id'>{pcId}</span>
            </div>
            <div class='info-row'>
                <span class='info-label'>Bilgisayar Adı:</span>
                <span class='info-value'>{pcAd}</span>
            </div>
            <div class='info-row'>
                <span class='info-label'>Model:</span>
                <span class='info-value'>{pcModel}</span>
            </div>
            <div class='info-row'>
                <span class='info-label'>Zimmetli Personel:</span>
                <span class='info-value'>{personel}</span>
            </div>
            <div class='info-row'>
                <span class='info-label'>Kurulum Tarihi:</span>
                <span class='info-value'>{kurulum}</span>
            </div>
            <div class='info-row'>
                <span class='info-label'>Durum:</span>
                <span class='status'>Aktif</span>
            </div>
        </div>

        <div class='qr-info'>
            <strong>📱 QR Kod Tarandı!</strong><br>
            Bu bilgiler QR kod taraması ile otomatik olarak yüklendi.
        </div>

        <div class='footer'>
            <p>Son güncelleme: {DateTime.Now:dd.MM.yyyy HH:mm}</p>
            <p>© 2024 PC Kayıt Sistemi - Tüm hakları saklıdır.</p>
        </div>
    </div>
</body>
</html>";
        }
    }
} 