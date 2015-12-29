using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;

namespace Giser_Lu
{
    class LoadCustomizeCMDToCatalog
    {


        private IMapControlDefault m_MapControl;
        private DevComponents.DotNetBar.DotNetBarManager m_dotNetBarManager;
        private DevComponents.DotNetBar.ButtonItem m_ButtonItem;
        private Giser_Lu.MapAndPageLayoutSynchronizer.ControlsSynchronizer m_ControlsSynchronizer = null;


        public LoadCustomizeCMDToCatalog(DevComponents.DotNetBar.DotNetBarManager dotNetBarMag , IMapControlDefault mapcontrol)
        {
            m_MapControl = mapcontrol;
            m_dotNetBarManager = dotNetBarMag;
            AddCommandToCategory();
        }

        #region 载入命令目录

        #region 命令目录按钮
        private void AddCommandToCategory()
        {
            #region 文件目录命令按钮
            //新建命令
            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem();
            m_ButtonItem.Text = "新建1";
            m_ButtonItem.Category = "文件";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_NewDoc);
            

            //打开命令
            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem();
            m_ButtonItem.Text = "打开1";
            m_ButtonItem.Category = "文件";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_OpenDoc);

          
            //保存命令
            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem();
            m_ButtonItem.Text = "保存1";
            m_ButtonItem.Category = "文件";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_SaveDoc);

            //另存为命令
            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem();
            m_ButtonItem.Text = "另存为";
            m_ButtonItem.Category = "文件";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_SaveAsDoc);


            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem();
            m_ButtonItem.Text = "撤消1";
            m_ButtonItem.Category = "文件";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.meunItem_Undo_Click);




            #endregion

            #region 工具目录命令按钮

            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem("btncmd_FullExtend");
            m_ButtonItem.Text = "全局视图";
            m_ButtonItem.Category = "工具";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_FullExtend);

            m_ButtonItem = new DevComponents.DotNetBar.ButtonItem("btncmd_ZoomIn");
            m_ButtonItem.Text = "拉框放大";
            m_ButtonItem.Category = "工具";
            m_dotNetBarManager.Items.Add(m_ButtonItem);
            m_ButtonItem.Click += new EventHandler(this.cmd_ZoomIn);

            #endregion

        }
        #endregion

        #region 文件目录命令事件

         private void cmd_NewDoc(System.Object sender, EventArgs e)
             {
                ICommand cmd = new NewMapDocument();
                cmd.OnCreate(m_MapControl);
                cmd.OnClick();
             }

         private void cmd_OpenDoc(System.Object sender, EventArgs e)
             {
            ICommand cmd = new OpenDocument(m_ControlsSynchronizer);
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
            }
 
        private void cmd_SaveDoc(System.Object sender, EventArgs e)
        {
            if (m_MapControl.CheckMxFile(m_MapControl.DocumentFilename))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_MapControl.DocumentFilename, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_MapControl.DocumentFilename))
                {
                    MessageBox.Show("地图为只读!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_MapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }
        
        private void cmd_SaveAsDoc(System.Object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_ControlsSynchronizer.ActiveControl);
            command.OnClick();
        }
        #endregion

        #region 工具目录命令事件

        private void cmd_FullExtend(object sender, EventArgs e)
        {
            ICommand c = new ControlsMapFullExtentCommandClass();
            c.OnCreate(m_MapControl);
            c.OnClick();
        }

        private void cmd_ZoomIn(object sender, EventArgs e)
        {
            ICommand tool = new ControlsMapZoomInToolClass();
            tool.OnCreate(m_MapControl);
           m_MapControl.CurrentTool = tool as ITool;
           
        }

        #endregion

        private void meunItem_Undo_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsUndoCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        private void meunItem_Option_Click(object sender, EventArgs e)
        {

        }


}
        #endregion
    }

