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
    /// Summary description for CreateEnvelopeTool.
    /// </summary>
    [Guid("7273a481-463b-4104-8671-7e9cd52485df")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.CreateEnvelopeTool")]
    public sealed class CreateEnvelopeTool : BaseTool
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

       // private IHookHelper m_hookHelper;
        IMapControlDefault m_MapControl;
        INewEnvelopeFeedback m_EnvelopeFeedback;
        IFeatureLayer m_CurrentLayer;
        IEngineEditProperties m_EngineEditProperties = null;

        public CreateEnvelopeTool()
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

            m_EngineEditProperties = new EngineEditorClass();
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_MapControl = (IMapControlDefault)hook;

            m_CurrentLayer = (IFeatureLayer)m_EngineEditProperties.TargetLayer;
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CreateEnvelopeTool.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //获得鼠标在控件上点击的位置，产生一个点对象
            IPoint pPt = m_MapControl.ActiveView .ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            if (m_EnvelopeFeedback == null)
            {
                m_EnvelopeFeedback = new NewEnvelopeFeedbackClass();
                m_EnvelopeFeedback.Display = m_MapControl.ActiveView.ScreenDisplay;
                m_EnvelopeFeedback.Start(pPt);
            }

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            IPoint pPt = m_MapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //MoveTo方法继承自IDisplayFeedback接口的定义
            if (m_EnvelopeFeedback != null) m_EnvelopeFeedback.MoveTo(pPt);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            IGeometry pGeo = null;
            pGeo = m_EnvelopeFeedback.Stop();
            m_EnvelopeFeedback = null;
            CreateFeature(pGeo);
        }

        private void CreateFeature(IGeometry pGeom)
        {
            IWorkspaceEdit pWorkspaceEdit = GetWorkspaceEdit();
            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_CurrentLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IConstructLine pConstructArc = pGeom as IConstructLine;
            //IConstructCircularArc pConstructArc = pGeom as IConstructCircularArc;
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
            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, m_CurrentLayer, pGeom.Envelope);
        }

        private IWorkspaceEdit GetWorkspaceEdit()
        {
            IDataset pDataset = (IDataset)m_CurrentLayer.FeatureClass;
            if (pDataset == null)
            {
                return null;
            }
            IWorkspaceEdit pWorksapceEdit = (IWorkspaceEdit)pDataset.Workspace;
            return pWorksapceEdit;

        }
        #endregion
    }
}
