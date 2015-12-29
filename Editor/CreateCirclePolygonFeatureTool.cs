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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for CreateCirclePolygonFeatureTool.
    /// </summary>
    [Guid("49704a05-f841-435f-bbe3-d1cb0fdff310")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.CreateCirclePolygonFeatureTool")]
    public sealed class CreateCirclePolygonFeatureTool : BaseTool
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

        //private IHookHelper m_hookHelper;
        IHookHelper m_hookHelper = new HookHelperClass();
        IMap m_Map;
        IActiveView m_ActiveView;
        INewCircleFeedback pCircleFeedback;
        IFeatureLayer m_pCurrentLayer;
        IEngineEditProperties m_EngineEditProperties = null;

        public CreateCirclePolygonFeatureTool()
        {
            //if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            //{
            //    m_pCurrentLayer = featureLayer;
            //}
            //else
            //{
            //    return;
            //}
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
            m_EngineEditProperties = new EngineEditorClass();
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
            m_ActiveView = m_hookHelper.ActiveView;
            m_Map = m_hookHelper.FocusMap;

            m_pCurrentLayer = (IFeatureLayer)m_EngineEditProperties.TargetLayer;
            
           
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //获得鼠标在控件上点击的位置，产生一个点对象
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            if (pCircleFeedback == null)
            {
                pCircleFeedback = new NewCircleFeedbackClass();
                pCircleFeedback.Display = m_ActiveView.ScreenDisplay;
                pCircleFeedback.Start(pPt);
            }

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //MoveTo方法继承自IDisplayFeedback接口的定义
            if (pCircleFeedback != null) pCircleFeedback.MoveTo(pPt);

        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            IGeometry pGeo = null;
            pGeo = pCircleFeedback.Stop();
            pCircleFeedback = null;
            CreateFeature(pGeo);

        }

        private void CreateFeature(IGeometry pGeom)
        {
           IWorkspaceEdit pWorkspaceEdit = GetWorkspaceEdit();
            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_pCurrentLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IConstructCircularArc pConstructArc = pGeom as IConstructCircularArc;
            IPolygon pPolygon = new PolygonClass();
            ISegmentCollection pSegmentCollection = pPolygon as ISegmentCollection;
            ISegment pSegment = pConstructArc as ISegment;
            object missing = Type.Missing;
            pSegmentCollection.AddSegment(pSegment, ref missing, ref missing);
            pWorkspaceEdit.StartEditOperation();
            IFeature pFeature = pFeatureClass.CreateFeature();
            pFeature.Shape = pPolygon;
            
            pFeature.Store();
            pWorkspaceEdit.StopEditOperation();
            m_ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, m_pCurrentLayer, pGeom.Envelope);
        }

        private IWorkspaceEdit GetWorkspaceEdit()
        {
            IDataset pDataset =(IDataset)m_pCurrentLayer.FeatureClass;
            if(pDataset == null)
            {
                return null;
            }
            IWorkspaceEdit pWorksapceEdit = (IWorkspaceEdit)pDataset.Workspace;
            return pWorksapceEdit;
           
        }

        #endregion



    
    }
}
