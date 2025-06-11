@echo off
title PC Kayit Programi - Server Ayarlari
color 0B
echo.
echo ============================================
echo   PC KAYIT PROGRAMI - SERVER AYARLARI
echo ============================================
echo.

set "CONFIG_FILE=..\pcKayitProgram\App.config"
set "DBLOADER_FILE=..\DBYukleyici\Program.cs"

if not exist "%CONFIG_FILE%" (
    echo HATA: App.config dosyası bulunamadı!
    echo Dosya yolu: %CONFIG_FILE%
    pause
    exit /b 1
)

echo Mevcut Server Ayarları:
echo.
echo 1. Yerel bilgisayar (localhost/.)
echo 2. Yerel SQL Server Express (.\SQLEXPRESS)  [ÖNERİLEN]
echo 3. Ağdaki başka bilgisayar (IP/Bilgisayar adı)
echo 4. Manuel connection string girişi
echo.

set /p "CHOICE=Seçiminizi yapın (1-4): "

if "%CHOICE%"=="1" (
    set "SERVER_NAME=."
    set "INSTANCE_NAME="
) else if "%CHOICE%"=="2" (
    set "SERVER_NAME=.\SQLEXPRESS"
    set "INSTANCE_NAME="
) else if "%CHOICE%"=="3" (
    set /p "SERVER_NAME=Server adı veya IP adresi girin: "
    set "INSTANCE_NAME="
) else if "%CHOICE%"=="4" (
    goto :manual_config
) else (
    echo Geçersiz seçim!
    pause
    exit /b 1
)

echo.
echo Authentication yöntemi seçin:
echo 1. Windows Authentication (Önerilen)
echo 2. SQL Server Authentication
echo.
set /p "AUTH_CHOICE=Seçim (1-2): "

if "%AUTH_CHOICE%"=="1" (
    set "AUTH_STRING=integrated security=True"
    set "CS_AUTH_STRING=Integrated Security=True"
) else if "%AUTH_CHOICE%"=="2" (
    set /p "SQL_USER=SQL Server kullanıcı adı: "
    set /p "SQL_PASS=SQL Server şifresi: "
    set "AUTH_STRING=User ID=%SQL_USER%;Password=%SQL_PASS%"
    set "CS_AUTH_STRING=User ID=%SQL_USER%;Password=%SQL_PASS%"
) else (
    echo Geçersiz seçim!
    pause
    exit /b 1
)

goto :update_config

:manual_config
echo.
echo Manuel Connection String girişi:
echo Örnek: Data Source=ServerAdi;Initial Catalog=dbPcKayit;Integrated Security=True
set /p "MANUAL_CS=Connection String: "
goto :manual_update

:update_config
echo.
echo Connection string'ler güncelleniyor...

:: App.config dosyasını güncelle
powershell -Command "(Get-Content '%CONFIG_FILE%') | ForEach-Object { $_ -replace 'data source=[^;]*', 'data source=%SERVER_NAME%' } | Set-Content '%CONFIG_FILE%'"
powershell -Command "(Get-Content '%CONFIG_FILE%') | ForEach-Object { $_ -replace 'Data Source=[^;]*', 'Data Source=%SERVER_NAME%' } | Set-Content '%CONFIG_FILE%'"
powershell -Command "(Get-Content '%CONFIG_FILE%') | ForEach-Object { $_ -replace 'integrated security=[^;]*', '%AUTH_STRING%' } | Set-Content '%CONFIG_FILE%'"
powershell -Command "(Get-Content '%CONFIG_FILE%') | ForEach-Object { $_ -replace 'Integrated Security=[^;]*', '%CS_AUTH_STRING%' } | Set-Content '%CONFIG_FILE%'"

:: DBYukleyici dosyasını güncelle
if exist "%DBLOADER_FILE%" (
    powershell -Command "(Get-Content '%DBLOADER_FILE%') | ForEach-Object { $_ -replace 'Data Source=[^;]*', 'Data Source=%SERVER_NAME%' } | Set-Content '%DBLOADER_FILE%'"
    powershell -Command "(Get-Content '%DBLOADER_FILE%') | ForEach-Object { $_ -replace 'Integrated Security=True', '%CS_AUTH_STRING%' } | Set-Content '%DBLOADER_FILE%'"
)

goto :finish

:manual_update
:: Manuel connection string güncellemesi
powershell -Command "(Get-Content '%CONFIG_FILE%') | ForEach-Object { $_ -replace 'connectionString=\"Data Source=[^\"]*\"', 'connectionString=\"%MANUAL_CS%\"' } | Set-Content '%CONFIG_FILE%'"

:finish
echo.
echo ============================================
echo     AYARLAR BAŞARIYLA GÜNCELLENDİ!
echo ============================================
echo.
echo Güncelenen dosyalar:
echo - %CONFIG_FILE%
if exist "%DBLOADER_FILE%" echo - %DBLOADER_FILE%
echo.
echo Yeni ayarlar:
echo - Server: %SERVER_NAME%
if defined AUTH_STRING echo - Authentication: %AUTH_STRING%
echo.
echo UYARI: Değişikliklerin etkili olması için programı yeniden başlatın!
echo.

pause

:: Test bağlantısı teklifi
echo.
set /p "TEST_CONN=Bağlantıyı test etmek istiyor musunuz? (E/H): "
if /i "%TEST_CONN%"=="E" (
    echo.
    echo Bağlantı test ediliyor...
    sqlcmd -S "%SERVER_NAME%" -Q "SELECT @@VERSION" >nul 2>&1
    if %errorLevel% equ 0 (
        echo ✓ Bağlantı başarılı!
    ) else (
        echo ✗ Bağlantı başarısız!
        echo - SQL Server servisinin çalıştığından emin olun
        echo - Server adının doğru olduğunu kontrol edin
        echo - Firewall ayarlarını kontrol edin
    )
    pause
) 