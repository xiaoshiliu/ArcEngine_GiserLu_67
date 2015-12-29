using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for NewMapDocument.
    /// </summary>
    [Guid("a335c782-f995-453e-9749-391486efb101")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.NewMapDocument")]
    public sealed class NewMapDocument : BaseCommand
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

        private IHookHelper m_hookHelper;
       
        
      

        public NewMapDocument()
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
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
        //    DialogResult res = MessageBox.Show("是否保存当前文档?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (res == DialogResult.Yes)
        //    {
        //        ICommand command = new ControlsSaveAsDocCommandClass();
        //        if (m_mapcontrol != null)
        //        {
        //            command.OnCreate(m_controlsSynchronizer.MapControl.Object);
        //        }
        //        else
        //        {
        //            command.OnCreate(m_controlsSynchronizer.PageLayoutControl.Object);
        //        }
        //        command.OnClick();

        //    }

        //    IMap map = new MapClass();
        //    map.Name = "新建地图文档";
        //    m_controlsSynchronizer.MapControl.DocumentFilename = string.Empty;

        //    m_controlsSynchronizer.ReplaceMap(map);




            IMapControl3 mapControl = null;

            //get the MapControl from the hook in case the container is a ToolbatControl
            if (m_hookHelper.Hook is IToolbarControl)
            {
                mapControl = (IMapControl3)((IToolbarControl)m_hookHelper.Hook).Buddy;
            }
            //In case the container is MapControl
            else if (m_hookHelper.Hook is IMapControl3)
            {
                mapControl = (IMapControl3)m_hookHelper.Hook;
            }
            else
            {
                MessageBox.Show("Active control must be MapControl!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //allow the user to save the current document
            DialogResult res = MessageBox.Show("保存当前文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //launch the save command (why work hard!?)
                ICommand command = new ControlsSaveAsDocCommandClass();
                command.OnCreate(m_hookHelper.Hook);
                command.OnClick();
            }

            //craete a new Map
            IMap map = new MapClass();
            map.Name = "新建地图文档";

            //assign the new map to the MapControl
            mapControl.DocumentFilename = string.Empty;
            mapControl.Map = map;
        }

        #endregion
    }
}
