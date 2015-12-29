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
    public partial class frmLableByField : Form
    {
        IMapControlDefault m_MapControl;
        IFeatureLayer m_FeatureLayer;

        public frmLableByField(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmLableByField_Load(object sender, EventArgs e)
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
           

            IFeatureClass pFeatureClass = (IFeatureClass)m_FeatureLayer.FeatureClass;
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, true);

            IFeature pFeatrue = pFeatureCursor.NextFeature();
            while (pFeatrue != null)
            {
                IFields pFields = pFeatrue.Fields;
                int i = pFields.FindField(cbx_Field.SelectedItem.ToString());

                IEnvelope pEnvelope = pFeatrue.Extent;
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);

                stdole.IFontDisp pFont;
                pFont = new stdole.StdFontClass() as stdole.IFontDisp;

                pFont.Name = lbl_PreviewFont.Font.Name;
                pFont.Italic = lbl_PreviewFont.Font.Italic;
                pFont.Underline = lbl_PreviewFont.Font.Underline;
                pFont.Bold = lbl_PreviewFont.Font.Bold;
                pFont.Size = (decimal)lbl_PreviewFont.Font.Size;
                pFont.Strikethrough = lbl_PreviewFont.Font.Strikeout;
                
                IRgbColor pRGB = new RgbColorClass();
                pRGB.Red =(int) lbl_PreviewFont.ForeColor.R;
                pRGB.Green =(int)lbl_PreviewFont.ForeColor.G;
                pRGB.Blue =(int)lbl_PreviewFont.ForeColor.B;

                ITextSymbol pTextSymbol = new TextSymbolClass();

                pTextSymbol.Size = lbl_PreviewFont.Font.Size;
                pTextSymbol.Font = pFont;
                pTextSymbol.Color = pRGB;

                ITextElement pTextEle = new TextElementClass();
                pTextEle.Text = pFeatrue.get_Value(i).ToString();
                pTextEle.ScaleText = true;
                pTextEle.Symbol = pTextSymbol;

                IElement pEle = (IElement)pTextEle;
                pEle.Geometry = pPoint;

                IActiveView pActiveView = (IActiveView)m_MapControl.Map;
                IGraphicsContainer pGraphicsContatiner = (IGraphicsContainer)m_MapControl.Map;

                pGraphicsContatiner.AddElement(pEle, 0);

                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                pPoint = null;
                pEle = null;
                pFeatrue = pFeatureCursor.NextFeature();
            }

            
        }

      

       

       

        



     
    }
}