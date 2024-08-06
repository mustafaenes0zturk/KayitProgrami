using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Xpf.Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class FormSistemAyar : DevExpress.XtraEditors.XtraForm
    {
        public FormSistemAyar()
        {
            InitializeComponent();
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string caption = e.Item.Value.ToString();

            Properties.Settings.Default.Tema = caption;
            Properties.Settings.Default.Save();
        }

        private void btnCikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}