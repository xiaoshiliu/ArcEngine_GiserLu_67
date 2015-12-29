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
using ESRI.ArcGIS.Geodatabase;

namespace Giser_Lu
{
    public partial class frmAttributeTable : Form
    {
        private IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private string m_LayerName;
        public frmAttributeTable(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
             ILayer layer = (ILayer)m_MapControl.CustomProperty;
            m_LayerName = layer.Name;
        }

        public frmAttributeTable(IMapControlDefault mapcontrol, string layerName)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
            m_LayerName = layerName;
           
        }

        private void frmAttributeTable_Load(object sender, EventArgs e)
        {
           
           GetFieldToDataGridView();
           
           statusLbl_Count.Text = "所有记录数: " + Convert.ToString(dataGridView1.Rows.Count-1);
        }

        private void GetFieldToDataGridView()
        {
            
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_LayerName == m_MapControl.Map.get_Layer(i).Name)
                    {
                        m_FeatureLayer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);
                        break;
                    }
                }
            }


            IFields  pFields  = m_FeatureLayer.FeatureClass.Fields;
            dataGridView1.ColumnCount = pFields.FieldCount;
            for (int j = 0; j< pFields.FieldCount; j++)
            {
                dataGridView1.Columns[j].Name = pFields.get_Field(j).Name;
                
            }

            IFeatureCursor pFeatureCursor = m_FeatureLayer.FeatureClass.Search(null, true);
            IFeature pFeature = pFeatureCursor.NextFeature();

            while (pFeature != null)
            {
                string[] pFieldValueArray = new string[pFields.FieldCount];
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    if (pFields.get_Field(i).Name == "Shape")
                    {
                        pFieldValueArray[i] = pFeature.Shape.GeometryType.ToString();
                    }
                    else
                    {
                        pFieldValueArray[i] = pFeature.get_Value(i).ToString();
                    }
                    
                }

                dataGridView1.Rows.Add(pFieldValueArray);
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            statuslbl_selectedrows.Text ="选中的记录数: "+  dataGridView1.SelectedRows.Count.ToString();
          
                SelectFeturesBySelectedRows();
            
           
        }

        private void SelectFeturesBySelectedRows()
        {
           
            m_MapControl.Map.ClearSelection();
            IFeatureSelection pFeatureSelection;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            string pWhereClauseFidOr= "";
            pFeatureSelection = (IFeatureSelection)m_FeatureLayer;
            
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
			    {
                    if (dataGridView1.SelectedRows[i].Cells[0].Value != null)
                    {
                    
                       pWhereClauseFidOr = "Fid =" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + " or ";
                        if (i == dataGridView1.SelectedRows.Count - 1)
                        {
                          pWhereClauseFidOr = "Fid =" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                        }
                    }

                     pQueryFilter.WhereClause += pWhereClauseFidOr;
			    }
              if(dataGridView1.SelectedRows.Count!=0 && pQueryFilter.WhereClause!="")
            {
                    
                    pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    m_MapControl.ActiveView.Refresh();
            }
            
        }

        private void 清除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            m_MapControl.Map.ClearSelection();
            m_MapControl.ActiveView.Refresh();
        }

        private void 选择全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            
        }

        private void 只显示选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList pTempRows = new System.Collections.ArrayList();
                foreach (object var in dataGridView1.SelectedRows)
                {
                    pTempRows.Add(var);
                }
                dataGridView1.Rows.Clear();
                for (int i = pTempRows.Count-1; i>=0 ; i--)
                {
                    dataGridView1.Rows.Add((DataGridViewRow)pTempRows[i]);
                }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetFieldToDataGridView();
        }

        private void ZoomToSelectFeature()
        {
            ICommand cmd = new ZoomToSelectedFeatures();
            cmd.OnCreate(m_MapControl.Object);
            cmd.OnClick();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ZoomToSelectFeature();
        }

        
    }
}