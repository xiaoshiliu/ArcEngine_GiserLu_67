using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;


using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;


namespace Giser_Lu
{
    public partial class frmOverlayAnalyst : Form
    {
        private IMapControlDefault m_MapControl;
        //private IFeatureLayer m_FeatureLayer;

        private string m_SelectedOverlayAnalystType;
       private string m_InputLayer;
        private string m_InputLayerPrecisionLevel;
       private string m_OverlayLayer;
        private string m_OverlayLayerPrecisionLevel;
        private double  m_Tolerance;
        private string m_OutputAttributeType;
        private string m_OutputFeatureType;
        private string m_OutPutPath = System.IO.Path.GetTempPath();


        public frmOverlayAnalyst(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
            cbx_OverlayAnalystType.SelectedIndex = 0;
        }

        private void frmOverlayAnalyst_Load(object sender, EventArgs e)
        {
            AddLayerCBX(cbx_InPutLayer);

            
        }

        private void AddLayerCBX(ComboBox CBX)
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is FeatureLayer)
                    {
                        CBX.Items.Add(m_MapControl.Map.get_Layer(i).Name.ToString());
                    }
                }
                CBX.SelectedIndex = 0;
            }
        }

        private void AddLayerCBX(ComboBox CBX, esriGeometryType GeoType)
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is FeatureLayer )
                    {
                        IFeatureLayer pFeatureLyaer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);

                        if (pFeatureLyaer.FeatureClass.ShapeType == GeoType)
                        {
                            CBX.Items.Add(m_MapControl.Map.get_Layer(i).Name.ToString());
                        }
                    }
                }
                CBX.SelectedIndex = 0;
            }
        }

        private void cbx_OverlayAnalystType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_SelectedOverlayAnalystType = cbx_OverlayAnalystType.SelectedItem.ToString();
            switch(m_SelectedOverlayAnalystType)
            {
                case "求交叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer);

                        nmUd_InputPrecisionLevel.Enabled = true;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = true;
                        cbx_OutPutAttributeType.Enabled = true;
                        cbx_OutPutFeatureType.Enabled = true;

                        break;
                    }

                case "求和叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer ,esriGeometryType.esriGeometryPolygon);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer ,esriGeometryType.esriGeometryPolygon);

                        nmUd_InputPrecisionLevel.Enabled = true;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = true;
                        cbx_OutPutAttributeType.Enabled = true;
                        cbx_OutPutFeatureType.Enabled = false;

                        break;
                    }

                case "擦除叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer, esriGeometryType.esriGeometryPolygon);

                        nmUd_InputPrecisionLevel.Enabled = false;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = false;
                        cbx_OutPutAttributeType.Enabled = false;
                        cbx_OutPutFeatureType.Enabled = false;

                        break;
                    }

                case "同一性叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer, esriGeometryType.esriGeometryPolygon);

                        nmUd_InputPrecisionLevel.Enabled = false;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = false;
                        cbx_OutPutAttributeType.Enabled = true;
                        cbx_OutPutFeatureType.Enabled = false;

                        break;
                    }

                case "更新叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer,esriGeometryType.esriGeometryPolygon);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer, esriGeometryType.esriGeometryPolygon);

                        nmUd_InputPrecisionLevel.Enabled = false;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = false;
                        cbx_OutPutAttributeType.Enabled = false;
                        cbx_OutPutFeatureType.Enabled = false;

                        break;
                    }

                case "异或叠置":
                    {
                        cbx_InPutLayer.Items.Clear();
                        AddLayerCBX(cbx_InPutLayer, esriGeometryType.esriGeometryPolygon);
                        cbx_OverlayLayer.Items.Clear();
                        AddLayerCBX(cbx_OverlayLayer, esriGeometryType.esriGeometryPolygon);

                        nmUd_InputPrecisionLevel.Enabled = false;
                        nmUD_OverlayLayerPrecisionLevel.Enabled = false;
                        cbx_OutPutAttributeType.Enabled =true;
                        cbx_OutPutFeatureType.Enabled = false;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void cbx_OutPutAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pOutputAttributeType = cbx_OutPutAttributeType.SelectedItem.ToString();
            switch (pOutputAttributeType)
            {
                case "所有属性":
                    {
                        m_OutputAttributeType = "All";

                        break;
                    }
                case "不包括FID":
                    {
                        m_OutputAttributeType = "NO_FID";

                        break;
                    }
                case "仅包括FID":
                    {
                        m_OutputAttributeType = "ONLY_FID";

                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }
        private void cbx_OutPutFeatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pOutPutFeatureType = cbx_OutPutFeatureType.SelectedItem.ToString();
            switch (pOutPutFeatureType)
            {
                case "根据输入要素确定":
                    {
                        m_OutputFeatureType = "INPUT";
                        break;
                    }

                case "线":
                    {
                        m_OutputFeatureType = "LINE";
                        break;
                    }

                case "点":
                    {
                        m_OutputFeatureType = "POINT";
                        break;
                    }

                default:
                    { break; }
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            Geoprocessor pGeoprocessor = new Geoprocessor();
            pGeoprocessor.OverwriteOutput = true;

            IGeoProcessorResult pGPResult = null;
            switch (m_SelectedOverlayAnalystType)
            {
               
                case "求交叠置":
                    {
                      pGPResult =  IntersectOverlay(pGeoprocessor);
                        break;
                    }
                case "求和叠置":
                    {
                         pGPResult = UnionOverlay(pGeoprocessor);
                         break;
                    }
                case "擦除叠置":
                    {
                        pGPResult= EraseOverlay(pGeoprocessor);
                         break;
                    }
                case "同一性叠置":
                   {
                         pGPResult = IdentityOverlay(pGeoprocessor);
                         break;
                   }

                case "更新叠置":
                    {
                        pGPResult = UpdateOverlay(pGeoprocessor);
                        break;
                    }
                case "异或叠置":
                    {
                       pGPResult = SymDiffOverlay(pGeoprocessor);
                        break;
                    }
                default:
                   { break;}
                    
            }
        }

        private IGeoProcessorResult IntersectOverlay(Geoprocessor gp)
        {
           
            string pOutPutFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "Intersect");

            IGpValueTableObject pGpValueTableObject = new GpValueTableObjectClass();
            pGpValueTableObject.SetColumns(2);

            object pRow = null;
            pRow = m_InputLayer + " " + m_InputLayerPrecisionLevel;
            pGpValueTableObject.AddRow(ref pRow);
            pRow = m_OverlayLayer + " " + m_OverlayLayerPrecisionLevel; 
            pGpValueTableObject.AddRow(ref pRow);

            IVariantArray pVariantArray = new VarArrayClass();
            pVariantArray.Add(pGpValueTableObject);
            pVariantArray.Add(pOutPutFullPath);
            pVariantArray.Add(m_OutputAttributeType);
            pVariantArray.Add(m_Tolerance);
            pVariantArray.Add(m_OutputFeatureType);

            IGeoProcessorResult pGPResult = (IGeoProcessorResult)gp.Execute("intersect_analysis", pVariantArray, null) ;

            return pGPResult;
        }
        private IGeoProcessorResult UnionOverlay(Geoprocessor gp)
        {
            //Union_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, gaps)

            string pOutPutFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "Union");

            IGpValueTableObject pGpValueTableObject = new GpValueTableObjectClass();
            pGpValueTableObject.SetColumns(2);

            object pRow = "";
            pRow = m_InputLayer + " " + m_InputLayerPrecisionLevel;
            pGpValueTableObject.AddRow(ref pRow);
            pRow = m_OverlayLayer + " " + m_OverlayLayerPrecisionLevel;
            pGpValueTableObject.AddRow(ref pRow);

            IVariantArray pVariantArray = new VarArrayClass();
            pVariantArray.Add(pGpValueTableObject);
            pVariantArray.Add(pOutPutFullPath);
            pVariantArray.Add(m_OutputAttributeType);
            pVariantArray.Add(m_Tolerance);





            IGeoProcessorResult pGPResult = gp.Execute("Union_analysis", pVariantArray, null) as IGeoProcessorResult;

            return pGPResult;

        }
        private IGeoProcessorResult EraseOverlay(Geoprocessor gp)
        {
            //Erase_analysis (in_features, erase_features, out_feature_class, cluster_tolerance) 
           


            Erase erase = new Erase();
            erase.in_features = m_InputLayer;
            erase.erase_features = m_OverlayLayer;
            string outputFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "Erase");
            erase.out_feature_class = outputFullPath;
            erase.cluster_tolerance = m_Tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(erase, null);
            return results;
        }
        private IGeoProcessorResult IdentityOverlay(Geoprocessor gp)
        {
            //Identity_analysis(in_features, identity_features, out_feature_class, join_attributes, cluster_tolerance, relationship)
            Identity identity = new Identity();
            identity.in_features = m_InputLayer;
            identity.identity_features = m_OverlayLayer;
            string outputFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "Identity");
            identity.out_feature_class = outputFullPath;
            identity.join_attributes = m_OutputAttributeType;
            identity.cluster_tolerance = m_Tolerance;
            //identity.relationship = true;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(identity, null);
            return results;
        }
        private IGeoProcessorResult UpdateOverlay(Geoprocessor gp)
        {
            //Update_analysis (in_features, update_features, out_feature_class, keep_borders, cluster_tolerance) 

            Update update = new Update();
            update.in_features = m_InputLayer;
            update.update_features = m_OverlayLayer;
            string outputFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "Update");
            update.out_feature_class = outputFullPath;
            update.keep_borders = "false";
            update.cluster_tolerance = m_Tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(update, null);
            return results;
        }
        private IGeoProcessorResult SymDiffOverlay(Geoprocessor gp)
        {
            //SymDiff_analysis (in_features, update_features, out_feature_class, join_attributes, cluster_tolerance) 

            SymDiff symDiff = new SymDiff();
            symDiff.in_features = m_InputLayer;
            symDiff.update_features = m_OverlayLayer;
            string outputFullPath = System.IO.Path.Combine(m_OutPutPath, m_InputLayer + "_" + m_OverlayLayer + "_" + "SymDiff");
            symDiff.out_feature_class = outputFullPath;
            symDiff.join_attributes = m_OutputAttributeType;
            symDiff.cluster_tolerance = m_Tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(symDiff, null);
            return results;
        }

        private void nmUd_InputPrecisionLevel_ValueChanged(object sender, EventArgs e)
        {
            m_InputLayerPrecisionLevel = nmUd_InputPrecisionLevel.Value.ToString() ;
        }

        private void nmUD_OverlayLayerPrecisionLevel_ValueChanged(object sender, EventArgs e)
        {
            m_OverlayLayerPrecisionLevel = nmUD_OverlayLayerPrecisionLevel.Value.ToString();
        }

        private void nmUd_Tolerance_ValueChanged(object sender, EventArgs e)
        {
            m_Tolerance = Convert.ToDouble(nmUd_Tolerance.Value);
        }

        private void cbx_InPutLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_InputLayer = cbx_InPutLayer.SelectedItem.ToString();
        }

        private void cbx_OverlayLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_OverlayLayer = cbx_OverlayLayer.SelectedItem.ToString();
        }

        private void btn_BrowseOutPutPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                m_OutPutPath = folderBrowserDlg.SelectedPath;
            }
        }







    }



    
}