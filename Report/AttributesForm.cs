using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace DynamicReport
{
    //功能：以DataGridView显示地图各图层的属性，显示内容可以是整个图层上的所有要素，或仅图层上的选择要素
    public partial class AttributesForm : Form
    {
        IMap m_map;
        bool displaySelectedFeatures = true;
        const string m_dataSetName = "m_layerDataSet";
        const string m_dataSourceName = "GeoDataSource";
        DataSet m_layerDataSet = new DataSet(m_dataSetName);

        public AttributesForm(IMap map,bool displaySelFeatures)
        {
            InitializeComponent();
            m_map = map;
            displaySelectedFeatures = displaySelFeatures;
        }

        private void AttributesForm_Load(object sender, EventArgs e)
        {
            CreateLayersTreeView();            
        }

        #region "CreateLayersTreeView"
        private void CreateLayersTreeView()
        {
            TreeNode rootnode = new TreeNode("Layers");
            trvLayers.Nodes.Add(rootnode);
            for (int i = 0; i <= m_map.LayerCount - 1; i++)
            {
                TreeNode layerName = new TreeNode(m_map.get_Layer(i).Name);
                if (m_map.get_Layer(i) is IGroupLayer || m_map.get_Layer(i) is ICompositeLayer)
                {
                    ICompositeLayer cLayer = m_map.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j <= cLayer.Count - 1; j++)
                    {
                        TreeNode subLayerName = new TreeNode(cLayer.get_Layer(j).Name);
                        layerName.Nodes.Add(subLayerName);
                    }
                }
                rootnode.Nodes.Add(layerName);
            }
            trvLayers.Sort();
        }

        #endregion

        #region "trvLayers_AfterSelect"
        private void trvLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string layerName = e.Node.Text;
            IFeatureLayer featureLayer = GetLayerByName(layerName);
            if (featureLayer == null) return;
            ConstructDataSet(featureLayer);
            dataGridView1.DataSource = m_layerDataSet;
            dataGridView1.DataMember = featureLayer.Name;
        }
        #endregion

        #region "ConstructDataSet"
        private void ConstructDataSet(IFeatureLayer pFeatLyr)
        {
            ILayerFields pFeatlyrFields;
            pFeatlyrFields = pFeatLyr as ILayerFields;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            if (m_layerDataSet.Tables[pFeatLyr.Name] == null)
            {
                DataTable pTable = new DataTable(pFeatLyr.Name);
                DataColumn pTableCol;
                for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                {
                    pTableCol = new DataColumn(pFeatlyrFields.get_Field(i).AliasName);
                    pTable.Columns.Add(pTableCol);
                    pTableCol = null;
                }
                if (displaySelectedFeatures)
                {
                    IFeatureSelection selectLayer = pFeatLyr as IFeatureSelection;
                    ISelectionSet selectionSet = selectLayer.SelectionSet;
                    IEnumIDs enumIDs = selectionSet.IDs;
                    IFeature feature;
                    int iD = enumIDs.Next();
                    while (iD != -1) //-1 is reutned after the last valid ID has been reached        
                    {
                        feature = pFeatCls.GetFeature(iD);
                        DataRow pTableRow = pTable.NewRow();
                        for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                        {
                            //pTableRow[i] = feature.get_Value(i);
                            if (pFeatlyrFields.FindField(pFeatCls.ShapeFieldName) == i)
                            {
                                pTableRow[i] = pFeatCls.ShapeType;
                            }
                            else
                            {
                                pTableRow[i] = feature.get_Value(i);
                            }
                        }
                        pTable.Rows.Add(pTableRow);
                        iD = enumIDs.Next();
                    }
                    m_layerDataSet.Tables.Add(pTable);
                }
                else
                {
                    IFeatureCursor features = pFeatLyr.Search(null, false);
                    IFeature feature = features.NextFeature();
                    while (feature != null)
                    {
                        DataRow pTableRow = pTable.NewRow();
                        for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                        {
                            //pTableRow[i] = feature.get_Value(i);
                            if (pFeatlyrFields.FindField(pFeatCls.ShapeFieldName) == i)
                            {
                                pTableRow[i] = pFeatCls.ShapeType;
                            }
                            else
                            {
                                pTableRow[i] = feature.get_Value(i);
                            }
                        }
                        pTable.Rows.Add(pTableRow);
                        feature = features.NextFeature();
                    }
                    m_layerDataSet.Tables.Add(pTable);
                }
            }
        }

        #endregion 


        #region "GetLayerByName"

        private IFeatureLayer GetLayerByName(string layerName)
        {            
            for (int i = 0; i <= m_map.LayerCount - 1; i++)
            {
                ILayer layer = m_map.get_Layer(i);
                if (layer != null)
                {
                    if (layer is IFeatureLayer)
                    {
                        if (((IFeatureLayer)layer).FeatureClass.AliasName == layerName)
                            return layer as IFeatureLayer;
                    }
                }
                if (layer is IGroupLayer || layer is ICompositeLayer)
                {
                    ICompositeLayer cLayer = layer as ICompositeLayer;
                    for (int j = 0; j <= cLayer.Count - 1; j++)
                    {
                        ILayer subLayer = cLayer.get_Layer(j);
                        if (((IFeatureLayer)subLayer).FeatureClass.AliasName == layerName)
                            return subLayer as IFeatureLayer;
                    }
                }
            }
            return null;
        }
        #endregion                     

    }
}