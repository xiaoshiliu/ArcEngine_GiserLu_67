using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace Giser_Lu
{

    public sealed class PolygonsDifference : BaseTool
    {
        
        //Application m_application = null;    
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null; 
        IMap m_map = null;
        IMapControlDefault m_Mapcontrol;
        IFeatureLayer pFeaturelayer;
        IEngineEditProperties m_engineEditor = null;
        
        public PolygonsDifference()
        {

            m_engineEditor = new EngineEditorClass();
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_Mapcontrol = (IMapControlDefault)hook;
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            {

                return;
            }
            pFeaturelayer = (IFeatureLayer)layer;
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            if ( m_map.SelectionCount != 2)
            {
                MessageBox.Show("不可用");
            }
           
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add PolygonsDifference.OnMouseDown implementation
            if (Button != (int)Keys.LButton) return;
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            {
             
                return;
            }
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
            ESRI.ArcGIS.Geometry.IPoint pPoint = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            ISelectionEnvironment pSelectionEnvironment = new SelectionEnvironmentClass(); pSelectionEnvironment.PointSelectionMethod = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelWithin;
            m_map.SelectByShape(pPoint as ESRI.ArcGIS.Geometry.IGeometry, pSelectionEnvironment, false);
            //if (m_map.SelectionCount != 2)
            //{ 
            //    MessageBox.Show("选择的多边形个数应该为2！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            //    return;
            //}
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
            ESRI.ArcGIS.Geodatabase.IEnumFeature pEnumFeature = m_map.FeatureSelection as ESRI.ArcGIS.Geodatabase.IEnumFeature;
            ESRI.ArcGIS.Geodatabase.IFeature firstFeature = pEnumFeature.Next();
            ESRI.ArcGIS.Geodatabase.IFeature secondFeature = pEnumFeature.Next();
            bool firstPolygonIsLarge = false;
            ESRI.ArcGIS.Geometry.IGeometry pGeometry = null;
            ESRI.ArcGIS.Geometry.IRelationalOperator pRelOp1 = firstFeature.Shape as ESRI.ArcGIS.Geometry.IRelationalOperator;
            ESRI.ArcGIS.Geometry.IRelationalOperator pRelOp2 = secondFeature.Shape as ESRI.ArcGIS.Geometry.IRelationalOperator;
            ESRI.ArcGIS.Geometry.ITopologicalOperator pTopologicalOperator = null;
            if (pRelOp1.Contains(secondFeature.Shape))
            {
                pTopologicalOperator = firstFeature.Shape as ESRI.ArcGIS.Geometry.ITopologicalOperator;
                pGeometry = pTopologicalOperator.Difference(secondFeature.Shape);
                firstPolygonIsLarge = true;
            }
            else if (pRelOp2.Contains(firstFeature.Shape))
            {
                pTopologicalOperator = secondFeature.Shape as ESRI.ArcGIS.Geometry.ITopologicalOperator;
                pGeometry = pTopologicalOperator.Difference(firstFeature.Shape);
                firstPolygonIsLarge = false;
            }
            else return;
            bool deleteInteriorPolygon = false;
            DialogResult pDialogResult = MessageBox.Show("是否要删除内多边形？", "操作提示", MessageBoxButtons.YesNo);
            if (pDialogResult == DialogResult.Yes)
            { deleteInteriorPolygon = true; }
            ESRI.ArcGIS.Geodatabase.IFeatureClass featureClass = firstFeature.Class as ESRI.ArcGIS.Geodatabase.IFeatureClass;
            ESRI.ArcGIS.Geodatabase.IDataset dataset = featureClass as ESRI.ArcGIS.Geodatabase.IDataset;
            ESRI.ArcGIS.Geodatabase.IWorkspaceEdit workspaceEdit = dataset.Workspace as ESRI.ArcGIS.Geodatabase.IWorkspaceEdit;
            if (!(workspaceEdit.IsBeingEdited())) return;
            workspaceEdit.StartEditOperation();
            if (firstPolygonIsLarge)
            {
                firstFeature.Shape = pGeometry;
                firstFeature.Store();
                if (deleteInteriorPolygon) secondFeature.Delete();
            }
            else
            {
                secondFeature.Shape = pGeometry;
                secondFeature.Store();
                if (deleteInteriorPolygon) firstFeature.Delete();
            }
            workspaceEdit.StopEditOperation();
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
            m_Mapcontrol.CurrentTool = null;
            

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add PolygonsDifference.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add PolygonsDifference.OnMouseUp implementation
        }

        public override bool Enabled
        {
            get
            {
                bool pEnable = true;
                if (pFeaturelayer.FeatureClass.ShapeType != ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon || m_map.SelectionCount != 2)
                {
                    pEnable = false;
                }
                return pEnable;

            }
        }
        #endregion
    }
}
