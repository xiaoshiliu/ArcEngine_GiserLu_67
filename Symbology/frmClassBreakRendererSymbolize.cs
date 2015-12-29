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
    public partial class frmClassBreakRendererSymbolize : Form
    {
        IMapControlDefault m_MapControl;
        private IClassBreaksRenderer m_classBreaksRenderer;
        private IStyleGalleryItem m_styleGalleryItem;
        private IFeatureLayer m_FeatureLayer;
        //private IGeoFeatureLayer m_geofeaturelayer;
        double m_MaxOfField;
        double m_MinOfField;


        public frmClassBreakRendererSymbolize(IMapControlDefault mapControl)
        {
            InitializeComponent();
            m_MapControl = mapControl;
          
        }

        private void frmClassBreakRendererSymbolize_Load(object sender, EventArgs e)
        {
            AddLayersToCBX();
            AddFieldToCBX();
            AddStyleOfSymbol();
            
           
            this.numUD_TotalClasses.Value = 3;
          
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
        private void AddStyleOfSymbol()
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

        private string ReadRegistry(string sKey)
        {
            //Open the subkey for reading
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, true);
            if (rk == null) return "";
            // Get the data from a specified item in the key.
            return (string)rk.GetValue("InstallDir");
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

        private void cbx_Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)m_FeatureLayer;

            //Find the selected field in the feature layer
            IFeatureClass featureClass = m_FeatureLayer.FeatureClass;
            string pFileName = cbx_Field.SelectedItem.ToString();
            if (pFileName == "None") { MessageBox.Show("不可用的字段,请选择其它图层"); return; }
            IField field = featureClass.Fields.get_Field(featureClass.FindField(pFileName));

            //Get a feature cursor
            ICursor cursor = (ICursor)m_FeatureLayer.Search(null, false);

            //Create a DataStatistics object and initialize properties
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = field.Name;
            dataStatistics.Cursor = cursor;

            //Get the result statistics
            IStatisticsResults statisticsResults = dataStatistics.Statistics;
           
            //Set the values min min and max values
            m_MinOfField = statisticsResults.Minimum;
            m_MaxOfField = statisticsResults.Maximum;
            
            m_classBreaksRenderer = new ClassBreaksRenderer();
            m_classBreaksRenderer.Field = cbx_Field.SelectedItem.ToString();
            m_classBreaksRenderer.BreakCount = (int)numUD_TotalClasses.Value;
            m_classBreaksRenderer.MinimumBreak = m_MinOfField;
           
            double interval = (m_MaxOfField - m_MinOfField) / m_classBreaksRenderer.BreakCount;

            //Get the color ramp
            IColorRamp colorRamp = (IColorRamp)m_styleGalleryItem.Item;
            //Set the size of the color ramp and recreate it
            colorRamp.Size = Convert.ToInt32(numUD_TotalClasses.Value);
            bool createRamp;
            colorRamp.CreateRamp(out createRamp);

            //Get the enumeration of colors from the color ramp
            IEnumColors enumColors = colorRamp.Colors;
            enumColors.Reset();
            double currentBreak = m_classBreaksRenderer.MinimumBreak;

            ISimpleFillSymbol simpleFillSymbol;
            //Loop rhough each class break
            for (int i = 0; i <= m_classBreaksRenderer.BreakCount - 1; i++)
            {
                //Set class break
                m_classBreaksRenderer.set_Break(i, currentBreak);
                //Create simple fill symbol and set color
                simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = enumColors.Next();
                //Add symbol to renderer
                m_classBreaksRenderer.set_Symbol(i, (ISymbol)simpleFillSymbol);
                currentBreak += interval;
            }

            pGeoFeatureLayer.Renderer = (IFeatureRenderer)m_classBreaksRenderer;

           // geofeaturelayer.Renderer = (IFeatureRenderer)classBreaksRenderer;
            m_MapControl.ActiveView.ContentsChanged();
            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, pGeoFeatureLayer, null);

        }

        private void cbx_Layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldToCBX();
        }

    }
}