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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using stdole;


namespace Giser_Lu
{
    public partial class frmProportionalSymbolRenderer : Form
    {
        IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private IStyleGalleryItem m_StyleGallertItem;
        private IColor m_BackGroundColor;
        



        public frmProportionalSymbolRenderer(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmProportionalSymbolRenderer_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldToCBX();
            AddMakerSymbolToControl();
            m_BackGroundColor = new RgbColorClass();
           
            
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
                cbx_Layer.SelectedIndex = 0;
            }

        }
        private void AddFieldToCBX()
        {
            cbx_Field.Items.Clear();
            GetLayerByName(cbx_Layer.SelectedItem.ToString());

            if (m_FeatureLayer.FeatureClass.Fields != null)
            {

                for (int i = 0; i < m_FeatureLayer.FeatureClass.Fields.FieldCount; i++)
                {
                    if ((m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeDouble) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeInteger) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeSingle) ||
                        (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeSmallInteger))
                    {

                        cbx_Field.Items.Add(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Name.ToString());
                    }
                }
                if (cbx_Field.Items.Count == 0)
                {
                    cbx_Field.Items.Add("None");
                    
                }

                cbx_Field.SelectedIndex = 0;
              
            }
           
            
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

        private void AddMakerSymbolToControl()
        {
            //Get the ArcGIS install location
            string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");

            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");

            //Set the style class
            axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;

            //Select the color ramp item
            axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass).SelectItem(0);
        }
        private string ReadRegistry(string sKey)
        {
            //Open the subkey for reading
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, true);
            if (rk == null) return "";
            // Get the data from a specified item in the key.
            return (string)rk.GetValue("InstallDir");
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_StyleGallertItem = (IStyleGalleryItem)e.styleGalleryItem;
            PreviewImage();
        }

        private void PreviewImage()
        {
            //Get and set the style class 
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);

            //Preview an image of the symbol
            stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_StyleGallertItem, pictureBox1.Width, pictureBox1.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            pictureBox1.Image = image;
           
           
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string FieldName = cbx_Field.SelectedItem.ToString();
            if (FieldName == "None") { MessageBox.Show("不可用字段,请选择其它图层"); return; }
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)m_FeatureLayer;

            pGeoFeatureLayer.ScaleSymbols = true;
            ITable pTable = (ITable)pGeoFeatureLayer;
            ICursor pCursor = pTable.Search(null, true);

            IDataStatistics pDataStatistics = new DataStatisticsClass();
            pDataStatistics.Cursor = pCursor;
            //Set statistical field
            pDataStatistics.Field = FieldName;
            //Get the result of statistics
            IStatisticsResults pStatisticsResult = pDataStatistics.Statistics;
            if (pStatisticsResult == null)
            {
                MessageBox.Show("Failed to gather stats on the feature class");
                return;
            }

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
           // pFillSymbol.Color = m_BackGroundColor;
            

            IMarkerSymbol pCharaterMarkerS= new CharacterMarkerSymbolClass();
           
            pCharaterMarkerS = (IMarkerSymbol)m_StyleGallertItem.Item;     
            pCharaterMarkerS.Size = (int)numericUpDown1.Value;
            pCharaterMarkerS.Color=m_BackGroundColor;

            IProportionalSymbolRenderer pProportionalSymbolR = new ProportionalSymbolRendererClass();
            pProportionalSymbolR.ValueUnit = esriUnits.esriUnknownUnits;
            pProportionalSymbolR.Field = FieldName;
            pProportionalSymbolR.FlanneryCompensation = false;
            pProportionalSymbolR.MinDataValue = pStatisticsResult.Minimum;
            pProportionalSymbolR.MaxDataValue = pStatisticsResult.Maximum;
            pProportionalSymbolR.BackgroundSymbol = pFillSymbol;
            pProportionalSymbolR.MinSymbol = (ISymbol)pCharaterMarkerS;
            pProportionalSymbolR.LegendSymbolCount = 5;
            pProportionalSymbolR.CreateLegendSymbols();

            IRotationRenderer pRotationRenderer = (IRotationRenderer)pProportionalSymbolR;
            pRotationRenderer.RotationField = FieldName;
            pRotationRenderer.RotationType = esriSymbolRotationType.esriRotateSymbolGeographic;
            //Set the states layer renderer to the proportional symbol renderer and refresh the display
            pGeoFeatureLayer.Renderer = (IFeatureRenderer)pProportionalSymbolR;

            m_MapControl.ActiveView.ContentsChanged();
            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private IColor getRGBColor(int red, int green, int blue)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = red;
            pColor.Green = green;
            pColor.Blue = blue;
            return pColor;
        }

    
      


        private void btn_Color_Click(object sender, EventArgs e)
        {
;
            m_BackGroundColor.RGB = 255;
            //新建一个颜色板对象
            IColorPalette pPalette = new ColorPaletteClass();
            //定义一个范围结构
            tagRECT pRect = new tagRECT();
            pRect.left = 10;
            pRect.top = 10;
            pPalette.TrackPopupMenu(ref pRect, m_BackGroundColor, false, 0);
            //获得新的颜色
            m_BackGroundColor = pPalette.Color;
            PreviewImage();
            
        }
    }
     

      
      




    
}