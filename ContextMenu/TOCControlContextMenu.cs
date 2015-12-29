using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Text;


using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;

namespace Giser_Lu
{
    class TOCControlContextMenu
    {
        
        ITOCControlDefault m_TOCControl;
        IMapControlDefault m_MapControl;

        IToolbarMenu m_MapContextMenu;
        IToolbarMenu m_LayerContextMenu;
        IToolbarMenu m_SetScaleRangeContextMenu;
       

        public TOCControlContextMenu(ITOCControlDefault tocControl ,IMapControlDefault mapControl)
        {
            m_TOCControl = tocControl;
            m_MapControl = mapControl;
            AddItemToContextMenu();
        }

       private void  AddItemToContextMenu()
        {
            m_MapContextMenu = new ToolbarMenuClass();
            m_MapContextMenu.AddItem(new SetLayerVisible(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_MapContextMenu.AddItem(new SetLayerVisible(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_MapContextMenu.AddItem(new ZoomToSelectedFeatures(), -1, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_MapContextMenu.SetHook(m_MapControl);

            m_SetScaleRangeContextMenu = new ToolbarMenuClass();
            m_SetScaleRangeContextMenu.Caption = "设置比例尺";
            m_SetScaleRangeContextMenu.AddItem(new SetScaleRange(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_SetScaleRangeContextMenu.AddItem(new SetScaleRange(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_SetScaleRangeContextMenu.AddItem(new SetScaleRange(), 3, 2, false, esriCommandStyles.esriCommandStyleTextOnly);

            m_LayerContextMenu = new ToolbarMenuClass();
            m_LayerContextMenu.AddItem(new ZoomToLayer(), -1, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_LayerContextMenu.AddItem(new RemoveLayer(),-1,-1,false,esriCommandStyles.esriCommandStyleTextOnly);
            m_LayerContextMenu.AddItem(new OpenAttributeTable(m_MapControl), -1, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_LayerContextMenu.AddItem(new OpenFormLableByField(m_MapControl), -1, -1, false, esriCommandStyles.esriCommandStyleTextOnly);

            m_LayerContextMenu.AddSubMenu(m_SetScaleRangeContextMenu, 2, true);

            m_LayerContextMenu.SetHook(m_MapControl);
        }
       public void SelectLayer(object sender, ITOCControlEvents_OnMouseDownEvent e)
       {
           esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
           IBasicMap pMap = null;
           ILayer pLayer = null;
           object pOther = new object();
           object pIndex = new object();

            if (e.button == 2)
            {
                if (m_MapControl.LayerCount > 0)
                {
                    

                    m_TOCControl.HitTest(e.x,e.y,ref item,ref pMap,ref pLayer , ref pOther ,ref pIndex);

                    if (item == esriTOCControlItem.esriTOCControlItemMap)
                    {
                        m_TOCControl.SelectItem(pMap,null);
                        m_MapControl.CustomProperty = (IMap)pMap;
                        m_MapContextMenu.PopupMenu(e.x, e.y, m_TOCControl.hWnd);
                      
                    }

                   

                    if (item == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        m_TOCControl.SelectItem(pLayer, null);
                        m_MapControl.CustomProperty = pLayer;
                        m_LayerContextMenu.PopupMenu(e.x, e.y, m_TOCControl.hWnd);
                    }
                   

                }
            }
            if (e.button == 1)
            {
                if (m_MapControl.LayerCount > 0)
                {
                    

                    m_TOCControl.HitTest(e.x, e.y, ref item, ref pMap, ref pLayer, ref pOther, ref pIndex);


                    if (item == esriTOCControlItem.esriTOCControlItemLegendClass)
                    {
                       MessageBox.Show("To Be Continue...");
                        ILegendClass pLegendClass ; ;
                        ILegendGroup pLegendGroup;
                        ISymbol pSymbol ;
                        pLegendGroup = (ILegendGroup)pOther;
                        pLegendClass = pLegendGroup.get_Class(Convert.ToInt32(pIndex));
                        pSymbol = pLegendClass.Symbol;

                        pSymbol = GetSimpleSymbolBySelector(pSymbol);

                        pLegendClass.Symbol = pSymbol;

                    }
                   
                   
                }
             
            }
        }

        private ISymbol GetSimpleSymbolBySelector(ISymbol symbolType)
        {
            ISymbolSelector pSymbolSelector = new SymbolSelectorClass();
            ISymbol symbol = null;
            if (symbolType is IMarkerSymbol)
            { symbol = new SimpleMarkerSymbolClass(); }
            if (symbolType is ILineSymbol)
            { symbol = new SimpleLineSymbolClass(); }
            if (symbolType is IFillSymbol)
            { symbol = new SimpleFillSymbolClass(); }
            pSymbolSelector.AddSymbol(symbol);
            bool response = pSymbolSelector.SelectSymbol(0);
            if (response)
            {
                symbol = pSymbolSelector.GetSymbolAt(0);
                return symbol;
            }
            return null;
        }
    }
}
