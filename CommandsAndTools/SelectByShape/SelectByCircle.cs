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

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for SelectByCircle.
    /// </summary>
    [Guid("e6a06c80-3f8a-4947-a770-c3cbb7bea8bb")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.SelectByCircle")]
    public sealed class SelectByCircle : BaseTool
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
        private IMapControlDefault m_mapControl;
        public SelectByCircle()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            //try
            //{
            //    //
            //    // TODO: change resource name if necessary
            //    //
            //    string bitmapResourceName = GetType().Name + ".bmp";
            //    base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            //    base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            //}
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            //if (m_hookHelper == null)
            //    m_hookHelper = new HookHelperClass();

            //m_hookHelper.Hook = hook;

            m_mapControl = (IMapControlDefault)hook;
            // TODO:  Add SelectByCircle.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add SelectByCircle.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            if (Button == 1)
            {

                IGeometry pGeo;

                pGeo = m_mapControl.TrackCircle();

                m_mapControl.Map.ClearSelection();

                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                m_mapControl.Map.SelectByShape(pGeo, null, false);


                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add SelectByCircle.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add SelectByCircle.OnMouseUp implementation
        }
        #endregion
    }
}
