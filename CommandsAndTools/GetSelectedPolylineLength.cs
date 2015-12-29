using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.GeoDatabaseUI;
using ESRI.ArcGIS.Geodatabase;


namespace Giser_Lu
{
    /// <summary>
    /// Summary description for GetSelectedPolylineLength.
    /// </summary>
    [Guid("ace846f8-dc08-48bc-a401-bbafedfad847")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.GetSelectedPolylineLength")]
    public sealed class GetSelectedPolylineLength : BaseCommand
    {
        

        //private IHookHelper m_hookHelper;
        private IMapControlDefault m_mapControl;
        private string m_PolylineLength;

        public string PolyLineLength
        {
            get { return m_PolylineLength; }
            set { m_PolylineLength = value; }
        }

       
        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControlDefault)hook;
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            
            IEnumFeature selectedFeatures = (IEnumFeature)m_mapControl.Map.FeatureSelection;

            selectedFeatures.Reset();

            IFeature selectedFeature = (IFeature)selectedFeatures.Next();

            if (selectedFeature == null)
            {
                m_PolylineLength = "无线要素";
                return;
            }
            else
            {
                IFeatureClass featureClass = (IFeatureClass)selectedFeature.Class;

                if (featureClass.ShapeType != esriGeometryType.esriGeometryPolyline)
                {
                    m_PolylineLength = "不是线要素";
                    return;
                }
                else
                {
                    IPolyline polyline = (IPolyline)selectedFeature.ShapeCopy;
                    
                    m_PolylineLength = polyline.Length.ToString();
                }
            }
        }

 

        #endregion
    }
}
