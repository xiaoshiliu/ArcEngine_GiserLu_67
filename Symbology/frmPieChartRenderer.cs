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
    public partial class frmPieChartRenderer : Form
    {

        IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private IStyleGalleryItem m_StyleGallertItem;
        private IColor m_BackGroundColor;

        public frmPieChartRenderer(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmPieChartRenderer_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldsToLeftListBox();
            AddColorRampToControl();
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
        private void AddFieldsToLeftListBox()
        {

            lstbx_LeftFields.Items.Clear();
            lstbx_RightFields.Items.Clear();
            
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

                        lstbx_LeftFields.Items.Add(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Name.ToString());
                    }
                }
                if (lstbx_LeftFields.Items.Count == 0)
                {
                    lstbx_LeftFields.Items.Add("None");

                }

                lstbx_LeftFields.SelectedIndex = 0;


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
            AddFieldsToLeftListBox();
        }

        private void btn_AddField_Click(object sender, EventArgs e)
        {
            if (lstbx_LeftFields.Items.Count > 0)
            {
                if (lstbx_LeftFields.SelectedItem != null)
                {
                    lstbx_RightFields.Items.Add(lstbx_LeftFields.SelectedItem);
                    lstbx_LeftFields.Items.Remove(lstbx_LeftFields.SelectedItem);
                    lstbx_RightFields.SelectedIndex = lstbx_RightFields.Items.Count - 1; 
                }
            }
        }
        private void btn_RemoveField_Click(object sender, EventArgs e)
        {
            if (lstbx_RightFields.Items.Count > 0)
            {
                if (lstbx_RightFields.SelectedItem != null)
                {
                    lstbx_LeftFields.Items.Add(lstbx_RightFields.SelectedItem);
                    lstbx_RightFields.Items.Remove(lstbx_RightFields.SelectedItem);
                    lstbx_LeftFields.SelectedIndex = lstbx_LeftFields.Items.Count - 1; 
                }
            }
        }
        private void btn_RemoveAllFields_Click(object sender, EventArgs e)
        {
            if (lstbx_RightFields.Items.Count > 0)
            {
                
                lstbx_LeftFields.Items.AddRange(lstbx_RightFields.Items);
                lstbx_RightFields.Items.Clear();
                
            }
        }

        private void AddColorRampToControl()
        {
            //Get the ArcGIS install location
            string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");

            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");

            //Set the style class
            axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassColorRamps;

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

        private void btn_BackGroundColor_Click(object sender, EventArgs e)
        {
            
            m_BackGroundColor.RGB = 255;
            
            IColorPalette pPalette = new ColorPaletteClass();
            
            tagRECT pRect = new tagRECT();
            pRect.left = 10;
            pRect.top = 10;
           
            pPalette.TrackPopupMenu(ref pRect, m_BackGroundColor, false, 0);
            
            m_BackGroundColor = pPalette.Color;
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_StyleGallertItem = (IStyleGalleryItem)e.styleGalleryItem;
        }

        private IColor getRGB(int red, int green, int blue)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = red;
            pColor.Green = green;
            pColor.Blue = blue;
            return pColor;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string LayerName = cbx_Layer.SelectedItem.ToString();
         
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)m_FeatureLayer;
            ITable pTable = (ITable)pGeoFeatureLayer;
            ICursor pCursor = pTable.Search(null, true);

            int numFields = lstbx_RightFields.Items.Count;
            string[] fildName = new string[numFields];
            int[] fieldIndecies = new int[numFields];

            for (int i = 0; i < numFields; i++)
            {
                if (lstbx_RightFields.Items[i].ToString() != "None")
                {
                    fildName[i] = lstbx_RightFields.Items[i].ToString();
                   fieldIndecies[i] = pTable.FindField(fildName[i]);

                }
                else
                {
                    MessageBox.Show("不可用的字段,请选择其它图层");
                    return;
                    
                }
            }
            //fieldIndecies[0] = pTable.FindField(strPopField1);
            //fieldIndecies[1] = pTable.FindField(strPopField2);
            bool firstValue = true;
            double dmaxValue = 0.0;
            //Iterate across each feature
            IRowBuffer pRowBuffer = pCursor.NextRow();
            double dfieldValue;

            while (pRowBuffer != null)
            {
                // iterate  through each data field and update the maxVal if needed
                for (int lfieldIndex = 0; lfieldIndex <= numFields - 1; lfieldIndex++)
                {
                    dfieldValue = (double)pRowBuffer.get_Value(fieldIndecies[lfieldIndex]);
                    if (firstValue)
                    {
                        // Special case for the first value in a feature class
                        dmaxValue = dfieldValue;
                        firstValue = false;
                    }
                    else
                    {
                        if (dfieldValue > dmaxValue)
                        {
                            // we've got a new biggest value
                            dmaxValue = dfieldValue;
                        }
                    }
                }
                pRowBuffer = pCursor.NextRow();
            }
            if (dmaxValue <= 0)
            {
                MessageBox.Show("Failed to gather stats on the feature class");
                return;
            }

            IChartRenderer pChartRenderer = new ChartRendererClass();
            //Set up the fields to draw charts of
            IRendererFields pRendererFields = (IRendererFields)pChartRenderer;
            for (int i = 0; i < numFields; i++)
            {
                pRendererFields.AddField(fildName[i], fildName[i]);
            }
            

            // Set up the chart marker symbol to use with the renderer
            IPieChartSymbol pPieChartSymbol;
            pPieChartSymbol = new PieChartSymbolClass();
            //饼图使用顺时针方法
            pPieChartSymbol.Clockwise = true;
            //饼图有外轮廓线
            pPieChartSymbol.UseOutline = true;
            IChartSymbol pChartSymbol = (IChartSymbol)pPieChartSymbol;
            pChartSymbol.MaxValue = dmaxValue;
            ILineSymbol pOutline;
            pOutline = new SimpleLineSymbolClass();
            pOutline.Color = getRGB(213, 212, 252);
            pOutline.Width = 1;
            //设置外轮廓线的样式
            pPieChartSymbol.Outline = pOutline;
            IMarkerSymbol pMarkerSymbol = (IMarkerSymbol)pPieChartSymbol;
            pMarkerSymbol.Size = 8;

            IColorRamp pColorRamp = (IColorRamp)m_StyleGallertItem.Item;
            pColorRamp.Size = pTable.RowCount(null);

            bool ok = true;
            pColorRamp.CreateRamp(out ok);
            IEnumColors pEnumRamp = pColorRamp.Colors;
            IFillSymbol pFillSymbol;
            ISymbolArray pSymbolArray = (ISymbolArray)pPieChartSymbol;
            for (int i = 0; i < numFields; i++)
            {
                 pFillSymbol = new SimpleFillSymbolClass();
                 for (int j = 0; j < 8; j++)
                 {
                     pEnumRamp.Next();
                 }
                 pFillSymbol.Color = pEnumRamp.Next();
                 pSymbolArray.AddSymbol((ISymbol)pFillSymbol);
            }


            //Now set the barchart symbol into the renderer
            pChartRenderer.ChartSymbol = (IChartSymbol)pPieChartSymbol;
           // pChartRenderer.Label = "Population";

            //set up the background symbol to use tan color
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = m_BackGroundColor;
            pChartRenderer.BaseSymbol = (ISymbol)pFillSymbol;
            pChartRenderer.UseOverposter = false;

            IPieChartRenderer pPieChartRenderer = pChartRenderer as IPieChartRenderer;
            pPieChartRenderer.MinSize = 3;
            //设置最小值，用于尺寸比例
            pPieChartRenderer.MinValue = 453588;
            pPieChartRenderer.FlanneryCompensation = false;
            pPieChartRenderer.ProportionalBySum = true;
            //pChartRenderer.Label = "Population";
            //产生图例对象
            pChartRenderer.CreateLegend();
            //pdate the renderer and refresh the screen
            pGeoFeatureLayer.Renderer = (IFeatureRenderer)pChartRenderer;
            m_MapControl.ActiveView.ContentsChanged();
            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void lstbx_LeftFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (lstbx_LeftFields.Items.Count > 0)
            {
                if (lstbx_LeftFields.SelectedItem != null)
                {
                    lstbx_RightFields.Items.Add(lstbx_LeftFields.SelectedItem);
                    lstbx_LeftFields.Items.Remove(lstbx_LeftFields.SelectedItem);
                    lstbx_RightFields.SelectedIndex = lstbx_RightFields.Items.Count - 1;
                }
            }
        }

        private void lstbx_RightFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstbx_RightFields.Items.Count > 0)
            {
                if (lstbx_RightFields.SelectedItem != null)
                {
                    lstbx_LeftFields.Items.Add(lstbx_RightFields.SelectedItem);
                    lstbx_RightFields.Items.Remove(lstbx_RightFields.SelectedItem);
                    lstbx_LeftFields.SelectedIndex = lstbx_LeftFields.Items.Count - 1;
                }
            }
        }

     

        

     

     



    


       
    }
}