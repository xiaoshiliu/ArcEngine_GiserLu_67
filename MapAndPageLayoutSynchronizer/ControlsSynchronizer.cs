using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;



namespace Giser_Lu.MapAndPageLayoutSynchronizer
{
  public class ControlsSynchronizer
    {
        private IMapControlDefault m_mapControl = null;
        private IPageLayoutControlDefault m_pageLayoutControl = null;
        private ITool m_mapActiveTool = null;
        private ITool m_pageLayoutActiveTool = null;
        private bool m_IsMapControlActive = true;
        private ArrayList m_frameworkControls = null;
     

        public ControlsSynchronizer()
        {
            m_frameworkControls = new ArrayList();
        }
        public ControlsSynchronizer(IMapControlDefault mapControl,IPageLayoutControlDefault pageLayoutControl):this()
        {
            m_mapControl = mapControl;
            m_pageLayoutControl = pageLayoutControl;
        }

        public IMapControlDefault MapControl
        {
            get { return m_mapControl; }
            set { m_mapControl = value;}
        }
        public IPageLayoutControlDefault PageLayoutControl
        {
            get { return m_pageLayoutControl; }
            set { m_pageLayoutControl = value; }
        }
        public string ActiveViewType
        {
            get 
            {
                if (m_IsMapControlActive)
                {
                    return "MapControl";
                }
                else
                {
                    return "PageLayoutControl";
                }
            }
        }

      public ITool ActiveControlCurrentTool
      {
          set
          {
              if (ActiveControl == m_mapControl.Object)
              {
               //   m_mapControl.CurrentTool = null;
                  m_mapControl.CurrentTool = value; ;
              }
              else
              {
                  m_pageLayoutControl.CurrentTool = null;
                  m_pageLayoutControl.CurrentTool =value;
              }
          }
      }
        public object ActiveControl
        {
            get
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronzier::ActiveControl:\r\n MapControl or PageLayoutControl is not initialized");
                }
                if (m_IsMapControlActive)
                {
                    return m_mapControl.Object;
                }
                else
                {
                    return m_pageLayoutControl.Object;
                }
            }
        }


        public void ActivateMap()
        {
            try
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronizer::ActivateMap:/n/r MapControl or PageLayoutControl is not initialized");
                }

                //保存PageLayoutControl最后使用的工具并停用
                if (m_pageLayoutControl.CurrentTool != null)
                {
                    m_pageLayoutActiveTool = m_pageLayoutControl.CurrentTool;
                }
                m_pageLayoutControl.ActiveView.Deactivate();

                //激活MapControl并分配预先保留的工具
                m_mapControl.ActiveView.Activate(m_mapControl.hWnd);

                if (m_mapActiveTool != null)
                {
                     m_mapControl.CurrentTool =m_mapActiveTool;
                }

               //指示器
                m_IsMapControlActive = true;

                //设置MapControl的Buddies
                this.SetBuddies(m_mapControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivateMap:/r/n",ex.Message));
            }

        }
        public void ActivatePageLayout()
        {
            try
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                {
                    throw new Exception("ControlsSynchronizer::ActivatePageLayout:/r/nMapControl or PageLayoutControl is not initialized");
                }

                if (m_mapControl.CurrentTool != null)
                {
                    m_mapActiveTool = m_mapControl.CurrentTool;

                }
                m_mapControl.ActiveView.Deactivate();


                m_pageLayoutControl.ActiveView.Activate(m_pageLayoutControl.hWnd);
                if (m_pageLayoutActiveTool != null)
                {
                    m_pageLayoutControl.CurrentTool = m_pageLayoutActiveTool;
                }
 
                
                m_IsMapControlActive = false;

                this.SetBuddies(m_pageLayoutControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivatePageLayout:/r/n",ex.Message));
            }
        }
        public void ReplaceMap(IMap newMap)
        {
            if (newMap == null)
            {
                throw new Exception("ControlsSynchronizer::ReplaceMap:/r/n New Map is not initialized");
            } 

            if (m_mapControl == null || m_pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronzier::ReplaceMap:\r\n MapControl or PageLayoutControl is not initialized");
            }

            IMaps maps = new Maps();
            maps.Add(newMap);

            bool IsMapActive = m_IsMapControlActive;

            this.ActivatePageLayout();
            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);

            m_mapControl.Map = newMap;

            m_mapActiveTool = null;
            m_pageLayoutActiveTool = null;

            if (IsMapActive)
            {
                this.ActivateMap();
                m_mapControl.ActiveView.Refresh();
            }
            else
            {
                this.ActivatePageLayout();
                m_pageLayoutControl.ActiveView.Refresh();
            }
            
        }
        public void BindControls(IMapControlDefault mapControl, IPageLayoutControlDefault pageLayoutControl, bool activeMapFirst)
        {
            if (mapControl == null || pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronizer::BindControls:/r/nMapControl or PageLayoutControl is not initialized.");
            }

            m_mapControl = MapControl;
            m_pageLayoutControl = pageLayoutControl;

            this.BindControls(activeMapFirst);
        }
        public void BindControls(bool activeMapFirst)
        {
            if (m_mapControl == null || m_pageLayoutControl == null)
            {
                throw new Exception("ControlsSynchronizer::BindControls:/r/n MapControl or PageLayoutControl is not initialized.");
            }

            IMap newMap = new MapClass();
            newMap.Name = "Map";

            IMaps maps = new Maps();
            maps.Add(newMap);

            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            m_mapControl.Map = newMap;

            m_mapActiveTool = null;
            m_pageLayoutActiveTool = null;

            if (activeMapFirst)
            {
                this.ActivateMap();
            }
            else
            {
                this.ActivatePageLayout();
            }
        }
        public void AddFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::AddFrameworkControl:/r/n Added control is not initialized.");
            }
            else 
            {
                m_frameworkControls.Add(control);
            }
        }
        public void RemoveFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControl:/r/n Control to be removed is not initialized.");
            }
            else
            {
                m_frameworkControls.Remove(control);
            }
        }
        public void RemoveFrameworkControlAt(int index)
        {
            if (index < 0 || index > m_frameworkControls.Count)
            {
                throw new Exception("ControlsSychronizer::RemoveFrameworkControlAt:/r/n Index is out of range.");
            }
            else
            {
                m_frameworkControls.RemoveAt(index);
            }
        }

        private void SetBuddies(object buddy)
        {
            try
            {
                if (buddy == null)
                {
                    throw new Exception("ControlsSynchronizer::SetBuddies:/r/n Target Buddy Control is not initialized");
                }
                else
                {
                    foreach (object obj in m_frameworkControls)
                    {
                        if (obj is IToolbarControl)
                        {
                            ((IToolbarControl)obj).SetBuddyControl(buddy);
                        }
                        else if (obj is ITOCControl)
                        {
                            ((ITOCControl)obj).SetBuddyControl(buddy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronzier::SetBuddies:/r/n",ex.Message));
            }
        }


    }
}
