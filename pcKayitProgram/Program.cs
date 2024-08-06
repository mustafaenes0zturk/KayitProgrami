using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using pcKayitProgram.Formlar;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcKayitProgram
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string tema = Properties.Settings.Default.Tema;
            if (!String.IsNullOrEmpty(tema))
            {
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle(tema);
            }

            GirisForm girisfrm = new GirisForm();
            if (girisfrm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new XtraFormMain());
            }
            else
            {
                Application.Exit();
            }    
        }
    }
}
