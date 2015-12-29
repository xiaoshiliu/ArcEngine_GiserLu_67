using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for UnionFeatures.
    /// </summary>
   
    public sealed class UnionFeaturesCmd : BaseCommand
    {
        IHookHelper m_hookHelper = null;
        ESRI.ArcGIS.Carto.IActiveView m_activeView = null;
        IMap m_map = null;
        IFeatureLayer currentLayer = null;
        IEngineEditProperties m_engineEditor = null;




      


        public UnionFeaturesCmd()
        {
            m_engineEditor = new EngineEditorClass();
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null) return;
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            { return; }
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
            IEnumFeature selectedFeatures = GetSelectedFeatures();
            if (selectedFeatures == null) return;
            UnionFeatures(selectedFeatures); m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography | esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);

            // TODO: Add UnionFeaturesCmd.OnClick implementation
        }
        private ESRI.ArcGIS.Geodatabase.IEnumFeature GetSelectedFeatures()
        {
            if (m_map.SelectionCount < 2)
            { MessageBox.Show("选择要素少于两个！按shift选择多个要素！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return null; }
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null) return null;
            if (!(layer is IFeatureLayer)) return null;
            currentLayer = layer as IFeatureLayer;
            if (currentLayer.FeatureClass.ShapeType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
            { MessageBox.Show("所选要素应都为点要素！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return null; }
            IEnumFeature SelectedFeatures = m_map.FeatureSelection as IEnumFeature;
            if (SelectedFeatures == null) return null;
            //判断SelectedFeatures是否为相同的几何类型，且是否与m_engineEditor.TargetLayer几何类型相同
            bool sameGeometryType = JudgeGeometryType(SelectedFeatures);
            if (!sameGeometryType)
            { MessageBox.Show("所选要素应都为线要素！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return null; }
            return SelectedFeatures;
        }
        private bool JudgeGeometryType(IEnumFeature SelectedFeatures)
        {
            SelectedFeatures.Reset();
            IFeature feature = SelectedFeatures.Next();
            if (feature == null) return false;
            esriGeometryType geometryType = feature.ShapeCopy.GeometryType;
            while ((feature = SelectedFeatures.Next()) != null)
            {
                if (geometryType != feature.ShapeCopy.GeometryType)
                { return false; }
            }
            if (geometryType == currentLayer.FeatureClass.ShapeType)
                return true;
            return false;
        }
        private void UnionFeatures(IEnumFeature selectedFeatures)
        {
            IFeature feature = null;
            IGeometry geometry = null;
            object missing = Type.Missing;
            selectedFeatures.Reset();
            feature = selectedFeatures.Next();
            if (feature == null) return;
            IFeatureClass featureClass = feature.Class as IFeatureClass;
            IGeometryCollection geometries = new GeometryBagClass();
            while (feature != null)
            {
                geometry = feature.ShapeCopy;
                geometries.AddGeometry(geometry, ref missing, ref missing);
                feature = selectedFeatures.Next();
            }
            ITopologicalOperator unionedGeometry = null;
            switch (featureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryMultipoint:
                    unionedGeometry = new MultipointClass(); break;
                case esriGeometryType.esriGeometryPolyline:
                    unionedGeometry = new PolylineClass(); break;
                case esriGeometryType.esriGeometryPolygon:
                    unionedGeometry = new PolygonClass(); break;
                default: break;
            }

            unionedGeometry.ConstructUnion(geometries as IEnumGeometry);
            ITopologicalOperator2 topo = unionedGeometry as ITopologicalOperator2;
            topo.IsKnownSimple_2 = false; topo.Simplify();
            IFeatureClass targetFeatureClass = currentLayer.FeatureClass;
            IDataset dataset = featureClass as IDataset;
            IWorkspaceEdit workspaceEdit = dataset.Workspace as IWorkspaceEdit;
            if (!(workspaceEdit.IsBeingEdited())) return;
            try
            {
                workspaceEdit.StartEditOperation();
                IFeature unionedFeature = targetFeatureClass.CreateFeature();
                unionedFeature.Shape = unionedGeometry as IGeometry;
                unionedFeature.Store();
                workspaceEdit.StopEditOperation();
            }
            catch (Exception ex)
            {
                workspaceEdit.AbortEditOperation();
                MessageBox.Show("要素合并失败！！" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion
    }
}
