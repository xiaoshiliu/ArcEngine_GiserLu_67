using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace Giser_Lu
{
    class ChangeOrderOfLayersInTOCC
    {
        ITOCControlDefault m_TOCControl;
        IMapControlDefault m_MapControl;
        ILayer m_MoveLayer ;
        int ToIndex ;


        public ChangeOrderOfLayersInTOCC(IMapControlDefault pmapControl ,ITOCControlDefault ptocControl)
        {
            m_MapControl = pmapControl;
            m_TOCControl = ptocControl;
        }

        public void SelectMoveLayer(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;

                m_TOCControl.HitTest(e.x,e.y,ref item,ref map,ref layer,ref other ,ref index);

                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (layer is IAnnotationSublayer)
                    {
                        return;
                    }
                    else
                    {
                        m_MoveLayer = layer;
                    }
                }
            }
        }

        public void MoveToTargetLayer(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            if(e.button == 1)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;

                m_TOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

                IMap pmap = m_MapControl.ActiveView.FocusMap;
                
                if(item == esriTOCControlItem.esriTOCControlItemLayer || layer != null)
                {
                    if (m_MoveLayer != layer)
                    {
                        ILayer pTempLayer;
                        for (int i = 0; i < pmap.LayerCount; i++)
                        {
                            pTempLayer = pmap.get_Layer(i);
                            if (pTempLayer == layer)
                            {
                                ToIndex = i;
                            }
                        }
                        pmap.MoveLayer(m_MoveLayer, ToIndex);

                        m_MapControl.ActiveView.Refresh();

                       // m_TOCControl.Update();
                    }
                }

            }
        }

    }
}
