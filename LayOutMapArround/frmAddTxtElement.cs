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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace Giser_Lu
{
    public partial class frmAddTxtElement : Form
    {

        private IMapControlDefault m_MapControl;

        public frmAddTxtElement(IMapControlDefault mapcontrol)
        {
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            PreView();
        }

        private void PreView()
        {
            textBox1.Font= fontDialog1.Font;
            textBox1.ForeColor = colorDialog1.Color;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            PreView();
        }

        private void frmDrawTxt_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

      
       public void MapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //If left hand mouse button
            if (e.button == 1)
            {
                //Create a point and grab hold of the IPoint inteface
                IPoint pPoint = new PointClass();
                //Set point properties

                pPoint.PutCoords(e.mapX, e.mapY);

                ITextSymbol pTextSymbol = new TextSymbolClass();
              
                stdole.IFontDisp pFont;
                pFont = new stdole.StdFontClass() as stdole.IFontDisp;

                pFont.Name = textBox1.Font.Name;
                pFont.Italic = textBox1.Font.Italic;
                pFont.Underline = textBox1.Font.Underline;
                pFont.Bold = textBox1.Font.Bold;
                pFont.Size = (decimal)textBox1.Font.Size;
                pFont.Strikethrough = textBox1.Font.Strikeout;

                IRgbColor pRGB = new RgbColorClass();
                pRGB.Red = (int)textBox1.ForeColor.R;
                pRGB.Green = (int)textBox1.ForeColor.G;
                pRGB.Blue = (int)textBox1.ForeColor.B;


                pTextSymbol.Size = textBox1.Font.Size;
                pTextSymbol.Font = pFont;
                pTextSymbol.Color = pRGB;



                ITextElement pTextEle = new TextElementClass();
                pTextEle.Text = textBox1.Text;
                pTextEle.ScaleText = true;
                pTextEle.Symbol = pTextSymbol;

                IElement pEle = (IElement)pTextEle;
                pEle.Geometry = pPoint;

                IActiveView pActiveView = (IActiveView)m_MapControl.Map;
                IGraphicsContainer pGraphicsContatiner = (IGraphicsContainer)m_MapControl.Map;

                pGraphicsContatiner.AddElement(pEle, 0);

                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            }
            this.Close();
        }

      
    }
}