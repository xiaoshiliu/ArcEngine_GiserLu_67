using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace DynamicReport
{
    /// <summary>
    /// 主要功能：为报表准备XML格式的数据源
    /// 基本思路：“选择数据源”按钮使用GxDialog对话框，选择数据源（要素集和（或）要素类、shapefile文件），
    /// 　　　　　并自动填充“数据源”TreeView和“数据源”对应的ListView；“输出为报表数据”按钮
    /// 　　　　　根据用户选择的数据源，将其转换为本系统报表所需的XML数据。
    /// </summary>
    public partial class LayerDataToXML : Form
    {
        string m_treePathSeparator = "/";
        IFeatureWorkspace featureWorkspace = null;
        string xmlSaveDirectory = System.IO.Path.GetTempPath();

        public LayerDataToXML()
        {
            InitializeComponent();
        }

        private void LayerDataToXML_Load(object sender, EventArgs e)
        {
            lsvDetails.CheckBoxes = true;
            lsvDetails.View = View.List ;
        }

        //使用GxDialog对话框选择要输出的数据源（要素集和（或）要素类、shapefile文件）
        private IEnumGxObject AddLayerWithGxDialog()
        {
            try
            {    
                IGxDialog gxDlg = new GxDialogClass();
                // create a data format filter
                IGxObjectFilter gxObjFilter = new GxFilterFeatureDatasetsAndFeatureClassesClass();
                // set the properties of the open dialog
                gxDlg.Title = "Add Feature Datasets and/or Feature Classes";
                gxDlg.ObjectFilter = gxObjFilter;
                gxDlg.AllowMultiSelect = true;
                gxDlg.RememberLocation = true;
                
                IEnumGxObject gxObjects;
                bool open = gxDlg.DoModalOpen(0, out gxObjects);

                IGxDataset gxDataset = gxObjects.Next() as IGxDataset;
                if (gxDataset != null)
                {
                    if (gxDataset.Dataset is IFeatureClass)
                    {
                        IFeatureClass featureClass = gxDataset.Dataset as IFeatureClass;
                        IFeatureDataset featureDataSet = featureClass.FeatureDataset;
                        if (featureDataSet == null)
                        {
                            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
                            featureWorkspace = pWorkspaceFactory.OpenFromFile(gxDlg.FinalLocation.FullName,this.Handle.ToInt32()) as IFeatureWorkspace;
                        }
                        else
                        {
                            featureWorkspace = featureDataSet.Workspace as IFeatureWorkspace;
                        }
                    }
                    else if (gxDataset.Dataset is IFeatureDataset)
                    {
                        IFeatureDataset featureDataSet = gxDataset.Dataset as IFeatureDataset;
                        featureWorkspace = featureDataSet.Workspace as IFeatureWorkspace;
                    }
                }
                return gxObjects;
            }
            catch 
            {
                MessageBox.Show("不能打开数据集或要素类！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        private void btnSelectDataSources_Click(object sender, EventArgs e)
        {
            IEnumGxObject gxObjects = AddLayerWithGxDialog();
            trvDatasets.Nodes.Clear();
            lsvDetails.Items.Clear();
            FillTreeView(gxObjects);
        }

        private void FillTreeView(IEnumGxObject pGxObjects)
        {
            if (pGxObjects == null)
                return;

            pGxObjects.Reset();
            TreeNode rootnode = new TreeNode("数据源");
            trvDatasets.Nodes.Add(rootnode);

            IGxDataset pGxDataset = pGxObjects.Next() as IGxDataset;
            while (pGxDataset != null)
            {
                if (pGxDataset.Dataset is IFeatureClass)
                {
                    IDataset featureDataset = pGxDataset.Dataset;
                    TreeNode featureClassName = new TreeNode(featureDataset.Name);
                    rootnode.Nodes.Add(featureClassName);
                }
                else if (pGxDataset.Dataset is IFeatureDataset)
                {
                    TreeNode datasetName = new TreeNode(pGxDataset.Dataset.Name);
                    IEnumDataset pEnumDataset;
                    pEnumDataset = pGxDataset.Dataset.Subsets;
                    pEnumDataset.Reset();
                    IDataset pDataSet = pEnumDataset.Next();
                    while (pDataSet != null)
                    {
                        //注意：拓扑要素及网络线要素不能作为报表数据源
                        if ((pDataSet is ITopology) || (pDataSet is IGeometricNetwork) || (pDataSet is INetworkDataset))
                        {
                            pDataSet = pEnumDataset.Next();
                        }
                        else
                        {
                            TreeNode featureClassName = new TreeNode(pDataSet.Name);
                            datasetName.Nodes.Add(featureClassName);
                            pDataSet = pEnumDataset.Next();
                        }
                    }
                    rootnode.Nodes.Add(datasetName);
                }
                pGxDataset = pGxObjects.Next() as IGxDataset;
            }
            trvDatasets.Sort();

            for (int i = 0; i < rootnode.Nodes.Count; i++)
            {
                ListViewItem item = new ListViewItem(rootnode.Nodes[i].Text);
                lsvDetails.Items.Add(item);
            }
            lsvDetails.Refresh();
        }

        private void trvDatasets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode datasetNode = e.Node;           
            lsvDetails.Clear();

            for (int i = 0; i < datasetNode.Nodes.Count; i++)
            {
                ListViewItem item = new ListViewItem(datasetNode.Nodes[i].Text);
                lsvDetails.Items.Add(item);
            }
            if (datasetNode.Nodes.Count == 0)
            {
                ListViewItem item = new ListViewItem(datasetNode.Text);
                lsvDetails.Items.Add(item);
            }
            lsvDetails.Refresh();

        }

        private void btnLayerDataToXML_Click(object sender, EventArgs e)
        {           
            List<string> checkedItems = GetCheckedItems();
            if (checkedItems == null) return;
            ExportFeatureClasses(checkedItems);
            MessageBox.Show("数据输出完毕！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectXMLSaveDirectory()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                xmlSaveDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private int GetSelectedNodeLevel()
        {
            TreeNode selectedNode = trvDatasets.SelectedNode;
            if (selectedNode == null)  return -1;
            selectedNode.TreeView.PathSeparator = m_treePathSeparator;
            string selectedNodePath = trvDatasets.SelectedNode.FullPath;
            char[] delimit = new char[] { m_treePathSeparator.ToCharArray()[0] };
            string[] words = selectedNodePath.Split(delimit);
            int level = words.GetLength(0);
            return level;
        }

        private List<string> GetCheckedItems()
        {
            List<string> checkedItems = new List<string>();
            int item_count = lsvDetails.Items.Count;
            int checked_count = lsvDetails.CheckedItems.Count;

            if (checked_count > 0)
            {
                for (int index = 0; index < item_count; index++)
                {
                    if (lsvDetails.Items[index].Checked)
                    {
                        checkedItems.Add(lsvDetails.Items[index].Text);
                    }
                }
                return checkedItems;
            }
            return null;
        }

        private void ExportFeatureClasses(List<string> checkedItems)
        {
            string datasetOrFeatureClassName;
            for (int i = 0; i < checkedItems.Count; i++)
            {
                datasetOrFeatureClassName = checkedItems[i];
                if (CheckIfDatasetOrFeatureClass(datasetOrFeatureClassName, esriDatasetType.esriDTFeatureDataset))
                {
                    ExportDatasetToXML(datasetOrFeatureClassName);
                }                
                else
                {
                    ExportFeatureClassToXML(datasetOrFeatureClassName);
                }
            }            
        }
        

        private bool CheckIfDatasetOrFeatureClass(string checkedName,esriDatasetType datasetType)
        {
            bool checkedYes = false;
            IWorkspace workspace = featureWorkspace as IWorkspace;
            IEnumDatasetName datasetNames = workspace.get_DatasetNames(datasetType);
            if (datasetNames == null) return false;
            datasetNames.Reset();
            IDatasetName datasetName = datasetNames.Next();
            while (datasetName != null)
            {
                if (checkedName == datasetName.Name)
                {
                    checkedYes = true;
                    break;
                }
                datasetName = datasetNames.Next();
            }
            return checkedYes;
        }

        private void ExportDatasetToXML(string datasetFeatureClassName)
        {
            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(datasetFeatureClassName);
            IFeatureClassContainer featureClassContainer = featureDataset as IFeatureClassContainer;
            for (int i = 0; i < featureClassContainer.ClassCount; i++)
            {
                IFeatureClass featureClass = featureClassContainer.get_Class(i);
                ExportFeatureClassToReportData(featureClass);
            }
        }

        private void ExportFeatureClassToXML(string datasetFeatureClassName)
        {
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(datasetFeatureClassName);
            ExportFeatureClassToReportData(featureClass);
        }


        private void ExportFeatureClassToReportData(IFeatureClass featureClass)
        {            
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;

            DataSet dataSet = ConstructDataSet(featureLayer);
            string xmlFileName = featureLayer.Name + ".xml";
            string xmlFilepath = System.IO.Path.Combine(xmlSaveDirectory, xmlFileName);
            dataSet.WriteXml(xmlFilepath);
        }

        #region "ConstructDataSet"
        private DataSet ConstructDataSet(IFeatureLayer pFeatLyr)
        {
            ILayerFields pFeatlyrFields;
            pFeatlyrFields = pFeatLyr as ILayerFields;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            DataSet layerDataSet = new DataSet();
            if (layerDataSet.Tables[pFeatLyr.Name] == null)
            {
                DataTable pTable = new DataTable(pFeatLyr.Name);
                DataColumn pTableCol;
                for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                {
                    pTableCol = new DataColumn(pFeatlyrFields.get_Field(i).AliasName);
                    pTable.Columns.Add(pTableCol);
                    pTableCol = null;
                }

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
                layerDataSet.Tables.Add(pTable);
                return layerDataSet;
            }
            return null;
        }

        #endregion

        private void btnExportDir_Click(object sender, EventArgs e)
        {
            SelectXMLSaveDirectory();
        }


    }
}