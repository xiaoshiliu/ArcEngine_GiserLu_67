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

namespace DynamicReport
{
    public partial class frmGeoReport : Form
    {
        bool displaySelectedFeatures = true;
        //bool displayViaReport = true;
        IMap m_map;

        public frmGeoReport(IMap map)
        {
            InitializeComponent();
            m_map = map;
        }
        

        #region "rdoSelectedFeatures_CheckedChanged"
        private void rdoSelectedFeatures_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSelectedFeatures.Checked)
                displaySelectedFeatures = true;
            else
                displaySelectedFeatures = false;
        }
        #endregion


        #region "rdoReport_CheckedChanged"
        //private void rdoReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoReport.Checked)
        //        displayViaReport = true;
        //    else
        //        displayViaReport = false;
        //}
        #endregion

        private void btnAttributesReport_Click(object sender, EventArgs e)
        {
            //if (displayViaReport)
            //{
                DynamicAttributesReport displayAtrributes = new DynamicAttributesReport(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            //}
            //else
            //{
            //    AttributesForm displayAtrributes = new AttributesForm(m_map, displaySelectedFeatures);
            //    displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}