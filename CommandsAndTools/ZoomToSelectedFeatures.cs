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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for ZoomToSelectedFeatures.
    /// </summary>
    [Guid("e7e4809f-5ee6-4ce2-b878-0a17b9c7232b")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.CommandsAndTools.ZoomToSelectedFeatures")]
    public sealed class ZoomToSelectedFeatures : BaseCommand
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

        public ZoomToSelectedFeatures()
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
            m_MapControl = (IMapControlDefault)hook;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {

            IEnumFeature pEnumFeature = (IEnumFeature)m_MapControl.Map.FeatureSelection;
            IFeature pFeature = pEnumFeature.Next();
            IEnvelope pEnvelope = new EnvelopeClass();
            if (pFeature != null)
            {
                if (pFeature.ShapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.X = (pFeature.Extent.XMax + pFeature.Extent.XMin) / 2;
                    pPoint.Y = (pFeature.Extent.YMax + pFeature.Extent.YMin) / 2;

                    m_MapControl.CenterAt(pPoint);

                }
                else
                {
                    while (pFeature != null)
                    {
                        pEnvelope.Union(pFeature.Extent);
                        pFeature = pEnumFeature.Next();
                    }
                }
                m_MapControl.ActiveView.Extent = pEnvelope;

                m_MapControl.ActiveView.Refresh();
            }
            
        }
        public override string Caption
        {
            get
            {
                return "缩放到所选要素";
            }
        }
        #endregion
    }
}
