using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Giser_Lu
{
    public partial class frmSelectionByLocation : Form
    {
        private IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private esriSpatialRelEnum m_SpatoalRel;
      
        public frmSelectionByLocation(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
            
        }

        private void frmSelectionByLocation_Load(object sender, EventArgs e)
        {
           AddSelectFeatureInLayersToLSTBX();
           AddInTheLayerToCBX();
            cbx_SelectMethod.SelectedIndex = 0;
            cbx_SelectRelationShip.SelectedIndex = 0;
            if (m_MapControl.Map.SelectionCount == 0)
            {
                chx_OnlySelectedFeatures.Enabled = false;
            }
            else
            {
                chx_OnlySelectedFeatures.Enabled = true;
            }

            
        }

        private void AddSelectFeatureInLayersToLSTBX()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is FeatureLayer)
                    {
                        chxlstbx_SelecteFeatureInLayer.Items.Add(m_MapControl.Map.get_Layer(i).Name);
                       
                    }
                }

                chxlstbx_SelecteFeatureInLayer.SetItemChecked(0, true);
                lbl_FormLayer.Text = "在 ";

                foreach (object chexItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                {
                    lbl_FormLayer.Text += chexItem.ToString() + "|";
                }
            }
        }

        private void AddInTheLayerToCBX()
        {
            cbx_InTheLayer.Items.Clear();

            if (chxlstbx_SelecteFeatureInLayer.Items.Count > 0)
            {

                for (int i = 0; i < chxlstbx_SelecteFeatureInLayer.Items.Count; i++)
                {
                    cbx_InTheLayer.Items.Add(chxlstbx_SelecteFeatureInLayer.Items[i].ToString());
                }
                foreach (object CheckedItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                {
                    cbx_InTheLayer.Items.Remove(CheckedItem);
                }

                if (cbx_InTheLayer.Items.Count <= 0)
                {
                    cbx_InTheLayer.Items.Add("None");
                }
               
            }
            else
            {
                cbx_InTheLayer.Items.Add("None");
            }
            cbx_InTheLayer.SelectedIndex = 0;
            
       
        }

        private void GetLayerByName(string name)
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (name == m_MapControl.Map.get_Layer(i).Name)
                    {
                        m_FeatureLayer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);
                    }
                }
            }

        }

        private ISpatialFilter GetSpatialFilter()
        {
            try
            {
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                IEnumFeature pEnumFeature = null;
                IFeature pFeature = null;
                IFeatureCursor pFeatureCursor = null;
                IGeometry pGeometry = null;
                ITopologicalOperator pTopologicalOperator;

                if (cbx_InTheLayer.SelectedItem.ToString() != "None")
                {
                    GetLayerByName(cbx_InTheLayer.SelectedItem.ToString());
                }


                if (chx_OnlySelectedFeatures.Checked == true)
                {
                    pEnumFeature = (IEnumFeature)m_MapControl.Map.FeatureSelection;
                    pEnumFeature.Reset();
                    pFeature = pEnumFeature.Next();

                }
                else
                {
                    pFeatureCursor = m_FeatureLayer.FeatureClass.Search(null, true);
                    pFeature = pFeatureCursor.NextFeature();

                }

                pGeometry = pFeature.Shape;
                while (pFeature != null)
                {

                    pTopologicalOperator = (ITopologicalOperator)pFeature.ShapeCopy;
                    pGeometry = pTopologicalOperator.Union(pGeometry);
                    if (chx_OnlySelectedFeatures.Checked == true)
                    {
                        pFeature = pEnumFeature.Next();
                    }
                    else
                    {
                        pFeature = pFeatureCursor.NextFeature();

                    }
                }


                if (chx_BufferDistance.Checked == true)
                {
                    double pBufferDistance = Convert.ToDouble(nmUD_Distance.Value);
                    pTopologicalOperator = pGeometry as ITopologicalOperator;
                    pGeometry = pTopologicalOperator.Buffer(pBufferDistance);
                    pTopologicalOperator.Simplify();
                }


                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.SpatialRel = m_SpatoalRel;

                return pSpatialFilter;
               
            }
            catch(Exception)
            {
                MessageBox.Show("构造查询过滤器失败");
                return null;
            }

          
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            IFeatureSelection pFeatureSelection;
            
           
                if (cbx_SelectMethod.SelectedIndex == 0)
                {
                    m_MapControl.Map.ClearSelection();
                    foreach (object chechItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                    {
                        GetLayerByName(chechItem.ToString());
                        pFeatureSelection = (IFeatureSelection)m_FeatureLayer;
                        pFeatureSelection.SelectFeatures(GetSpatialFilter(), esriSelectionResultEnum.esriSelectionResultAdd, false);
                    }
                }
                if (cbx_SelectMethod.SelectedIndex == 1)
                {
                    foreach (object chechItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                    {
                        GetLayerByName(chechItem.ToString());
                        pFeatureSelection = (IFeatureSelection)m_FeatureLayer;
                        pFeatureSelection.SelectFeatures(GetSpatialFilter(), esriSelectionResultEnum.esriSelectionResultAdd, false);
                    }
                }
                if (cbx_SelectMethod.SelectedIndex == 2)
                {
                    foreach (object chechItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                    {
                        GetLayerByName(chechItem.ToString());
                        pFeatureSelection = (IFeatureSelection)m_FeatureLayer;
                        pFeatureSelection.SelectFeatures(GetSpatialFilter(),esriSelectionResultEnum.esriSelectionResultSubtract ,false);
                    }
                }
                if (cbx_SelectMethod.SelectedIndex == 3)
                {
                      foreach (object chechItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
                    {
                        GetLayerByName(chechItem.ToString());
                        pFeatureSelection = (IFeatureSelection)m_FeatureLayer;
                        pFeatureSelection.SelectFeatures(GetSpatialFilter(),esriSelectionResultEnum.esriSelectionResultAnd ,false);
                    }
                }
            

            m_MapControl.ActiveView.Refresh();

            if (m_MapControl.Map.SelectionCount == 0)
            {
                chx_OnlySelectedFeatures.Enabled = false;
            }
            else
            {
                chx_OnlySelectedFeatures.Enabled = true;
            }
        }


        private void chxlstbx_SelecteFeatureInLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddInTheLayerToCBX();
            lbl_FormLayer.Text = "在 ";

            foreach (object chexItem in chxlstbx_SelecteFeatureInLayer.CheckedItems)
            {
                lbl_FormLayer.Text += chexItem.ToString() + "| ";
            }
        }

        private void cbx_SelectMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_SelectMethod.Text = "";
            lbl_SelectMethod.Text = "我想 " + cbx_SelectMethod.SelectedItem.ToString();
        }

        private void cbx_SelectRelationShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pSelectedItem = cbx_SelectRelationShip.SelectedIndex;
            switch (pSelectedItem)
            {
                case 0:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        break;
                    }
                case 1:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;
                        break;
                    }
                case 2:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelIndexIntersects;
                        break;
                    }
                case 3:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelTouches;
                        break;
                    }
                case 4:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                        break;
                    }
                case 5:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                        break;
                    }
                case 6:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelWithin;
                        break;
                    }
                case 7:
                    {
                        m_SpatoalRel = esriSpatialRelEnum.esriSpatialRelContains;
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }

        private void cbx_InTheLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLayerByName(cbx_InTheLayer.SelectedItem.ToString());
            lbl_InLayer.Text = "在" + cbx_InTheLayer.SelectedItem.ToString() + "图层中";
            chx_BufferDistance.Text = "在距" + cbx_InTheLayer.SelectedItem.ToString() + "图层";
        }

        private void chx_OnlySelectedFeatures_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_OnlySelectedFeatures.Checked == true)
            {
                lbl_TotalFeatureS.Text = "共有" + m_MapControl.Map.SelectionCount.ToString() + "个选中的要素";
                cbx_InTheLayer.Enabled = false;
            }
            else
            {
                lbl_TotalFeatureS.Text = "";
                cbx_InTheLayer.Enabled = true;
            }
        }


       

     
    }
}