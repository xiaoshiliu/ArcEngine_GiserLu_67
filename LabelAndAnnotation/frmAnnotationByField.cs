using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace Giser_Lu
{
    public partial class frmAnnotationByField : Form
    {
        IMapControlDefault m_MapControl;
        IFeatureLayer m_FeatureLayer;

        public frmAnnotationByField(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmAnnotationByField_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldToCBX();
        }

        private void AddLayersToCBX()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is IFeatureLayer)
                    {
                        cbx_Layer.Items.Add(m_MapControl.Map.get_Layer(i).Name.ToString());
                    }
                }
                if (m_MapControl.CustomProperty != null)
                {
                    m_FeatureLayer = (IFeatureLayer)m_MapControl.CustomProperty;
                    int index = cbx_Layer.Items.IndexOf(m_FeatureLayer.Name);
                    cbx_Layer.SelectedIndex = index;
                }
                else
                {
                    cbx_Layer.SelectedIndex = 0;
                }
            }

        }
        private void AddFieldToCBX()
        {

            cbx_Field.Items.Clear();
            GetLayerByName(cbx_Layer.SelectedItem.ToString());
            for (int i = 0; i < m_FeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                cbx_Field.Items.Add(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Name.ToString());
            }
            cbx_Field.SelectedIndex = 0;

        }
        private void GetLayerByName(string name)
        {
            for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
            {
                if (name == m_MapControl.Map.get_Layer(i).Name.ToString())
                {
                    m_FeatureLayer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);
                }
            }
        }
        private void cbx_Layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldToCBX();
        }
        private void PreView()
        {
            lbl_PreviewFont.ForeColor = colorDialog1.Color;
            lbl_PreviewFont.Font = fontDialog1.Font;

        }

        private void btn_FontSelector_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            PreView();
        }

        private void btn_FontColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            PreView();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)m_FeatureLayer;

            //清除原有注记
            pGeoFeatureLayer.DisplayAnnotation = false;
            m_MapControl.Refresh(esriViewDrawPhase.esriViewBackground, null, null);


            //得到图层的标注属性集合对象
            IAnnotateLayerPropertiesCollection pAnnoProps = pGeoFeatureLayer.AnnotationProperties;

            //清空这个集合内的对象
            pAnnoProps.Clear();

            IAnnotateLayerProperties pAnnoLayerProps;
            ILineLabelPlacementPriorities pPlacement;
            ILineLabelPosition pPosition;
            IBasicOverposterLayerProperties pBasic;
            ILabelEngineLayerProperties pLabelEngine;

            
            //设置文本属性
            stdole.IFontDisp pFont;
            pFont = new stdole.StdFontClass() as stdole.IFontDisp;

            pFont.Name = lbl_PreviewFont.Font.Name;
            pFont.Italic = lbl_PreviewFont.Font.Italic;
            pFont.Underline = lbl_PreviewFont.Font.Underline;
            pFont.Bold = lbl_PreviewFont.Font.Bold;
            pFont.Size = (decimal)lbl_PreviewFont.Font.Size;
            pFont.Strikethrough = lbl_PreviewFont.Font.Strikeout;

            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = (int)lbl_PreviewFont.ForeColor.R;
            pRGB.Green = (int)lbl_PreviewFont.ForeColor.G;
            pRGB.Blue = (int)lbl_PreviewFont.ForeColor.B;

            ITextSymbol pTextSymbol = new TextSymbolClass();

            pTextSymbol.Size = lbl_PreviewFont.Font.Size;
            pTextSymbol.Font = pFont;
            pTextSymbol.Color = pRGB;

            //设置注记文本的位置
            pPosition = new LineLabelPositionClass();
            pPosition.Parallel = false;
            pPosition.Perpendicular = true;

            pPlacement = new LineLabelPlacementPrioritiesClass();

            pBasic = new BasicOverposterLayerPropertiesClass();
            pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
            pBasic.LineLabelPosition = pPosition;

            //新建一个图层注记引擎对象，并设置它的属性
            pLabelEngine = new LabelEngineLayerPropertiesClass();
            pLabelEngine.Symbol = pTextSymbol;
            pLabelEngine.BasicOverposterLayerProperties = pBasic;

            //设置注记字段
            pLabelEngine.Expression = "["+cbx_Field.SelectedItem.ToString()+"]";

            pAnnoLayerProps = (IAnnotateLayerProperties)pLabelEngine;
            pAnnoProps.Add(pAnnoLayerProps);
            pGeoFeatureLayer.DisplayAnnotation = true;

            m_MapControl.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
        }

      
       

      
        

    

     

       

   

       
    }
}