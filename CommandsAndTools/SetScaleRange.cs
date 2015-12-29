using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for SetScaleRange.
    /// </summary>
    [Guid("a109d9f5-e81e-4ebc-94a3-c3e002269647")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.SetScaleRange")]
    public sealed class SetScaleRange : BaseCommand,ICommandSubType
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

        private IMapControlDefault m_MapControl;
        private int m_SubType;

        public SetScaleRange()
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
            
            // TODO:  Add other initialization code
            m_MapControl = (IMapControlDefault)hook;
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            ILayer pLayer = (ILayer)m_MapControl.CustomProperty;

            if (m_SubType == 1)
            { 
                pLayer.MaximumScale = m_MapControl.MapScale;
            }

            if (m_SubType == 2)
            {
                pLayer.MinimumScale = m_MapControl.MapScale;
            }

            if (m_SubType == 3)
            { 
                pLayer.MaximumScale=0;
                pLayer.MinimumScale = 0;
            }

            m_MapControl.Refresh(esriViewDrawPhase.esriViewGeography,null,null);
        }

        #endregion

        #region ICommandSubType 成员

        public int GetCount()
        {
            return 3;
        }

        public void SetSubType(int SubType)
        {
            m_SubType = SubType;
        }
        public override string Caption
        {
            get
            {
                if (m_SubType == 1)
                {
                    return "设置当前视图为最大比例尺";
                }
                else if (m_SubType == 2)
                {
                    return "设置当前视图为最小比例尺";
                }
                else
                {
                    return "清除所设比例尺";
                }
            }
        }

        public override bool Enabled
        {
            get
            {
                bool pEnabled = true;
                ILayer player = (ILayer)m_MapControl.CustomProperty;

                if (m_SubType == 3)
                {
                    if (player.MaximumScale == 0 && player.MinimumScale == 0)
                    {
                        pEnabled = false;
                    }
                }
                return pEnabled;
            }
        }
        #endregion
    }
}
