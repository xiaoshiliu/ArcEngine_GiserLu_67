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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;


namespace Giser_Lu
{
    /// <summary>
    /// Summary description for SelectbyPoint.
    /// </summary>
    [Guid("53e2a1f4-1686-4b90-96a8-4c2e013cdca7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.SelectbyPoint")]
    public sealed class SelectbyPoint : BaseTool
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

        private IHookHelper m_hookHelper = new HookHelperClass();
        IMap  m_Map;
        IActiveView m_ActiveView;
        //private IMapControlDefault m_MapControl;

        public SelectbyPoint()
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
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
            // TODO:  Add SelectbyPoint.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add SelectbyPoint.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {

            if (Button == 1)
            {
                m_ActiveView = m_hookHelper.ActiveView;
                m_Map = m_hookHelper.FocusMap;

                IFeatureLayer pFeatureLayer =(IFeatureLayer) m_Map.get_Layer(0);
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

                IPoint pPoint = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

                ITopologicalOperator pTopo = (ITopologicalOperator)pPoint;

                IGeometry pBuffer = pTopo.Buffer(0.1);

                IGeometry pGeo = pBuffer.Envelope;

                ISpatialFilter pSpatialFilter = new SpatialFilterClass();

                pSpatialFilter.Geometry = pGeo;

                switch (pFeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        break;
                }
                IFeatureSelection pFeatureSelection = (IFeatureSelection)pFeatureLayer;

                pFeatureSelection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                ISelectionSet pFeatureSet = pFeatureSelection.SelectionSet;

                ICursor pCursor;

                pFeatureSet.Search(null, true, out pCursor);

                IFeatureCursor pFeatureCursor = (IFeatureCursor)pCursor;

                IFeature pFeature = pFeatureCursor.NextFeature();


                while (pFeature != null)
                {
                    m_Map.SelectFeature((ILayer)pFeatureLayer, pFeature);
                    pFeature = pFeatureCursor.NextFeature();
                }

                m_ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);


               // m_MapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;

               // IPoint point = new PointClass();

               // point.PutCoords(X, Y);

               // //IScreenDisplay pScreenDisplay = m_MapControl.ActiveView.ScreenDisplay;
               // //pScreenDisplay.DisplayTransformation
               // //m_MapControl.Map.ClearSelection();

               // m_MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

               // IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)m_MapControl.Map;
               // IEnumElement pEnumEle = pGraphicsContainer.LocateElements(point, 1);
                
                
               // m_MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
               // //m_MapControl.Map.SelectByShape((IGeometry)point, null, false);
               //// m_MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    
            }

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add SelectbyPoint.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add SelectbyPoint.OnMouseUp implementation
        }
        #endregion
    }
}
