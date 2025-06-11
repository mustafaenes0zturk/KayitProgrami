@echo off
title PC Kayit Programi - Kurulum
color 0A
echo.
echo ============================================
echo     PC KAYIT PROGRAMI KURULUM SISTEMI
echo ============================================
echo.

:: Yönetici yetkisi kontrolü
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo HATA: Bu script yönetici yetkisiyle çalıştırılmalıdır!
    echo Sağ tıklayıp "Yönetici olarak çalıştır" seçin.
    pause
    exit /b 1
)

echo [1/6] Sistem Hazırlığı...
echo - Windows sürümü kontrol ediliyor...
for /f "tokens=3" %%i in ('reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion" /v ProductName 2^>nul ^| find "ProductName"') do set "OS_NAME=%%i"
echo - İşletim Sistemi: %OS_NAME%

echo.
echo [2/6] .NET Framework 4.8 Kontrolü...
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release 2>nul | find "Release" >nul
if %errorLevel% neq 0 (
    echo - .NET Framework 4.8 kuruluyor...
    if exist "dotnet-framework-4.8.exe" (
        start /wait dotnet-framework-4.8.exe /quiet /norestart
        echo - .NET Framework 4.8 kurulumu tamamlandı.
    ) else (
        echo - UYARI: dotnet-framework-4.8.exe bulunamadı!
        echo - Manuel olarak Microsoft sitesinden indirip kurun.
    )
) else (
    echo - .NET Framework 4.8 zaten kurulu.
)

echo.
echo [3/6] SQL Server Express Kontrolü...
sc query "MSSQL$SQLEXPRESS" >nul 2>&1
if %errorLevel% neq 0 (
    echo - SQL Server Express kuruluyor...
    if exist "SQL_Server_Express.exe" (
        echo - Bu işlem 5-10 dakika sürebilir...
        start /wait SQL_Server_Express.exe /Q /ACTION=Install /FEATURES=SQLEngine /INSTANCENAME=SQLEXPRESS /SECURITYMODE=SQL /SAPWD=Admin123! /TCPENABLED=1 /NPENABLED=1
        echo - SQL Server Express kurulumu tamamlandı.
        
        echo - SQL Server servisleri başlatılıyor...
        net start "SQL Server (SQLEXPRESS)" >nul 2>&1
        net start "SQL Server Browser" >nul 2>&1
    ) else (
        echo - UYARI: SQL_Server_Express.exe bulunamadı!
        echo - Manuel olarak Microsoft sitesinden indirip kurun.
    )
) else (
    echo - SQL Server Express zaten kurulu.
    net start "SQL Server (SQLEXPRESS)" >nul 2>&1
    net start "SQL Server Browser" >nul 2>&1
)

echo.
echo [4/6] SQL Server Management Studio (SSMS) Kontrolü...
if exist "C:\Program Files (x86)\Microsoft SQL Server Management Studio 19\Common7\IDE\Ssms.exe" (
    echo - SSMS zaten kurulu.
) else (
    if exist "SSMS-Setup.exe" (
        echo - SSMS kuruluyor...
        start /wait SSMS-Setup.exe /S
        echo - SSMS kurulumu tamamlandı.
    ) else (
        echo - UYARI: SSMS-Setup.exe bulunamadı!
        echo - SSMS manuel olarak kurulmalı.
    )
)

echo.
echo [5/6] Veritabanı Oluşturuluyor...
if exist "..\DBYukleyici\bin\Release\DBYukleyici.exe" (
    echo - DBYukleyici çalıştırılıyor...
    cd /d "..\DBYukleyici\bin\Release"
    echo y | DBYukleyici.exe
    cd /d "%~dp0"
    echo - Veritabanı oluşturuldu.
) else (
    echo - HATA: DBYukleyici.exe bulunamadı!
    echo - Önce Visual Studio'da projeyi build edin.
)

echo.
echo [6/6] Firewall Ayarları...
echo - SQL Server için firewall kuralları ekleniyor...
netsh advfirewall firewall add rule name="SQL Server" dir=in action=allow protocol=TCP localport=1433 >nul 2>&1
netsh advfirewall firewall add rule name="SQL Browser" dir=in action=allow protocol=UDP localport=1434 >nul 2>&1

echo.
echo ============================================
echo            KURULUM TAMAMLANDI!
echo ============================================
echo.
echo Giriş Bilgileri:
echo - Kullanıcı Adı: admin
echo - Şifre: admin
echo.
echo Ana programı başlatmak için:
echo "%~dp0..\pcKayitProgram\bin\Release\pcKayitProgram.exe"
echo.
echo Veritabanı Bağlantısı:
echo - Server: .\SQLEXPRESS
echo - Database: dbPcKayit
echo.

pause

:: Ana programı başlat (isteğe bağlı)
set /p "STARTAPP=Ana programı şimdi başlatmak istiyor musunuz? (E/H): "
if /i "%STARTAPP%"=="E" (
    if exist "..\pcKayitProgram\bin\Release\pcKayitProgram.exe" (
        start "" "..\pcKayitProgram\bin\Release\pcKayitProgram.exe"
    ) else (
        echo HATA: Ana program bulunamadı! Önce Visual Studio'da build edin.
        pause
    )
) 