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
    /// Summary description for SetLayerVisible.
    /// </summary>
    [Guid("8b3c7ac4-9189-4b9d-bf99-c03d97ac13a1")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.SetLayerVisible")]
    public sealed class SetLayerVisible : BaseCommand,ICommandSubType
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
        private int m_SubType ;

        public SetLayerVisible()
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

            

            m_hookHelper.Hook = hook;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add SetLayerVisible.OnClick implementation
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount ; i++)
            {
                if (m_SubType == 1)
                {
                    m_hookHelper.FocusMap.get_Layer(i).Visible = true;
                }
                if(m_SubType == 2)
                {
                    m_hookHelper.FocusMap.get_Layer(i).Visible = false;
                }
            }
            m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        #endregion

        #region ICommandSubType 成员

        public int GetCount()
        {
            return 2;
           
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
                    return "打开所有图层";
                }
                else
                {
                    return "关闭所有图层";
                }
            }
        }

        public override bool Enabled
        {
            
            get
            {
                bool pEnabled = false;
                if (m_SubType == 1)
                {
                    for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
                    {
                        if (m_hookHelper.FocusMap.get_Layer(i).Visible == false)
                        {
                            pEnabled =true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
                    {
                        if (m_hookHelper.FocusMap.get_Layer(i).Visible == true)
                        {
                            pEnabled =true;
                            break;
                        }
                    }
                }

                return pEnabled;
            }
        }
        #endregion
    }
}
