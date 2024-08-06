using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBYukleyici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Integrated Security=True";

            string createDatabaseQuery = "CREATE DATABASE DENEME";

            string createTablesQuery = @"
            USE DENEME;

            CREATE TABLE [dbo].[SirketTablo](
                [SirketID] [int] IDENTITY(1,1) NOT NULL,
                [SirketAdi] [nvarchar](80) NULL,
	            [SirketTel] [nvarchar](100) NULL,
	            [SirketAdres] [nvarchar](300) NULL,

                CONSTRAINT [PK_SirketTablo] PRIMARY KEY CLUSTERED 
                (
                    [SirketID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            CREATE TABLE [dbo].[DepartmanTablo](
                [DepartmanID] [int] IDENTITY(1,1) NOT NULL,
                [DepartmanAdi] [nvarchar](50) NULL,

                CONSTRAINT [PK_DepartmanTablo] PRIMARY KEY CLUSTERED 
                (
                    [DepartmanID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            CREATE TABLE [dbo].[UnvanTablo](
                [UnvanID] [int] IDENTITY(1,1) NOT NULL,
                [UnvanAdi] [nvarchar](50) NULL,

                CONSTRAINT [PK_UnvanTablo] PRIMARY KEY CLUSTERED 
                (
                    [UnvanID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            CREATE TABLE [dbo].[PersonelTablosu](
                [PersonelID] [int] IDENTITY(1,1) NOT NULL,
                [PersonelAdi] [nvarchar](80) NULL,
	            [UnvanID] [int] NULL,
	            [SirketID] [int] NULL,
	            [DepartmanID] [int] NULL,
	            [PersonelTel] [nvarchar](80) NULL,
	            [PersonelMail] [nvarchar](80) NULL,

                CONSTRAINT [PK_PersonelTablosu] PRIMARY KEY CLUSTERED 
                (
                    [PersonelID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            ALTER TABLE [dbo].[PersonelTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PersonelTablosu_DepartmanTablo2] FOREIGN KEY([DepartmanID])
            REFERENCES [dbo].[DepartmanTablo] ([DepartmanID]);

            ALTER TABLE [dbo].[PersonelTablosu] CHECK CONSTRAINT [FK_PersonelTablosu_DepartmanTablo2];

            ALTER TABLE [dbo].[PersonelTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PersonelTablosu_SirketTablo3] FOREIGN KEY([SirketID])
            REFERENCES [dbo].[SirketTablo] ([SirketID]);

            ALTER TABLE [dbo].[PersonelTablosu] CHECK CONSTRAINT [FK_PersonelTablosu_SirketTablo3];

            ALTER TABLE [dbo].[PersonelTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PersonelTablosu_UnvanTablo3] FOREIGN KEY([UnvanID])
            REFERENCES [dbo].[UnvanTablo] ([UnvanID]);

            ALTER TABLE [dbo].[PersonelTablosu] CHECK CONSTRAINT [FK_PersonelTablosu_UnvanTablo3];

            CREATE TABLE [dbo].[BilgisayarTABLO](
                [BilgisayarID] [int] IDENTITY(1,1) NOT NULL,
                [BilgisayarAdi] [nvarchar](100) NULL,
                [BilgisayarModeli] [nvarchar](100) NULL,
                [PersonelID] [int] NULL,
                [KurulumTarihi] [date] NULL,
                PRIMARY KEY CLUSTERED 
                (
                    [BilgisayarID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            ALTER TABLE [dbo].[BilgisayarTABLO]  WITH CHECK ADD FOREIGN KEY([PersonelID])
            REFERENCES [dbo].[PersonelTablosu] ([PersonelID]);

            CREATE TABLE [dbo].[ProgramTABLO](
                [ProgramID] [int] IDENTITY(1,1) NOT NULL,
                [ProgramAdi] [nvarchar](100) NULL,
                PRIMARY KEY CLUSTERED 
                (
                    [ProgramID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            CREATE TABLE [dbo].[ProgramBilgisayar](
                [ComputerProgramID] [int] IDENTITY(1,1) NOT NULL,
                [BilgisayarID] [int] NULL,
                [ProgramID] [int] NULL,
                PRIMARY KEY CLUSTERED 
                (
                    [ComputerProgramID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            ALTER TABLE [dbo].[ProgramBilgisayar]  WITH CHECK ADD FOREIGN KEY([BilgisayarID])
            REFERENCES [dbo].[BilgisayarTABLO] ([BilgisayarID]);

            ALTER TABLE [dbo].[ProgramBilgisayar]  WITH CHECK ADD FOREIGN KEY([ProgramID])
            REFERENCES [dbo].[ProgramTABLO] ([ProgramID]);

            CREATE TABLE [dbo].[KullaniciTablo](
                [KullaniciID] [int] IDENTITY(1,1) NOT NULL,
                [KullaniciAdiGercek] [nvarchar](100) NULL,
                [KullaniciMail] [nvarchar](100) NULL,
                [KullaniciGirisAdi] [nvarchar](100) NULL,
                [KullaniciSifre] [nvarchar](100) NULL,
                CONSTRAINT [PK_KullaniciTablo] PRIMARY KEY CLUSTERED 
                (
                    [KullaniciID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY];

            ALTER TABLE [dbo].[KullaniciTablo] ADD DEFAULT ('') FOR [KullaniciAdiGercek];
            ALTER TABLE [dbo].[KullaniciTablo] ADD DEFAULT ('') FOR [KullaniciMail];
            ALTER TABLE [dbo].[KullaniciTablo] ADD DEFAULT ('') FOR [KullaniciGirisAdi];
            ALTER TABLE [dbo].[KullaniciTablo] ADD DEFAULT ('') FOR [KullaniciSifre];
            
            INSERT INTO [dbo].[KullaniciTablo] (KullaniciAdiGercek, KullaniciMail, KullaniciGirisAdi, KullaniciSifre)
            VALUES ('admin', 'admin', 'admin', 'admin');
            ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand createDbCommand = new SqlCommand(createDatabaseQuery, connection);
                    SqlCommand createTablesCommand = new SqlCommand(createTablesQuery, connection);

                    connection.Open();
                    createDbCommand.ExecuteNonQuery();
                    createTablesCommand.ExecuteNonQuery();

                    Console.WriteLine("Veritabanı ve tablolar başarıyla oluşturuldu ve varsayılan kullanıcı eklendi.");
                    Console.WriteLine("Giriş ID: admin");
                    Console.WriteLine("Şifre: admin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}