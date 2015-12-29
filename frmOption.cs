using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System.IO;
using Microsoft.Win32;


namespace Giser_Lu
{
    public partial class frmOption : Form
    {
       
        public frmOption()
        {
            InitializeComponent();
        }

        


        private void DefaultLayout()
        {
            if (File.Exists(frmMain.LayoutConfigName))
            {
                File.Delete(frmMain.LayoutConfigName);
            }
        }

        private void ClearRecentList()
        {
            Registry.CurrentUser.DeleteSubKey(@"Software\Giser_Lu\Recent Files");
        }


        
        private void frmOption_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(chx_DefaultLayout.Checked || chx_ClearRecentList.Checked))
            {
                this.Close();
            }
            else
            {
                if (chx_ClearRecentList.Checked)
                {
                    ClearRecentList();
                }
                if (chx_DefaultLayout.Checked)
                {
                    DefaultLayout();
                }

                MessageBox.Show("重启程序后生效");
                this.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
    }
}