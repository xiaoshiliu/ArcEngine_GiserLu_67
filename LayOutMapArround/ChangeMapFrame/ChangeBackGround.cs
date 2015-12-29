using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.CartoUI;
namespace Giser_Lu
{
    /// <summary>
    /// Summary description for ChangeBackGround.
    /// </summary>
    [Guid("d76549d1-7f77-4c98-a0d4-bd74f5c118d9")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.ChangeBackGround")]
    public sealed class ChangeBackGround : BaseCommand
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
        private IPageLayoutControlDefault m_PageLayOutControl;
        //private IHookHelper m_hookHelper;

        public ChangeBackGround()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text
            base.m_message = "";  //localizable text 
            base.m_toolTip = "";  //localizable text 
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_PageLayOutControl = (IPageLayoutControlDefault)hook;
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            IActiveView pActiveView = (IActiveView)m_PageLayOutControl.PageLayout;

            IMap pMap = pActiveView.FocusMap;

            IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)pActiveView;

            IMapFrame pMapFrame = (IMapFrame)pGraphicsContainer.FindFrame(pMap);

            IStyleSelector pStyleSelector = new BackgroundSelectorClass();

            bool m_bOK = pStyleSelector.DoModal(m_PageLayOutControl.hWnd);

            if (!m_bOK) return;

            IBackground pBackground = (IBackground)pStyleSelector.GetStyle(0);

            pMapFrame.Background = pBackground;

            m_PageLayOutControl.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
            
        }

        #endregion
    }
}
