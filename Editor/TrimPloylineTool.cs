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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for TrimPloylineTool.
    /// </summary>
    [Guid("0923683e-9154-4a60-a0f7-d507b4f30a9d")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.TrimPloylineTool")]
    public sealed class TrimPloylineTool : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

     
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        IEngineEditProperties m_engineEditor = null;
        IPoint m_firstPoint = null;
        IPoint m_secondPoint = null;
        IPoint m_activePoint = null;
        IFeature m_firstFeature = null;
        IFeature m_secondFeature = null;
        enum ToolPhase { SelectFirstFeature, SelectSecondFeature }
        ToolPhase m_toolPhase;


        public TrimPloylineTool()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }

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
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
            m_firstPoint = new PointClass();
            m_secondPoint = new PointClass();
            m_activePoint = new PointClass();

            // TODO:  Add TrimPloylineTool.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            m_toolPhase = ToolPhase.SelectFirstFeature;
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            {
                 return;
            }

        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (m_map == null || m_activeView == null) return;
            if (Button != (int)Keys.LButton) return;
            m_activeView.Refresh();
            m_activePoint = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            
            switch (m_toolPhase)
            {
                case (ToolPhase.SelectFirstFeature):
                    GetFirstFeature();
                    break;
                case (ToolPhase.SelectSecondFeature):
                    GetSecondFeafeature();
                    break;
            }

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add TrimPloylineTool.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add TrimPloylineTool.OnMouseUp implementation
        }

        public override bool Deactivate()
        {
            m_firstFeature = null;            m_secondFeature = null;
            m_firstPoint = null;            m_secondPoint = null;
            m_activePoint = null;
            return true;       

        }

        public override void OnKeyDown(int keyCode, int Shift)
        {
            // If the Escape key is used, throw away the calculated point.
            if (keyCode == (int)Keys.Escape)
            {
                m_toolPhase = ToolPhase.SelectFirstFeature;
                m_map.ClearSelection();
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
            }

        }
        #endregion


        private void GetFirstFeature()
        {
            m_firstPoint = m_activePoint;
            m_firstFeature = SelctFeatureBasedMousePoint(m_firstPoint); //用于修剪的目标线
            if (m_firstFeature != null)
                m_toolPhase = ToolPhase.SelectSecondFeature;
        }


        private IFeature SelctFeatureBasedMousePoint(IPoint pPoint)
        {
            ITopologicalOperator pTopo = pPoint as ITopologicalOperator;
            IGeometry pBuffer = pTopo.Buffer(0.5);
            IGeometry pGeometry = pBuffer.Envelope;
            // SetAllPolylinePolygonLayersSelectable();
            ISelectionEnvironment selEnvironment = new SelectionEnvironmentClass();
            selEnvironment.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
            m_map.SelectByShape(pGeometry, selEnvironment, true);
            IEnumFeature SelectedFeatures = m_map.FeatureSelection as IEnumFeature;
            SelectedFeatures.Reset();
            IFeature selFeature = SelectedFeatures.Next();
            //SetAllLayersSelectable();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
            return selFeature;
        }

        private void GetSecondFeafeature()
        {   //获得需要修剪的线要素，并进行修剪
            if (m_firstFeature == null)
            {
                m_toolPhase = ToolPhase.SelectFirstFeature;
                return;
            }
            m_secondPoint = m_activePoint;
            m_secondFeature = SelctFeatureBasedMousePoint(m_secondPoint);
            if (m_secondFeature == null)
            {
                m_toolPhase = ToolPhase.SelectSecondFeature;
                return;
            }
            TrimPolyline(m_secondFeature, m_firstFeature, m_secondPoint);
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography | esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
            m_toolPhase = ToolPhase.SelectFirstFeature;
        } 

        private void TrimPolyline(IFeature trimFeature, IFeature targetFeature, IPoint secondPoint)
        {   IGeometry preservedGeom = null;
            IGeometry leftGeom = null;
            IGeometry rightGeom = null;
            double distanceOnCurve = 0;
            double nearestDistance = 0;
            bool isRightSide = false;
            IPoint outPoint = new PointClass();
            IFeatureClass featureClass = trimFeature.Class as IFeatureClass;
            IDataset dataset = featureClass as IDataset;
            IWorkspaceEdit workspaceEdit = dataset.Workspace as IWorkspaceEdit;
            if (!(workspaceEdit.IsBeingEdited())) return;


            try
      {   IGeometry targetGeometry = targetFeature.ShapeCopy;
          IGeometry trimGeometry = trimFeature.ShapeCopy;
          ITopologicalOperator2 topo = trimGeometry as ITopologicalOperator2;
          topo.IsKnownSimple_2 = false;
          topo.Simplify();
          ITopologicalOperator2 topo2 = targetGeometry as ITopologicalOperator2;
          topo2.IsKnownSimple_2 = false;
          topo2.Simplify();
          topo.Cut(targetGeometry as IPolyline, out leftGeom, out rightGeom);
          ICurve curve = targetGeometry as ICurve;
          curve.QueryPointAndDistance (esriSegmentExtension.esriNoExtension, secondPoint, false, outPoint, ref distanceOnCurve, ref nearestDistance, ref isRightSide);
          if (isRightSide)
          { preservedGeom = leftGeom; }
          else
          { preservedGeom = rightGeom; }
          workspaceEdit.StartEditOperation();
          trimFeature.Shape = preservedGeom;
          trimFeature.Store();
          workspaceEdit.StopEditOperation();
          FlashGeometry(trimGeometry as IGeometry, 3, 10);
      }
      catch (Exception ex)
      {
          workspaceEdit.AbortEditOperation();
          MessageBox.Show("线要素延伸失败！！" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
  }

        private void FlashGeometry(IGeometry geometry, int flashCount, int interval)
        {
            IScreenDisplay display = m_activeView.ScreenDisplay;
            ISymbol symbol = CreateSimpleSymbol(geometry.GeometryType);
            display.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache); display.SetSymbol(symbol);
            for (int i = 0; i < flashCount; i++)
            {
                switch (geometry.GeometryType)
                {
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                        display.DrawPoint(geometry); break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                        display.DrawMultipoint(geometry); break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                        display.DrawPolyline(geometry); break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                        display.DrawPolygon(geometry); break;
                } System.Threading.Thread.Sleep(interval);
            } display.FinishDrawing();
        }

        private ISymbol CreateSimpleSymbol(esriGeometryType geometryType)
        {
            ISymbol symbol = null;
            switch (geometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                case esriGeometryType.esriGeometryMultipoint:
                    ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbolClass();
                    markerSymbol.Color = getRGB(255, 128, 128); markerSymbol.Size = 2;
                    symbol = markerSymbol as ISymbol; break;
                case esriGeometryType.esriGeometryPolyline:
                case esriGeometryType.esriGeometryPath:
                    ISimpleLineSymbol lineSymbol = new SimpleLineSymbolClass();
                    lineSymbol.Color = getRGB(255, 128, 128); lineSymbol.Width = 4;
                    symbol = lineSymbol as ISymbol; break;
                case esriGeometryType.esriGeometryPolygon:
                case esriGeometryType.esriGeometryRing:
                    ISimpleFillSymbol fillSymbol = new SimpleFillSymbolClass();
                    fillSymbol.Color = getRGB(255, 128, 128); symbol = fillSymbol as ISymbol; break;
            } symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            return symbol;
        }

        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
    }
}
