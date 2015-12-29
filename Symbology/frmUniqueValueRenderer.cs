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


namespace Giser_Lu
{
    public partial class frmUniqueValueRenderer : Form
    {
        private IMapControlDefault m_MapControl;
        private IFeatureLayer m_FeatureLayer;
        private IStyleGalleryItem m_StyleGallertItem;

        public frmUniqueValueRenderer(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmUniqueValueRenderer_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldToCBX();
            AddColorRampToControl();

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
                    m_FeatureLayer =(IFeatureLayer) m_MapControl.Map.get_Layer(i);
                }
            }
        }
        private void cbx_Layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldToCBX();
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
        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_StyleGallertItem = (IStyleGalleryItem)e.styleGalleryItem;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            string FieldName = cbx_Field.SelectedItem.ToString();
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)m_FeatureLayer;

            pGeoFeatureLayer.ScaleSymbols = false;
            ITable pTable = (ITable)pGeoFeatureLayer;

            if (pTable.FindField(FieldName) == -1)
            {
                return;
            }
            else
            {
                IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();
                pUniqueValueRenderer.FieldCount = 1;
                pUniqueValueRenderer.set_Field(0, FieldName);

                IColorRamp pColorRamp = (IColorRamp)m_StyleGallertItem.Item;
                pColorRamp.Size = pTable.RowCount(null);

                bool ok = true;
                pColorRamp.CreateRamp(out ok);
                IEnumColors pEnumRamp = pColorRamp.Colors;

                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.AddField(FieldName);
                //依据某个字段在表中找出指向所有行的游标对象
                ICursor pCursor = pTable.Search(pQueryFilter, true);
                IRow pNextRow = pCursor.NextRow();
                //遍历所有的要素
                IColor pNextUniqueColor;
                string codeValue;
                while (pNextRow != null)
                {

                    codeValue = pNextRow.get_Value(pTable.FindField(FieldName)).ToString();
                    //获得随机颜色带中的任意一种颜色
                    pNextUniqueColor = pEnumRamp.Next();
                    IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                    pFillSymbol.Color = pNextUniqueColor;
                    //将每次得到的要素字段值和修饰它的符号放入着色对象中
                   pUniqueValueRenderer.AddValue(codeValue, FieldName, (ISymbol)pFillSymbol);
                    pNextRow = pCursor.NextRow();
                }
                pGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;
                m_MapControl.ActiveView.ContentsChanged();
              m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);	
               
            }
        }



    }
}