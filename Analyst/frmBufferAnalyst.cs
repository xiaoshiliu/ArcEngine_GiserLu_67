using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using stdole;


namespace Giser_Lu
{
    public partial class frmBufferAnalyst : Form
    {
        private IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private string m_OutPutShpPath =null;
        

        public frmBufferAnalyst(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmBufferAnalyst_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldToCBX();
            GetUnitsByMap();
            GetOutPutPath();
           
            
            
        }

        private void AddLayersToCBX()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is IFeatureLayer)
                    {
                        cbx_Layer.Items.Add(m_MapControl.Map.get_Layer(i).Name.ToString());
                    }
                }
                cbx_Layer.SelectedIndex = 0;
            }

        }
        private void AddFieldToCBX()
        {
            cbx_Field.Items.Clear();
            GetLayerByName(cbx_Layer.SelectedItem.ToString());

            if (m_FeatureLayer.FeatureClass.Fields != null)
            {

                for (int i = 0; i < m_FeatureLayer.FeatureClass.Fields.FieldCount; i++)
                {
                    if ((m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeDouble) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeInteger) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeSingle) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeSmallInteger))
                    {

                        cbx_Field.Items.Add(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Name.ToString());
                    }
                }
                if (cbx_Field.Items.Count == 0)
                {
                    cbx_Field.Items.Add("None");

                }

                cbx_Field.SelectedIndex = 0;

            }


        }

        private void GetOutPutPath()
        {
            
                m_OutPutShpPath = Path.GetTempPath() + cbx_Layer.SelectedItem.ToString()
                   + "_" + "buffer" + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString()
                   + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString()
                   + ".shp";
            

            txtbx_TestPath.Text = m_OutPutShpPath;
        }
        private void GetLayerByName(string name)
        {
            for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
            {
                if (name == m_MapControl.Map.get_Layer(i).Name.ToString())
                {
                    m_FeatureLayer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);
                }
            }
        }

        private void GetUnitsByMap()
        {
            int DefaultUnits = Convert.ToInt32(m_MapControl.ActiveView.FocusMap.MapUnits);
            cbx_GlobalUnit.SelectedIndex = DefaultUnits;

            
        }

        private void cbx_Layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldToCBX();
            GetOutPutPath();
          
        }

        private void cbx_GlobalUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_DistanceUnit.Text = cbx_GlobalUnit.SelectedItem.ToString();
            lbl_FieldUnit.Text = cbx_GlobalUnit.SelectedItem.ToString();
            lbl_RingUnit.Text = cbx_GlobalUnit.SelectedItem.ToString();
        }
        private void btn_BrowsePathOfSaveShp_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Title = "选择保存位置";
            saveFileDlg.Filter = "ShapeFile(*.shp)|*.shp";
            saveFileDlg.AddExtension = true;

            saveFileDlg.OverwritePrompt = true;
            saveFileDlg.RestoreDirectory = true;
            saveFileDlg.FileName = cbx_Layer.SelectedItem.ToString()
                + "_" + "buffer" + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString()
                + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString()
                + "_" + DateTime.Now.Second.ToString() + "_" + ".shp";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                m_OutPutShpPath = saveFileDlg.FileName;
            }

            txtbx_TestPath.Text = m_OutPutShpPath;
        }


        private void AddBufferLayerToControl()
        {
           string pDirectoryOfShapeFile = Path.GetDirectoryName(m_OutPutShpPath);
           string pFileName = Path.GetFileName(m_OutPutShpPath);
            m_MapControl.AddShapeFile(pDirectoryOfShapeFile,pFileName);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            status_Waiting.Visible = true;
          

           BufferByDistance();
           
           
            //get an instance of the geoprocessor
          
            status_Waiting.Visible = false;

            AddBufferLayerToControl();

        }


               
               
          
        private void BufferByDistance()
        {
            
            
            string pBufferDistanceOrField =null;
            string pBufferUnits = cbx_GlobalUnit.SelectedItem.ToString();
            string pDissovle =null;

            //if (0.0 == pBufferDistanceOrField)
            //{
            //    MessageBox.Show("Bad buffer distance!");
            //    return;
            //}
            if (m_MapControl.ActiveView.FocusMap.LayerCount == 0)
                return;

            if (null == m_FeatureLayer)
            {
                return;
            }
            if (rdb_Field.Checked == true)
            {
                pBufferDistanceOrField = cbx_Field.SelectedItem.ToString(); 
            }
            else if(rdb_Distance.Checked  ==true)
            {
                pBufferDistanceOrField = nmUD_Distance.Value.ToString()+" "+pBufferUnits;;
            }

            if(rdb_DissovleFalse.Checked ==true)
            {
                pDissovle ="NONE";
            }
            else if(rdb_DissolveTrue.Checked ==true)
            {
                pDissovle ="ALL";
            }
            

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            //create a new instance of a buffer tool
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer();
            buffer.in_features = m_FeatureLayer;
            buffer.out_feature_class = m_OutPutShpPath;
            buffer.buffer_distance_or_field = pBufferDistanceOrField;
            buffer.dissolve_option = pDissovle;
                

            //execute the buffer tool (very easy :-))
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(buffer, null);



            //if (results.Status != esriJobStatus.esriJobSucceeded)
            //{
            //    MessageBox.Show("Failed to buffer layer: ");
            //}
        }
       
    }
}