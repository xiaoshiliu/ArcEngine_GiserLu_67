using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using DevComponents.DotNetBar;
using ESRI.ArcGIS.Geodatabase;

namespace Giser_Lu
{
   
    class ManagerEditorToolBar
    {
        private IMapControlDefault m_MapControl;
        private ILayer m_CurrentLayer ;
        private ComboBoxItem m_ComboxItem;
      
        public ManagerEditorToolBar(IMapControlDefault mapcontrol ,ComboBoxItem cbx)
        {
            m_MapControl = mapcontrol;
            m_ComboxItem = cbx;
         }

        private void AddLayersToTargetCBX()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                m_ComboxItem.Items.Clear();
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is IFeatureLayer)
                    {
                        m_ComboxItem.Items.Add(m_MapControl.Map.get_Layer(i).Name.ToString());
                    }
                }
                m_ComboxItem.SelectedIndex = 0;
            }
        }

        private void GetCurrentLayer()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_ComboxItem.SelectedItem.ToString()== m_MapControl.Map.get_Layer(i).Name)
                    {
                        m_CurrentLayer = m_MapControl.Map.get_Layer(i);
                    }
                }
               
            }
        }


        private void StartEditing()
        {
            GetCurrentLayer();
            if (m_CurrentLayer == null)
            {
                return;
            }
            if ((IGeoFeatureLayer)m_CurrentLayer == null)
            {
                return;
            }

            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_CurrentLayer;
            IDataset pDataset = (IDataset)pFeatureLayer.FeatureClass;

            if (pDataset == null)
            {
                return;
            }

            IWorkspaceEdit pWorkspaceEdit = (IWorkspaceEdit)pDataset.Workspace;
            if (!pWorkspaceEdit.IsBeingEdited())
            {
                pWorkspaceEdit.StartEditing(true);
                pWorkspaceEdit.EnableUndoRedo();
            }
        }



    }
}
