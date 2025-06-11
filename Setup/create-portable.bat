@echo off
title PC Kayit Programi - Portable Paket Olusturucu
color 0C
echo.
echo ============================================
echo  PC KAYIT PROGRAMI - PORTABLE OLUSTURUCU
echo ============================================
echo.

set "PORTABLE_DIR=PC_Kayit_Portable"
set "CURRENT_DIR=%~dp0"

echo [1/7] Portable klasör hazırlanıyor...
if exist "%PORTABLE_DIR%" rd /s /q "%PORTABLE_DIR%"
mkdir "%PORTABLE_DIR%"
mkdir "%PORTABLE_DIR%\Program"
mkdir "%PORTABLE_DIR%\Setup"
mkdir "%PORTABLE_DIR%\Database"

echo [2/7] Program dosyaları kopyalanıyor...
if exist "..\pcKayitProgram\bin\Release" (
    xcopy "..\pcKayitProgram\bin\Release\*" "%PORTABLE_DIR%\Program\" /s /e /y >nul
    echo - Ana program dosyaları kopyalandı
) else (
    echo HATA: pcKayitProgram\bin\Release bulunamadı!
    echo Önce Visual Studio'da projeyi Release modunda build edin.
    pause
    exit /b 1
)

echo [3/7] Veritabanı yükleyici kopyalanıyor...
if exist "..\DBYukleyici\bin\Release" (
    xcopy "..\DBYukleyici\bin\Release\*" "%PORTABLE_DIR%\Database\" /s /e /y >nul
    echo - DBYukleyici dosyaları kopyalandı
) else (
    echo HATA: DBYukleyici\bin\Release bulunamadı!
    echo Önce Visual Studio'da DBYukleyici projesini Release modunda build edin.
    pause
    exit /b 1
)

echo [4/7] Kurulum scriptleri kopyalanıyor...
copy "install.bat" "%PORTABLE_DIR%\Setup\" >nul 2>&1
copy "config-server.bat" "%PORTABLE_DIR%\Setup\" >nul 2>&1
echo - Kurulum scriptleri kopyalandı

echo [5/7] README dosyası kopyalanıyor...
copy "..\README.md" "%PORTABLE_DIR%\" >nul 2>&1
echo - Dokümantasyon kopyalandı

echo [6/7] Başlatıcı script oluşturuluyor...
(
echo @echo off
echo title PC Kayit Programi
echo cd /d "%%~dp0Program"
echo if exist "pcKayitProgram.exe" ^(
echo     start "" "pcKayitProgram.exe"
echo ^) else ^(
echo     echo HATA: pcKayitProgram.exe bulunamadi!
echo     pause
echo ^)
) > "%PORTABLE_DIR%\PC_Kayit_Baslat.bat"

echo [7/7] Kurulum rehberi oluşturuluyor...
(
echo ============================================
echo     PC KAYIT PROGRAMI - PORTABLE SURUM
echo ============================================
echo.
echo KURULUM ADIMLARI:
echo.
echo 1. GEREKSINIMLER KURULUMU:
echo    - Setup\install.bat dosyasini yonetici olarak calistirin
echo    - Bu dosya .NET Framework ve SQL Server Express kuracak
echo.
echo 2. VERITABANI KURULUMU:
echo    - Database\DBYukleyici.exe dosyasini calistirin
echo    - Bu dosya gerekli veritabanini olusturacak
echo.
echo 3. SERVER AYARLARI ^(isteege bagli^):
echo    - Setup\config-server.bat ile server ayarlarini degistirebilirsiniz
echo    - Varsayilan ayarlar cogu sistem icin yeterlidir
echo.
echo 4. PROGRAMI BASLATMA:
echo    - PC_Kayit_Baslat.bat dosyasini calistirin
echo    - Veya Program\pcKayitProgram.exe dosyasini dogrudan calistirin
echo.
echo GIRIS BILGILERI:
echo - Kullanici Adi: admin
echo - Sifre: admin
echo.
echo SORUN GIDERME:
echo - README.md dosyasindaki sorun giderme bolumunu inceleyin
echo - SQL Server servislerinin calistigini kontrol edin
echo - Windows Firewall ayarlarini kontrol edin
echo.
echo DESTEK:
echo - Detayli bilgi icin README.md dosyasini okuyun
echo.
echo ============================================
) > "%PORTABLE_DIR%\KURULUM_REHBERI.txt"

echo.
echo ============================================
echo        PORTABLE PAKET HAZIRLANDI!
echo ============================================
echo.
echo Portable paket konumu: %PORTABLE_DIR%
echo.
echo Paket içeriği:
echo ├── PC_Kayit_Baslat.bat      ^(Ana program başlatıcı^)
echo ├── KURULUM_REHBERI.txt      ^(Kurulum talimatları^)
echo ├── README.md                ^(Detaylı dokümantasyon^)
echo ├── Program\                 ^(Ana program dosyaları^)
echo ├── Database\                ^(Veritabanı yükleyici^)
echo └── Setup\                   ^(Kurulum scriptleri^)
echo.
echo Bu klasörü başka bilgisayarlara kopyalayabilirsiniz.
echo.

:: ZIP oluşturma teklifi
set /p "CREATE_ZIP=Portable paketi ZIP olarak sıkıştırmak istiyor musunuz? (E/H): "
if /i "%CREATE_ZIP%"=="E" (
    echo.
    echo ZIP dosyası oluşturuluyor...
    powershell -command "Compress-Archive -Path '%PORTABLE_DIR%' -DestinationPath 'PC_Kayit_Portable.zip' -Force"
    if exist "PC_Kayit_Portable.zip" (
        echo ✓ ZIP dosyası oluşturuldu: PC_Kayit_Portable.zip
    ) else (
        echo ✗ ZIP dosyası oluşturulamadı!
    )
)

echo.
pause

:: Explorer'da klasörü açma teklifi
set /p "OPEN_FOLDER=Portable klasörünü açmak istiyor musunuz? (E/H): "
if /i "%OPEN_FOLDER%"=="E" (
    start "" "%PORTABLE_DIR%"
) 