using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;


namespace Giser_Lu
{
    class OverView
    {
        private IMapControlDefault m_MainFormMapControl;
        
        private AxMapControl m_axMapControl;

        public OverView (ref Form frmoverview , IMapControlDefault mapControl )
        {
            m_MainFormMapControl = mapControl;
            m_axMapControl = new AxMapControl();
            frmoverview.Controls.Add(m_axMapControl);
            m_axMapControl.Dock = DockStyle.Fill;
            
        
           
            
        }

         public void OverViewSynchronizeDraw(object sender , IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IEnvelope pEnv;
            pEnv = (IEnvelope)e.newEnvelope;

            IGraphicsContainer pGraphicsContrainer;

            IActiveView pActiveView;

            pGraphicsContrainer = (IGraphicsContainer)m_axMapControl.Map;
            pActiveView = (IActiveView)pGraphicsContrainer;

            //在绘制新的矩形框前,清除Map对象中的任何图形元素
            pGraphicsContrainer.DeleteAllElements();

            IRectangleElement pRectangleEle = new RectangleElementClass();

            IElement pEle = (IElement)pRectangleEle;

            pEle.Geometry = pEnv;

            IRgbColor pColor;

            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Transparency = 255;

            ILineSymbol pOutLine = new SimpleLineSymbolClass();

            pOutLine.Width = 1;
            pOutLine.Color = pColor;

            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Transparency = 0;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;

            IFillShapeElement pFillShapeEle;
            pFillShapeEle = (IFillShapeElement)pEle;
            pFillShapeEle.Symbol = pFillSymbol;
            pEle = (IElement)pFillShapeEle;

            pGraphicsContrainer.AddElement(pEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        
        public void OverViewSynchronizeOnMapReplace(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            if (m_MainFormMapControl != null && m_axMapControl != null)
            {
                m_axMapControl.Map.ClearLayers();
                IMap pMap = m_MainFormMapControl.Map;
                
                for (int i = 0; i < pMap.LayerCount; i++)
                {
                    m_axMapControl.Map.AddLayer(pMap.get_Layer(i));
                }

                
            }

            m_axMapControl.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
           
        }
       
        public void frmOverView_Shown(object sender, EventArgs e)
        {
            if (m_MainFormMapControl.Map.LayerCount > 0)
            {
                if (m_MainFormMapControl != null && m_axMapControl != null)
                {
                    m_axMapControl.Map.ClearLayers();

                    IMap pMap = m_MainFormMapControl.Map;
                    for (int i = 0; i < pMap.LayerCount; i++)
                    {
                        m_axMapControl.Map.AddLayer(pMap.get_Layer(i));
                    }
                }

                m_axMapControl.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
               
            }
        }

    }
}
