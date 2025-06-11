@echo off
title PC Kayit Programi - Sistem Kontrolu
color 0E
echo.
echo ============================================
echo    PC KAYIT PROGRAMI - SISTEM KONTROLU
echo ============================================
echo.

echo [1/8] İşletim Sistemi Kontrolü...
for /f "tokens=3*" %%i in ('reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion" /v ProductName 2^>nul ^| find "ProductName"') do set "OS_NAME=%%i %%j"
for /f "tokens=3" %%i in ('reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion" /v CurrentVersion 2^>nul ^| find "CurrentVersion"') do set "OS_VERSION=%%i"
echo - İşletim Sistemi: %OS_NAME%
echo - Sürüm: %OS_VERSION%

if "%OS_VERSION%" LSS "10.0" (
    echo ⚠️  UYARI: Windows 10 veya üzeri önerilir
) else (
    echo ✓ İşletim sistemi uyumlu
)

echo.
echo [2/8] .NET Framework Kontrolü...
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release >nul 2>&1
if %errorLevel% equ 0 (
    for /f "tokens=3" %%i in ('reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release 2^>nul ^| find "Release"') do set "NET_RELEASE=%%i"
    if !NET_RELEASE! GEQ 528040 (
        echo ✓ .NET Framework 4.8 kurulu
    ) else (
        echo ⚠️  .NET Framework 4.8 gerekli
    )
) else (
    echo ❌ .NET Framework bulunamadı
)

echo.
echo [3/8] SQL Server Kontrolü...
sc query "MSSQLSERVER" >nul 2>&1
if %errorLevel% equ 0 (
    echo ✓ SQL Server (Default Instance) bulundu
    sc query "MSSQLSERVER" | find "RUNNING" >nul
    if %errorLevel% equ 0 (
        echo ✓ SQL Server çalışıyor
    ) else (
        echo ⚠️  SQL Server durdurulmuş
    )
) else (
    sc query "MSSQL$SQLEXPRESS" >nul 2>&1
    if %errorLevel% equ 0 (
        echo ✓ SQL Server Express bulundu
        sc query "MSSQL$SQLEXPRESS" | find "RUNNING" >nul
        if %errorLevel% equ 0 (
            echo ✓ SQL Server Express çalışıyor
        ) else (
            echo ⚠️  SQL Server Express durdurulmuş
        )
    ) else (
        echo ❌ SQL Server bulunamadı
    )
)

echo.
echo [4/8] SQL Server Browser Kontrolü...
sc query "SQLBrowser" >nul 2>&1
if %errorLevel% equ 0 (
    sc query "SQLBrowser" | find "RUNNING" >nul
    if %errorLevel% equ 0 (
        echo ✓ SQL Server Browser çalışıyor
    ) else (
        echo ⚠️  SQL Server Browser durdurulmuş
    )
) else (
    echo ❌ SQL Server Browser bulunamadı
)

echo.
echo [5/8] Veritabanı Bağlantı Kontrolü...
sqlcmd -S ".\SQLEXPRESS" -Q "SELECT 1" >nul 2>&1
if %errorLevel% equ 0 (
    echo ✓ SQL Server Express bağlantısı başarılı
    
    sqlcmd -S ".\SQLEXPRESS" -Q "SELECT name FROM sys.databases WHERE name = 'dbPcKayit'" | find "dbPcKayit" >nul
    if %errorLevel% equ 0 (
        echo ✓ dbPcKayit veritabanı mevcut
    ) else (
        echo ⚠️  dbPcKayit veritabanı bulunamadı
    )
) else (
    sqlcmd -S "." -Q "SELECT 1" >nul 2>&1
    if %errorLevel% equ 0 (
        echo ✓ SQL Server bağlantısı başarılı
        
        sqlcmd -S "." -Q "SELECT name FROM sys.databases WHERE name = 'dbPcKayit'" | find "dbPcKayit" >nul
        if %errorLevel% equ 0 (
            echo ✓ dbPcKayit veritabanı mevcut
        ) else (
            echo ⚠️  dbPcKayit veritabanı bulunamadı
        )
    ) else (
        echo ❌ SQL Server bağlantısı başarısız
    )
)

echo.
echo [6/8] Firewall Port Kontrolü...
netstat -an | find ":1433 " >nul
if %errorLevel% equ 0 (
    echo ✓ Port 1433 açık (SQL Server)
) else (
    echo ⚠️  Port 1433 kapalı veya dinlenmiyor
)

netstat -an | find ":1434 " >nul
if %errorLevel% equ 0 (
    echo ✓ Port 1434 açık (SQL Browser)
) else (
    echo ⚠️  Port 1434 kapalı veya dinlenmiyor
)

echo.
echo [7/8] Program Dosyaları Kontrolü...
if exist "..\pcKayitProgram\bin\Release\pcKayitProgram.exe" (
    echo ✓ Ana program dosyası mevcut
) else (
    echo ❌ Ana program dosyası bulunamadı
    echo   - Visual Studio'da projeyi Release modunda build edin
)

if exist "..\DBYukleyici\bin\Release\DBYukleyici.exe" (
    echo ✓ DBYukleyici dosyası mevcut
) else (
    echo ❌ DBYukleyici dosyası bulunamadı
    echo   - Visual Studio'da DBYukleyici projesini Release modunda build edin
)

if exist "..\pcKayitProgram\App.config" (
    echo ✓ App.config dosyası mevcut
) else (
    echo ❌ App.config dosyası bulunamadı
)

echo.
echo [8/8] Sistem Kaynakları Kontrolü...
for /f "tokens=2 delims=:" %%i in ('systeminfo ^| find "Total Physical Memory"') do set "TOTAL_RAM=%%i"
echo - Toplam RAM:%TOTAL_RAM%

for /f "tokens=3" %%i in ('dir C:\ ^| find "bytes free"') do set "FREE_SPACE=%%i"
echo - C:\ Boş Alan: %FREE_SPACE% bytes

echo.
echo ============================================
echo            KONTROL TAMAMLANDI
echo ============================================
echo.

:: Özet rapor
set "ISSUES=0"
echo ÖZET RAPOR:
echo.

reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release >nul 2>&1
if %errorLevel% neq 0 (
    echo ❌ .NET Framework 4.8 kurulmalı
    set /a ISSUES+=1
)

sc query "MSSQLSERVER" >nul 2>&1 || sc query "MSSQL$SQLEXPRESS" >nul 2>&1
if %errorLevel% neq 0 (
    echo ❌ SQL Server kurulmalı
    set /a ISSUES+=1
)

sqlcmd -S ".\SQLEXPRESS" -Q "SELECT 1" >nul 2>&1 || sqlcmd -S "." -Q "SELECT 1" >nul 2>&1
if %errorLevel% neq 0 (
    echo ❌ SQL Server bağlantısı düzeltilmeli
    set /a ISSUES+=1
)

if not exist "..\pcKayitProgram\bin\Release\pcKayitProgram.exe" (
    echo ❌ Ana program build edilmeli
    set /a ISSUES+=1
)

if not exist "..\DBYukleyici\bin\Release\DBYukleyici.exe" (
    echo ❌ DBYukleyici build edilmeli
    set /a ISSUES+=1
)

if %ISSUES% equ 0 (
    echo ✓ Sistem kuruluma hazır!
    echo.
    echo ÖNERİLEN İŞLEMLER:
    echo 1. Setup\install.bat ile kurulumu başlatın
    echo 2. Database\DBYukleyici.exe ile veritabanını oluşturun
    echo 3. Ana programı çalıştırın
) else (
    echo.
    echo ⚠️  %ISSUES% sorun tespit edildi.
    echo Yukarıdaki sorunları çözdükten sonra tekrar kontrol edin.
)

echo.
pause

:: Otomatik çözüm teklifi
if %ISSUES% gtr 0 (
    echo.
    set /p "AUTO_FIX=Otomatik kurulum başlatmak istiyor musunuz? (E/H): "
    if /i "%AUTO_FIX%"=="E" (
        echo.
        echo Otomatik kurulum başlatılıyor...
        call install.bat
    )
) 